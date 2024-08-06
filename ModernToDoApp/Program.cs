using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace ModernToDoApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddScoped<Services.UserService>();
        builder.Services.AddScoped<Services.DutyService>();
        builder.Services.AddScoped<Services.NotificationService>();

        // Register HTTP clients for each microservice
        builder.Services.AddHttpClient("UserService", client => client.BaseAddress = new Uri("https://localhost:7049/"));
        builder.Services.AddHttpClient("DutyService", client => client.BaseAddress = new Uri("https://localhost:7039/"));
        builder.Services.AddHttpClient("NotificationService", client => client.BaseAddress = new Uri("https://localhost:7224/"));

        // Global exception handling
        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
            var exception = error.ExceptionObject as Exception;
            // Redirect to the error page with the error message
            var navigationManager = builder.Services.BuildServiceProvider().GetRequiredService<NavigationManager>();
            navigationManager.NavigateTo($"/error?message={Uri.EscapeDataString(exception?.Message ?? "An error occurred")}");
        };

        builder.Services.AddOidcAuthentication(options =>
        {
            builder.Configuration.Bind("Local", options.ProviderOptions);
        });

        await builder.Build().RunAsync();
    }
}
