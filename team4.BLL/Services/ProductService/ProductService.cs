using AutoMapper;
using team4.BLL.Dtos.Product;
using team4.DAL.Entities;
using team4.DAL.Repositories.Product;

namespace team4.BLL.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ImageService _imageService;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, ImageService imageService, IMapper mapper)
        {
            _productRepository = productRepository;
            _imageService = imageService;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> CreateAsync(CreateProductDto dto)
        {
            var entity = _mapper.Map<ProductEntity>(dto);
            var category = await _categoryRepository.GetByNameAsync(dto.Category);

            if (category == null)
                return ServiceResponse.Error("Categoty not found");

            entity.Category = category;

            if(dto.Image != null)
                entity.Image = await _imageService.SaveImageAsync(dto.Image);

            bool result = await _productRepository.CreateAsync(entity);
            return ServiceResponse.FromResult(result, "The product has been created successfully", "Error during creation");
        }

        public async Task<ServiceResponse> DeleteAsync(string id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            if (entity == null)
                return ServiceResponse.Error("Product not found");

            bool result = await _productRepository.DeleteAsync(entity);
            return ServiceResponse.FromResult(result, "Product successfully removed", "Error during uninstallation");
        }

        public ServiceResponse GetAll()
        {
            var entities = _productRepository.GetAll();

            var dtos = _mapper.Map<List<ProductDto>>(entities);

            return ServiceResponse.Success("Products received", dtos);
        }

        public async Task<ServiceResponse> GetByIdAsync(string id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            if (entity == null)
                return ServiceResponse.Error("Product not found");

            var dto = _mapper.Map<ProductDto>(entity);

            return ServiceResponse.Success("Product received", dto);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateProductDto dto)
        {
            var entity = await _productRepository.GetByIdAsync(dto.Id);
            if (entity == null)
                return ServiceResponse.Error("Product not found");

            entity = _mapper.Map(dto, entity);

            bool result = await _productRepository.UpdateAsync(entity);
            return ServiceResponse.FromResult(result, "The product has been updated", "Error during update");
        }
    }
}
