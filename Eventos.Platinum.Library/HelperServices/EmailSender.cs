using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Eventos.Platinum.Library.HelperServices
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Send(List<string> emailAccounts, string subject, string message, string senderName)
        {
            try
            {
                string smtpServer = _configuration.GetSection("AppSettings:EmailSmtpServer").Value;
                string port = _configuration.GetSection("AppSettings:EmailPort").Value;
                string accountSending = _configuration.GetSection("AppSettings:EmailAccount").Value;
                string password = _configuration.GetSection("AppSettings:EmailPassword").Value;

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(accountSending));
                foreach (var itemMail in emailAccounts)
                {
                    email.To.Add(MailboxAddress.Parse(itemMail));
                }
                email.Subject = subject;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };

                using SmtpClient smtpClient = new();
                smtpClient.Connect(smtpServer, Convert.ToInt32(port), MailKit.Security.SecureSocketOptions.StartTls);

                smtpClient.Authenticate(accountSending, password);

                smtpClient.Send(email);
                smtpClient.Disconnect(true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
