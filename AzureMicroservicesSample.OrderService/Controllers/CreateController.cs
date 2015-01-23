using System;
using System.Web.Http;
using AzureMicroservicesSample.OrderService.Entities;

namespace AzureMicroservicesSample.OrderService.Controllers
{
    public class CreateController : ApiController
    {
        // POST api/<controller>
        public void Post([FromBody]Order order)
        {
            OrderTransactionScript.UpdateTotal(order);

            order.Id = Guid.NewGuid();
            order.IsConfirmed = false;
            
            using (var context = new OrdersContext())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
    }
}