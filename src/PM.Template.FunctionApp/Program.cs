using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PM.Template.FunctionApp.Options;

[assembly: InternalsVisibleTo("PM.Template.FunctionApp.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace PM.Template.FunctionApp;

[ExcludeFromCodeCoverage(Justification = "This class cannot be tested.")]
public class Program
{
    public static void Main()
    {
        var host = new HostBuilder().ConfigureFunctionsWebApplication()
                                    .ConfigureAppConfiguration(ConfigureAppConfiguration)
                                    .ConfigureServices(ConfigureServices)
                                    .Build();

        host.Run();
    }

    private static void ConfigureAppConfiguration(IConfigurationBuilder builder)
    {
        builder.AddJsonFile("appsettings.json", true, true)
               .AddJsonFile("appsettings.local.json", true, true)
               .AddJsonFile("local.settings.json", true, true)
               .AddEnvironmentVariables()
               .Build();
    }

    private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        // to use the configurationOptions here, uncomment the next block
        /*
        var configuration = context.Configuration;
        var configurationOptions = new ConfigurationOptions();
        configuration.Bind(configurationOptions);
        */

        // add custom configuration
        services.AddOptions<ConfigurationOptions>().Bind(context.Configuration);

        services.AddSingleton<Fixture>(new Fixture())
                .AddSingleton<IOpenApiConfigurationOptions>(
                     _ =>
                     {
                         var options = new OpenApiConfigurationOptions()
                         {
                             Info = new OpenApiInfo()
                             {
                                 Version = DefaultOpenApiConfigurationOptions.GetOpenApiDocVersion(),
                                 Title = $"{DefaultOpenApiConfigurationOptions.GetOpenApiDocTitle()} (Injected)",
                                 Description = DefaultOpenApiConfigurationOptions.GetOpenApiDocDescription(),
                                 TermsOfService = new Uri("https://github.com/Azure/azure-functions-openapi-extension"),
                                 Contact =
                                     new OpenApiContact()
                                     {
                                         Name = "Enquiry",
                                         Email = "info@plantemoran.com",
                                         Url = new Uri("https://github.com/Azure/azure-functions-openapi-extension/issues"),
                                     },
                                 License = new OpenApiLicense() { Name = "MIT", Url = new Uri("http://opensource.org/licenses/MIT"), }
                             },
                             Servers = DefaultOpenApiConfigurationOptions.GetHostNames(),
                             OpenApiVersion = DefaultOpenApiConfigurationOptions.GetOpenApiVersion(),
                             IncludeRequestingHostName = DefaultOpenApiConfigurationOptions.IsFunctionsRuntimeEnvironmentDevelopment(),
                             ForceHttps = DefaultOpenApiConfigurationOptions.IsHttpsForced(),
                             ForceHttp = DefaultOpenApiConfigurationOptions.IsHttpForced(),
                         };

                         return options;
                     })
                .AddSingleton<IOpenApiHttpTriggerAuthorization>(
                     _ =>
                     {
                         var auth = new OpenApiHttpTriggerAuthorization(
                             req =>
                             {
                                 var result = default(OpenApiAuthorizationResult);

                                 return Task.FromResult(result);
                             });

                         return auth;
                     })
                .AddSingleton<IOpenApiCustomUIOptions>(
                     _ =>
                     {
                         var assembly = Assembly.GetExecutingAssembly();

                         var options = new OpenApiCustomUIOptions(assembly)
                         {
                             GetStylesheet = () =>
                             {
                                 var result = string.Empty;

                                 return Task.FromResult(result);
                             },
                             GetJavaScript = () =>
                             {
                                 var result = string.Empty;

                                 return Task.FromResult(result);
                             },
                         };

                         return options;
                     });
    }
}
