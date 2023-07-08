using GongChaWebAPI.Data;
using GongChaWebAPI.Interfaces;
using GongChaWebAPI.Models;

namespace GongChaWebAPI.Repository
{
    public class ProductTypeSizeRepository : IProductTypeSizeRepository
    {
        private readonly GongChaWebAPIContext _context;
        public ProductTypeSizeRepository(GongChaWebAPIContext context)
        {
            _context = context;
        }
        public ICollection<ProductTypeSize> GetProductTypeSizesByProductId(int productId)
        {
            return _context.ProductTypeSize.Where(pts => pts.ProductId == productId).OrderBy(pts => pts.Id).ToList();
        }
    }
}
