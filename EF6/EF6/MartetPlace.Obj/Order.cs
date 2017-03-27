using MartetPlace.Obj.Enums;
using System.ComponentModel.DataAnnotations;

namespace MartetPlace.Obj
{
    public class Order
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
        [Required]
        public Shipper Shipper { get; set; }
        [Required]
        public Buyer Buyer { get; set; }
    }
}