using System.ComponentModel.DataAnnotations;

namespace VistaBasket.Web.Models.Catalog
{
    public class BrandDto
    {
        public string? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
