using LilsCareApp.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Components
{
    public class CarouselProductsComponent : ViewComponent
    {
        private readonly IProductsService _service;

        public CarouselProductsComponent(IProductsService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            var products = await _service.GetAllAsync(userId);
            return await Task.FromResult((IViewComponentResult)View(products));
        }


    }
}


