using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.Entities
{
    public class ImageEntity
    {
        [Key]
        public int ImageId { get; set; }
        [Required] 
        public string ImageSrc { get; set; }
        public string ImageAlt { get; set; }
        public ProductEntity Product { get; set; } 
    }
}
