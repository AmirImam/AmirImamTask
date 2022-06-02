namespace AmirImamTask.BlazorUI.Shared;
public partial class MainLayout
{
    [Inject]
    private UserAccountService UserAccountService { get; set; }
    [Inject]
    private HttpClient Http { get; set; }

    private string ReportsUrl
    => $"{Http.BaseAddress.ToString()}Item/BalancesReport";
    public void Refresh() => StateHasChanged();

    protected override async Task OnInitializedAsync()
    {
        await UserAccountService.DetectLoggedAsync();
        Refresh();
    }
}