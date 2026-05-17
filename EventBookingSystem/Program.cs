using EventBookingSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. New Blazor Web App template ki services add ho rahi hain
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. DEPENDENCY INJECTION: Aapki database service register ho rahi hai
builder.Services.AddSingleton<DatabaseService>();

var app = builder.Build();

// 3. Error handling setup
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// 4. NEW ROUTING: Yeh line error khatam karegi aur App.razor ko target karegi
app.MapRazorComponents<EventBookingSystem.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();