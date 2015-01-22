using System;
using System.Web.Mvc;
using AzureMicroservicesSample.Web.Models;
using AzureMicroservicesSample.Web.Services;

namespace AzureMicroservicesSample.Web.Controllers
{
    public class OrdersController : Controller
    {
        private OrderRepository _orderRepository;
        private OrderService _orderService;

        public ActionResult NewOrder()
        {
            var viewModel = new Order();
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult NewOrder(Order viewModel)
        {
            _orderService.CreateNewOrder(viewModel);

            TempData["Message"] = "Your order have been saved";
            return RedirectToAction("ConfirmMessage", "Home");
        }

        public ActionResult Index(Guid id)
        {
            var order = _orderRepository.GetOrder(id);

            return View(order);
        }

        [HttpPost]
        public ActionResult ConfirmOrder(Guid orderId)
        {
            _orderService.ConfirmOrder(orderId);

            TempData["Message"] = "Your order have been confirmed";
            return RedirectToAction("ConfirmMessage", "Home");
        }
    }
}