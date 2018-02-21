using System;
using System.Collections.Generic;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class Entitlement
    {
        public Entitlement()
        {
            EntitlementMapping = new HashSet<EntitlementMapping>();
        }

        public string EntitlementCode { get; set; }
        public string EntitlementName { get; set; }
        public string EntitlementDescription { get; set; }

        public ICollection<EntitlementMapping> EntitlementMapping { get; set; }
    }
}
