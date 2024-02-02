using BusinessLogicLayer.Abstract;
using CoreInfrastructureLayer.Helpers;

namespace BusinessLogicLayer.Conctrete
{
    public class AuthManager : IAuthService
    {


        public bool Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public string GenerateToken(string? username, string? email, string secretRaw, TimeSpan tokenExpiration)
        {
            if (username == null || email == null) return "Username or email cannot be null!";

            if (secretRaw == null) throw new ArgumentNullException(nameof(secretRaw));
            if (tokenExpiration <= TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(tokenExpiration));

            string tokenGenerated = JwtTokenGenerator.GenerateToken(username!, email!, secretRaw, tokenExpiration);

            return tokenGenerated;
        }

        public string Register(string username, string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}