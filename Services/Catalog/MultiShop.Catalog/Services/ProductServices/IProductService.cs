﻿using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProducAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByCategoryIdAsync(string CategoryId);

    }
}
