
namespace AmirImamTask.BlazorUI.Services;
public class UserAccountService
{
    private readonly ISessionStorageService sessionStorage;
    private readonly NavigationManager navigator;
    private readonly HttpClient http;
    private readonly ScopeManager scope;

    public UserAccountService(ISessionStorageService sessionStorage,
    NavigationManager navigator,
    HttpClient http,
    ScopeManager scope)
    {
        this.sessionStorage = sessionStorage;
        this.navigator = navigator;
        this.http = http;
        this.scope = scope;
    }
    public async Task OnLoggedAsync(Person person)
    {
        //In real application this will be encrypted
        await sessionStorage.SetItemAsync("Person", person);
        this.scope.Me = person;
        http.DefaultRequestHeaders.Authorization
         = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", person.AccessToken);
        this.navigator.NavigateTo("/");
    }

    public async Task DetectLoggedAsync()
    {

        var person = await sessionStorage.GetItemAsync<Person>("Person");
        if (person != null)
        {
            this.scope.Me = person;
            http.DefaultRequestHeaders.Authorization
       = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", person.AccessToken);
        }
    }
}