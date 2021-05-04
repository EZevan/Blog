using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AntDesign;
using Evans.Blog.Consts;
using Evans.Blog.Domain.Shared.Dto;
using Evans.Blog.Dto;
using Microsoft.AspNetCore.Components;
using Volo.Abp.Application.Dtos;

namespace Evans.Blog.Blazor.Pages.Post
{
    public partial class PostList
    {
        [Inject] private HttpClient HttpClient { get; set; }
        
        private int PageNumber { get; set; }

        private int PageSize { get; set; } = LimitedResultRequestDto.DefaultMaxResultCount;

        //private string CurrentSorting { get; set; } = nameof(PostDto.CreationTime) + " Desc";

        private int TotalPage { get; set; }

        private int TotalCount { get; set; }

        private static IReadOnlyList<PostDto> Posts { get; set; } = new List<PostDto>();

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


        private async Task RenderPageAsync(int pageNumber)
        {
            PageNumber = pageNumber;
            
            var skipCount = PageSize * (PageNumber - 1);
            var api = $"{ApiConsts.ApiRootPath}/post/getList";

            if (skipCount <= 0 && PageSize > 0)
            {
                api += $"?maxResultCount={PageSize}";
            }

            if(PageSize <= 0 && skipCount > 0)
            {
                api += $"?skipCount={skipCount}";
            }

            if(skipCount > 0 && PageSize > 0)
            {
                api += $"?skipCount={skipCount}&maxResultCount={PageSize}";
            }

            Console.WriteLine($"+++++++++++++api:{api}");
            
            var result = await HttpClient.GetFromJsonAsync<ServiceResult<PagedResultDto<PostDto>>>(api);

            if(result != null)
            {
                Posts = result.Data.Items;
                TotalCount = (int)result.Data.TotalCount;
            }

            TotalPage = (int)Math.Ceiling((double)TotalCount / PageSize);
            
            Console.WriteLine($"total page: {TotalPage}");
            Console.WriteLine($"total count: {TotalCount}");
        }
    }
}