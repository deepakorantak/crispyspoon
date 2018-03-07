namespace CrispySpoon.Models
{
    public class Vendor : BaseEntity
    {
        public string VendorCode { get; set; }
        public string VendorName { get; set; }

        public Vendor() { }
    }
}
