using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System.Threading.Tasks;

namespace Crushy.Services
{
    public class FirebaseNotificationService
    {
        public async Task SendPushNotificationAsync(string fcmToken, string title, string message)
        {
       //     Console.WriteLine($"[Firebase] Preparing to send notification to token: {fcmToken}");
        //    Console.WriteLine($"[Firebase] Title: {title}, Message: {message}");

            if (FirebaseMessaging.DefaultInstance == null)
            {
                Console.WriteLine("[Firebase] FirebaseMessaging.DefaultInstance is null!");
                return;
            }
            
            var notification = new Notification
            {
                Title = title,
                Body = message
            };

            var messageObj = new Message
            {
                Token = fcmToken,
                Notification = notification
            };

            try
            {
                string response = await FirebaseMessaging.DefaultInstance.SendAsync(messageObj);
//                Console.WriteLine($"[Firebase] Notification sent successfully. Response: {response}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Firebase] Failed to send notification. Error: {ex.Message}");
            }
        }

        public async Task SendSilentNotificationAsync(string fcmToken, string action)
        {
            var messageObj = new Message
            {
                Token = fcmToken,
                Data = new Dictionary<string, string>
                {
                    { "action", action }
                },
                Android = new AndroidConfig
                {
                    Priority = Priority.High
                },
                Apns = new ApnsConfig
                {
                    Aps = new Aps
                    {
                        ContentAvailable = true
                    }
                }
            };

            await FirebaseMessaging.DefaultInstance.SendAsync(messageObj);
        }

        public async Task SendCrushyCoinNotificationAsync(string fcmToken)
        {
            var notification = new Notification
            {
                Title = "Crushy Vakti ⏰",
                Body = "Günlük Crushy Coin hakkın yenilendi! Hadi hemen ruh eşini bulalım 👩‍❤️‍👨"
            };

            var message = new Message
            {
                Token = fcmToken,
                Notification = notification
            };

            await FirebaseMessaging.DefaultInstance.SendAsync(message);
        }
    }
}