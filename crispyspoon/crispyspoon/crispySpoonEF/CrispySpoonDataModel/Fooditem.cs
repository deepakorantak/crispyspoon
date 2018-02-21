using System;
using System.Collections.Generic;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class Fooditem
    {
        public Fooditem()
        {
            MenuItem = new HashSet<MenuItem>();
            UserFavorites = new HashSet<UserFavorites>();
        }

        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public decimal CalorieCount { get; set; }
        public string ItemVegNonveg { get; set; }
        public string VendorCode { get; set; }

        public Vendor Vendor { get; set; }
        public ICollection<MenuItem> MenuItem { get; set; }
        public ICollection<UserFavorites> UserFavorites { get; set; }
    }
}
