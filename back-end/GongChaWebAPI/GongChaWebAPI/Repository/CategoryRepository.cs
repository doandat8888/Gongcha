using GongChaWebAPI.Data;
using GongChaWebAPI.Interfaces;
using GongChaWebAPI.Models;

namespace GongChaWebAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GongChaWebAPIContext _context;

        public CategoryRepository(GongChaWebAPIContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int cateId)
        {
            return _context.Category.Any(c => c.Id == cateId);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Category.OrderBy(c => c.Id).ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Category.Where(c => c.Id == id).FirstOrDefault();
        }

        public Category GetCategory(string name)
        {
            return _context.Category.Where(c => c.Name == name).FirstOrDefault();
        }
    }
}
