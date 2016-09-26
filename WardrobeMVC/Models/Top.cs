using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WardrobeMVC.Models
{
    public class Top
    {
        [Key]
        public int TopId { get; set; }
        public string TopName { get; set; }
        public string TopPhoto { get; set; }

        public virtual ICollection<Outfit> Outfits { get; set; }

        [ForeignKey("Color")]
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }

        [ForeignKey("Season")]
        public int SeasonId { get; set; }
        public virtual Season Season { get; set; }

        [ForeignKey("Occasion")]
        public int OccasionId { get; set; }
        public virtual Occasion Occasion { get; set; }


    }
}