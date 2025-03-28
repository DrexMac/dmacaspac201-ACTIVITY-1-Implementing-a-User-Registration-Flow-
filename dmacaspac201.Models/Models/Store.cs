using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmacaspac201.Data.Models
{
    public class Store
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public User? User { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}