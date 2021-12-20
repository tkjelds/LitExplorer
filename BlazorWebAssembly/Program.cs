using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using BlazorWebAssembly;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("iLit.API", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
// Supply HttpClient instances that include access tokens when making requests to the server project
/*builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("iLit.API"));
/*
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("api://8bfdad82-6c9e-41a2-bd1a-83d65103e5e1/API.Access");
    options.UserOptions.RoleClaim = "appRole";
}); */
await builder.Build().RunAsync();
