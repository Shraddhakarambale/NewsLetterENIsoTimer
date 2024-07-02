using System;
using NewsLetterENIsoTimer.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Storage.Queues;
using System.Globalization;
using NewsLetterENIsoTimer.Models;
using System.Collections.Generic;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;


namespace NewsLetterENIsoTimer
{
    public class IsoTimer
    {
        private readonly ILogger _logger;
        private readonly IArticleService _articleService;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;


        public IsoTimer(ILoggerFactory loggerFactory, IArticleService articleService,IUserService userService, IConfiguration configuration)
        {
            _logger = loggerFactory.CreateLogger<IsoTimer>();
            _articleService = articleService;
            _userService = userService;
            _configuration = configuration;
        }

        [Function("IsoTimer")]
        public void Run([TimerTrigger("0 */1 * * * *", RunOnStartup = true)] TimerInfo myTimer)//RunOnStartup =true
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            var userList = _userService.GetUsers();
            

            QueueClient queueClient = new(_configuration["AzureWebJobsStorage"], "ennewsletterqueue", new QueueClientOptions()
            { MessageEncoding = QueueMessageEncoding.Base64 });
            //  QueueClient  queueClient = new (_configuration["AzureWebJobsStorage"], "newsletterqueue", new QueueClientOptions


            foreach (var user in userList)
            {
                try
                {
                    var articles = _articleService.GetArticlesByCategory(user.Category1, user.Category2, user.Category3, user.Category4);
                    
                    user.Body = GenarateEmailBody(articles);
                    
                    queueClient.SendMessage(JsonConvert.SerializeObject(user));

                    _logger.LogInformation($"Message to {user.EmailAddress} sent to queue");
                }
                catch (Exception ex)
                {
                    _logger.LogInformation($"Something went wrong - {ex.Message} ");
                }



            }

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }

        public string GenarateEmailBody(List<Article> articles)
        {
            var html = "<html><body>";
            html += "<h1>Your Daily Newsletter</h1>";
            html += "<p>Here are the latest articles for you:</p>";

            html += "<div class='row'>";

            foreach (var row in articles)
            {
                html += "<div class='col-md-4 bg-white border p-3 gap-3 mt-2 mb-2'>";
                html += $"<img src='{row.ImageLink}' style='width:40%; height:40%' alt='Article Image'>";
                html += $"<h2 style='color:black;cursor:pointer' class='mb-2 mt-2'>";
                html += $"<a href='https://expressnews.azurewebsites.net/Article/SingleArticle/{row.Id}'>{row.HeadLine}</a>";
                html += "</h2>";
                html += $"<p class='mb-2 mt-2'>{row.ContentSummary}</p>";
                html += "</div>";
            }

            html += "</div>";

            html += "</body></html>";

            return html;

        }
    }
}
