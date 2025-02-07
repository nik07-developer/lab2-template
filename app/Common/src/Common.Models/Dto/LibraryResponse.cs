using System.Runtime.Serialization;

namespace Common.Models.DTO;

public class LibraryResponse
{
    [DataMember(Name="libraryUid")]
    public string LibraryUid { get; set; }

    [DataMember(Name="name")]
    public string Name { get; set; }

    [DataMember(Name="address")]
    public string Address { get; set; }

    [DataMember(Name="city")]
    public string City { get; set; }
}