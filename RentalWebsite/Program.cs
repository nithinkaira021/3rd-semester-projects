using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using mvc_surfboard.Data;
using mvc_surfboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<mvc_surfboardContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("mvc_surfboardContext") ?? throw new InvalidOperationException("Connection string 'mvc_surfboardContext' not found.")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() // Add support for roles
    .AddEntityFrameworkStores<mvc_surfboardContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<WebApiService>();
builder.Services.AddScoped<WebApiService>();

var app = builder.Build();

var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
            };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // create roles
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

    if (!roleManager.RoleExistsAsync("Admin").Result)
    {
        roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
    }

    if (!roleManager.RoleExistsAsync("User").Result)
    {
        roleManager.CreateAsync(new IdentityRole("User")).Wait();
    }

    if (!roleManager.RoleExistsAsync("Guest").Result)
    {
        roleManager.CreateAsync(new IdentityRole("Guest")).Wait();
    }

    SeedData.Initialize(services); 
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


app.Run();
