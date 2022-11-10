using PhotoAlbumAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.Abstractions.Services
{
    public interface ICombiningService
    {
        Task<IEnumerable<PhotoAlbumItem>> GetAllPhotoAlbums();
        Task<IEnumerable<PhotoAlbumItem>> GetPhotoAlbumsFromUserId(int id);
        Task<PhotoAlbumItem> GetPhotoAlbumFromAlbumId(int id);
        IEnumerable<PhotoAlbumItem> CombinePhotoAlbums(IEnumerable<AlbumItem> albumItems, IEnumerable<PhotoItem> photoItems);
        IEnumerable<PhotoAlbumItem> CombinePhotoAlbumFromUserId(IEnumerable<AlbumItem> albumItems, IEnumerable<PhotoItem> photoItems, int id);
        PhotoAlbumItem CombinePhotoAlbumFromAlbumId(IEnumerable<AlbumItem> albumItems, IEnumerable<PhotoItem> photoItems, int id);

    }
}
