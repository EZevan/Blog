using System;
using System.Collections.Generic;

namespace Evans.Blog.Dto
{
    public class PostDtoPagedResultDto
    {
        public int TotalCount { get; set; }

        public IList<PostDto> Items { get; set; }
    }
}