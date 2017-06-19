using FlixOne.BookStore.Models;
using System;

namespace FlixOne.BookStore.Common
{
    public interface IOrder
    {
        OrderModel GetBy(Guid orderId);
    }
}
