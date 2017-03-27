using System.Collections.Generic;

namespace MartetPlace.Obj
{
    public class Buyer
    {
        public int BuyerId { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}