
using MM.Common.Models;
using MM.DataLayer.Contracts;

namespace MM.BusinessLayer.Contracts
{
    public interface IAlbumsProvider : IAlbumRepository
    {
        Album GetAlbumBySongId(int songId);
    }
}
