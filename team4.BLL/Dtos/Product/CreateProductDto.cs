using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace team4.BLL.Dtos.Product
{
    public class CreateProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Amount must be at least 1.")]
        public int Amount { get; set; }

        [Required]
        public string Category { get; set; } = null!;

        public IFormFile? Image { get; set; }
    }
}
