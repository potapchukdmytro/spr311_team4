using Microsoft.AspNetCore.Http;

namespace team4.BLL.Dtos.Product
{
    public class UpdateProductDto
    {
        public required string Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string? Category { get; set; }
        public IFormFile? Image { get; set; }
    }
}
