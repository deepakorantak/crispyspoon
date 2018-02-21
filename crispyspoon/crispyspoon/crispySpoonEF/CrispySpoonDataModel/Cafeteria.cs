using System;
using System.Collections.Generic;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class Cafeteria
    {
        public Cafeteria()
        {
            FacilityCafeteriaMapping = new HashSet<FacilityCafeteriaMapping>();
            Menu = new HashSet<Menu>();
        }

        public string CafeteriaCode { get; set; }
        public string CafeteriaName { get; set; }
        public string VendorCode { get; set; }

        public Vendor Vendor { get; set; }
        public ICollection<FacilityCafeteriaMapping> FacilityCafeteriaMapping { get; set; }
        public ICollection<Menu> Menu { get; set; }
    }
}
