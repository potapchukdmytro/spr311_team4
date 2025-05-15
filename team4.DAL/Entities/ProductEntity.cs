using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team4.DAL.Entities
{
    public class ProductEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [MaxLength(255)]
        [Required]
        public required string Name { get; set; }
        [MaxLength(255)]
        [Required]
        public string? NormalizedName { get; set; } 
        [MaxLength]
        public string Description { get; set; } = string.Empty;
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }

        [ForeignKey("Category")]
        public required string CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
    }
}
