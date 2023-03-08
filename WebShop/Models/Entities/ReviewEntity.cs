using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.Entities
{
    public class ReviewEntity
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public string Review { get; set; }
        public ProductEntity Product { get; set; }
    }
}
