using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VistaBasket.Web;
using VistaBasket.Web.Extensions;
using VistaBasket.Web.Utility;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddApplicationServices();
builder.Services.AddAuthorizationCore();
//builder.Services.AddBlazoredLocalStorage();
await builder.Build().RunAsync();
