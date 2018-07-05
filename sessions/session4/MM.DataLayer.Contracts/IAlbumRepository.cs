using MM.Common.Models;
using System.Collections.Generic;

namespace MM.DataLayer.Contracts
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> GetAll(int skip = 0, int take = 100);
        Album GetById(int id);
        Album Create(Album album);
        Album Update(Album album);
        bool Delete(Album album);
    }
}
