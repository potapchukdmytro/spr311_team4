namespace team4.DAL.Entities
{
    public class CategoryEntity : BaseEntity<string>
    {
        override public string Id { get; set; } = Guid.NewGuid().ToString();

        public ICollection<ProductEntity> Products { get; set; } = [];
    }
}
