using GongChaWebAPI.Data;
using GongChaWebAPI.Interfaces;
using GongChaWebAPI.Models;

namespace GongChaWebAPI.Repository
{
    public class SizeRepository : ISizeRepository
    {
        private readonly GongChaWebAPIContext _context;
        public SizeRepository(GongChaWebAPIContext context)
        {
            _context = context;
        }
        public ICollection<Size> GetSizes()
        {
            return _context.Size.OrderBy(s => s.Id).ToList();
        }

        public Size GetSize(int id)
        {
            return _context.Size.Where(s => s.Id == id).FirstOrDefault();
        }

        public Size GetSize(string name)
        {
            return _context.Size.Where(s => s.Name == name).FirstOrDefault();
        }
    }
}
