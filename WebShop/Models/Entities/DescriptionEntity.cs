using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.Entities
{
    public class DescriptionEntity
    {
        [Key]
        public int DescriptionId { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
