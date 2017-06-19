using System;
using FlixOne.BookStore.Models;

namespace FlixOne.BookStore.Common
{
    public class OrderRepository : IOrderRepository
    {

        public OrderModel Get(Guid orderId)
        {
            //call data method here
            return new OrderModel
            {
                OrderId = Guid.NewGuid(),
                OrderDate = DateTime.Now,
                OrderStatus = "In Transit"
            };
        }
    }
}