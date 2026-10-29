using Hospital_full_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.mvc wala part
builder.Services.AddControllersWithViews();

// DAtabse wala part
builder.Services.AddDbContext<HospitalDbContext>(Options =>

    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder after registering services
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
