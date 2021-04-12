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

        private string CurrentSorting { get; set; } = nameof(CategoryDto.CategoryName);

        private async Task RenderPageAsync()
        {
            var api = $"{ApiConsts.ApiRootPath}/category?sorting={CurrentSorting}";
            var PagedResults = await HttpClient.GetFromJsonAsync<PagedResultDto<CategoryDto>>(api);
        }
    }
}