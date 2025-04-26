using Dapper;
using EmailService.Library;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EmailService.Logging
{
    public class SqlEmailLogger : IEmailLogger
    {
        private readonly string _connectionString;

        public SqlEmailLogger(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task LogEmailAsync(string sender, string recipient, string subject, string body, DateTime sentDate, string status)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var log = new EmailLog
                {
                    Sender = sender,
                    Recipient = recipient,
                    Subject = subject,
                    Body = body,
                    SentDate = sentDate,
                    Status = status
                };

                await connection.ExecuteAsync(
                    "INSERT INTO EmailLogs (Sender, Recipient, Subject, Body, SentDate, Status) VALUES (@Sender, @Recipient, @Subject, @Body, @SentDate, @Status)",
                    log);
            }
        }
    }
}