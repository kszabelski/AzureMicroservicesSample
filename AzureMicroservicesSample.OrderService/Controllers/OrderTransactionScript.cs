using AzureMicroservicesSample.OrderService.Entities;

namespace AzureMicroservicesSample.OrderService.Controllers
{
    public class OrderTransactionScript
    {
        public static void UpdateTotal(Order order)
        {
            decimal vodkaTotal = order.VodkaAmout*20.0M;
            decimal beerTotal = order.BeerAmount*3.0M;
            decimal wineTotal = order.WineAmount*15.0M;

            decimal beerDiscount = 0;
            if (vodkaTotal > 100)
                beerDiscount = 0.2M;

            order.TotalPriceIncludingDiscout = vodkaTotal + wineTotal + beerTotal*(1 - beerDiscount);
        }
    }
}