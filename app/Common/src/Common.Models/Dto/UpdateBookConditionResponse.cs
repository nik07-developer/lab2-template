using System.Runtime.Serialization;
using Common.Models.Enums;

namespace Common.Models.DTO;

[DataContract]
public class UpdateBookConditionResponse
{
    [DataMember(Name="bookUid")]
    public Guid BookUid { get; set; }

    [DataMember(Name="libraryUid")]
    public Guid LibraryUid { get; set; }

    public BookCondition OldCondition  { get; set; }
    public BookCondition NewCondition  { get; set; }
}