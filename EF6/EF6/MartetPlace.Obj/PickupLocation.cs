using System.ComponentModel.DataAnnotations;

namespace MartetPlace.Obj
{
    public class PickupLocation
    {
        public int PickupLocationId { get; set; }
        public string Name { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}