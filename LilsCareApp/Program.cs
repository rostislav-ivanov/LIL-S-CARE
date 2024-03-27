using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var supportedCultures = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("bg-BG")
};

builder.Services.AddAppDbContext(builder.Configuration);
builder.Services.AddAppIdentity();
builder.Services.AddAppLocalization();

builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();


builder.Services.AddControllersWithViews();
builder.Services.AddAppServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseRequestLocalization(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

// Enable session middleware
app.UseSession();

app.MapDefaultControllerRoute();
app.MapRazorPages();

await app.RunAsync();
