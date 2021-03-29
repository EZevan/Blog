using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Evans.Blog.Blazor.Shared
{
    public partial class Header
    {
        [Inject] 
        private Common Common { get; set; }
        
        ///<summary>
        /// Collapse Navi menu while in mobile client
        /// </summary>
        private bool _collapseNavMenu;

        ///<summary>
        /// Current theme
        /// </summary>
        private string _currentTheme;

        ///<summary>
        /// Collapse navi menu or not.
        /// </summary>
        private string NavMenuCssClass => _collapseNavMenu ? "active" : null;

        ///<summary>
        /// Toggles navi menu collapsed
        /// </summary>
        private void ToggleNavMenu() => _collapseNavMenu = !_collapseNavMenu;

        ///<summary>
        /// Initializes the global theme as light color.
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            _currentTheme = await Common.GetLocalStorageAsync("theme") ?? "Light";

            await Common.InvokeVoidAsync("window.func.switchTheme");
        }

        ///<summary>
        /// Switches global theme.
        /// </summary>
        private async Task SwitchTheme()
        {
            _currentTheme = _currentTheme == "Light" ? "Dark" : "Light";

            await Common.SetLocalStorage("theme", _currentTheme);

            await Common.InvokeVoidAsync("window.func.switchTheme");
        }
    }
}