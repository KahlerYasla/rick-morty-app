
using System.Formats.Asn1;
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

            return Task.FromResult(users);
        }
        public Task<User> GetUserById(int id)
        {
            User user = _repository.GetById(id)!;

            return Task.FromResult(user);
        }
        public Task<User> GetUserByEmail(string email)
        {
            User user = _repository.Find(u => u.Email == email).FirstOrDefault()!;

            return Task.FromResult(user);
        }
        public Task<User> AddUser(User user)
        {
            _repository.Add(user);

            return Task.FromResult(user);
        }
        public Task<User> UpdateUser(User user)
        {
            _repository.Update(user);

            return Task.FromResult(user);
        }
        public Task<User> DeleteUserById(int id)
        {
            User user = _repository.GetById(id)!;
            _repository.Remove(user);

            return Task.FromResult(user);
        }
    }
}