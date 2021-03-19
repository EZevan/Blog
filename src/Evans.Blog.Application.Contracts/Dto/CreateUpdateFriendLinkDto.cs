using System.ComponentModel.DataAnnotations;

namespace Evans.Blog.Dto
{
    public class CreateUpdateFriendLinkDto
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string LinkUrl { get; set; }
    }
}
