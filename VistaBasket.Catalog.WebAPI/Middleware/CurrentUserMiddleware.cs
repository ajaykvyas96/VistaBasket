using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Security.Claims;
using VistaBasket.Catalog.Service.Interface;
using VistaBasket.Catalog.Service.Service;

namespace VistaBasket.Catalog.WebAPI.Middleware
{
    public class CurrentUserMiddleware : IMiddleware
    {
        private readonly IUserService _userService;

        public CurrentUserMiddleware(IUserService userService)
        {
            _userService = userService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);
            string currentUserId = userIdClaim?.Value;
            _userService.SetCurrentUserId(currentUserId);
            await next(context);
        }
    }
}
