
using rick_morty_app.EntityLayer.Concrete;

namespace BusinessLogicLayer.Abstract.Internals
{
    public interface IUserService
    {
        // Get
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserById(int id);
        public Task<User> GetUserByEmail(string email);

        // Post
        public Task<User> AddUser(User user);

        // Put
        public Task<User> UpdateUser(User user);

        // Delete
        public Task<User> DeleteUserById(int id);

        // Custom
        public Task<IEnumerable<Character>> GetUserFavouriteCharactersByUserId(int id);
        public Task<User> AddFavouriteCharacterToUser(int userId, string characterName);
        public Task<User> RemoveFavouriteCharacterFromUser(int userId, string characterName);
    }
}