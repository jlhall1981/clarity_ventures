using Microsoft.Extensions.Configuration;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailService.Library
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailLogger _emailLogger;

        public EmailService(IConfiguration configuration, IEmailLogger emailLogger)
        {
            _configuration = configuration;
            _emailLogger = emailLogger;
        }

        public async Task<bool> SendEmailAsync(string recipient, string subject, string body)
        {
            var smtpSettings = _configuration.GetSection("SmtpSettings");
            string sender = smtpSettings["SenderEmail"];
            string smtpHost = smtpSettings["Host"];
            int smtpPort = int.Parse(smtpSettings["Port"]);
            string username = smtpSettings["Username"];
            string password = smtpSettings["Password"];

            int maxRetries = 3;
            int retryDelayMs = 1000;
            bool success = false;
            string status = "Failed";

            for (int attempt = 1; attempt <= maxRetries && !success; attempt++)
            {
                try
                {
                    using (var client = new SmtpClient(smtpHost, smtpPort))
                    {
                        client.EnableSsl = true;
                        client.Credentials = new System.Net.NetworkCredential(username, password);

                        var mailMessage = new MailMessage
                        {
                            From = new MailAddress(sender),
                            Subject = subject,
                            Body = body,
                            IsBodyHtml = true
                        };
                        mailMessage.To.Add(recipient);

                        await client.SendMailAsync(mailMessage);
                        success = true;
                        status = "Success";
                    }
                }
                catch (Exception ex)
                {
                    status = $"Failed (Attempt {attempt}): {ex.Message}";
                    if (attempt < maxRetries)
                        await Task.Delay(retryDelayMs);
                }
            }

            // Log email details
            await _emailLogger.LogEmailAsync(sender, recipient, subject, body, DateTime.UtcNow, status);
            return success;
        }
    }
}