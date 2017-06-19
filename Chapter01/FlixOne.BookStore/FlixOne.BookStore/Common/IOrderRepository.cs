using System;
using FlixOne.BookStore.Models;

namespace FlixOne.BookStore.Common
{
    public interface IOrderRepository
    {
        OrderModel Get(Guid orderId);
    }
}