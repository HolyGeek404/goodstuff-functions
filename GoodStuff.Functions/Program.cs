using Azure.Identity;
using GoodStuff.Functions.Configuration;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var builder = FunctionsApplication.CreateBuilder(args);

builder.Configuration.AddAzureKeyVault(new Uri(Environment.GetEnvironmentVariable("KvUrl")), new DefaultAzureCredential());

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(new LoggerConfiguration().WriteTo.Console().CreateLogger()));

builder.Services.AddHttpClient();
builder.Services.AddServices();
builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Build().Run();