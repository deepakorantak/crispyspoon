//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrispySpoon.API
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbm_fooditem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbm_fooditem()
        {
            this.tbt_menu = new HashSet<tbt_menu>();
            this.tbm_user = new HashSet<tbm_user>();
        }
    
        public string item_code { get; set; }
        public string item_description { get; set; }
        public decimal calorie_count { get; set; }
        public string item_veg_nonveg { get; set; }
        public string vendor_code { get; set; }
    
        public virtual tbm_vendor tbm_vendor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbt_menu> tbt_menu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbm_user> tbm_user { get; set; }
    }
}
