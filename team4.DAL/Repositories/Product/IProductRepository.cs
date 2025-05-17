using team4.DAL.Entities;

namespace team4.DAL.Repositories.Product
{
    public interface IProductRepository
    {
        Task<bool> CreateAsync(ProductEntity entity);
        Task<bool> UpdateAsync(ProductEntity entity);
        Task<bool> DeleteAsync(ProductEntity entity);
        Task<ProductEntity?> GetByIdAsync(string id);
        IEnumerable<ProductEntity> GetAll();
    }
}
