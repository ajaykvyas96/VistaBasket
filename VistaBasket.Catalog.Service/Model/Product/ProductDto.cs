using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaBasket.Catalog.Service.Model.Product
{
    public class ProductDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int AvailableStock { get; set; }
    }
}
