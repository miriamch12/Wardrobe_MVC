namespace WardrobeMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accessories", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Accessories", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Accessories", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Tops", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Tops", "OccasionId", "dbo.Occasions");
            DropForeignKey("dbo.Tops", "SeasonId", "dbo.Seasons");
            DropForeignKey("dbo.Bottoms", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Bottoms", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Bottoms", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Shoes", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Shoes", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Shoes", "SeasonID", "dbo.Seasons");
            DropIndex("dbo.Outfits", new[] { "Top_TopId" });
            DropIndex("dbo.Outfits", new[] { "Accessory_AccessoryID" });
            DropIndex("dbo.Outfits", new[] { "Bottom_BottomID" });
            DropIndex("dbo.Outfits", new[] { "Shoe_ShoeID" });
            RenameColumn(table: "dbo.Outfits", name: "Accessory_AccessoryID", newName: "AccessoryID");
            RenameColumn(table: "dbo.Outfits", name: "Top_TopId", newName: "TopID");
            RenameColumn(table: "dbo.Outfits", name: "Bottom_BottomID", newName: "BottomID");
            RenameColumn(table: "dbo.Outfits", name: "Shoe_ShoeID", newName: "ShoeID");
            AlterColumn("dbo.Outfits", "TopID", c => c.Int(nullable: false));
            AlterColumn("dbo.Outfits", "AccessoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Outfits", "BottomID", c => c.Int(nullable: false));
            AlterColumn("dbo.Outfits", "ShoeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Outfits", "BottomID");
            CreateIndex("dbo.Outfits", "ShoeID");
            CreateIndex("dbo.Outfits", "TopID");
            CreateIndex("dbo.Outfits", "AccessoryID");
            AddForeignKey("dbo.Accessories", "ColorID", "dbo.Colors", "ColorId");
            AddForeignKey("dbo.Accessories", "OccasionID", "dbo.Occasions", "OccasionId");
            AddForeignKey("dbo.Accessories", "SeasonID", "dbo.Seasons", "SeasonId");
            AddForeignKey("dbo.Tops", "ColorId", "dbo.Colors", "ColorId");
            AddForeignKey("dbo.Tops", "OccasionId", "dbo.Occasions", "OccasionId");
            AddForeignKey("dbo.Tops", "SeasonId", "dbo.Seasons", "SeasonId");
            AddForeignKey("dbo.Bottoms", "ColorID", "dbo.Colors", "ColorId");
            AddForeignKey("dbo.Bottoms", "OccasionID", "dbo.Occasions", "OccasionId");
            AddForeignKey("dbo.Bottoms", "SeasonID", "dbo.Seasons", "SeasonId");
            AddForeignKey("dbo.Shoes", "ColorID", "dbo.Colors", "ColorId");
            AddForeignKey("dbo.Shoes", "OccasionID", "dbo.Occasions", "OccasionId");
            AddForeignKey("dbo.Shoes", "SeasonID", "dbo.Seasons", "SeasonId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shoes", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Shoes", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Shoes", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Bottoms", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Bottoms", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Bottoms", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Tops", "SeasonId", "dbo.Seasons");
            DropForeignKey("dbo.Tops", "OccasionId", "dbo.Occasions");
            DropForeignKey("dbo.Tops", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Accessories", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Accessories", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Accessories", "ColorID", "dbo.Colors");
            DropIndex("dbo.Outfits", new[] { "AccessoryID" });
            DropIndex("dbo.Outfits", new[] { "TopID" });
            DropIndex("dbo.Outfits", new[] { "ShoeID" });
            DropIndex("dbo.Outfits", new[] { "BottomID" });
            AlterColumn("dbo.Outfits", "ShoeID", c => c.Int());
            AlterColumn("dbo.Outfits", "BottomID", c => c.Int());
            AlterColumn("dbo.Outfits", "AccessoryID", c => c.Int());
            AlterColumn("dbo.Outfits", "TopID", c => c.Int());
            RenameColumn(table: "dbo.Outfits", name: "ShoeID", newName: "Shoe_ShoeID");
            RenameColumn(table: "dbo.Outfits", name: "BottomID", newName: "Bottom_BottomID");
            RenameColumn(table: "dbo.Outfits", name: "TopID", newName: "Top_TopId");
            RenameColumn(table: "dbo.Outfits", name: "AccessoryID", newName: "Accessory_AccessoryID");
            CreateIndex("dbo.Outfits", "Shoe_ShoeID");
            CreateIndex("dbo.Outfits", "Bottom_BottomID");
            CreateIndex("dbo.Outfits", "Accessory_AccessoryID");
            CreateIndex("dbo.Outfits", "Top_TopId");
            AddForeignKey("dbo.Shoes", "SeasonID", "dbo.Seasons", "SeasonId", cascadeDelete: true);
            AddForeignKey("dbo.Shoes", "OccasionID", "dbo.Occasions", "OccasionId", cascadeDelete: true);
            AddForeignKey("dbo.Shoes", "ColorID", "dbo.Colors", "ColorId", cascadeDelete: true);
            AddForeignKey("dbo.Bottoms", "SeasonID", "dbo.Seasons", "SeasonId", cascadeDelete: true);
            AddForeignKey("dbo.Bottoms", "OccasionID", "dbo.Occasions", "OccasionId", cascadeDelete: true);
            AddForeignKey("dbo.Bottoms", "ColorID", "dbo.Colors", "ColorId", cascadeDelete: true);
            AddForeignKey("dbo.Tops", "SeasonId", "dbo.Seasons", "SeasonId", cascadeDelete: true);
            AddForeignKey("dbo.Tops", "OccasionId", "dbo.Occasions", "OccasionId", cascadeDelete: true);
            AddForeignKey("dbo.Tops", "ColorId", "dbo.Colors", "ColorId", cascadeDelete: true);
            AddForeignKey("dbo.Accessories", "SeasonID", "dbo.Seasons", "SeasonId", cascadeDelete: true);
            AddForeignKey("dbo.Accessories", "OccasionID", "dbo.Occasions", "OccasionId", cascadeDelete: true);
            AddForeignKey("dbo.Accessories", "ColorID", "dbo.Colors", "ColorId", cascadeDelete: true);
        }
    }
}
