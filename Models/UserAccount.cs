namespace Restaurent.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Passwork { get; set; }
        public string? Email { get; set; }
        public int Phone { get; set; }
        public int Status { get; set; }
    }
}
