using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmacaspac201.Contracts.Users
{
    public class UserDto
    {
        public Guid? Id { get; set; }
        public string? EmailAddress { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? PasswordHash { get; set; } 
        public bool? IsActive { get; set; }
        public string? Role { get; set; }

        public string? Fullname
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }
    }
}

