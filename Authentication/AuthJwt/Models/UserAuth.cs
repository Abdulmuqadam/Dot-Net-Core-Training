namespace AuthJwt.Models
{
    public class UserAuth
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
        public string UserRole { get; set; }
    }
}
