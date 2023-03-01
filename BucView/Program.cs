using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BucView.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();


string? connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<BucViewContext>(options => options.UseSqlite(connection));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddUserManager<UserManager<IdentityUser>>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BucViewContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Scope repo!!
builder.Services.AddScoped<ITourRepository, TourRepository>();

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

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
