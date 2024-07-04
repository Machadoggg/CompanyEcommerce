namespace Company.Ecommerce.Application.DTO
{
    public class UsersDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string UsrName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}
