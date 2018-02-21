using System;
using System.Collections.Generic;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class Menu
    {
        public Menu()
        {
            MenuItem = new HashSet<MenuItem>();
            Order = new HashSet<Order>();
        }

        public decimal MenuId { get; set; }
        public DateTime MenuDate { get; set; }
        public string MealType { get; set; }
        public string MenuItemName { get; set; }
        public string CafeteriaCode { get; set; }

        public Cafeteria Cafeteria { get; set; }
        public ICollection<MenuItem> MenuItem { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
