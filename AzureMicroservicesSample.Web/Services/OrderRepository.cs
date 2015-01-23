using System;
using System.Collections.Generic;
using System.Linq;
using AzureMicroservicesSample.OrderService.Entities;

namespace AzureMicroservicesSample.Web.Services
{
    public class OrderRepository
    {
        public Order GetOrder(Guid id)
        {
            using (var context = new OrdersContext())
            {
                return context.Orders.Single(o => o.Id == id);
            }
        }

        public IList<Order> GetAll()
        {
            using (var context = new OrdersContext())
            {
                return context.Orders.ToList();
            }
        }
    }
}