using CoinMarketCap;
using TokeroAssignment.Components;
using TokeroAssignment.Core;
using TokeroAssignment.ViewModels;

#if DEBUG
// In Debugging environment we'll have to import the environment variable from /Config/config.json
EnvironementSetup.DebugSetup();
#endif

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<HomeViewModel>();

builder.Services.AddScoped(sp =>
    new CoinMarketCapClient(AppConstant.CmcApiKey)
);
builder.Services.AddScoped<HomeViewModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
