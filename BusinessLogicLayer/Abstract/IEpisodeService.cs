using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rick_morty_app.EntityLayer.Concrete;

namespace BusinessLogicLayer.Abstract
{
    public interface IEpisodeService
    {
        Task<IEnumerable<Episode>> GetAllEpisodes();
        Task<Episode> GetEpisodeById(int id);
        Task<Episode> AddEpisode(Episode episode);
        Task<Episode> UpdateEpisode(Episode episode);
        Task<Episode> DeleteEpisodeById(int id);
    }
}