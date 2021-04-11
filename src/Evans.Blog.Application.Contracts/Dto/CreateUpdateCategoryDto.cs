using System.ComponentModel.DataAnnotations;
using Evans.Blog.Consts;

namespace Evans.Blog.Dto
{
    public class CreateUpdateCategoryDto
    {
        [Required]
        [StringLength(ConstraintConsts.MaxNameLength)]
        public string CategoryName { get; set; }
        
        [StringLength(ConstraintConsts.MaxNameLength)]
        public string DisplayName { get; set; }
    }
}
