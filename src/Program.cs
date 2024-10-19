// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleFakePowerBiClient;

var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

var serviceProvider = new ServiceCollection()
    .AddPowerBiClients()
    .AddSingleton<IConfiguration>(provider => configuration)
    .AddScoped<IPowerBiClientProvider, PowerBiClientProvider>()
    .BuildServiceProvider();

var chokotom = serviceProvider.GetRequiredService<IPowerBiClientProvider>()
.GetPowerBiClient("Chokotom")
.GetDocumentAsString("Chokotom : 123456");

var major = serviceProvider.GetRequiredService<IPowerBiClientProvider>()
.GetPowerBiClient("Major")
.GetDocumentAsString("Major : 123456");

Console.WriteLine($"Here is major document : {major}");
Console.WriteLine($"Here is chokotom document : {chokotom}");
