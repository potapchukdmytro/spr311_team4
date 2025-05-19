using System.ComponentModel.DataAnnotations;

namespace team4.BLL.Dtos.Category
{
    public class CreateCategoryDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;
    }
}
