namespace AmirImamTask.Entities;

public class ResponseResult<T>
{
    public ResponseResult()
    {

    }
    public ResponseResult(Exception exception)
    {
        var ex = exception;
    Start:
        string key = ex.GetType().Name;
        if (!Errors.ContainsKey(key))
        {
            Errors.Add(key, new List<string>());
        }
        Errors[key].Add(ex.Message);
        if (ex.InnerException != null)
        {
            ex = ex.InnerException;
            goto Start;
        }
    }
    public T Model { get; set; }
    public Dictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();
    public bool Success
        => !Errors.Any();
    public List<string> ErrorsAsList
        => Errors.Select(it => $"{it.Key}:[{string.Join(",", it.Value)}]").ToList();

    public static ResponseResult<T> Ok(T model)
        => new ResponseResult<T>() { Model = model };
    public static ResponseResult<T> Error(Exception ex)
        => new ResponseResult<T>(ex);
    public static ResponseResult<T> Error(Dictionary<string, List<string>> errors)
        => new ResponseResult<T>() { Errors = errors };
    public static ResponseResult<T> Error(string key, string value)
        => ResponseResult<T>.Error(new Dictionary<string, List<string>>()
        {
        { key, new() { value } }

        });
}

