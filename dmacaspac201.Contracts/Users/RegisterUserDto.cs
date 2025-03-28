using dmacaspac201.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmacaspac201.Contracts.Users
{
    public class RegisterUserDto : UserDto
    {
        public string? EmailAdress { get; set; }
        public string? Password { get; set; }
        public UserRole Role { get; set; } = UserRole.Buyer;
    }

}
