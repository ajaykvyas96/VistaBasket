namespace VistaBasket.Web.Models.Catalog
{
    public class ProductResponseDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] ImageBlob { get; set; }
        public string CategoryId { get; set; }
        public string BrandId { get; set; }
        public int AvailableStock { get; set; }
    }
}
