using System;
using System.Net.Mail;
using System.Net;
using System.Security.Policy;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using NewsLetterIsoQueue.Models;

namespace NewsLetterIsoQueue
{
    public class NewsLetterIsoQueue
    {
        private readonly ILogger<NewsLetterIsoQueue> _logger;
        private readonly IConfiguration _configuration;
        public NewsLetterIsoQueue(ILogger<NewsLetterIsoQueue> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [Function(nameof(NewsLetterIsoQueue))]
        public void Run([QueueTrigger("ennewsletterqueue", Connection = "AzureWebJobsStorage")] NewsLetter message)
        {
            SendEmail(message);

            _logger.LogInformation($"C# Queue trigger function processed: {message.Body}");
        }

        public async Task SendEmail(NewsLetter email)
        {
            var host = "smtp.gmail.com";

            var port = 587;

            var fromEmail = "expressnewscontact@gmail.com";

            var username = "expressnewscontact@gmail.com";

            var password = "eydd dadk plbf uqcw";

            var message = new MailMessage();

            message.From = new MailAddress(fromEmail);

            message.To.Add(email.EmailAddress);

            message.Subject = "News Letter form Express News";

            message.Body = email.Body;

            message.IsBodyHtml = true; // Ensures that the email body is treated as HTML

            using (var smtpClient = new SmtpClient(host, port))
            {

                smtpClient.EnableSsl = true;

                smtpClient.UseDefaultCredentials = false;

                smtpClient.Credentials = new NetworkCredential(username, password);

                await smtpClient.SendMailAsync(message);
            }
        }




    }
}
