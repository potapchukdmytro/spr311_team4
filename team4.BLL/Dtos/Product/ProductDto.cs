namespace team4.BLL.Dtos.Product
{
    public class ProductDto
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string? Image { get; set; }
        public required string Category { get; set; }
    }
}
