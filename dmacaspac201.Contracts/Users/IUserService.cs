using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmacaspac201.Contracts.Users
{
    public interface IUserService : IService
    {
        List<UserDto>? GetUsers();
        UserDto? GetUserById(Guid? id);
        UserDto? GetUserByEmail(string? emailAddress = null);
        UserDto? UpdateUserProfile(UserDto? user);
        Task<UserDto> RegisterUser(RegisterUserDto registerUserDto); 
        Task<Paged<UserDto>>? Search(bool? isActive = true, int? pageIndex = 1, int? pageSize = 10, string? keyword = "");
        
    }
}
