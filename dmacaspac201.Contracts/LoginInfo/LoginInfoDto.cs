using dmacaspac201.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmacaspac201.Contracts.LoginInfo
{
    public class LoginInfoDto
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public User? User { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsActive { get; set; }

    }
}
