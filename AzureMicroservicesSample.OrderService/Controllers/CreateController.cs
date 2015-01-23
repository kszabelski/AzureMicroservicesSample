using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AzureMicroservicesSample.OrderService.Entities;

namespace AzureMicroservicesSample.OrderService.Controllers
{
    public class CreateController : ApiController
    {
        // POST api/<controller>
        public void Post([FromBody]Order order)
        {
            // calculate price 
            // save to db
        }
    }
}