using System;
using System.Collections.Generic;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class UserFavorites
    {
        public decimal UserId { get; set; }
        public string ItemCode { get; set; }

        public Fooditem Fooditem { get; set; }
        public User User { get; set; }
    }
}
