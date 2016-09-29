namespace WardrobeMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedConstraint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Outfits", "AccessoryID", "dbo.Accessories");
            DropIndex("dbo.Outfits", new[] { "AccessoryID" });
            CreateTable(
                "dbo.OutfitAccessories",
                c => new
                    {
                        Outfit_OutfitId = c.Int(nullable: false),
                        Accessory_AccessoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Outfit_OutfitId, t.Accessory_AccessoryID })
                .ForeignKey("dbo.Outfits", t => t.Outfit_OutfitId, cascadeDelete: true)
                .ForeignKey("dbo.Accessories", t => t.Accessory_AccessoryID, cascadeDelete: true)
                .Index(t => t.Outfit_OutfitId)
                .Index(t => t.Accessory_AccessoryID);
            
            DropColumn("dbo.Outfits", "AccessoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Outfits", "AccessoryID", c => c.Int(nullable: false));
            DropForeignKey("dbo.OutfitAccessories", "Accessory_AccessoryID", "dbo.Accessories");
            DropForeignKey("dbo.OutfitAccessories", "Outfit_OutfitId", "dbo.Outfits");
            DropIndex("dbo.OutfitAccessories", new[] { "Accessory_AccessoryID" });
            DropIndex("dbo.OutfitAccessories", new[] { "Outfit_OutfitId" });
            DropTable("dbo.OutfitAccessories");
            CreateIndex("dbo.Outfits", "AccessoryID");
            AddForeignKey("dbo.Outfits", "AccessoryID", "dbo.Accessories", "AccessoryID");
        }
    }
}
