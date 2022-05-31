using AmirImamTask.DataServices;
using EdenPlugins.ApiCoreConfiguration;

namespace AmirImamTask.API;

public static class ProgramExtensions
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder.RegisterAppServices();
        builder.RegisterIdentity();
        builder.RegisterBusinessServices();
        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy("GeneralPolicy", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });
        return builder;
        
    }

    private static void RegisterBusinessServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IPersonService, PersonService>();
        builder.Services.AddScoped<IItemService, ItemService>();
        builder.Services.AddScoped<IStoreService, StoreService>();
        builder.Services.AddScoped<IItemStoreService, ItemStoreService>();

        builder.Services.AddScoped<ITransactionService, TransactionService>();
        builder.Services.AddScoped<ITransactionDetailService, TransactionDetailService>();
    }

    private static void RegisterAppServices(this WebApplicationBuilder builder)
    {
        // Add services to the container.

        builder.Services.AddControllers().AddNewtonsoftJson(opt =>
        {
            opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            opt.UseMemberCasing();
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

    }

    private static void RegisterIdentity(this WebApplicationBuilder builder)
    {
        //Combined configurations for Asp.Net Core API and Sql Server in NuGet package created by me 
        //https://www.nuget.org/packages/EdenPlugins.ApiCoreConfiguration/1.0.4
        builder.Services.ConfigureIdentityDbContext<ApplicationDbContext>(new IdentityDbContextConfigurationOptions()
        {
            ConnectionString = builder.Configuration.GetConnectionString(nameof(ApplicationDbContext)),
            RequireDigit = true,
            RequiredLength = 6,
            RequiredUniqueChars = 1,
            RequireLowercase = true,
            RequireNonAlphanume = true,
            RequireUppercase = true,
            TokenKey = builder.Configuration["TokenKey"]
        });
    }
}
