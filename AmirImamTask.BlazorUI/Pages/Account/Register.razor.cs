namespace AmirImamTask.BlazorUI.Pages.Account;

public partial class Register : ViewBase
{

    [CascadingParameter]
    public AccountContainer Container { get; set; }

    [Inject]
    private IPersonService PersonService { get; set; }
    [Inject]
    private UserAccountService UserAccountService { get; set; }
    private Person Model = new();

    private async void Submit()
    {
        var result = await PersonService.CreateAsync(Model);
        if (result.Success == false)
        {
            this.AssignErrors(result.Errors);
        }
        else
        {
            var loginResult = await PersonService.LoginAsync(new()
            {
                Email = Model.Email,
                Password = Model.Locker
            });
            await UserAccountService.OnLoggedAsync(loginResult.Model);

        }
    }
}