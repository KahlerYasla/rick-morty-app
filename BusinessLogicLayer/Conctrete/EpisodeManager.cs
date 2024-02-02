using BusinessLogicLayer.Abstract;
using DataAccessLayer.Repositories;
using rick_morty_app.DataAccessLayer;
using rick_morty_app.EntityLayer.Concrete;

namespace BusinessLogicLayer.Concrete
{
    public class EpisodeManager : IEpisodeService
    {
        private readonly IGenericRepository<Episode> _repository;

        public EpisodeManager()
        {
            _repository = new GenericRepository<Episode>();
        }

        public Task<Episode> AddEpisode(Episode episode)
        {
            _repository.Add(episode);
            _repository.SaveChanges();

            return Task.FromResult(episode);
        }

        public Task<Episode> DeleteEpisodeById(int id)
        {
            Episode episode = _repository.GetById(id)!;
            _repository.Remove(episode);
            _repository.SaveChanges();

            return Task.FromResult(episode);
        }

        public Task<IEnumerable<Episode>> GetAllEpisodes()
        {
            IEnumerable<Episode> episodes = _repository.GetAll();

            return Task.FromResult(episodes);
        }

        public Task<Episode> GetEpisodeById(int id)
        {
            Episode episode = _repository.GetById(id)!;

            return Task.FromResult(episode);
        }

        public Task<Episode> UpdateEpisode(Episode episode)
        {
            _repository.Update(episode);
            _repository.SaveChanges();

            return Task.FromResult(episode);
        }

    }
}