using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Evans.Blog.Consts;
using Evans.Blog.Dto;
using Microsoft.AspNetCore.Components;
using Volo.Abp.Application.Dtos;

namespace Evans.Blog.Blazor.Pages.Category
{
    public partial class Category
    {
        [Inject]
        private HttpClient HttpClient { get; set; }
        
        private string CurrentSorting { get; set; }
        
        private string CurrentFilter { get; set; }
        
        // private int PageSize { get; set; }
        //
        // private int PageNumber { get; set; }

        private int MaxResultCount { get; set; } = LimitedResultRequestDto.DefaultMaxResultCount;

        private IList<GetCategoryDto> Categories { get; set; } = new List<GetCategoryDto>();

        protected override async Task OnInitializedAsync()
        {
            await RenderPageAsync();
            await base.OnInitializedAsync();
        }

        private async Task RenderPageAsync()
        {
            //var skipCount = PageSize * (PageNumber - 1);
            var api = $"{ApiConsts.ApiRootPath}/category/get-list-without-pagination";

            if (!CurrentSorting.IsNullOrWhiteSpace() && CurrentFilter.IsNullOrWhiteSpace())
            {
                api += $"?sorting={CurrentSorting}";
            }

            if (!CurrentFilter.IsNullOrWhiteSpace() && CurrentSorting.IsNullOrWhiteSpace())
            {
                api += $"?filter={CurrentFilter}";
            }

            if (!CurrentFilter.IsNullOrWhiteSpace() && !CurrentSorting.IsNullOrWhiteSpace())
            {
                api += $"?sorting={CurrentSorting}&filter={CurrentFilter}";
            }

            Categories = await HttpClient.GetFromJsonAsync<List<GetCategoryDto>>(api);
        }
    }
}