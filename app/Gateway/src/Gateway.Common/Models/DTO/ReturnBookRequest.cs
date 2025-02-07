using System.Runtime.Serialization;
using Common.Models.Enums;

namespace Gateway.Common.Models.DTO;

[DataContract]
public class ReturnBookRequest
{
    [DataMember(Name="condition")]
    public BookCondition Condition { get; set; }

    [DataMember(Name="date")]
    public DateOnly Date { get; set; }
}