using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Components
{
    public class HeaderComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View());
        }
    }
}
