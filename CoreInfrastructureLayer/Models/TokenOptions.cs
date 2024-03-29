namespace CoreInfrastructureLayer.Models
{
    public class TokenOptions
    {
        public required string Audience { get; set; }
        public required string Issuer { get; set; }
        public int AccessTokenExpriation { get; set; }
        public required string SecurityKey { get; set; }
    }
}