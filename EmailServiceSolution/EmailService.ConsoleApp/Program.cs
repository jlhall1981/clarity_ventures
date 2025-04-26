using EmailService.Library;
using EmailService.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EmailService.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Setup configuration
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Setup DI
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IEmailLogger, SqlEmailLogger>();
            services.AddSingleton<EmailService>();
            var serviceProvider = services.BuildServiceProvider();

            var emailService = serviceProvider.GetService<EmailService>();

            // Get user input
            Console.WriteLine("Enter recipient email:");
            string recipient = Console.ReadLine();
            string subject = "Test Email";
            string body = "This is a test email sent from the console app.";

            // Send email
            bool success = await emailService.SendEmailAsync(recipient, subject, body);
            Console.WriteLine(success ? "Email sent successfully!" : "Failed to send email after retries.");
        }
    }
}