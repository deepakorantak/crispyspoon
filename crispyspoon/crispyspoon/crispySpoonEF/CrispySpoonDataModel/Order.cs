using System;
using System.Collections.Generic;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class Order
    {
        public decimal OrderId { get; set; }
        public decimal MenuId { get; set; }
        public decimal UserId { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderDelivered { get; set; }
        public DateTime? OrderPrinted { get; set; }
        public string OrderStatus { get; set; }
        public byte[] OrderQrCode { get; set; }
        public decimal? OrderRating { get; set; }

        public Menu Menu { get; set; }
    }
}
