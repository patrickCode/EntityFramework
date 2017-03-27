using MartetPlace.Obj.Enums;

namespace MartetPlace.Obj
{
    public class Order
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; }
    }
}