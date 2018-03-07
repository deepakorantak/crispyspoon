using SQLite;

namespace CrispySpoon.Models
{
    public class Vendor : IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }

        public Vendor()
        {

        }

    }
}
