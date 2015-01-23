using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AzureMicroservicesSample.OrderService.Controllers
{
    public class ConfirmController : ApiController
    {
        // POST api/<controller>
        public void Post([FromBody]Guid orderId)
        {
            // save to db as confirmed
            // queue message to invoice service
        }
    }
}