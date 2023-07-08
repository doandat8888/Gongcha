using GongChaWebAPI.Models;

namespace GongChaWebAPI.Interfaces
{
    public interface IProductTypeSizeRepository
    {
        ICollection<ProductTypeSize> GetProductTypeSizesByProductId(int productId);
    }
}
