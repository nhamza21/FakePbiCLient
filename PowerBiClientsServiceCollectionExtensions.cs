using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace SimpleFakePowerBiClient;
public static class PowerBiClientsServiceCollectionExtensions
{
    public static IServiceCollection AddPowerBiClients(this IServiceCollection services)
    {
        services.AddChokotom();
        services.AddMajor();

        return services;
    }

    private static void AddChokotom(this IServiceCollection services)
    {
        var name = "Chokotom";
        services.AddPbiClientOptions(name);

        services.AddScoped<IPowerBiClient>(provider =>
        {
            var options = provider.GetRequiredService<IOptionsMonitor<PBClientOptions>>().Get(name);
            var gateway = new FakePowerBiGateway(options.ApiKey, options.ConnectionString, options.UserName, options.UserSecret);
            var client = new ChokotomPowerBiClient(gateway);
            return client;
        });
    }

    private static void AddMajor(this IServiceCollection services)
    {
        var name = "Major";
        services.AddPbiClientOptions(name);

        services.AddScoped<IPowerBiClient>(provider =>
        {
            var options = provider.GetRequiredService<IOptionsMonitor<PBClientOptions>>().Get(name);
            var gateway = new FakePowerBiGateway(options.ApiKey, options.ConnectionString, options.UserName, options.UserSecret);
            var client = new MajorPowerBiClient(gateway);
            return client;
        });
    }

    private static void AddPbiClientOptions(this IServiceCollection services, string optionName)
    {
        services.AddOptions<PBClientOptions>()
                        .BindConfiguration($"PowerBiClients:{optionName}")
                        .ValidateOnStart();
    }
}