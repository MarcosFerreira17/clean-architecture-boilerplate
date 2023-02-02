namespace Costumer.Application.Exceptions.Model;

public class ErrorResponse<T>
{
    public string Message { get; set; }
    public static ErrorResponse<T> Fail(string errorMessage)
    {
        return new ErrorResponse<T> { Message = errorMessage };
    }
}
