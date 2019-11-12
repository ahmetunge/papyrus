namespace Core.Utilities.Security.JWT
{
    public class JwtTokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }

        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}