
using System.Formats.Asn1;
using BusinessLogicLayer.Abstract.Internals;
using DataAccessLayer.Repositories;
using rick_morty_app.DataAccessLayer;
using rick_morty_app.EntityLayer.Concrete;

namespace BusinessLogicLayer.Concrete.Internals
{
    // Singleton pattern for internal usage
    public class UserManager : IUserService
    {
        private static UserManager? _instance;
        private static readonly object _lock = new();
        private readonly IGenericRepository<User> _repository;

        private UserManager()
        {
            _repository = new GenericRepository<User>();
        }

        public static UserManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance ??= new UserManager();
                    }
                }
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

        public Task<IEnumerable<Character>> GetUserFavouriteCharactersByUserId(int id)
        {
            User user = _repository.GetById(id)!;
            IEnumerable<Character> characters = user.FavoriteCharacters;

            return Task.FromResult(characters);
        }

        public Task<User> AddUser(User user)
        {
            _repository.Add(user);
            _repository.SaveChanges();

            return Task.FromResult(user);
        }

        public Task<User> UpdateUser(User user)
        {
            _repository.Update(user);
            _repository.SaveChanges();

            return Task.FromResult(user);
        }

        public Task<User> DeleteUserById(int id)
        {
            User user = _repository.GetById(id)!;
            _repository.Remove(user);
            _repository.SaveChanges();

            return Task.FromResult(user);
        }
    }
}