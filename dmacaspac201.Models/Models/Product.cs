using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmacaspac201.Data.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid StoreId { get; set; }
        public string? Description { get; set; }
        public string? UnitOfMeasure { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Store? Store { get; set; }
    }
}