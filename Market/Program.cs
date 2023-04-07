using Market;
using Market.Services;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MarketDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddIdentityCore<MarketDbContext>(op => op.SignIn.RequireConfirmedAccount = true);
builder.Services.AddScoped<IProductSaleService, ProductSaleService>();
builder.Services.AddScoped<IWareHouseService, WareHouseService>();
builder.Services.AddScoped<ISaleService, SaleService>();

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

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


