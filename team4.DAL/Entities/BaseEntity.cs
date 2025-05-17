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
        virtual public T Id { get; set; } = default!;
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string NormalizedName { get; set; } = string.Empty;
        [MaxLength]
        public string Description { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Image { get; set; } = string.Empty;
    }
}
