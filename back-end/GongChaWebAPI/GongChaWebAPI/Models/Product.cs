using System.ComponentModel.DataAnnotations;

namespace GongChaWebAPI.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Img { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        
        public string? Description { get; set; }
        [Required]
        public int Status { get; set; }
    }
}
