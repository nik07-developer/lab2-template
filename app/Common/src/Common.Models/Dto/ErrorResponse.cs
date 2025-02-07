using System.Runtime.Serialization;

namespace Common.Models.DTO;

[DataContract]
public class ErrorResponse(string message)
{
    [DataMember(Name = "message")]
    public string Message { get; set; } = message;
}