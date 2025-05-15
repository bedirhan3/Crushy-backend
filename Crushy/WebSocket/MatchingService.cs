using System.Collections.Concurrent;
using System.Threading.Tasks;
using Crushy.Models; 
using Microsoft.AspNetCore.SignalR; 
using System.Linq;
using System;

namespace Crushy.WebSocket
{
    public class MatchingService
    {
        private static readonly ConcurrentDictionary<int, (string ConnectionId, int Age, string Location)> _waitingUsers = 
            new ConcurrentDictionary<int, (string, int, string)>();
        
        private readonly SignalRService _signalRService;

        public MatchingService(SignalRService signalRService)
        {
            _signalRService = signalRService;
        }

        public async Task AddUserToPoolAsync(int userId, string connectionId, int age, string location)
        {
            _waitingUsers.TryAdd(userId, (connectionId, age, location));
            await TryMatchUsersAsync(userId, connectionId, age, location);
        }

        public void RemoveUserFromPool(int userId)
        {
            _waitingUsers.TryRemove(userId, out _);
        }

        private bool IsLocationNear(string location1, string location2)
        {
            return location1.Equals(location2, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsAgeNear(int age1, int age2)
        {
            const int maxAgeDifference = 5; // Maksimum yaş farkı
            return Math.Abs(age1 - age2) <= maxAgeDifference;
        }

        private (int UserId, string ConnectionId)? FindBestMatch(int currentUserId, int currentAge, string currentLocation)
        {
            var potentialMatches = _waitingUsers
                .Where(u => u.Key != currentUserId)
                .Select(u => new
                {
                    UserId = u.Key,
                    ConnectionId = u.Value.ConnectionId,
                    Age = u.Value.Age,
                    Location = u.Value.Location,
                    Score = CalculateMatchScore(currentAge, currentLocation, u.Value.Age, u.Value.Location)
                })
                .OrderByDescending(m => m.Score)
                .ToList();

            return potentialMatches.FirstOrDefault() != null 
                ? (potentialMatches.First().UserId, potentialMatches.First().ConnectionId)
                : null;
        }

        private double CalculateMatchScore(int age1, string location1, int age2, string location2)
        {
            double score = 0;

            double ageScore = 1 - (Math.Abs(age1 - age2) / 20.0); 
            score += ageScore * 0.5; 

            // Konum uyumu puanı (0-1 arası)
            double locationScore = IsLocationNear(location1, location2) ? 1.0 : 0.0;
            score += locationScore * 0.5; 

            return score;
        }

        private async Task TryMatchUsersAsync(int currentUserId, string currentUserConnectionId, int currentAge, string currentLocation)
        {
            if (_waitingUsers.Count < 2)
            {
                await _signalRService.SendMessageToUserAsync(currentUserId, "MatchingStatus", "Eşleştirme için bekleniyor...");
                return;
            }

            var bestMatch = FindBestMatch(currentUserId, currentAge, currentLocation);

            if (bestMatch.HasValue)
            {
                var (opponentId, opponentConnectionId) = bestMatch.Value;
                
                _waitingUsers.TryRemove(currentUserId, out _);
                _waitingUsers.TryRemove(opponentId, out var opponentData);

                if (opponentConnectionId != null)
                {
                    var currentUserData = _waitingUsers.GetValueOrDefault(currentUserId);
                    var matchInfo = new
                    {
                        OpponentId = opponentId,
                        OpponentAge = opponentData.Age,
                        OpponentLocation = opponentData.Location,
                        MatchScore = CalculateMatchScore(currentAge, currentLocation, opponentData.Age, opponentData.Location)
                    };

                    await _signalRService.SendMessageToUserAsync(currentUserId, "MatchFound", matchInfo);
                    await _signalRService.SendMessageToUserAsync(opponentId, "MatchFound", new
                    {
                        OpponentId = currentUserId,
                        OpponentAge = currentAge,
                        OpponentLocation = currentLocation,
                        MatchScore = matchInfo.MatchScore
                    });
                }
                else
                {
                    _waitingUsers.TryAdd(currentUserId, (currentUserConnectionId, currentAge, currentLocation));
                }
            }
            else
            {
                await _signalRService.SendMessageToUserAsync(currentUserId, "MatchingStatus", "Şu an için uygun eş bulunamadı. Beklemeye devam ediliyor...");
            }
        }

        public async Task FindMatchForUserAsync(int userId, string connectionId, int age, string location)
        {
            if (!_waitingUsers.ContainsKey(userId))
            {
                _waitingUsers.TryAdd(userId, (connectionId, age, location));
            }
            await TryMatchUsersAsync(userId, connectionId, age, location);
        }
    }
} 
