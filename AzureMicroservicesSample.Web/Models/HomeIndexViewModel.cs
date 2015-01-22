using System.Collections.Generic;

namespace AzureMicroservicesSample.Web.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}