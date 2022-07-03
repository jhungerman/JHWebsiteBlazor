using Azure.Identity;
using JosephHungerman.UI;
using JosephHungerman.UI.Services.About;
using JosephHungerman.UI.Services.Contact;
using JosephHungerman.UI.Services.Quote;
using JosephHungerman.UI.Services.Resume;
using JosephHungerman.UI.Services.Toast;
using JosephHungerman.UI.Static;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ApiEndpoints.ApiBaseUrl = new Uri("https://api.josephhungerman.com");

builder.Services.AddSingleton(_ => new HttpClient { BaseAddress = ApiEndpoints.ApiBaseUrl });
builder.Services.AddScoped<IQuoteService, QuoteService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IToastService, ToastService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IResumeService, ResumeService>();

await builder.Build().RunAsync();
