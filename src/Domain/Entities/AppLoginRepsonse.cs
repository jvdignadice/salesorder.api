namespace Domain.Entities
{
    public class AppLoginRepsonse
    {
        public string? UserName  { get; set; }
        public string? AccessToken { get; set; }
        public int ExpirationTime { get; set; }
    }
}
