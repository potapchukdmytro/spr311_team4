using team4.BLL.Dtos.Product;

namespace team4.BLL.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse> CreateAsync(CreateProductDto dto);
        Task<ServiceResponse> UpdateAsync(UpdateProductDto dto);
        Task<ServiceResponse> DeleteAsync(string id);
        ServiceResponse GetAll();
        Task<ServiceResponse> GetByIdAsync(string id);
    }
}
