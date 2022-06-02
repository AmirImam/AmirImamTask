namespace AmirImamTask.BlazorUI.Pages.Account;
public partial class Login : ViewBase
{

    [CascadingParameter]
    public AccountContainer Container { get; set; }
    [Inject]
    private IPersonService PersonService { get; set; }
    [Inject]
    private UserAccountService UserAccountService { get; set; }
    private LoginModel model = new();

    private async void LoginSubmit()
    {
        var result = await this.PersonService.LoginAsync(model);
        if (result.Success == false)
        {
            AssignErrors(result.Errors);
        }
        else
        {
            await UserAccountService.OnLoggedAsync(result.Model);
            this.Layout.Refresh();
        }
    }
}