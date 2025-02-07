using System.Text.Json.Serialization;
using Common.Models.Enums;
using Common.Models.Serialization;

namespace Common.Models.DTO;

public class RawBookReservationResponse
{
    public Guid ReservationUid { get; set; }
    public string Username { get; set; }
    public Guid BookUid { get; set; }
    public Guid LibraryUid { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ReservationStatus Status { get; set; }
    
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly StartDate { get; set; }
    
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly TillDate { get; set; }
}