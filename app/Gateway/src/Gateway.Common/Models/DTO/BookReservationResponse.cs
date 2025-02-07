using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Common.Models.DTO;
using Common.Models.Enums;
using Common.Models.Serialization;

namespace Gateway.Common.Models.DTO;

public class BookReservationResponse
{
    [DataMember(Name="reservationUid")]
    public Guid ReservationUid { get; set; }

    [DataMember(Name="status")]
    public ReservationStatus Status { get; set; }

    [DataMember(Name="startDate")]
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly StartDate { get; set; }

    [DataMember(Name="tillDate")]
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly TillDate { get; set; }
    
    [DataMember(Name="book")]
    public BookInfo Book { get; set; }
    
    [DataMember(Name="library")]
    public LibraryResponse Library { get; set; }
}