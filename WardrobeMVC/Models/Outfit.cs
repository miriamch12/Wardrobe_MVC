using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WardrobeMVC.Models
{
    public class Outfit
    {
        [Key]
        public int OutfitId { get; set; }

        public Outfit()
        {
            Accessories = new HashSet<Accessory>();
        }

        [ForeignKey("Bottom")]
        public int BottomID { get; set; }
        public virtual Bottom Bottom { get; set; }

        [ForeignKey("Shoe")]
        public int ShoeID { get; set; }
        public virtual Shoe Shoe { get; set; }

        [ForeignKey("Top")]
        public int TopID { get; set; }
        public virtual Top Top { get; set; }

        public virtual ICollection<Accessory> Accessories { get; set; }

    }

}