using System.ComponentModel.DataAnnotations;
using Evans.Blog.Enums;

namespace Evans.Blog.Dto
{
    public class CreateUpdateTagDto
    {
        [Required]
        public PostTags TagType { get; set; }

        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }
    }
}
