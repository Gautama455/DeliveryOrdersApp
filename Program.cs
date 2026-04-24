using Microsoft.EntityFrameworkCore;
using DeliveryOrdersApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OrderDbContex>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString"))
);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Map("/", () => Results.Redirect("/Order/CreateOrder"));

app.UseAuthorization();
app.MapStaticAssets();

app.Run();
