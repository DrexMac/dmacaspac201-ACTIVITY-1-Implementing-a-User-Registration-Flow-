using dmacaspac201.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmacaspac201.Data.BaseMoodelFolder
{
    public class BaseModel
    {
        public Guid Id { get; set; }

        public string? EmailAddress { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
