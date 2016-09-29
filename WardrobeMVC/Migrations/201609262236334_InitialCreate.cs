namespace WardrobeMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        AccessoryID = c.Int(nullable: false, identity: true),
                        AccessoryName = c.String(),
                        AccessoryPhoto = c.String(),
                        ColorID = c.Int(nullable: false),
                        SeasonID = c.Int(nullable: false),
                        OccasionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessoryID)
                .ForeignKey("dbo.Colors", t => t.ColorID, cascadeDelete: true)
                .ForeignKey("dbo.Occasions", t => t.OccasionID, cascadeDelete: true)
                .ForeignKey("dbo.Seasons", t => t.SeasonID, cascadeDelete: true)
                .Index(t => t.ColorID)
                .Index(t => t.SeasonID)
                .Index(t => t.OccasionID);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorId = c.Int(nullable: false, identity: true),
                        ColorName = c.String(),
                    })
                .PrimaryKey(t => t.ColorId);
            
            CreateTable(
                "dbo.Tops",
                c => new
                    {
                        TopId = c.Int(nullable: false, identity: true),
                        TopName = c.String(),
                        TopPhoto = c.String(),
                        ColorId = c.Int(nullable: false),
                        SeasonId = c.Int(nullable: false),
                        OccasionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TopId)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.Occasions", t => t.OccasionId, cascadeDelete: true)
                .ForeignKey("dbo.Seasons", t => t.SeasonId, cascadeDelete: true)
                .Index(t => t.ColorId)
                .Index(t => t.SeasonId)
                .Index(t => t.OccasionId);
            
            CreateTable(
                "dbo.Occasions",
                c => new
                    {
                        OccasionId = c.Int(nullable: false, identity: true),
                        OccasionName = c.String(),
                    })
                .PrimaryKey(t => t.OccasionId);
            
            CreateTable(
                "dbo.Outfits",
                c => new
                    {
                        OutfitId = c.Int(nullable: false, identity: true),
                        Top_TopId = c.Int(),
                        Accessory_AccessoryID = c.Int(),
                        Bottom_BottomID = c.Int(),
                        Shoe_ShoeID = c.Int(),
                    })
                .PrimaryKey(t => t.OutfitId)
                .ForeignKey("dbo.Tops", t => t.Top_TopId)
                .ForeignKey("dbo.Accessories", t => t.Accessory_AccessoryID)
                .ForeignKey("dbo.Bottoms", t => t.Bottom_BottomID)
                .ForeignKey("dbo.Shoes", t => t.Shoe_ShoeID)
                .Index(t => t.Top_TopId)
                .Index(t => t.Accessory_AccessoryID)
                .Index(t => t.Bottom_BottomID)
                .Index(t => t.Shoe_ShoeID);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        SeasonId = c.Int(nullable: false, identity: true),
                        SeasonName = c.String(),
                    })
                .PrimaryKey(t => t.SeasonId);
            
            CreateTable(
                "dbo.Bottoms",
                c => new
                    {
                        BottomID = c.Int(nullable: false, identity: true),
                        BottomName = c.String(),
                        BottomPhoto = c.String(),
                        ColorID = c.Int(nullable: false),
                        SeasonID = c.Int(nullable: false),
                        OccasionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BottomID)
                .ForeignKey("dbo.Colors", t => t.ColorID, cascadeDelete: true)
                .ForeignKey("dbo.Occasions", t => t.OccasionID, cascadeDelete: true)
                .ForeignKey("dbo.Seasons", t => t.SeasonID, cascadeDelete: true)
                .Index(t => t.ColorID)
                .Index(t => t.SeasonID)
                .Index(t => t.OccasionID);
            
            CreateTable(
                "dbo.Shoes",
                c => new
                    {
                        ShoeID = c.Int(nullable: false, identity: true),
                        ShoeName = c.String(),
                        ShoePhoto = c.String(),
                        ColorID = c.Int(nullable: false),
                        SeasonID = c.Int(nullable: false),
                        OccasionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoeID)
                .ForeignKey("dbo.Colors", t => t.ColorID, cascadeDelete: true)
                .ForeignKey("dbo.Occasions", t => t.OccasionID, cascadeDelete: true)
                .ForeignKey("dbo.Seasons", t => t.SeasonID, cascadeDelete: true)
                .Index(t => t.ColorID)
                .Index(t => t.SeasonID)
                .Index(t => t.OccasionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shoes", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Outfits", "Shoe_ShoeID", "dbo.Shoes");
            DropForeignKey("dbo.Shoes", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Shoes", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Bottoms", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Outfits", "Bottom_BottomID", "dbo.Bottoms");
            DropForeignKey("dbo.Bottoms", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Bottoms", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Accessories", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Outfits", "Accessory_AccessoryID", "dbo.Accessories");
            DropForeignKey("dbo.Accessories", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Accessories", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Tops", "SeasonId", "dbo.Seasons");
            DropForeignKey("dbo.Outfits", "Top_TopId", "dbo.Tops");
            DropForeignKey("dbo.Tops", "OccasionId", "dbo.Occasions");
            DropForeignKey("dbo.Tops", "ColorId", "dbo.Colors");
            DropIndex("dbo.Shoes", new[] { "OccasionID" });
            DropIndex("dbo.Shoes", new[] { "SeasonID" });
            DropIndex("dbo.Shoes", new[] { "ColorID" });
            DropIndex("dbo.Bottoms", new[] { "OccasionID" });
            DropIndex("dbo.Bottoms", new[] { "SeasonID" });
            DropIndex("dbo.Bottoms", new[] { "ColorID" });
            DropIndex("dbo.Outfits", new[] { "Shoe_ShoeID" });
            DropIndex("dbo.Outfits", new[] { "Bottom_BottomID" });
            DropIndex("dbo.Outfits", new[] { "Accessory_AccessoryID" });
            DropIndex("dbo.Outfits", new[] { "Top_TopId" });
            DropIndex("dbo.Tops", new[] { "OccasionId" });
            DropIndex("dbo.Tops", new[] { "SeasonId" });
            DropIndex("dbo.Tops", new[] { "ColorId" });
            DropIndex("dbo.Accessories", new[] { "OccasionID" });
            DropIndex("dbo.Accessories", new[] { "SeasonID" });
            DropIndex("dbo.Accessories", new[] { "ColorID" });
            DropTable("dbo.Shoes");
            DropTable("dbo.Bottoms");
            DropTable("dbo.Seasons");
            DropTable("dbo.Outfits");
            DropTable("dbo.Occasions");
            DropTable("dbo.Tops");
            DropTable("dbo.Colors");
            DropTable("dbo.Accessories");
        }
    }
}
