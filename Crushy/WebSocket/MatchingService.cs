using System.Collections.Concurrent;
using System.Threading.Tasks;
using Crushy.Models; 
using Microsoft.AspNetCore.SignalR; 
using System.Linq;
using System;
using System.Collections.Generic;
using Crushy.Dtos;

namespace Crushy.WebSocket
{
    public class MatchingService
    {
        private static readonly ConcurrentDictionary<int, (string ConnectionId, int Age, double Latitude, double Longitude, int CurrentPhase, DateTime LastPhaseTime)> _waitingUsers = 
            new ConcurrentDictionary<int, (string, int, double, double, int, DateTime)>();
        
        private readonly SignalRService _signalRService;

        public MatchingService(SignalRService signalRService)
        {
            _signalRService = signalRService;
        }

        public async Task AddUserToPoolAsync(int userId, string connectionId, int age, double latitude, double longitude)
        {

            _waitingUsers.TryAdd(userId, (connectionId, age, latitude, longitude, 1, DateTime.UtcNow));
            await TryMatchUsersAsync(userId, connectionId, age, latitude, longitude);
        }

        public void RemoveUserFromPool(int userId)
        {
            _waitingUsers.TryRemove(userId, out _);
        }

        private readonly List<MatchCriteria> _matchingPhases = new List<MatchCriteria>
        {
            new MatchCriteria { MaxAgeDifference = 3, MaxDistanceKm = 5, Description = "5km içi, yakın yaş", WaitTimeSeconds = 30 },
            
            new MatchCriteria { MaxAgeDifference = 5, MaxDistanceKm = 15, Description = "15km içi, uyumlu yaş", WaitTimeSeconds = 45 },
            
            new MatchCriteria { MaxAgeDifference = 3, MaxDistanceKm = 50, Description = "Şehir içi, yakın yaş", WaitTimeSeconds = 60 },
            
            new MatchCriteria { MaxAgeDifference = 7, MaxDistanceKm = 100, Description = "Bölgesel, uyumlu yaş", WaitTimeSeconds = 90 },
            
            new MatchCriteria { MaxAgeDifference = 10, MaxDistanceKm = 250, Description = "Geniş bölge, esnek yaş", WaitTimeSeconds = 120 },
            
            new MatchCriteria { MaxAgeDifference = 15, MaxDistanceKm = double.MaxValue, Description = "Ülke çapı eşleştirme", WaitTimeSeconds = int.MaxValue }
        };

        private class MatchCriteria
        {
            public int MaxAgeDifference { get; set; }
            public double MaxDistanceKm { get; set; }
            public string Description { get; set; }
            public int WaitTimeSeconds { get; set; }
        }

        private double CalculateDistanceKm(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; 
            
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);
            
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            
            return R * c;
        }

        private double ToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        private bool IsLocationMatch(double lat1, double lon1, double lat2, double lon2, double maxDistanceKm)
        {
            if (maxDistanceKm == double.MaxValue) return true;
            
            var distance = CalculateDistanceKm(lat1, lon1, lat2, lon2);
            return distance <= maxDistanceKm;
        }

        private bool IsAgeMatch(int age1, int age2, int maxAgeDifference)
        {
            return Math.Abs(age1 - age2) <= maxAgeDifference;
        }

        private int GetUserCurrentPhase(int userId)
        {
            if (!_waitingUsers.TryGetValue(userId, out var userData))
                return 1;

            var (_, _, _, _, currentPhase, lastPhaseTime) = userData;
            var elapsed = (DateTime.UtcNow - lastPhaseTime).TotalSeconds;
            
            if (currentPhase <= _matchingPhases.Count)
            {
                var currentCriteria = _matchingPhases[currentPhase - 1];
                if (elapsed >= currentCriteria.WaitTimeSeconds && currentPhase < _matchingPhases.Count)
                {
                    var newPhase = currentPhase + 1;
                    var (connectionId, age, lat, lon, _, _) = userData;
                    _waitingUsers.TryUpdate(userId, (connectionId, age, lat, lon, newPhase, DateTime.UtcNow), userData);
                    
                    var newCriteria = _matchingPhases[newPhase - 1];
                    _ = Task.Run(async () => 
                    {
                        await _signalRService.SendMessageToUserAsync(userId, "MatchingStatus", 
                            $"⏰ Faz {newPhase}'ye geçildi: {newCriteria.Description} (Bekleme süresi: {elapsed:F0} saniye geçti)");
                    });
                    
                    return newPhase;
                }
            }
            
            return currentPhase;
        }

