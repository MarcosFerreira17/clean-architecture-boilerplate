namespace Application.DTO;
public class ResultGeneric<T>
{
    public T Value { get; }
    public bool IsSuccess { get; }
    public List<string> Errors { get; }

    private ResultGeneric(T value, bool isSuccess, List<string> errors)
    {
        Value = value;
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public static ResultGeneric<T> Success(T value) => new ResultGeneric<T>(value, true, new List<string>());

    public static ResultGeneric<T> Failure(List<string> errors) => new ResultGeneric<T>(default, false, errors);

    public static ResultGeneric<T> Failure(string error) => new ResultGeneric<T>(default, false, new List<string> { error });
}