using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PM.Template.FunctionApp.Options;

namespace PM.Template.FunctionApp.Functions
{
    public class SampleFunction
    {
        private readonly ILogger<SampleFunction> logger;
        private readonly ConfigurationOptions options;

        public SampleFunction(ILogger<SampleFunction> logger, IOptions<ConfigurationOptions> optionsAccessor)
        {
            this.logger = logger;
            this.options = optionsAccessor.Value;
        }

        [Function(nameof(SampleFunction))]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            this.logger.LogInformation("C# HTTP trigger function processed a request.");

            this.logger.LogInformation("The options value is: {value}", this.options.SampleString);

            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
