using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Common.Models.Enums;

namespace Common.Models.DTO;

public class LibraryBookResponse
{
    [DataMember(Name="bookUid")]
    public Guid BookUid { get; set; }

    [DataMember(Name="name")]
    public string Name { get; set; }

    [DataMember(Name="author")]
    public string Author { get; set; }

    [DataMember(Name="genre")]
    public string Genre { get; set; }

    [DataMember(Name="condition")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BookCondition Condition { get; set; }

    [DataMember(Name="availableCount")]
    public int AvailableCount { get; set; }
}