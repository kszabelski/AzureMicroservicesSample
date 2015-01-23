using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AzureMicroservicesSample.OrderService.Entities;

namespace AzureMicroservicesSample.OrderService.Controllers
{
    public class ConfirmController : ApiController
    {
        // POST api/<controller>
        public void Post([FromBody]Guid orderId)
        {
            using (var context = new OrdersContext())
            {
                var order = context.Orders.SingleOrDefault(o => o.Id == orderId);
                if (order == null)
                    throw new HttpException(404, "Order not found");

                order.IsConfirmed = true;
                context.SaveChanges();
            }

            // TODO: queue message to invoice service
        }
    }
}