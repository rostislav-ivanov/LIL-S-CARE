using LilsCareApp.Infrastructure.Data.DataConfiguration;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAppDbContext(builder.Configuration);
builder.Services.AddAppIdentity();
builder.Services.AddAppLocalization();
builder.Services.AddAppAuthentication(builder.Configuration);


builder.Services.AddControllersWithViews();
builder.Services.AddAppServices();

var app = builder.Build();

app.SeedAdmin();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseRequestLocalization(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("bg-BG")
    };
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});


// Enable session middleware
app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints?.MapControllerRoute(
        name: "Areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints?.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints?.MapDefaultControllerRoute();
    endpoints?.MapRazorPages();
});


await app.RunAsync();
