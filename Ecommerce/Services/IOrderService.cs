using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface IOrderService
    {
        //IEnumerable<Order> GetOrders();
        int AddOrder(Order order);
        int DeleteOrder(int orderId);
        Order GetOrder(int orderId);
        List<Order> GetOrders();
        int UpdateOrder(int orderId, Order order);

    }
}
