using System;
using System.Collections.Generic;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class MenuItem
    {
        public string ItemCode { get; set; }
        public decimal MenuId { get; set; }

        public Fooditem Fooditem { get; set; }
        public Menu Menu { get; set; }
    }
}
