using Microsoft.EntityFrameworkCore;
using BPMeasurementApp.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string? connStr = builder.Configuration.GetConnectionString("MeasurementDbContext");

// For MS SQL Server:
builder.Services.AddDbContext<MeasurementDbContext>(options => options.UseSqlServer(connStr));

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
    pattern: "{controller=Measurements}/{action=Index}/{id?}");

app.Run();
