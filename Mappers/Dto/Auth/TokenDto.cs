namespace Nx.Dto.Auth
{
    public class TokenDto
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SessionId { get; set; }
        public string Token { get; set; }
    }
}
