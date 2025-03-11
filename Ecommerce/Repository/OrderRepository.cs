using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;
        private readonly string _connectionString;

        public OrderRepository(OrderContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("SqlConnection");
        }

        public int AddOrder(Order order)
        {
            _context.Orders_.Add(order);
            int result = _context.SaveChanges();
            return result;
        }

        public int DeleteOrder(int orderId)
        {
            Order O = _context.Orders_.Where(x => x.OrderId == orderId).FirstOrDefault();
            _context.Orders_.Remove(O);
            return _context.SaveChanges();
        }

        public Order GetOrder(int orderId)
        {
            return _context.Orders_.Where(x => x.OrderId == orderId).FirstOrDefault();
        }

        public List<Order> GetOrders()
        {
            return _context.Orders_.ToList();
        }

        public int UpdateOrder(int orderId, Order order)
        {
            Order O = _context.Orders_.Where(x => x.OrderId == orderId).FirstOrDefault();
            if (O != null)
            {
                O.ShippingAddress = order.ShippingAddress;
                O.OrderDate = order.OrderDate;
                O.UserId = order.UserId;
                O.OrderStatus = order.OrderStatus;
                _context.Entry<Order>(O).State = EntityState.Modified;
                int result = _context.SaveChanges();
                return result;
            }
            return 0;
        }

    }
}
