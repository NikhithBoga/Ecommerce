using Ecommerce.Exceptions;
using Ecommerce.Models;
using Ecommerce.Repository;

namespace Ecommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public int AddOrder(Order order)
        {
            if (_orderRepository.GetOrder(order.OrderId) != null)
            {
                throw new OrderAlreadyExistsException($"Order with Order Id {order.OrderId} already exists");

            }
            return _orderRepository.AddOrder(order);
        }

        public int DeleteOrder(int orderId)
        {
            if (_orderRepository.GetOrder(orderId) == null)
            {
                throw new OrderNotFoundException($"Order with Order Id{orderId} does not exists");

            }
            return _orderRepository.DeleteOrder(orderId);
        }

        public Order GetOrder(int orderId)
        {
            Order O = _orderRepository.GetOrder(orderId);
            if (O == null)
            {
                throw new OrderNotFoundException($"Order with Order Id {orderId} does not exists");
            }
            return O;
        }

        public List<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }

        public int UpdateOrder(int orderId, Order order)
        {
            if (_orderRepository.GetOrder(orderId) == null)
            {
                throw new OrderNotFoundException($"Order with Order Id {orderId} does not exists");
            }
            return _orderRepository.UpdateOrder(orderId, order);
        }


    }
}
