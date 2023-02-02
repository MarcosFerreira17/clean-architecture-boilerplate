using System.Globalization;
using System.Runtime.Serialization;

namespace Costumer.Application.Exceptions;

[Serializable]
// Important: This attribute is NOT inherited from Exception, and MUST be specified 
// otherwise serialization will fail with a SerializationException stating that
// "Type X in Assembly Y is not marked as serializable."
public class GenericException : Exception
{
    public GenericException() : base() { }
    public GenericException(string message) : base(message) { }
    public GenericException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args)) { }
    public GenericException(string message, Exception innerException) : base(message, innerException) { }
    protected GenericException(SerializationInfo info, StreamingContext context)
    : base(info, context) { }
}
