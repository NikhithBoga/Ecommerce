using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface IOrderItemService
    {
        int AddOrderItem(OrderItem orderItem);
        int DeleteOrderItem(int orderItemId);
        OrderItem GetOrderItem(int orderItemId);
        List<OrderItem> GetOrderItems();
        int UpdateOrderItem(int orderItemId, OrderItem orderItem);
    }
}
