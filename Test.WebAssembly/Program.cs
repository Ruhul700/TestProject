using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Test.WebAssembly;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddScoped<DialogService>()
    .AddScoped<NotificationService>()
    .AddScoped<TooltipService>()
    .AddScoped<ContextMenuService>()
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress), Timeout = TimeSpan.FromMinutes(10) });

await builder.Build().RunAsync();
