using Ecommerce.Models;

namespace Ecommerce.Repository
{
    public interface IOrderItemRepository
    {
        int AddOrderItem(OrderItem orderItem);
        int DeleteOrderItem(int orderItemId);
        OrderItem GetOrderItem(int orderItemId);
        List<OrderItem> GetOrderItems();

        int UpdateOrderItem(int orderItemId, OrderItem orderItem);

    }
}
