namespace AmirImamTask.BlazorUI.Pages.Stores;

public partial class Form : ViewBase
{
    [Parameter]
    public Guid? Id { get; set; }
    [Inject]
    private IStoreService StoreService { get; set; }
    [Inject]
    private IPersonService PersonService { get; set; }
    private Store model = new();
    private List<Person> personsList = new();

    protected override async Task OnInitializedAsync()
    {
        personsList = (await PersonService.GetAllAsync()).ToList();
        if (Id != null)
        {
            model = await StoreService.GetAsync(Id.Value);
        }
    }
    private async void Submit()
    {
        var result = Id == null ? await StoreService.CreateAsync(model) : await StoreService.UpdateAsync(model);
        if (result.Success == true)
        {
            Navigator.NavigateTo("/stores");
        }
        else
        {
            this.AssignErrors(result.Errors);
        }
    }
}