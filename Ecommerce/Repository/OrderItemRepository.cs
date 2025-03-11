using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly OrderContext _context;

        public OrderItemRepository(OrderContext context)
        {
            _context = context;
        }

        public int AddOrderItem(OrderItem orderItem)
        {
            _context.OrderItems_.Add(orderItem);
            return _context.SaveChanges();
        }

        public int DeleteOrderItem(int orderItemId)
        {
            OrderItem Oi = _context.OrderItems_.Where(x => x.OrderItemId == orderItemId).FirstOrDefault();
            _context.OrderItems_.Remove(Oi);
            return _context.SaveChanges();
        }

        public OrderItem GetOrderItem(int orderItemId)
        {
            return _context.OrderItems_.Where(x => x.OrderItemId == orderItemId).FirstOrDefault();
        }

        public List<OrderItem> GetOrderItems()
        {
            return _context.OrderItems_.ToList();
        }

        public int UpdateOrderItem(int orderItemId, OrderItem orderItem)
        {
            OrderItem Oi = _context.OrderItems_.Where(x => x.OrderItemId == orderItemId).FirstOrDefault();
            if (Oi != null)
            {
                Oi.ProductId = orderItem.ProductId;
                Oi.Quantity = orderItem.Quantity;
                Oi.TotalPrice = orderItem.TotalPrice;
                _context.Entry<OrderItem>(Oi).State = EntityState.Modified;
                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
