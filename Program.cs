using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using VjencanjeIzSnova_WebApp.Autorizacija_Policies;
using VjencanjeIzSnova_WebApp.Data;
using VjencanjeIzSnova_WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LocalDb") ?? throw new InvalidOperationException("Connection string 'LocalDb' not found.");
builder.Services.AddDbContext<VjencanjeIzSnovaDbContext>(options =>
    options.UseSqlite(connectionString));

//builder.Services.AddDefaultIdentity<Korisnik>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<VjencanjeIzSnovaDbContext>();
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();


//konfiguracija za autentifikaciju kori�tenjem ASP.NET Core Identity API-a
builder.Services.AddIdentity<Korisnik, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<VjencanjeIzSnovaDbContext>()
.AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });
builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Partner", policy =>
        policy.Requirements.Add(new UserTypeRequirement("Partner")));
});

// Register the authorization handler
builder.Services.AddSingleton<IAuthorizationHandler, UserTypeHandler>();

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
