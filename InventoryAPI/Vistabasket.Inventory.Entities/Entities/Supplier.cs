using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistaBasket.Common.Repository;

namespace Vistabasket.Inventory.Entities.Entities
{
    public class Supplier : BaseEntity
    {
        public string SupplierName { get; set; }
        public string Contact { get; set; }
        public List<SupplierProduct> SupplierProducts { get; set; }
    }
}
