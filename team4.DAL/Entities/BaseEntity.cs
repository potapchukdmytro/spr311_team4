using System.ComponentModel.DataAnnotations;

namespace team4.DAL.Entities
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
        string Name { get; set; }
        string NormalizedName { get; set; }
        string Description { get; set; }
        string Image { get; set; }
    }

    public class BaseEntity<T> : IBaseEntity<T>
    {
        [Key]
        public T Id { get; set; } = default!;
        public required string Name { get; set; }
        public string NormalizedName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
