using System.Text.Json.Serialization;

namespace Ecommerce.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentStatus
    {
        Pending = 1,
        Completed = 2,
        Failed = 3
    }
}
