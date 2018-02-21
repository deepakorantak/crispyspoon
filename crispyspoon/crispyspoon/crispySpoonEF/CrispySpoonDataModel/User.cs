using System;
using System.Collections.Generic;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class User
    {
        public User()
        {
            UserRole = new HashSet<UserRole>();
            UserFavorites = new HashSet<UserFavorites>();
            UserWishlist = new HashSet<UserWishlist>();
        }

        public decimal UserId { get; set; }
        public string CityCode { get; set; }
        public string FacilityCode { get; set; }
        public string CafeteriaCode { get; set; }

        public ICollection<UserRole> UserRole { get; set; }
        public ICollection<UserFavorites> UserFavorites { get; set; }
        public ICollection<UserWishlist> UserWishlist { get; set; }
    }
}
