using PhotoAlbumAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.Abstractions.Services
{
    public interface IPhotoAlbumAPIService
    {
        Task<IEnumerable<AlbumItem>> GetAlbumItemsAsync();
        Task<IEnumerable<PhotoItem>> GetPhotoItemsAsync();
    }
}
