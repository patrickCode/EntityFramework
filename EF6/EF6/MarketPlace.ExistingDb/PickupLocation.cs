//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarketPlace.ExistingDb
{
    using System;
    using System.Collections.Generic;
    
    public partial class PickupLocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PickupLocation()
        {
            this.ItemProducts = new HashSet<ItemProduct>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int ContactId { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime LastModifiedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemProduct> ItemProducts { get; set; }
    }
}
