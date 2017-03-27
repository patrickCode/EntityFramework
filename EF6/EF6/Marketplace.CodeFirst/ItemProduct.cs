namespace Marketplace.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemProduct")]
    public partial class ItemProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemProduct()
        {
            LineItems = new HashSet<LineItem>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int ShipperId { get; set; }

        [StringLength(100)]
        public string Pack { get; set; }

        [StringLength(100)]
        public string Grade { get; set; }

        [StringLength(100)]
        public string Size { get; set; }

        public int CountryOfOriginId { get; set; }

        public int StateId { get; set; }

        public string Description { get; set; }

        public int AvailabilityId { get; set; }

        public int ItemProductPriceId { get; set; }

        public int PickupLocationId { get; set; }

        public int ItemProductGroupId { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(100)]
        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedIn { get; set; }

        public virtual Availability Availability { get; set; }

        public virtual ItemProductGroup ItemProductGroup { get; set; }

        public virtual ItemProductPrice ItemProductPrice { get; set; }

        public virtual PickupLocation PickupLocation { get; set; }

        public virtual Shipper Shipper { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
