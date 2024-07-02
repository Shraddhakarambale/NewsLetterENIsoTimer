using NewsLetterENIsoTimer.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsLetterENIsoTimer.Data;

var host = new HostBuilder()
     //.ConfigureFunctionsWorkerDefaults()
     .ConfigureFunctionsWebApplication()
     .ConfigureAppConfiguration(builder =>
    builder.AddJsonFile("local.settings.json", true, true)
    )
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<FuncDbContext>(options =>
        options.UseSqlServer(context.Configuration.GetConnectionString("LexiconConnection")));
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<IUserService, UserService>();
    })
    .Build();

host.Run();
