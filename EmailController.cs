using EmailService.Library;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmailService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            if (string.IsNullOrEmpty(request.Recipient) || string.IsNullOrEmpty(request.Subject) || string.IsNullOrEmpty(request.Body))
                return BadRequest("Invalid email data.");

            bool success = await _emailService.SendEmailAsync(request.Recipient, request.Subject, request.Body);
            return success ? Ok("Email sent successfully.") : StatusCode(500, "Failed to send email.");
        }
    }

    public class EmailRequest
    {
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}