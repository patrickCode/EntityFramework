namespace MartetPlace.Obj
{
    public class Shipper
    {
        public int ShipperId { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
