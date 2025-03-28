using dmacaspac201.Contracts.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dmacaspac201.Components.Pages.Accounts
{
    public class UserSearchModel : PageModel
    {
        private readonly IUserService _userService;

        public UserSearchModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty(SupportsGet = true)]
        public string? Keyword { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool IsActive { get; set; } = true;  // Default to true

        public List<UserDto> Users { get; set; } = new List<UserDto>();

        public async Task OnGetAsync()
        {
            var searchResults = await _userService.Search(
                isActive: IsActive,
                keyword: Keyword,
                pageIndex: 1,
                pageSize: 10
            );

            if (searchResults?.Items != null)
            {
                Users = searchResults.Items;
            }
        }
    }
}
