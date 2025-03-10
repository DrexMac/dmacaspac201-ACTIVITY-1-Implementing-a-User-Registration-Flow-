using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmacaspac201.Models
{
    public class LoginInfo
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? LoginType { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public User? User { get; set; }
    }
}
