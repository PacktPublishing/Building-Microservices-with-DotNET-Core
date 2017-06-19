using FlixOne.BookStore.Models;
using System;

namespace FlixOne.BookStore.Common
{
    public class Order : IOrder
    {
        private readonly IOrderRepository _orderRepository;
        public Order(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public OrderModel GetBy(Guid orderId)
        {
            return _orderRepository.Get(orderId);
        }
    }
}