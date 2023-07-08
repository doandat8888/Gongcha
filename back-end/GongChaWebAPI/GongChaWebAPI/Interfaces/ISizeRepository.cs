using GongChaWebAPI.Models;

namespace GongChaWebAPI.Interfaces
{
    public interface ISizeRepository
    {
        ICollection<Size> GetSizes();
        Size GetSize(int id);
        Size GetSize(string name);
    }
}
