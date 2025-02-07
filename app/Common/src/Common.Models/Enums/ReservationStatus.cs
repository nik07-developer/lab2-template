using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Common.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ReservationStatus
{
    [EnumMember(Value = "RENTED")]
    RENTED,
    
    [EnumMember(Value = "RETURNED")]
    RETURNED,
    
    [EnumMember(Value = "EXPIRED")]
    EXPIRED
}