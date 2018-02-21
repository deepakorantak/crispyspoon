using System;
using System.Collections.Generic;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class Role
    {
        public Role()
        {
            EntitlementMapping = new HashSet<EntitlementMapping>();
            UserRole = new HashSet<UserRole>();
        }

        public string RoleCode { get; set; }
        public string RoleDescription { get; set; }

        public ICollection<EntitlementMapping> EntitlementMapping { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
