using GongChaWebAPI.Data;
using GongChaWebAPI.Interfaces;
using GongChaWebAPI.Models;

namespace GongChaWebAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly GongChaWebAPIContext _context;
        public ProductRepository(GongChaWebAPIContext context) { 
            _context = context;
        }

        public Product GetProduct(int id)
        {
            return _context.Product.Where(p => p.Id == id).FirstOrDefault();
        }

        public Product GetProduct(string name)
        {
            return _context.Product.Where(p => p.Name == name).FirstOrDefault();
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Product.OrderBy(p => p.Id).ToList();
        }

        public ICollection<Product> GetProductsByCategoryId(int categoryId)
        {
            return _context.Product.Where(p => p.CategoryId == categoryId).OrderBy(p => p.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateProduct(Product product)
        {
            _context.Add(product);
            return Save();
        }

        public bool UpdateProduct(Product updatedProduct)
        {
            _context.Update(updatedProduct);
            return Save();
        }

        public bool ProductExists(int proId)
        {
            return _context.Product.Any(p => p.Id == proId);
        }

    }
}
