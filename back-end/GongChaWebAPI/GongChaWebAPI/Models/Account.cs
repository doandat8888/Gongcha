namespace GongChaWebAPI.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string? Img { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string UserTypeId { get; set; }
    }
}
