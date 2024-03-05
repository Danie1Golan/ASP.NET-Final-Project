using FactoryManagement.data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string db = builder.Configuration["ConnectionStrings:DBConnection"]!;
builder.Services.AddDbContext<FactoryManagementDBContext>
    (options => options.UseLazyLoadingProxies().UseSqlServer(db));



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<FactoryManagementDBContext>();
    ctx.Database.EnsureCreated();
    ctx.Database.EnsureDeleted();
}    


app.UseStaticFiles();

app.UseRouting();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LogIn}/{action=Index}/{id?}");

app.Run();
