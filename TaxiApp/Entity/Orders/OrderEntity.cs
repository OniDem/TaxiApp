using TaxiApp.Const;

namespace TaxiApp.Entity.Orders
{
    public class OrderEntity
    {

        public int OrderId { get; set; }

        public OrderTypeEnum OrderType { get; set; }

        public string OrderFrom { get; set; }

        public string OrderTo { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderPassengers { get; set; }

        public string OrderComment { get; set; }

        public int OrderPrice { get; set; }
    }
}
