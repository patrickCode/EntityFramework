namespace Marketplace.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderLineItems = new HashSet<OrderLineItem>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int BuyerId { get; set; }

        public int TotalQuantity { get; set; }

        public int TotalPallets { get; set; }

        [Column(TypeName = "money")]
        public decimal ItemSubtotal { get; set; }

        [Column(TypeName = "money")]
        public decimal Total { get; set; }

        [StringLength(50)]
        public string PO_Number { get; set; }

        public DateTime PickupDate { get; set; }

        public string OrderNotes { get; set; }

        public int OrderStatusId { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(100)]
        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }

        public virtual Buyer Buyer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }
    }
}
