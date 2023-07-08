using GongChaWebAPI.Models;

namespace GongChaWebAPI.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProduct(int id);
        Product GetProduct(string name);
        ICollection<Product> GetProductsByCategoryId(int categoryId);
        bool Save();
        bool UpdateProduct(Product updatedProduct);
        bool ProductExists(int cateId);
        bool CreateProduct(Product product);
    }
}
