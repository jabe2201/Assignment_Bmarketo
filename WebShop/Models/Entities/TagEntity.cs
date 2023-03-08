using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.Entities
{
    public class TagEntity
    {
        public TagEntity()
        {
            this.Products = new HashSet<ProductEntity>();
        }
        [Key]
        public int TagId { get; set; }
        [Required]
        public string Tag { get; set; }
        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
