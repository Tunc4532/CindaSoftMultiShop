using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _mongoCollection;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoryCollection;


        public ProductService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _mongoCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CatagoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _mongoCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var value = await _mongoCollection.Find(x => true).ToListAsync();
            return  _mapper.Map<List<ResultProductDto>>(value);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _mongoCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(value);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
            var values = await _mongoCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Catagory = await _categoryCollection.Find<Category>(x => x.CategoryId==item.CatagoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByCategoryIdAsync(string CategoryId)
        {
            var values = await _mongoCollection.Find(x => x.CatagoryId == CategoryId).ToListAsync();
            foreach (var item in values)
            {
                item.Catagory = await _categoryCollection.Find<Category>(x => x.CategoryId == item.CatagoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);


        }

        public async Task UpdateProducAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _mongoCollection.FindOneAndReplaceAsync(x =>x.ProductId == updateProductDto.ProductId, value);
        }
    }
}
