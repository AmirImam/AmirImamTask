namespace AmirImamTask.BlazorUI.Pages.Items;

public partial class Form : ViewBase
{
    [Parameter]
    public Guid? Id { get; set; }
    [Inject]
    private IItemService ItemService { get; set; }
    private Item Model = new();


    protected override async Task OnInitializedAsync()
    {
        if (Id != null)
        {
            this.Model = await ItemService.GetAsync(Id.Value);
        }
    }
    private async void Submit()
    {
        var result = Id == null ? await ItemService.CreateAsync(Model) : await ItemService.UpdateAsync(Model);
        if (result.Success == false)
        {
            this.AssignErrors(result.Errors);
        }
        else
        {
            Navigator.NavigateTo("/items");
        }
    }
}