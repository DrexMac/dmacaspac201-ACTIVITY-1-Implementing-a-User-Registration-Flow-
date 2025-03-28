using dmacaspac201.Data.BaseMoodelFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmacaspac201.Data.Models
{
    public class LoginInfo : BaseModel
    {
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
