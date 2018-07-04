using Music.Domain.Models;
using System.Collections.Generic;

namespace Music.DataLayer.Contracts
{
    public interface ISongsRepository : ISongsReadOnlyRepository
    {
        Song Create(Song song);
        Song Update(Song song);
        bool Delete(Song song);
    }

    public interface ISongsReadOnlyRepository
    {
        Song GetById(int id);
        IEnumerable<Song> GetAll(uint skip = 0, uint take = 100);
    }
}
