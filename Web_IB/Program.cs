using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Web_IB.Data;
using Web_IB.Repository;
using Web_IB.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
    });

builder.Services.AddAuthorization();

builder.Services.AddScoped<AuthService>();

builder.Services.AddDbContext<MyDbContextPortfolio>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<PersonneRepos>();
builder.Services.AddScoped<ProfilService>();
builder.Services.AddScoped<CompetenceRepos>();
builder.Services.AddScoped<ProjetRepos>();
builder.Services.AddScoped<ExperienceRepos>();
builder.Services.AddScoped<PortfolioService>();
builder.Services.AddScoped<ExploreService>();
builder.Services.AddScoped<MessageRepos>();
builder.Services.AddScoped<MessageService>();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
