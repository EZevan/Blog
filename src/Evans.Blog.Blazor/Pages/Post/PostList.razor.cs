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
        public int PageNumber { get; set; }

        public int MaxResultCount { get; set; }

        public int SkipCount { get; set; }
        
        public int TotalPage { get; set; }

        public int TotalCount { get; set; }

        public static IList<PostDto> Posts { get; set; } = new List<PostDto>();

        /// <summary>
        /// Initialization
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            PageNumber = 1;
            
            await RenderPageAsync(PageNumber);
            
            await base.OnInitializedAsync();
        }

        
        public async Task RenderPageAsync(int pageNumber)
        {
            PageNumber = pageNumber;
            SkipCount = 10;
            MaxResultCount = 10;
            
            var skipCount = SkipCount * (PageNumber - 1);
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

            TotalCount = postDtoPagedResultDto.TotalCount;
            
            TotalPage = (int)Math.Ceiling((double)TotalCount / SkipCount);
            
            Console.WriteLine($"total page: {TotalPage}");
            Console.WriteLine($"total count: {TotalCount}");
        }
    }
}