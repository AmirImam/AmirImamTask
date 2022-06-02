using AmirImamTask.BlazorUI;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.SessionStorage;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7231/api/") });
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IItemStoreService, ItemStoreService>();

builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionDetailService, TransactionDetailService>();

builder.Services.AddScoped<ScopeManager>();
builder.Services.AddScoped<UserAccountService>();
builder.Services.AddBlazoredSessionStorage();

await builder.Build().RunAsync();
