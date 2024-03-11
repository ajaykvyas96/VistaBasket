using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VistaBasket.Common.Repository;

namespace VistaBasket.Catalog.Entities.Entities
{
    public class Brand : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
