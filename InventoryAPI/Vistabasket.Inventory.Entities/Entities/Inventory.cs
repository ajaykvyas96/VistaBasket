using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistaBasket.Common.Repository;

namespace Vistabasket.Inventory.Entities.Entities
{
    public class ProductInventory : BaseEntity
    {
        public Guid ProductId { get; set; }
        public int QuantityOnHand { get; set; }
        public int ReservedQuantity { get; set; }
    }
}
