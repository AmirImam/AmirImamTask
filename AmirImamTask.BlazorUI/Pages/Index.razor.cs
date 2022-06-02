namespace AmirImamTask.BlazorUI.Pages;
public partial class Index
{
    private List<(string Title, bool State, string? Notes)> TasksList = new(){
      ( Title: "Use angular", State: true, Notes : "" ),
      ( Title: "Use bootstrap", State: true, Notes : "" ),
      ( Title: "Register & Login", State: true, Notes : "" ),
      ( Title: "Change password", State: true, Notes : "" ),
      ( Title: "Reset password", State: false, Notes: "It needs active email credentials, and for security reasons, I can't provide mine. But you can test it by getting OTP from database" ),
      ( Title: "Define Master Data", State: true, Notes : "" ),
      ( Title: "Transactions", State: true, Notes : "" ),
      ( Title: "Report for Item Balances", State: true, Notes : "" ),
      ( Title: "EF Code first", State: true, Notes : "" ),
      ( Title: "Layer for Data Access and Layer for Business Logic", State: true, Notes : "" ),
      ( Title: "REST APIs for Cruds utilizing DI", State: true, Notes : "" ),
      ( Title: "Login through JWT tokens", State: true, Notes : "" ),
      ( Title: "Unit Test using XUnit", State: true, Notes : "" ),
        };

    protected override async Task OnInitializedAsync()
    {
        //TasksList = new();
        StateHasChanged();
    }
}