using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Evans.Blog.Blazor.Shared
{
    public class Common
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly NavigationManager _navigationManager;

        public Common(
            IJSRuntime jsRuntime,
            NavigationManager navigationManager)
        {
            _jsRuntime = jsRuntime;
            _navigationManager = navigationManager;
        }

        public async Task NavigateToAsync(string url, bool forceLoad = true)
        {
            _navigationManager.NavigateTo(url,forceLoad);

            await Task.CompletedTask;
        }

        public async Task InvokeVoidAsync(string identifier, params object[] args)
        {
            await _jsRuntime.InvokeVoidAsync(identifier, args);
        }

        public async Task<TResult> InvokeAsync<TResult>(string identifier, params object[] args)
        {
            return await _jsRuntime.InvokeAsync<TResult>(identifier, args);
        }

        public async Task<string> GetLocalStorageAsync(string name)
        {
            return await InvokeAsync<string>("window.func.getLocalStorage", name);
        }

        public async Task SetLocalStorage(string name, string value)
        {
            await InvokeVoidAsync("window.func.setLocalStorage", name, value);
        }
    }
}