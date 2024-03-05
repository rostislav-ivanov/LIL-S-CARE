﻿using LilsCareApp.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LilsCareApp.Components
{
    public class HeaderComponent : ViewComponent
    {
        private readonly ILilsCareService _service;
        private readonly HttpContext _httpContext;


        public HeaderComponent(ILilsCareService service, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _httpContext = httpContextAccessor.HttpContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string? userId = _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.count = userId != null ? await _service.GetCountInBagAsync(userId) : 0;
            return await Task.FromResult((IViewComponentResult)View());
        }
    }
}
