using GongChaWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace GongChaWebAPI.ViewModel
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
