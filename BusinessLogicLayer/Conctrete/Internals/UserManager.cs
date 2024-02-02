
using DataAccessLayer.Repositories;
using rick_morty_app.DataAccessLayer;
using rick_morty_app.EntityLayer.Concrete;

namespace BusinessLogicLayer.Abstract.Internals
{
    // Singleton pattern for dashing dependency injection :D
    internal class UserManager : IUserService
    {
        private static UserManager _instance;
        private readonly IGenericRepository<User> _repository;

        private UserManager()
        {
            _repository = new GenericRepository<User>();
        }

        public static UserManager Instance
        {
            get
            {
                _instance ??= new UserManager();
                return _instance;
            }
        }
        public Task<IEnumerable<User>> GetAllUsers()
        {
            IEnumerable<User> users = _repository.GetAll();

            return users;
        }
        public Task<User> GetUserById(int id)
        {
            User user = _repository.GetById(id);

        }
        public Task<User> GetUserByEmail(string email)
        {
        }
        public Task<User> AddUser(User user)
        {
        }
        public Task<User> UpdateUser(User user)
        {
        }
        public Task<User> DeleteUserById(int id)
        {
        }
    }
}