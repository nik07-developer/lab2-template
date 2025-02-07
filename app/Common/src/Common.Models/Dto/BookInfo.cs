using System.Runtime.Serialization;

namespace Common.Models.DTO;

public class BookInfo
{
    [DataMember(Name="bookUid")]
    public Guid BookUid { get; set; }

    [DataMember(Name="name")]
    public string Name { get; set; }

    [DataMember(Name="author")]
    public string Author { get; set; }

    [DataMember(Name="genre")]
    public string Genre { get; set; }
}