using System.Text;

namespace AmirImamTask.ClientServices;

public class ServiceBase<T> : IServiceBase<T,ResponseResult<T>> where T : EntityBase
{
    protected readonly HttpClient Context;

    public ServiceBase(HttpClient context)
    {
        this.Context = context;
    }


    public virtual async Task<IEnumerable<T>> GetAllAsync() 
        => await Context.GetFromJsonAsync<IEnumerable<T>>(typeof(T).Name);
    public virtual async Task<T> GetAsync(Guid id) 
        => await Context.GetFromJsonAsync<T>($"{typeof(T).Name}/{id}");

    public virtual async Task<ResponseResult<T>> CreateAsync(T entity)
        => await ExecuteAsync("POST", entity, null);
    public virtual async Task<ResponseResult<T>> UpdateAsync(T entity)
        => await ExecuteAsync("PUT", entity, null);
    public virtual async Task<ResponseResult<T>> DeleteAsync(Guid id)
        => await ExecuteAsync("DELETE", null, id);

    
    private async Task<ResponseResult<T>> ExecuteAsync(string method, T? entity,Guid? id)
    {
        HttpResponseMessage response = new();
        switch (method)
        {
            case "POST":
                response = await Context.PostAsync(typeof(T).Name, entity.ToStringContent());
                break;
            case "PUT":
                response = await Context.PutAsync(typeof(T).Name, entity.ToStringContent());
                break;
            case "DELETE":
                response = await Context.DeleteAsync($"{typeof(T).Name}/{id}");
                break;
            default:
                break;
        }
        string responseStringContent = await response.Content.ReadAsStringAsync();
        ResponseResult<T> result = System.Text.Json.JsonSerializer.Deserialize<ResponseResult<T>>(responseStringContent);
        return result;
    }

   
}
