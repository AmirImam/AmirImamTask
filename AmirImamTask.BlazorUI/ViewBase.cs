

namespace AmirImamTask.BlazorUI;
public class ViewBase : ComponentBase
{

    [CascadingParameter]
    public MainLayout Layout { get; set; }
    [Inject]
    protected NavigationManager Navigator { get; set; }
    public Dictionary<string, List<string>> Errors { get; set; } = new();

    protected void AssignErrors(Dictionary<string, List<string>> items)
    {
        this.Errors = items;
        //Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(items));
        StateHasChanged();
    }

    protected void AssignError(string key, string value)
    {
        Errors.Add(key, new() { value });
        StateHasChanged();
    }



}