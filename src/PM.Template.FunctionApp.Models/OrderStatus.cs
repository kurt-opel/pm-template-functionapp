using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PM.Template.FunctionApp.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum OrderStatus
{
    [EnumMember(Value = "placed")] Placed = 1,

    [EnumMember(Value = "approved")] Approved = 2,

    [EnumMember(Value = "delivered")] Delivered = 3,
}
