using team4.DAL.Entities;

namespace team4.DAL.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(ProductEntity entity)
        {
            await _context.Products.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(ProductEntity entity)
        {
            _context.Products.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public IEnumerable<ProductEntity> GetAll()
            =>  _context.Products;

        public async Task<ProductEntity?> GetByIdAsync(string id)
            => await _context.Products.Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<bool> UpdateAsync(ProductEntity entity)
        {
            _context.Products.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
