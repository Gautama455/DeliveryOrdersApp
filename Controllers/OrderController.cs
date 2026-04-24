using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeliveryOrdersApp.Models;
using DeliveryOrdersApp.Data;

[Route("[controller]/[action]")]
public class OrderController : Controller
{
    private OrderDbContex _dbContext;

    public OrderController(OrderDbContex db) => _dbContext = db;

    [HttpGet]
    public IActionResult CreateOrder()
    {
        return View(new CreateOrderViewModel
        {
            PickupDate = DateTime.UtcNow.Date
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderViewModel ovm)
    {
        if(!ModelState.IsValid) return View(ovm);

        _dbContext.Orders.Add(new Order(ovm, await GenerateOrderNumber()));
        await _dbContext.SaveChangesAsync();
        
        return RedirectToAction("OrderList");
    }

    [HttpGet]
    public IActionResult OrdersList() =>
        View("OrdersList",_dbContext.Orders.OrderByDescending(o => o.CreatAt).ToList());

    [HttpGet("{orderNumber}")]
    public async Task<IActionResult> Details(decimal orderNumber) =>
        View(await _dbContext.Orders.FirstOrDefaultAsync(order => order.OrderNumber == orderNumber));


    private async Task<decimal> GenerateOrderNumber()
    {
        var now = DateTime.UtcNow;
        var prefix = int.Parse(now.ToString("yy")) * 1000 + now.DayOfYear;
        var startOfDay = now.Date;
        var endOfDay = startOfDay.AddDays(1);

        var todayCount = await _dbContext.Orders.CountAsync(x =>
            x.CreatAt >= startOfDay && x.CreatAt < endOfDay);

        return (decimal)(prefix * 10e4 + todayCount + 1);
    } 
}