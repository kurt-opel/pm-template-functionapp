using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Configurations;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PM.Template.FunctionApp.Models;

namespace PM.Template.FunctionApp.Functions
{
    public class StoreHttpTrigger
    {
        private readonly ILogger logger;
        private readonly OpenApiSettings openapi;
        private readonly Fixture fixture;

        public StoreHttpTrigger(ILoggerFactory loggerFactory, OpenApiSettings openapi, Fixture fixture)
        {
            this.logger = loggerFactory.ThrowIfNullOrDefault().CreateLogger<StoreHttpTrigger>();
            this.openapi = openapi.ThrowIfNullOrDefault();
            this.fixture = fixture.ThrowIfNullOrDefault();
        }

        [Function(nameof(StoreHttpTrigger.GetInventoryAsync))]
        [OpenApiOperation(
            operationId: "getInventory",
            tags: new[] { "store" },
            Summary = "Returns pet inventories by status",
            Description = "This returns a map of status codes to quantities",
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("api_key", SecuritySchemeType.ApiKey, Name = "api_key", In = OpenApiSecurityLocationType.Header)]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            contentType: "application/json",
            bodyType: typeof(Dictionary<string, int>),
            Description = "Successful Operation")]
        public async Task<HttpResponseData> GetInventoryAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "POST", Route = "store/inventory")] HttpRequestData req)
        {
            this.logger.LogInformation("document title: {title}", this.openapi.DocTitle);
            var response = req.CreateResponse(HttpStatusCode.OK);
            var result = this.fixture.Create<Dictionary<string, int>>();
            await response.WriteAsJsonAsync(result).ConfigureAwait(false);

            return await Task.FromResult(response).ConfigureAwait(false);
        }

        [Function(nameof(StoreHttpTrigger.PlaceOrderAsync))]
        [OpenApiOperation(
            operationId: "placeOrder",
            tags: new[] { "store" },
            Summary = "Places an order for a pet",
            Description = "This places an order for a pet",
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiRequestBody(
            contentType: "application/json",
            bodyType: typeof(Order),
            Required = true,
            Description = "order placed for purchasing the pet")]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            contentType: "application/json",
            bodyType: typeof(Order),
            Summary = "successful operation",
            Description = "successful operation")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "invalid input", Description = "invalid input")]
        public async Task<HttpResponseData> PlaceOrderAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "POST", Route = "store/order")] HttpRequestData req)
        {
            this.logger.LogInformation("Document Title: {DocTitle}", this.openapi.DocTitle);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(this.fixture.Create<Order>()).ConfigureAwait(false);

            return await Task.FromResult(response).ConfigureAwait(false);
        }

        [Function(nameof(StoreHttpTrigger.GetOrderByIdAsync))]
        [OpenApiOperation(
            operationId: "getOrderById",
            tags: new[] { "store" },
            Summary = "Finds Purchase order by ID",
            Description = "This finds the purchase order by Id",
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(
            name: "orderId",
            In = ParameterLocation.Path,
            Required = true,
            Type = typeof(long),
            Summary = "ID of the order that needs to be fetched",
            Description = "ID of the order that needs to be fetched",
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            contentType: "application/json",
            bodyType: typeof(Order),
            Description = "Successful Operation")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid ID supplied", Description = "Invalid ID supplied")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Summary = "Order not found", Description = "Order not found")]
        public async Task<HttpResponseData> GetOrderByIdAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "store/order/{orderId}")] HttpRequestData req,
            long orderId)
        {
            this.logger.LogInformation("Document Title: {DocTitle}", this.openapi.DocTitle);

            var response = req.CreateResponse(HttpStatusCode.OK);

            var order = this.fixture.Build<Order>().With(p => p.Id, orderId).Create();

            await response.WriteAsJsonAsync(order).ConfigureAwait(false);

            return await Task.FromResult(response).ConfigureAwait(false);
        }

        [Function(nameof(StoreHttpTrigger.DeleteOrderAsync))]
        [OpenApiOperation(
            operationId: "deleteOrder",
            tags: new[] { "store" },
            Summary = "Deletes Purchase order by ID",
            Description = "This deletes the purchase order by Id",
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(
            name: "orderId",
            In = ParameterLocation.Path,
            Required = true,
            Type = typeof(long),
            Summary = "ID of the order that needs to be deleted",
            Description = "ID of the order that needs to be deleted",
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid ID supplied", Description = "Invalid ID supplied")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Summary = "Order not found", Description = "Order not found")]
        public async Task<HttpResponseData> DeleteOrderAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "DELETE", Route = "store/order/{orderId}")] HttpRequestData req,
            long orderId)
        {
            this.logger.LogInformation("Document Title: {DocTitle}", this.openapi.DocTitle);

            var response = req.CreateResponse(HttpStatusCode.OK);

            return await Task.FromResult(response).ConfigureAwait(false);
        }
    }
}
