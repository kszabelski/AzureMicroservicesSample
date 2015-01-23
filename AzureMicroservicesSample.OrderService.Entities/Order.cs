using System;

namespace AzureMicroservicesSample.OrderService.Entities
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