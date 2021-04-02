using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AntDesign;
using Evans.Blog.Dto;
using Microsoft.AspNetCore.Components;

namespace Evans.Blog.Blazor.Pages.Post
{
    public partial class PostList
    {
        [Inject] private HttpClient HttpClient { get; set; }
        
        [Parameter]
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

        protected override async Task OnParametersSetAsync()
        {
            Console.WriteLine($"pageNumber:{PageNumber}");
            if (PageNumber != 1)
            {
                PageNumber = 1;
                await RenderPageAsync(PageNumber);
            }
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