using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WardrobeMVC.Models;

namespace WardrobeMVC.ViewModels
{
    public class OutfitViewModel
    {
        public Outfit Outfit { get; set; }
        public IEnumerable<SelectListItem> AllAccessories { get; set; }

        private List<int> _selectedAccessories;
        public List<int> SelectedAccessories
        {
            get
            {
                if (_selectedAccessories == null)
                {
                    // Look up the current outfit's accessories,
                    // and convert them into integer IDs
                    _selectedAccessories = (from a in Outfit.Accessories
                                            select a.AccessoryID).ToList();
                }
                return _selectedAccessories;
            }
            set { _selectedAccessories = value; }
        }


    }
}