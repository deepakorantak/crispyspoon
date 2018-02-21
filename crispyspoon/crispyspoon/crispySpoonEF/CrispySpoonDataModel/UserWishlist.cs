using System;
using System.Collections.Generic;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class UserWishlist
    {
        public decimal WishlistId { get; set; }
        public decimal UserId { get; set; }
        public string ItemName { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }

        public User User { get; set; }
    }
}
