using AmirImamTask.Entities.Helpers;
//using Microsoft.EntityFrameworkCore;

namespace AmirImamTask.ClientServices;

public class PersonService : ServiceBase<Person>, IPersonService
{
    
    public PersonService(HttpClient context) : base(context)
    {
        
    }

    public async Task<ResponseResult<Person>> ChangePasswordAsync(ChangePasswordModel model)
    {
        HttpResponseMessage response = await Context.PostAsync($"{nameof(Person)}/ChangePassword", model.ToStringContent());
        return await response.ToResponseResultAsync<Person>();
    }

    
    public async Task<ResponseResult<Person>> CreateOtpAsync(string email)
    {
        HttpResponseMessage response = await Context.PostAsync($"{nameof(Person)}/CreateOtp/{email}", null);
        return await response.ToResponseResultAsync<Person>();
    }

    public async Task<ResponseResult<Person>> LoginAsync(LoginModel model)
    {
        HttpResponseMessage response = await Context.PostAsync($"{nameof(Person)}/Login", model.ToStringContent());
        return await response.ToResponseResultAsync<Person>();
    }

    public async Task<ResponseResult<Person>> ResetPasswordAsync(Guid id, ChangePasswordModel model)
    {
        HttpResponseMessage response = await Context.PostAsync($"{nameof(Person)}/ResetPassword/{id}", model.ToStringContent());
        return await response.ToResponseResultAsync<Person>();
    }

    public async Task<ResponseResult<Person>> SubmitOtpAsync(Guid id, string otp)
    {
        HttpResponseMessage response = await Context.PostAsync($"{nameof(Person)}/SubmitOtp/{id}/{otp}", null);
        return await response.ToResponseResultAsync<Person>();
    }
}
