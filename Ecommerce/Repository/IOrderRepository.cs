using Ecommerce.Models;

namespace Ecommerce.Repository
{
    public interface IOrderRepository
    {
        int AddOrder(Order order);
        int DeleteOrder(int orderId);
        Order GetOrder(int orderId);
        List<Order> GetOrders();
        int UpdateOrder(int orderId, Order order);


    }
}
