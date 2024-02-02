using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Abstract.Internals;
using BusinessLogicLayer.Concrete.Internals;
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

        public string Unregister(string email)
        {
            User user = _userService.GetUserByEmail(email).Result;

            _userService.DeleteUserById(user.Id);

            return "User unregistered successfully!";
        }

        public string UpdatePassword(string email, string newPassword)
        {
            User user = _userService.GetUserByEmail(email).Result;

            user.Password = newPassword;

            _userService.UpdateUser(user);

            return "Password updated successfully!";
        }

        public string UpdateUsername(string email, string newUsername)
        {
            User user = _userService.GetUserByEmail(email).Result;

            user.Name = newUsername;

            _userService.UpdateUser(user);

            return "Username updated successfully!";
        }

        public string UpdateEmail(string email, string newEmail)
        {
            User user = _userService.GetUserByEmail(email).Result;

            user.Email = newEmail;

            _userService.UpdateUser(user);

            return "Email updated successfully!";
        }

        public string UpdateUser(string email, string newUsername, string newEmail, string newPassword)
        {
            User user = _userService.GetUserByEmail(email).Result;

            user.Name = newUsername;
            user.Email = newEmail;
            user.Password = newPassword;

            _userService.UpdateUser(user);

            return "User updated successfully!";
        }
    }
}