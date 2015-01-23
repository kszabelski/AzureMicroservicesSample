using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using AzureMicroservicesSample.OrderService.Entities;
using Newtonsoft.Json;

namespace AzureMicroservicesSample.Web.Services
{
    public class OrderServiceGateway
    {
        public void ConfirmOrder(Guid orderId)
        {
            PostJson("confirm", orderId);
        }

        public void CreateNewOrder(Order order)
        {
            PostJson("create", order);
        }

        private static void PostJson(string requestUri, object obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63477/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.PostAsync(requestUri, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")).Wait();
            }
        }
    }
}