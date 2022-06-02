namespace AmirImamTask.BlazorUI.Pages.Items;

public partial class Index : ViewBase
{
    [Inject]
    private IItemService ItemService { get; set; }
    private List<Item> itemsList = new();

    protected override async Task OnInitializedAsync()
    {
        itemsList = (await ItemService.GetAllAsync()).ToList();
    }
}