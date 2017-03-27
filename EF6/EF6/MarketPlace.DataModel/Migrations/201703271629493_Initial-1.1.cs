namespace MarketPlace.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Buyer_BuyerId", "dbo.Buyers");
            DropForeignKey("dbo.PickupLocations", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.Orders", new[] { "Buyer_BuyerId" });
            DropIndex("dbo.PickupLocations", new[] { "Address_AddressId" });
            RenameColumn(table: "dbo.Orders", name: "ShipperId", newName: "Shipper_ShipperId");
            RenameColumn(table: "dbo.Shippers", name: "AddressId", newName: "Address_AddressId");
            RenameIndex(table: "dbo.Orders", name: "IX_ShipperId", newName: "IX_Shipper_ShipperId");
            RenameIndex(table: "dbo.Shippers", name: "IX_AddressId", newName: "IX_Address_AddressId");
            AlterColumn("dbo.Orders", "Buyer_BuyerId", c => c.Int(nullable: false));
            AlterColumn("dbo.PickupLocations", "Address_AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Buyer_BuyerId");
            CreateIndex("dbo.PickupLocations", "Address_AddressId");
            AddForeignKey("dbo.Orders", "Buyer_BuyerId", "dbo.Buyers", "BuyerId", cascadeDelete: true);
            AddForeignKey("dbo.PickupLocations", "Address_AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PickupLocations", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "Buyer_BuyerId", "dbo.Buyers");
            DropIndex("dbo.PickupLocations", new[] { "Address_AddressId" });
            DropIndex("dbo.Orders", new[] { "Buyer_BuyerId" });
            AlterColumn("dbo.PickupLocations", "Address_AddressId", c => c.Int());
            AlterColumn("dbo.Orders", "Buyer_BuyerId", c => c.Int());
            RenameIndex(table: "dbo.Shippers", name: "IX_Address_AddressId", newName: "IX_AddressId");
            RenameIndex(table: "dbo.Orders", name: "IX_Shipper_ShipperId", newName: "IX_ShipperId");
            RenameColumn(table: "dbo.Shippers", name: "Address_AddressId", newName: "AddressId");
            RenameColumn(table: "dbo.Orders", name: "Shipper_ShipperId", newName: "ShipperId");
            CreateIndex("dbo.PickupLocations", "Address_AddressId");
            CreateIndex("dbo.Orders", "Buyer_BuyerId");
            AddForeignKey("dbo.PickupLocations", "Address_AddressId", "dbo.Addresses", "AddressId");
            AddForeignKey("dbo.Orders", "Buyer_BuyerId", "dbo.Buyers", "BuyerId");
        }
    }
}
