using MailKit.Net.Smtp;
using MimeKit;
using UniversityHousingSystem.Data.Helpers;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class EmailService : IEmailService
    {
        #region Fields
        private readonly SmtpSettings _smtpSettings;
        #endregion

        #region Constructor
        public EmailService(SmtpSettings smtpSettings)
        {
            _smtpSettings = smtpSettings;
        }
        #endregion

        #region Functions
        public async Task SendEmail(string email, string receiverName, string message, string subject)
        {
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, _smtpSettings.EnableSsl);
                await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
                var bodyBuilder = new BodyBuilder()
                {
                    HtmlBody = message,
                };

                var mimeMessage = new MimeMessage()
                {
                    Body = bodyBuilder.ToMessageBody()
                };
                mimeMessage.From.Add(new MailboxAddress(_smtpSettings.App, _smtpSettings.FromEmail));
                mimeMessage.To.Add(new MailboxAddress(receiverName, email));
                mimeMessage.Subject = subject;
                await client.SendAsync(mimeMessage);
                client.Disconnect(true);
            }
        }
        #endregion
    }
}
