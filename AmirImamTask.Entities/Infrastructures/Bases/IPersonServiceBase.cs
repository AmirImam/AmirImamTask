using AmirImamTask.Entities.Helpers;

namespace AmirImamTask.Entities.Infrastructures;

public interface IPersonServiceBase<TResult> : IServiceBase<Person,TResult>
{
    Task<TResult> LoginAsync(LoginModel model);
    Task<TResult> ChangePasswordAsync(ChangePasswordModel model);
    Task<TResult> CreateOtpAsync(string email);
    Task<TResult> SubmitOtpAsync(Guid id,string otp);
    Task<TResult> ResetPasswordAsync(Guid id, ChangePasswordModel model);
}
