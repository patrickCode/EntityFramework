namespace Marketplace.CodeFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MarketplaceCode : DbContext
    {
        public MarketplaceCode()
            : base("name=MarketplaceCode")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Availability> Availabilities { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemProduct> ItemProducts { get; set; }
        public virtual DbSet<ItemProductGroup> ItemProductGroups { get; set; }
        public virtual DbSet<ItemProductPrice> ItemProductPrices { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLineItem> OrderLineItems { get; set; }
        public virtual DbSet<PickupLocation> PickupLocations { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.CityId)
                .IsFixedLength();

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Buyers)
                .WithRequired(e => e.Address)
                .HasForeignKey(e => e.AddressId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Buyers1)
                .WithRequired(e => e.Address1)
                .HasForeignKey(e => e.BillingAddressId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Availability>()
                .HasMany(e => e.ItemProducts)
                .WithRequired(e => e.Availability)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Buyer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Buyer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemProduct>()
                .HasMany(e => e.LineItems)
                .WithRequired(e => e.ItemProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemProductPrice>()
                .Property(e => e.FOB_Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ItemProductPrice>()
                .Property(e => e.DeliveryPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ItemProductPrice>()
                .Property(e => e.Surcharge)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LineItem>()
                .Property(e => e.LineTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LineItem>()
                .HasMany(e => e.OrderLineItems)
                .WithRequired(e => e.LineItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ItemSubtotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderLineItems)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PickupLocation>()
                .HasMany(e => e.ItemProducts)
                .WithRequired(e => e.PickupLocation)
                .HasForeignKey(e => e.ShipperId)
                .WillCascadeOnDelete(false);
        }
    }
}
