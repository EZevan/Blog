using System.ComponentModel.DataAnnotations;

namespace Evans.Blog.Dto
{
    public class CreateUpdateCategoryDto
    {
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }
    }
}
