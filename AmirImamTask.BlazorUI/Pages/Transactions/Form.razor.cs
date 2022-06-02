namespace AmirImamTask.BlazorUI.Pages.Transactions;

public partial class Form : ViewBase
{
    [Parameter]
    public int Factor { get; set; }
    [Inject]
    private IStoreService StoreService { get; set; }
    [Inject]
    private ITransactionDetailService TransactionDetailService { get; set; }
    [Inject]
    private ITransactionService TransactionService { get; set; }
    public Transaction Model = new();
    public List<Store> StoresList = new();
    public List<TransactionDetailDto> ItemsList = new();
    public List<TransactionDetailDto> DetailsList = new();
    public TransactionDetailDto DetailModel = new();

    protected override async Task OnInitializedAsync()
    {
        this.Model.TransactionDate = DateTime.Now;

        this.StoresList = (await this.StoreService.GetAllAsync()).ToList();
    }



    public async Task ItemFinderInputKeyUp(ChangeEventArgs e)
    {
        var storeId = Guid.Parse(e.Value.ToString());
        this.Model.StoreId = storeId;
        this.ItemsList = (await this.TransactionDetailService.FindItemsByStoreAsync(storeId)).ToList();
        if (this.ItemsList.Count > 0)
        {

            this.DetailModel.ItemId = this.ItemsList[0].ItemId;
            this.DetailModel.Price = this.ItemsList[0].Price;
            this.DetailModel.Quantity = 1;
        }
    }

    public async Task AddItem()
    {
        TransactionDetailDto item = new()
        {
            ItemName = this.ItemsList.FirstOrDefault(it => it.ItemId == this.DetailModel.ItemId)?.ItemName,
            ItemCode = this.DetailModel.ItemCode,
            ItemDescription = this.DetailModel.ItemDescription,
            Price = this.DetailModel.Price,
            Quantity = this.DetailModel.Quantity,
            Value = 0,
            TransactionFactor = this.Factor,
            Id = Guid.Empty,
            ItemId = this.DetailModel.ItemId
        };
        item.Value = item.Price * item.Quantity;

        this.DetailsList.Add(item);
        this.CalculateTotals();
    }

    public void RemoveItem(int index)
    {
        this.DetailsList.RemoveAt(index);
        this.CalculateTotals();
    }

    public void CalculateTotals()
    {

        this.Model.ItemsCount = (int)this.DetailsList.Sum(it => it.Quantity);
        this.Model.TotalPrices = this.DetailsList.Sum(it => it.Price);
        this.Model.Net = this.DetailsList.Sum(it => it.Value);
        StateHasChanged();
    }

    public async void Submit()
    {
        this.Errors.Clear();
        this.Model.TransactionDetails = new List<TransactionDetail>();// this.DetailsList;
        foreach (TransactionDetailDto dto in DetailsList)
        {
            this.Model.TransactionDetails.Add(new()
            {
                ItemId = dto.ItemId,
                Price = dto.Price,
                Quantity = dto.Quantity,
                TransactionFactor = this.Factor,
                Value = dto.Value,

            });
        }
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(Model));
        var result = await this.TransactionService.CreateAsync(this.Model);
        if (result.Success == true)
        {
            this.Model = new Transaction();
            this.Model.TransactionDate = DateTime.Now;
            this.ItemsList.Clear();
            this.DetailsList.Clear();
            this.DetailModel = new TransactionDetailDto();
            StateHasChanged();
        }
        else
        {
            this.AssignErrors(result.Errors);
        }
    }
}