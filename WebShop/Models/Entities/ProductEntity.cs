using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.Entities
{
    public class ProductEntity
    {
        public ProductEntity()
        {
            this.Tags = new HashSet<TagEntity>();
            this.Images = new HashSet<ImageEntity>();
        }
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; } 
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public int? ReviewId { get; set; }
        public int? DescriptionId { get; set; }
        public virtual ICollection<ImageEntity> Images { get; set; }
        public ReviewEntity Review { get; set; }
        public virtual ICollection<TagEntity> Tags { get; set; }
        public virtual DescriptionEntity Description { get; set; }

    }
}
