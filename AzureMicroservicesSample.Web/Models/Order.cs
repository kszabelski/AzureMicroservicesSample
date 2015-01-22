using System;
using System.Collections.Generic;
using AzureMicroservicesSample.Web.Controllers;

namespace AzureMicroservicesSample.Web.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal TotalPriceIncludingDiscout { get; set; }
        public bool IsConfirmed { get; set; }
        public int BeerAmount { get; set; }
        public int WineAmount { get; set; }
        public int VodkaAmout { get; set; }
    }
}