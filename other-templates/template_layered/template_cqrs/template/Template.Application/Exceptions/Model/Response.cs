namespace Template.Application.Exceptions.Model;

public class Response<T>
{
    public Response()
    {
    }

    public Response(T data)
    {
        Succeeded = true;
        Message = string.Empty;
        Errors = null;
        Data = data;
    }
    public Response(T data, string message)
    {
        Data = data;
        Message = message;
        Succeeded = true;
    }

    public Response(string message)
    {
        Message = message;
    }
    public T Data { get; set; }
    public bool Succeeded { get; set; }
    public string[] Errors { get; set; }
    public string Message { get; set; }
}
