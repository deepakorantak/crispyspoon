//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrispySpoon.API.V2
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbt_user_wishlist
    {
        public decimal wishlist_id { get; set; }
        public decimal user_id { get; set; }
        public string item_name { get; set; }
        public string status { get; set; }
        public string remarks { get; set; }
    
        public virtual tbm_user tbm_user { get; set; }
    }
}
