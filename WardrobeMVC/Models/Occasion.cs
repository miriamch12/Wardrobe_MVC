using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WardrobeMVC.Models
{
    public class Occasion
    {
        [Key]
        public int occasionID { get; set; }
        public string occasionName { get; set; }

    }
}