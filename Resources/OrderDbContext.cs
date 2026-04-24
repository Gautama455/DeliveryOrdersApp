using Microsoft.EntityFrameworkCore;

namespace DeliveryOrdersApp.Data
{
    public class OrderDbContex : DbContext
    {
        public OrderDbContex(DbContextOptions<OrderDbContex> options) : base(options) {}

        public DbSet<Models.Order> Orders => Set<Models.Order>();
    }
}