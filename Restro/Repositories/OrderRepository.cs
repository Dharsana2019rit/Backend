using System.Collections.Generic;
using System.Threading.Tasks;
using Restro.Data;
using Microsoft.EntityFrameworkCore;
using Restro.Models;
using Restro.Repositories;

namespace Restro.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestroDbContext _context;

        public OrderRepository(RestroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
