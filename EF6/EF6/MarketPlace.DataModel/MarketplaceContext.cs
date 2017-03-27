using MartetPlace.Obj;
using System.Data.Entity;

namespace MarketPlace.DataModel
{
    public class MarketplaceContext: DbContext
    {
        //DbSet refers to a repository
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PickupLocation> PickupLocations { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}