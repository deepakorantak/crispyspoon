using crispySpoonEF.CrispySpoonDataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace crispySpoonEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CrispySpoonDBContext dbc = new CrispySpoonDBContext();
            dbc.Cafeteria.Include(s => s.FacilityCafeteriaMapping)
                         .Include(s => s.Vendor)
                         .ToList()
                         .ForEach(s => {
                                         Console.WriteLine($"{s.Vendor.VendorName},\t {s.CafeteriaCode},\t {s.CafeteriaName},\t {s.FacilityCafeteriaMapping.ToList().Count}");
                                         s.FacilityCafeteriaMapping.ToList().ForEach(a=> Console.WriteLine($"{a.FacilityCode},\t"));
                                       }
                                   );
        }
    }
}
