using Microsoft.EntityFrameworkCore;
using WebShop.Models.Entities;

namespace WebShop.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ImageEntity> Images { get; set; }
        public DbSet<DescriptionEntity> Descriptions { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
    }
}
