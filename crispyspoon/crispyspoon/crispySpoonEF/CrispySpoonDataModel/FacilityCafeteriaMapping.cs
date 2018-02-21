using System;
using System.Collections.Generic;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class FacilityCafeteriaMapping
    {
        public string FacilityCode { get; set; }
        public string CafeteriaCode { get; set; }

        public Cafeteria Cafeteria { get; set; }
        public Facility Facility { get; set; }
    }
}
