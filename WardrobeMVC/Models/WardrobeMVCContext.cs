using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WardrobeMVC.Models
{
    public class WardrobeMVCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WardrobeMVCContext() : base("name=WardrobeMVCContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public System.Data.Entity.DbSet<WardrobeMVC.Models.Occasion> Occasions { get; set; }

        public System.Data.Entity.DbSet<WardrobeMVC.Models.Top> Tops { get; set; }

        public System.Data.Entity.DbSet<WardrobeMVC.Models.Season> Seasons { get; set; }

        public System.Data.Entity.DbSet<WardrobeMVC.Models.Color> Colors { get; set; }

        public System.Data.Entity.DbSet<WardrobeMVC.Models.Shoe> Shoes { get; set; }

        public System.Data.Entity.DbSet<WardrobeMVC.Models.Bottom> Bottoms { get; set; }

        public System.Data.Entity.DbSet<WardrobeMVC.Models.Outfit> Outfits { get; set; }

        public System.Data.Entity.DbSet<WardrobeMVC.Models.Accessory> Accessories { get; set; }
    }
}
