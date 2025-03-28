using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dmacaspac201.Data.BaseMoodelFolder;

namespace dmacaspac201.Data.Models
{
    public class User : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public UserRole Role { get; set; }
        public int Points { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public ICollection<LoginInfo> LoginInfos { get; set; } = new List<LoginInfo>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
