using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TruckHubSystem.Core.Contracts.Factory;
using TruckHubSystem.Core.Services.Factory;
using TruckHubSystem.Infrastructure.Data;
using TruckHubSystem.Infrastructure.Data.Common;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TruckHubDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IFactoryService, FactoryService>();

builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<TruckHubDbContext>();
builder.Services.AddControllersWithViews();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
