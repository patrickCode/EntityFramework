namespace Marketplace.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shipper")]
    public partial class Shipper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shipper()
        {
            ItemProducts = new HashSet<ItemProduct>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int AddressId { get; set; }

        public int ContactId { get; set; }

        [StringLength(100)]
        public string ImageLink { get; set; }

        [StringLength(100)]
        public string LogoLink { get; set; }

        public string Specials { get; set; }

        [StringLength(100)]
        public string FoodSafetyDocumentLink { get; set; }

        public bool IsPriceAvailableToPrivateUsers { get; set; }

        [Required]
        [StringLength(100)]
        public string BillingName { get; set; }

        [Required]
        [StringLength(100)]
        public string BillingAddressId { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(100)]
        public string LastModifiedBy { get; set; }

        [Required]
        [StringLength(100)]
        public string LastModifiedOn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemProduct> ItemProducts { get; set; }
    }
}
