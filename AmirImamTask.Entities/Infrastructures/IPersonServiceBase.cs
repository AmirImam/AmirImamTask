using AmirImamTask.Entities.Helpers;

namespace AmirImamTask.Entities.Infrastructures;

public interface IPersonServiceBase<TResult> : IServiceBase<Person,TResult>
{
    Task<TResult> LoginAsync(LoginModel model);
    Task<TResult> ChangePasswordAsync(ChangePasswordModel model);
}
