//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace project_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public type()
        {
            this.outgoing_permission = new HashSet<outgoing_permission>();
            this.supply_permission = new HashSet<supply_permission>();
        }
    
        public string type_code { get; set; }
        public string type_name { get; set; }
        public string type_measuring_unit { get; set; }
        public Nullable<int> type_quantity { get; set; }
        public Nullable<int> store_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<outgoing_permission> outgoing_permission { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<supply_permission> supply_permission { get; set; }
    }
}