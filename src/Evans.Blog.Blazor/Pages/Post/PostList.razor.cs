using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Evans.Blog.Dto;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Evans.Blog.Blazor.Pages.Post
{
    public partial class PostList
    {
        [Inject] private HttpClient HttpClient { get; set; }
        
        ///<summary>
        /// Current page number, which will be used as routing parameter above
        /// </summary>
        // [Parameter]
        public int? PageNumber { get; set; }

        public int MaxResultCount { get; set; }

        public int SkipCount { get; set; } = 10;
        
        public int TotalPage { get; set; }

        public IList<PostDto> Posts { get; set; } = new List<PostDto>();
        
        
        /// <summary>
        /// Initialization
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            // setup default value
            PageNumber ??= 1;

            await RenderPageAsync(PageNumber);
            
            await base.OnInitializedAsync();
        }

        
        private async Task RenderPageAsync(int? pageNumber = 1)
        {
            var skipCount = SkipCount * (pageNumber - 1);
            var api = $"/api/evans-blog/post";

            if (skipCount <= 0 && MaxResultCount > 0)
                api += $"?maxResultCount={MaxResultCount}";

            if(MaxResultCount <= 0 && skipCount > 0)
                api += $"?skipCount={skipCount}";
            
            if(skipCount > 0 && MaxResultCount > 0)
                api += $"?skipCount={skipCount}&maxResultCount={MaxResultCount}";
            
            Console.WriteLine($"+++++++++++++api:{api}");
            
            var postDtoPagedResultDto = await HttpClient.GetFromJsonAsync<PostDtoPagedResultDto>(api);

            Posts = postDtoPagedResultDto.Items;

            Console.WriteLine(Posts.Count);

            TotalPage = (int)Math.Ceiling((double)Posts?.Count / SkipCount);
        }
    }
}