using System.ComponentModel.DataAnnotations;

namespace team4.DAL.Entities
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
        string Name { get; set; }
    }

    public class BaseEntity<T> : IBaseEntity<T>
    {
        [Key]
        virtual public T Id { get; set; } = default!;
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }
    }
}
