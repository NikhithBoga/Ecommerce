using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ecommerce.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }

        [Required(ErrorMessage = "Order ID is required.")]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [JsonIgnore]
        public Order? Order { get; set; }

        [Required(ErrorMessage = "ProductId is Required")]
        public int ProductId { get; set; }

        //[ForeignKey("ProductId")]
        //public Products Products { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        public int Quantity { get; set; }


        [Required]
        [Range(0.00, 200000.00, ErrorMessage = "Total Price must be between ₹0.00 and ₹20,0000.00.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }



    }
}
