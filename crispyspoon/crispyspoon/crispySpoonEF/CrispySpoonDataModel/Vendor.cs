using System;
using System.Collections.Generic;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class Vendor
    {
        public Vendor()
        {
            Cafeteria = new HashSet<Cafeteria>();
            Fooditem = new HashSet<Fooditem>();
        }

        public string VendorCode { get; set; }
        public string VendorName { get; set; }

        public ICollection<Cafeteria> Cafeteria { get; set; }
        public ICollection<Fooditem> Fooditem { get; set; }
    }
}
