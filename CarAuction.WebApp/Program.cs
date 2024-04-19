using CarAuction.WebApp;
using CarAuction.WebApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiSetting:ApiServiceBaseUrl"]!) });

//Services Registeration
builder.Services.AddScoped<ApiCallService>();
builder.Services.AddScoped<ICarAuctionService, CarAuctionService>();



//Registeration of MudBlazor
builder.Services.AddMudServices();

await builder.Build().RunAsync();
