using domain = Music.Domain.Models;

namespace Music.DataLayer.Contracts.BL
{
    public interface ISongsProvider : ISongsRepository
    {
        domain.Album GetAlbumBySong(int songId);
    }
}
