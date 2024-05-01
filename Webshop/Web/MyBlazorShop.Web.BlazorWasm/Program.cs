using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Lib.Services;
using Webshop;
using Webshop.Models;
using Webshop.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IStorageService, StorageService>();
builder.Services.AddSingleton<IShoppingCartService, ShoppingCartService>();
builder.Services.AddTransient<ISurfboardService, SurfboardService>();
builder.Services.AddScoped<WebApiService>();
builder.Services.AddBlazorBootstrap(); // Add this line

// Add & Config OpenAI
builder.Services.Configure<ChatOptions>((o) => builder.Configuration.GetSection("OpenAI").Bind(o));
builder.Services.AddScoped<OpenAIService>();

await builder.Build().RunAsync();
