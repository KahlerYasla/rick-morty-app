using BusinessLogicLayer.Abstract;
using DataAccessLayer.Repositories;
using rick_morty_app.DataAccessLayer;
using rick_morty_app.EntityLayer.Concrete;

namespace BusinessLogicLayer.Concrete
{
    public class CharacterManager : ICharacterService
    {
        private readonly IGenericRepository<Character> _repository;

        public CharacterManager()
        {
            _repository = new GenericRepository<Character>();
        }

        public Task<Character> AddCharacter(Character character)
        {
            _repository.Add(character);
            _repository.SaveChanges();

            return Task.FromResult(character);
        }

        public Task<Character> DeleteCharacterById(int id)
        {
            Character character = _repository.GetById(id)!;
            _repository.Remove(character);
            _repository.SaveChanges();

            return Task.FromResult(character);
        }

        public Task<IEnumerable<Character>> GetAllCharacters()
        {
            IEnumerable<Character> characters = _repository.GetAll();

            return Task.FromResult(characters);
        }

        public Task<Character> GetCharacterById(int id)
        {
            Character character = _repository.GetById(id)!;

            return Task.FromResult(character);
        }

        public Task<Character> UpdateCharacter(Character character)
        {
            _repository.Update(character);
            _repository.SaveChanges();

            return Task.FromResult(character);
        }
    }
}