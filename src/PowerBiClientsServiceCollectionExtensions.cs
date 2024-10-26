using System.Net.Sockets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace SimpleFakePowerBiClient;
public static class PowerBiClientsServiceCollectionExtensions
{
    public static IServiceCollection AddPowerBiClient<TClient>(this IServiceCollection services, string name) where TClient : IPowerBiClient
    {
        services.AddPbiClientOptions(name);
        services.AddScoped<IPowerBiClient>(provider =>
        {
            var options = provider.GetRequiredService<IOptionsMonitor<PBClientOptions>>().Get(name);
            var client = provider.CreatePbClient<TClient>(options);
            return client;
        });
        return services;
    }
    public static IServiceCollection AddPowerBiClients(this IServiceCollection services)
    {
        services.AddPowerBiClient<ChokotomPowerBiClient>("Chokotom");
        services.AddPowerBiClient<MajorPowerBiClient>("Major");

        //4947
        //4142
        return services;
    }


    private static TClient CreatePbClient<TClient>(this IServiceProvider serviceProvider, PBClientOptions options)
    {
        var constructor = typeof(TClient).GetConstructors()[0];
        var constructorParameters = constructor.GetParameters();
        var parameters = new object[constructorParameters.Length];

        for (int i = 0; i < constructorParameters.Length; i++)
        {
            parameters[i] = serviceProvider.GetParameter(constructorParameters[i].ParameterType, options);
        }
        return (TClient)constructor.Invoke(parameters);
    }

    private static object GetParameter(this IServiceProvider provider, Type parameterType, PBClientOptions options)
    {
        if (parameterType == typeof(FakePowerBiGateway))
            return new FakePowerBiGateway(options.ApiKey, options.ConnectionString, options.UserName, options.UserSecret);
        return provider.GetRequiredService(parameterType);
    }

    private static void AddPbiClientOptions(this IServiceCollection services, string optionName)
    {
        services.AddOptions<PBClientOptions>(optionName)
                        .BindConfiguration($"PowerBiClients:{optionName}")
                        .ValidateDataAnnotations()
                        .ValidateOnStart();
    }










    /// <summary>
    /// obsolete
    /// </summary>
    /// <param name="services"></param>
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


    /// <summary>
    /// obsolete
    /// </summary>
    /// <param name="services"></param>

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
}