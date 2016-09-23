using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WardrobeMVC.Models
{
    public class Color
    {
        [Key]
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        

    }
}