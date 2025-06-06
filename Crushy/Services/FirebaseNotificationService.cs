using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System.Threading.Tasks;

namespace Crushy.Services
{
    public class FirebaseNotificationService
    {
        private static bool _isInitialized = false;

        public FirebaseNotificationService()
        {
            try
            {
                if (!_isInitialized && FirebaseApp.DefaultInstance == null)
                {
                    Console.WriteLine("[Firebase] Initializing Firebase App...");
                    FirebaseApp.Create(new AppOptions
                    {
                        Credential = GoogleCredential.FromFile("Data/crushy-firebase-admin-key.json")
                    });

                    _isInitialized = true;
                    Console.WriteLine("[Firebase] Firebase App initialized.");
                }
                else
                {
                    Console.WriteLine("[Firebase] Firebase App already initialized.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Firebase] Error during initialization: {ex.Message}");
            }
        }

        
        public async Task SendPushNotificationAsync(string fcmToken, string title, string message)
        {
            Console.WriteLine($"[Firebase] Preparing to send notification to token: {fcmToken}");
            Console.WriteLine($"[Firebase] Title: {title}, Message: {message}");

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
                Console.WriteLine($"[Firebase] Notification sent successfully. Response: {response}");
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