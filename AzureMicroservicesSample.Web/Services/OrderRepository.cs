using System;
using System.Collections;
using System.Collections.Generic;
using AzureMicroservicesSample.Web.Models;

namespace AzureMicroservicesSample.Web.Services
{
    public class OrderRepository
    {
        public Order GetOrder(Guid id)
        {
            return new Order
            {
                Id = id,
                BeerAmount = 1,
                VodkaAmout = 2,
                WineAmount = 5,
                TotalPriceIncludingDiscout = 999.99M
            };
        }

        public IList<Order> GetAll()
        {
            return new List<Order> {new Order {Id = Guid.NewGuid()}, new Order {Id = Guid.NewGuid()}};
        }
    }
}