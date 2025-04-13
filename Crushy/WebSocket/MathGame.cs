using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace Crushy.WebSocket
{

	public class MathGame : Hub
	{
		private static Dictionary<string, List<string>> gameRooms = new(); // Oda adı => ConnectionId listesi
		private static Dictionary<string, Dictionary<string, int>> roomScores = new(); // Oda adı => ConnectionId => Puan

		public async Task JoinRoom(string roomName)
		{
			// Oda daha önce oluşturulmamışsa, yeni bir oda oluştur
			if (!gameRooms.ContainsKey(roomName))
			{
				gameRooms[roomName] = new List<string>();
				roomScores[roomName] = new Dictionary<string, int>(); // Yeni oda için puan tablosu oluştur
			}

			// Eğer oyuncu zaten odadaysa
			if (gameRooms[roomName].Count == 1 && gameRooms[roomName][0] == Context.ConnectionId)
			{
				await Clients.Caller.SendAsync("ReceiveMessage", "System", "Zaten odaya katıldınız");
				return;
			}

			// Oda zaten 2 kişiyle dolmuşsa, katılımı reddet
			if (gameRooms[roomName].Count >= 2)
			{
				await Clients.Caller.SendAsync("ReceiveMessage", "System", "Bu oda dolu. Lütfen başka bir oda seçin.");
				return;
			}

			// Oyuncuyu odaya ekle
			gameRooms[roomName].Add(Context.ConnectionId);
			roomScores[roomName][Context.ConnectionId] = 0; // Yeni oyuncuya sıfır puan ver

			// Odaya katılan oyuncuya bilgi gönder
			await Clients.Caller.SendAsync("ReceiveMessage", "System", $"Odaya katıldınız: {roomName}");

			// Odaya katılan tüm oyunculara bildirim gönder
			await Clients.Group(roomName).SendAsync("ReceiveMessage", "System", $"{Context.ConnectionId} odaya katıldı: {roomName}");

			// Eğer oda iki oyuncu ile dolmuşsa, diğer oyuncuları bilgilendir
			if (gameRooms[roomName].Count == 2)
			{
				await Clients.Group(roomName).SendAsync("ReceiveMessage", "System", $"Oda {roomName} doldu. Oyun başlayabilir.");
			}

			// Odaya katılmak için grup oluştur
			await Groups.AddToGroupAsync(Context.ConnectionId, roomName);

			if (gameRooms[roomName].Count == 2)
			{
				await GetScores(roomName);
				await PlayGame(roomName);
			}
		}


		public async Task PlayGame(string roomName)
		{
			// Odaya ait oyuncuların olup olmadığını kontrol et
			if (!gameRooms.ContainsKey(roomName))
			{
				await Clients.Caller.SendAsync("ReceiveMessage", "System", "Bu oda mevcut değil.");
				return;
			}

			Random random = new Random();
			int number1 = random.Next(1, 101);
			int number2 = random.Next(1, 10);
			int correctAnswer = number1 * number2;

			// Oyuncuya soru gönder
			await Clients.Group(roomName).SendAsync("Question", "System", $"{number1} x {number2} = ?");
			await Clients.Group(roomName).SendAsync("CorrectAnswer", "System", correctAnswer);

		}

		public async Task CorrectAnswer(string roomName)
		{
			if (!gameRooms.ContainsKey(roomName))
			{
				await Clients.Caller.SendAsync("ReceiveMessage", "System", "Bu oda mevcut değil.");
				return;
			}

			// Puanı artır
			roomScores[roomName][Context.ConnectionId] += 1;

			// Güncellenmiş puanları odadaki herkese gönder
			await Clients.Group(roomName).SendAsync("ReceiveMessage", "System", $"Oyuncu {Context.ConnectionId} doğru cevabı verdi! Puanı: {roomScores[roomName][Context.ConnectionId]}");
		}

		// Oyuncuların puan tablosunu görüntülemek için bir metot
		public async Task GetScores(string roomName)
		{
			if (!roomScores.ContainsKey(roomName))
			{
				await Clients.Caller.SendAsync("ReceiveMessage", "System", "Bu oda mevcut değil.");
				return;
			}

			var scores = roomScores[roomName];
			string scoreMessage = "Puan Tablosu:\n";
			foreach (var player in scores)
			{
				scoreMessage += $"{player.Key}: {player.Value} puan\n";
			}

			await Clients.Group(roomName).SendAsync("ReceiveMessage", "System", scoreMessage);
		}
	}
}

