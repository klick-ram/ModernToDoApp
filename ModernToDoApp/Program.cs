using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ModernToDoApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        // Register HTTP clients for each microservice
        builder.Services.AddHttpClient("UserService", client => client.BaseAddress = new Uri("https://localhost:53851/"));
        builder.Services.AddHttpClient("DutyService", client => client.BaseAddress = new Uri("https://localhost:53859/"));
        builder.Services.AddHttpClient("NotificationService", client => client.BaseAddress = new Uri("https://localhost:53854/"));

        await builder.Build().RunAsync();
    }
}
