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
    
    public partial class ItemProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemProduct()
        {
            this.LineItems = new HashSet<LineItem>();
        }
    
        public int Id { get; set; }
        public int ShipperId { get; set; }
        public string Pack { get; set; }
        public string Grade { get; set; }
        public string Size { get; set; }
        public int CountryOfOriginId { get; set; }
        public int StateId { get; set; }
        public string Description { get; set; }
        public int AvailabilityId { get; set; }
        public int ItemProductPriceId { get; set; }
        public int PickupLocationId { get; set; }
        public int ItemProductGroupId { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime LastModifiedIn { get; set; }
    
        public virtual Availability Availability { get; set; }
        public virtual ItemProductGroup ItemProductGroup { get; set; }
        public virtual ItemProductPrice ItemProductPrice { get; set; }
        public virtual PickupLocation PickupLocation { get; set; }
        public virtual Shipper Shipper { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}