        private (int UserId, string ConnectionId, int Phase, double Distance)? FindBestMatchForPhase(int currentUserId, int currentAge, double currentLat, double currentLon, int targetPhase)
        {
            var availableUsers = _waitingUsers.Where(u => u.Key != currentUserId).ToList();
            
            if (!availableUsers.Any() || targetPhase > _matchingPhases.Count)
                return null;

            var criteria = _matchingPhases[targetPhase - 1];
            
            var matchesInPhase = availableUsers
                .Where(u => IsAgeMatch(currentAge, u.Value.Age, criteria.MaxAgeDifference) &&
                          IsLocationMatch(currentLat, currentLon, u.Value.Latitude, u.Value.Longitude, criteria.MaxDistanceKm))
                .Select(u => new
                {
                    UserId = u.Key,
                    ConnectionId = u.Value.ConnectionId,
                    Age = u.Value.Age,
                    Latitude = u.Value.Latitude,
                    Longitude = u.Value.Longitude,
                    Distance = CalculateDistanceKm(currentLat, currentLon, u.Value.Latitude, u.Value.Longitude),
                    Score = CalculateAdvancedMatchScore(currentAge, currentLat, currentLon, u.Value.Age, u.Value.Latitude, u.Value.Longitude, criteria),
                    Phase = targetPhase
                })
                .OrderByDescending(m => m.Score)
                .ToList();

            if (matchesInPhase.Any())
            {
                var bestMatch = matchesInPhase.First();
                return (bestMatch.UserId, bestMatch.ConnectionId, bestMatch.Phase, bestMatch.Distance);
            }

            return null;
        }

        private double CalculateAdvancedMatchScore(int age1, double lat1, double lon1, int age2, double lat2, double lon2, MatchCriteria criteria)
        {
            double score = 0;

            double ageDifference = Math.Abs(age1 - age2);
            double ageScore = Math.Max(0, 1 - (ageDifference / criteria.MaxAgeDifference));
            score += ageScore * 0.6; 

            double distance = CalculateDistanceKm(lat1, lon1, lat2, lon2);
            double distanceScore;
            
            if (criteria.MaxDistanceKm == double.MaxValue)
            {
                distanceScore = 0.1; 
            }
            else
            {
                distanceScore = Math.Max(0, 1 - (distance / criteria.MaxDistanceKm));
            }
            
            score += distanceScore * 0.4;

            if (ageDifference <= 2) score += 0.05; 
            if (distance <= 1) score += 0.1;      
            if (distance <= 5) score += 0.05;     

            return Math.Min(1.0, score); 
        }

