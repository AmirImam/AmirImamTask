using System.Text;

namespace AmirImamTask.ClientServices;

public static class _Extensions
{
    public static StringContent ToStringContent(this object model)
    {
        string json = System.Text.Json.JsonSerializer.Serialize(model);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        return content;
    }

    public static async Task<ResponseResult<TResult>> ToResponseResultAsync<TResult>(this HttpResponseMessage response)
    {
        string responseMessage = await response.Content.ReadAsStringAsync();
        ResponseResult<TResult> result = System.Text.Json.JsonSerializer.Deserialize<ResponseResult<TResult>>(responseMessage);
        return result;
    }
}
