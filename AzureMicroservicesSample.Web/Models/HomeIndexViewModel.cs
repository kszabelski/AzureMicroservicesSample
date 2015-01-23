using System.Collections.Generic;
using AzureMicroservicesSample.OrderService.Entities;

namespace AzureMicroservicesSample.Web.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}