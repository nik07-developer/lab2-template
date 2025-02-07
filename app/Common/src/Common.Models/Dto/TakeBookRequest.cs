using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Common.Models.Serialization;

namespace Common.Models.DTO;

[DataContract]
public class TakeBookRequest
{
    [DataMember(Name="bookUid")]
    public Guid BookUid { get; set; }

    [DataMember(Name="libraryUid")]
    public Guid LibraryUid { get; set; }

    [DataMember(Name="tillDate")]
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly TillDate { get; set; }
}