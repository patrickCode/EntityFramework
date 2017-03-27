namespace MarketPlace.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Line1 = c.String(),
                        Line2 = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        BuyerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BuyerId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        ShipperId = c.Int(nullable: false),
                        Buyer_BuyerId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Shippers", t => t.ShipperId, cascadeDelete: true)
                .ForeignKey("dbo.Buyers", t => t.Buyer_BuyerId)
                .Index(t => t.ShipperId)
                .Index(t => t.Buyer_BuyerId);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ShipperId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipperId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.PickupLocations",
                c => new
                    {
                        PickupLocationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address_AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.PickupLocationId)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId)
                .Index(t => t.Address_AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PickupLocations", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "Buyer_BuyerId", "dbo.Buyers");
            DropForeignKey("dbo.Orders", "ShipperId", "dbo.Shippers");
            DropForeignKey("dbo.Shippers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.PickupLocations", new[] { "Address_AddressId" });
            DropIndex("dbo.Shippers", new[] { "AddressId" });
            DropIndex("dbo.Orders", new[] { "Buyer_BuyerId" });
            DropIndex("dbo.Orders", new[] { "ShipperId" });
            DropTable("dbo.PickupLocations");
            DropTable("dbo.Shippers");
            DropTable("dbo.Orders");
            DropTable("dbo.Buyers");
            DropTable("dbo.Addresses");
        }
    }
}
