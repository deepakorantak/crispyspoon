using System;
using System.Collections.Generic;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class UserRole
    {
        public string RoleCode { get; set; }
        public decimal UserId { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }
    }
}
