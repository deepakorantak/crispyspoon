using System;
using System.Collections.Generic;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class EntitlementMapping
    {
        public string RoleCode { get; set; }
        public string EntitlementCode { get; set; }

        public Entitlement Entitlement { get; set; }
        public Role Role { get; set; }
    }
}
