using FlixOne.BookStore.Common;
using System;
using System.Web.Mvc;

namespace FlixOne.BookStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _order;
        public OrderController(IOrder order)
        {
            _order = order;
        }
        // GET: Order
        public ActionResult Index()
        {

            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(string id)
        {
            var orderId = Guid.Parse(id);
            var orderModel = _order.GetBy(orderId);
            return View(orderModel);
        }

    }
}
