using System.Runtime.Serialization;

namespace LibraryService.Common.Exceptions;

public class NotFoundEntityByIdException : Exception
{
    public NotFoundEntityByIdException() { }
    public NotFoundEntityByIdException(string message) : base(message) { }
    public NotFoundEntityByIdException(string message, Exception ex) : base(message, ex) { }
    protected NotFoundEntityByIdException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}