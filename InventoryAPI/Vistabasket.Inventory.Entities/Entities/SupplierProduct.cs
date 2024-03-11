using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistaBasket.Common.Repository;

namespace Vistabasket.Inventory.Entities.Entities
{
    public class SupplierProduct : BaseEntity
    {
        public Guid SupplierID { get; set; }
        public Guid ProductID { get; set;}
        public decimal CostPrice { get; set; }
        public int LeadTime { get; set; }   
        // Navigation properties
        public Supplier Supplier { get; set; }
    }
}
