using System;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;

namespace PM.Template.FunctionApp.Models
{
    public class Order
    {
        public long Id { get; set; }

        public long PetId { get; set; }

        public int Quantity { get; set; }

        public DateTime ShipDate { get; set; }

        [OpenApiProperty(Description = "Order Status")]
        public OrderStatus Status { get; set; }

        [OpenApiProperty(Default = false)]
        public bool Complete { get; set; }
    }
}
