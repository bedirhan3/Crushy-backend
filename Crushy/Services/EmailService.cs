using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Crushy.Services
{
    public class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _email;
        private readonly string _password;

        public EmailService(IConfiguration configuration)
        {
            _smtpServer = configuration["EmailSettings:SmtpServer"];
            _smtpPort = int.Parse(configuration["EmailSettings:SmtpPort"]);
            _email = configuration["EmailSettings:SenderEmail"];
            _password = configuration["EmailSettings:SenderPassword"];
        }

        public async Task SendVerificationEmail(string email, string verificationLink)
        {
            Random random = new Random();

            var randomNumber = random.Next(100000, 1000000);
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Crushy", _email));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Email Verification";
            message.Body = new TextPart("plain")
            {
                Text = $"Please verify your email by clicking here: {verificationLink}"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpServer, _smtpPort, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_email, _password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
} 