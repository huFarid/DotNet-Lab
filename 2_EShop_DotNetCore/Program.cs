using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shop_DotNetCore.Data;
using Shop_DotNetCore.Data.Repositories;
using System.Drawing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); 
#region
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
//builder.Services.AddSingleton<IGroupRepository, GroupRepository>();
//builder.Services.AddTransient<IGroupRepository, GroupRepository>();

#endregion

builder.Services.AddDbContext<MyEshopContext>(options =>
{ options.UseSqlServer("Data Source=.; Initial Catalog = EshopCore_Db; Integrated Security = true;TrustServerCertificate=true;"); });





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
