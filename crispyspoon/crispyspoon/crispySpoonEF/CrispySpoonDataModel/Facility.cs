using System;
using System.Collections.Generic;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class Facility
    {
        public Facility()
        {
            FacilityCafeteriaMapping = new HashSet<FacilityCafeteriaMapping>();
        }

        public string FacilityCode { get; set; }
        public string FacilityName { get; set; }
        public string CityCode { get; set; }

        public City City { get; set; }
        public ICollection<FacilityCafeteriaMapping> FacilityCafeteriaMapping { get; set; }
    }
}
