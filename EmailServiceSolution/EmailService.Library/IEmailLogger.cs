using System;
using System.Threading.Tasks;

namespace EmailService.Library
{
    public interface IEmailLogger
    {
        Task LogEmailAsync(string sender, string recipient, string subject, string body, DateTime sentDate, string status);
    }
}