using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team4.DAL.Entities
{
    public class ProductEntity : BaseEntity<string>
    {
        [Key]
        override public string Id { get; set; } = Guid.NewGuid().ToString();
        public decimal Price { get; set; }
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }

        [ForeignKey("Category")]
        public required string CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
    }
}
