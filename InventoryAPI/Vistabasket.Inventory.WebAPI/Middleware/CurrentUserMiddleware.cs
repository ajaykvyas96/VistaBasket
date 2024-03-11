using System.Security.Claims;
using Vistabasket.Inventory.Service.Interface;

namespace Vistabasket.Inventory.WebAPI.Middleware
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
