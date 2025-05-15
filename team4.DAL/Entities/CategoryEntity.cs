using System.ComponentModel.DataAnnotations;

namespace team4.DAL.Entities
{
    public class CategoryEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string? NormalizedName { get; set; }
        [MaxLength]
        public string? Description { get; set; }

        public ICollection<ProductEntity> Products { get; set; } = [];
    }
}
