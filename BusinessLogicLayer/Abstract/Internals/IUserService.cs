
using rick_morty_app.EntityLayer.Concrete;

namespace BusinessLogicLayer.Abstract.Internals
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserById(int id);
        public Task<User> GetUserByEmail(string email);
        public Task<User> AddUser(User user);
        public Task<User> UpdateUser(User user);
        public Task<User> DeleteUserById(int id);
    }
}