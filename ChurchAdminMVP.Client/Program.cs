using ChurchAdminMVP.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient
 { 
  BaseAddress = new Uri("http://localhost:5046") 
});

builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();
