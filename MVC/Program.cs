using Business.Services;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region IoC Container
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Db>(options => options.UseSqlServer(connectionString));


builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
#endregion


//builder.Services.AddDbContext(option => option.UseSqlServer)


// add-migration v1
// update-database

builder.Services.AddControllersWithViews();

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
