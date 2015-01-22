using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AzureMicroservicesSample.Web.Models;
using AzureMicroservicesSample.Web.Services;

namespace AzureMicroservicesSample.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrderRepository _orderRepository;

        public HomeController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public ActionResult Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                Orders = _orderRepository.GetAll()
            };

            return View(viewModel);
        }

        public ActionResult ConfirmMessage()
        {
            return View();
        }
    }
}