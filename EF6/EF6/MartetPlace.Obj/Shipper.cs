using System.ComponentModel.DataAnnotations;

namespace MartetPlace.Obj
{
    public class Shipper
    {
        public int ShipperId { get; set; }
        public string Name { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}
