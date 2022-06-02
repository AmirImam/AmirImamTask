

namespace AmirImamTask.BlazorUI.Pages.Account;
public partial class UsersIndex
{
    [Inject]
    private IPersonService PersonService { get; set; }
    private List<Person> usersList = new();

    protected override async Task OnInitializedAsync()
    {
        usersList = (await PersonService.GetAllAsync()).ToList();
    }
}