namespace AmirImamTask.BlazorUI.Pages.Stores;

public partial class Index : ViewBase
{
    [Inject]
    private IStoreService StoreService { get; set; }
    private List<Store> storesList = new();

    protected override async Task OnInitializedAsync()
    {
        storesList = (await StoreService.GetAllAsync()).ToList();
    }
}