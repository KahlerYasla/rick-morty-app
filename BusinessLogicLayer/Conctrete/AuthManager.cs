using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Abstract.Internals;
using CoreInfrastructureLayer.Helpers;
using rick_morty_app.EntityLayer.Concrete;

namespace BusinessLogicLayer.Conctrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;

        public AuthManager()
        {
            _userService = UserManager.Instance;
        }

        public bool Authenticate(string username, string password)
        {
            User user = _userService.GetUserByEmail(username).Result;

            if (user == null) return false;

            bool isAuthenticated = user.Password == password;

            return isAuthenticated;
        }

        public string GenerateToken(string? username, string? email, string secretRaw, TimeSpan tokenExpiration)
        {
            if (username == null || email == null) return "Username or email cannot be null!";

            if (secretRaw == null) throw new ArgumentNullException(nameof(secretRaw));
            if (tokenExpiration <= TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(tokenExpiration));

            string tokenGenerated = JwtTokenGenerator.GenerateToken(username!, email!, secretRaw, tokenExpiration);

            return tokenGenerated;
        }

        public string Register(string name, string email, string password)
        {
            User user = new(name, email, password);

            _userService.AddUser(user);

            return "User registered successfully!";
        }
    }
}