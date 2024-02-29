using Microsoft.AspNetCore.Http;

namespace VistaBasket.Web.Models.Catalog
{
    public class ProductDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile ProductImage { get; set; }
        public string CategoryId { get; set; }
        public string BrandId { get; set; }
        public int AvailableStock { get; set; }
    }


}
