using PhotoAlbumAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.Abstractions.Services
{
    public interface ICombiningService
    {
        Task<IEnumerable<PhotoAlbumItem>> GetAllPhotoAlbums();
        Task<PhotoAlbumItem> GetPhotoAlbumFromId(int id);
        IEnumerable<PhotoAlbumItem> CombinePhotoAlbums(IEnumerable<AlbumItem> albumItems, IEnumerable<PhotoItem> photoItems);
        PhotoAlbumItem CombinePhotoAlbumFromId(IEnumerable<AlbumItem> albumItems, IEnumerable<PhotoItem> photoItems, int id);

    }
}
