namespace Application.DTO;
public class Result
{
    public bool IsSuccess { get; }
    public List<string> Errors { get; }

    private Result(bool isSuccess, List<string> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public static Result Success() => new Result(true, new List<string>());
    public static Result Failure(List<string> errors) => new Result(false, errors);
    public static Result Failure(string error) => new Result(false, new List<string> { error });
}