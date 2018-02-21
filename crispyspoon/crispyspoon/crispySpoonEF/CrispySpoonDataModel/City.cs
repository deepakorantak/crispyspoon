using System;
using System.Collections.Generic;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class City
    {
        public City()
        {
            Facility = new HashSet<Facility>();
        }

        public string CityCode { get; set; }
        public string CityName { get; set; }

        public ICollection<Facility> Facility { get; set; }
    }
}
