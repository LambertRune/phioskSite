using Microsoft.EntityFrameworkCore;
using PhioskSite.Domains.DataDB;
using PhioskSite.Domains.EntitiesDB;
using PhioskSite.Repositories;
using PhioskSite.Repositories.Interfaces;
using PhioskSite.Services;
using PhioskSite.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<PhioskDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<IDBService<Phone>, PhoneDBService>();
builder.Services.AddTransient<IDBDAO<Phone>, PhoneDBDAO>();

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

app.Run();
