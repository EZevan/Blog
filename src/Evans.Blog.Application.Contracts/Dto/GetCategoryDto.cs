using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Evans.Blog.Dto
{
    public class GetCategoryDto : CategoryDto
    {
        public int Count { get; set; }
    }
}
