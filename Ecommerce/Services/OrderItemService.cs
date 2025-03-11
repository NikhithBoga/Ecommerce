using Ecommerce.Exceptions;
using Ecommerce.Models;
using Ecommerce.Repository;

namespace Ecommerce.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly string _connectionString;

        public OrderItemService(IOrderItemRepository orderItemRepository, IConfiguration configuration)
        {
            _orderItemRepository = orderItemRepository;
            _connectionString = configuration.GetConnectionString("SqlConnection");
        }

        public int AddOrderItem(OrderItem orderItem)
        {
            if (_orderItemRepository.GetOrderItem(orderItem.OrderItemId) != null)
            {
                throw new OrderItemAlreadyExistsException($"Order with Order Id {orderItem.OrderItemId} already exists");
            }

            int result = _orderItemRepository.AddOrderItem(orderItem);
            return result;
        }

        public int DeleteOrderItem(int orderItemId)
        {
            OrderItem orderItem = _orderItemRepository.GetOrderItem(orderItemId);
            if (orderItem == null)
            {
                throw new OrderItemNotFoundException($"Order with Order Id {orderItemId} does not exist");
            }

            int result = _orderItemRepository.DeleteOrderItem(orderItemId);
            return result;
        }

        public OrderItem GetOrderItem(int orderItemId)
        {
            OrderItem Oi = _orderItemRepository.GetOrderItem(orderItemId);
            if (Oi == null)
            {
                throw new OrderNotFoundException($"Order with Order Id {orderItemId} does not exist");
            }
            return Oi;
        }

        public List<OrderItem> GetOrderItems()
        {
            return _orderItemRepository.GetOrderItems();
        }

        public int UpdateOrderItem(int orderItemId, OrderItem orderItem)
        {
            if (_orderItemRepository.GetOrderItem(orderItemId) == null)
            {
                throw new OrderItemNotFoundException($"Order with Order Id {orderItemId} does not exist");
            }

            int result = _orderItemRepository.UpdateOrderItem(orderItemId, orderItem);
            return result;
        }



    }
}