        private async Task TryMatchUsersAsync(int currentUserId, string currentUserConnectionId, int currentAge, double currentLat, double currentLon)
        {
            if (_waitingUsers.Count < 2)
            {
                await _signalRService.SendMessageToUserAsync(currentUserId, "MatchingStatus", 
                    "Eşleştirme için bekleniyor... Şu an havuzda sadece siz varsınız.");
                return;
            }

            var currentPhase = GetUserCurrentPhase(currentUserId);
            
            var bestMatch = FindBestMatchForPhase(currentUserId, currentAge, currentLat, currentLon, currentPhase);

            if (bestMatch.HasValue)
            {
                var (opponentId, opponentConnectionId, phase, distance) = bestMatch.Value;
                var criteria = _matchingPhases[phase - 1];
                
                _waitingUsers.TryRemove(currentUserId, out _);
                _waitingUsers.TryRemove(opponentId, out var opponentData);

                if (opponentConnectionId != null)
                {
                    var matchScore = CalculateAdvancedMatchScore(currentAge, currentLat, currentLon, 
                        opponentData.Age, opponentData.Latitude, opponentData.Longitude, criteria);
                    
                    var matchInfo = new MatchInfoDTO
                    {
                        OpponentId = opponentId,
                        OpponentAge = opponentData.Age,
                        OpponentLatitude = opponentData.Latitude,
                        OpponentLongitude = opponentData.Longitude,
                        Distance = Math.Round(distance, 2),
                        MatchScore = matchScore,
                        MatchPhase = phase,
                        MatchCriteria = criteria.Description
                    };

                    await _signalRService.SendMessageToUserAsync(currentUserId, "MatchFound", matchInfo);
                    await _signalRService.SendMessageToUserAsync(opponentId, "MatchFound", new MatchInfoDTO
                    {
                        OpponentId = opponentId,
                        OpponentAge = opponentData.Age,
                        OpponentLatitude = opponentData.Latitude,
                        OpponentLongitude = opponentData.Longitude,
                        Distance = Math.Round(distance, 2),
                        MatchScore = matchScore,
                        MatchPhase = phase,
                        MatchCriteria = criteria.Description
                    });

                    await _signalRService.SendMessageToUserAsync(currentUserId, "MatchingStatus", 
                        $"✅ Eşleşme bulundu: {opponentId} ! Faz {phase}: {criteria.Description} | Mesafe: {distance:F1}km | Skor: {(matchScore * 100):F1}%");
                    await _signalRService.SendMessageToUserAsync(opponentId, "MatchingStatus", 
                        $"✅ Eşleşme bulundu: {currentUserId}! Faz {phase}: {criteria.Description} | Mesafe: {distance:F1}km | Skor: {(matchScore * 100):F1}%");
                }
                else
                {
                    _waitingUsers.TryAdd(currentUserId, (currentUserConnectionId, currentAge, currentLat, currentLon, currentPhase, DateTime.UtcNow));
                    await _signalRService.SendMessageToUserAsync(currentUserId, "MatchingStatus", 
                        "Geçici bir bağlantı sorunu oluştu. Yeniden deneniyor...");
                }
            }
            else
            {
                // Şu anki fazda eşleşme bulunamadı
                var criteria = _matchingPhases[currentPhase - 1];
                var userData = _waitingUsers[currentUserId];
                var elapsed = (DateTime.UtcNow - userData.LastPhaseTime).TotalSeconds;
                var remaining = Math.Max(0, criteria.WaitTimeSeconds - elapsed);
                
                if (currentPhase < _matchingPhases.Count && remaining > 0)
                {
                    await _signalRService.SendMessageToUserAsync(currentUserId, "MatchingStatus", 
                        $"🔍 Faz {currentPhase}: {criteria.Description} - Eş aranıyor... (Kalan süre: {remaining:F0} saniye, Havuzda {_waitingUsers.Count - 1} kişi)");
                }
                else if (currentPhase >= _matchingPhases.Count)
                {
                    await _signalRService.SendMessageToUserAsync(currentUserId, "MatchingStatus", 
                        $"🔍 Son faz: Ülke çapında eş aranıyor... (Havuzda {_waitingUsers.Count - 1} kişi var)");
                }
            }
        }

        public async Task FindMatchForUserAsync(int userId, string connectionId, int age, double latitude, double longitude)
        {
            if (!_waitingUsers.ContainsKey(userId))
            {
                _waitingUsers.TryAdd(userId, (connectionId, age, latitude, longitude, 1, DateTime.UtcNow));
            }
            
            await _signalRService.SendMessageToUserAsync(userId, "MatchingStatus", 
                "🎯 Aşamalı eşleştirme başlatıldı! Faz 1 (En sıkı kriterler) ile başlıyoruz...");
                
            await TryMatchUsersAsync(userId, connectionId, age, latitude, longitude);
        }

        public async Task CheckAllUsersForMatching()
        {
            var userIds = _waitingUsers.Keys.ToList();
            
            foreach (var userId in userIds)
            {
                if (_waitingUsers.TryGetValue(userId, out var userData))
                {
                    var (connectionId, age, lat, lon, currentPhase, lastPhaseTime) = userData;
                    await TryMatchUsersAsync(userId, connectionId, age, lat, lon);
                }
            }
        }

        public async Task GetPoolStatusAsync(int userId)
        {
            var userCount = _waitingUsers.Count;
            var userAges = _waitingUsers.Values.Select(u => u.Age).ToList();
            var userPhases = _waitingUsers.Values.Select(u => u.CurrentPhase).ToList();
            
            var statusMessage = $"📊 Havuz Durumu: {userCount} kullanıcı | " +
                              $"Yaş Aralığı: {(userAges.Any() ? $"{userAges.Min()}-{userAges.Max()}" : "N/A")} | " +
                              $"Fazlar: {string.Join(", ", userPhases.GroupBy(p => p).Select(g => $"F{g.Key}:{g.Count()}"))}";
            
            await _signalRService.SendMessageToUserAsync(userId, "MatchingStatus", statusMessage);
        }
    }
} 
