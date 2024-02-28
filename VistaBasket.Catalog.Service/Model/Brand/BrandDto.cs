using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaBasket.Catalog.Service.Model.Brand
{
    public class BrandDto
    {
        public string? Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
