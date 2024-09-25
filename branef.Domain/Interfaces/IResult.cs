namespace branef.Domain.Interfaces;
public interface IResult<T> where T : class
{
    T? Data { get; }
    bool Success { get; set; }
    Dictionary<string, string> Errors { get; set; }
    string Message { get; set; }
}
