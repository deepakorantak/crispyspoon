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
    
    public partial class tbm_entitlement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbm_entitlement()
        {
            this.tbm_role = new HashSet<tbm_role>();
        }
    
        public string entitlement_code { get; set; }
        public string entitlement_name { get; set; }
        public string entitlement_description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbm_role> tbm_role { get; set; }
    }
}