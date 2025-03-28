using dmacaspac201.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace dmacaspac201.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  
    public class UserController : ControllerBase  
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("search")]  
        public async Task<Contracts.Paged<UserDto>> Search(
            bool? isActive = true,
            int? pageIndex = 1,
            int? pageSize = 10,
            string? keyword = "")
        {
            return await _userService.Search(isActive, pageIndex, pageSize, keyword);
        }
    }
}
