
namespace AmirImamTask.BlazorUI.Pages.Items;

public partial class ItemStores : ViewBase
{

    [Parameter]
    public Guid ItemId { get; set; }
    [Inject]
    private IItemStoreService ItemStoreService { get; set; }
    [Inject]
    private IItemService ItemService { get; set; }

    private Item itemModel = new();
    private List<ItemStoreDto> itemStoresList = new();

    protected override async Task OnInitializedAsync()
    {
        itemModel = await ItemService.GetAsync(ItemId);
        itemStoresList = (await ItemStoreService.GetItemStoresByItemAsync(ItemId)).ToList();
    }

    private async void AddItemToStore(ItemStoreDto context)
    {
        ItemStore itemStore = new()
        {
            ItemId = this.ItemId,
            StoreId = context.StoreId,
            Quantity = 0,

        };
        var result = await this.ItemStoreService.CreateAsync(itemStore);
        if (result.Success == true)
        {
            context.ItemId = this.ItemId;
            context.ItemName = this.itemModel.ItemName;
            context.Quantity = 0;
            context.ItemStoreId = result.Model.Id;
            StateHasChanged();
        }
    }
}