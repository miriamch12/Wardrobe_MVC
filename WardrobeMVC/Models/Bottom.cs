using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WardrobeMVC.Models
{
    public class Bottom
    {
        [Key]
        public int BottomID { get; set; }       
        public string BottomName { get; set; }
         public string BottomPhoto { get; set; }

        public virtual ICollection<Outfit> Outfits { get; set; }

        [ForeignKey("Color")]
        public int ColorID { get; set; }
        public virtual Color Color { get; set; }

        [ForeignKey("Season")]
        public int SeasonID { get; set; }
        public virtual Season Season { get; set; }

        [ForeignKey("Occasion")]
        public int OccasionID { get; set; }
        public virtual Occasion Occasion { get; set; }
    }

}