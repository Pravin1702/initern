using EShoppingMVCApp.Models;
using EShoppingMVCApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepo<string, User>, UserRepo>();
builder.Services.AddScoped<IRepoCart<Cart>, CartRepo>();
builder.Services.AddScoped<IReopProducts<int, Products>, ProductsRepo>();

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
