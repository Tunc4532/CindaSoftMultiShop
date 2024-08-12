using MultiShop.Catalog.Dtos.CatagoryDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string CatagoryId { get; set; }
        public ResultCategoryDto Catagory { get; set; }
    }
}
