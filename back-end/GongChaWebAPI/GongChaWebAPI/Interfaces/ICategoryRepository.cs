using GongChaWebAPI.Models;

namespace GongChaWebAPI.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        Category GetCategory(string name);
        bool CategoryExists(int cateId);
    }
}
