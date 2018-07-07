using MM.Common.Models;
using MM.DataLayer.Contracts;
using System.Collections.Generic;

namespace MM.BusinessLayer.Contracts
{
    public interface ISongsProvider : ISongsRepository
    {
        IEnumerable<SongWithAlbum> GetSongsWithAlbums(int skip, int take);
    }
}
