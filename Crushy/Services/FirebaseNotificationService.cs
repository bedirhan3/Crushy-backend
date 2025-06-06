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
            if (!_isInitialized)
            {
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromFile("Data/crushy-firebase-admin-key.json")
                });

                _isInitialized = true;
            }
        }

        
        public async Task SendPushNotificationAsync(string fcmToken, string title,string message)
        {
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

            await FirebaseMessaging.DefaultInstance.SendAsync(messageObj);
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