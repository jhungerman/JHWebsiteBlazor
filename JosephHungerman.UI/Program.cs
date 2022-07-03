using Azure.Identity;
using JosephHungerman.UI;
using JosephHungerman.UI.Services.Quote;
using JosephHungerman.UI.Static;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ApiEndpoints.ApiBaseUrl = new Uri("https://localhost:7103");

builder.Services.AddSingleton(_ => new HttpClient { BaseAddress = ApiEndpoints.ApiBaseUrl });
builder.Services.AddScoped<IQuoteService, QuoteService>();

//var keyVaultEndpoint = new Uri(builder.Configuration.GetSection("VaultUri").Value);
//builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());


await builder.Build().RunAsync();
