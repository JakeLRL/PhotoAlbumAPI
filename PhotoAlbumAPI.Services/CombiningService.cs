using PhotoAlbumAPI.Abstractions.Services;
using PhotoAlbumAPI.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.Services
{
    public class CombiningService : ICombiningService
    {
        private readonly IPhotoAlbumAPIService _photoAlbumApiService;

        public CombiningService(IPhotoAlbumAPIService photoAlbumApiService)
        {
            _photoAlbumApiService = photoAlbumApiService;
        }

        public async Task<IEnumerable<PhotoAlbumItem>> GetAllPhotoAlbums()
        {
            var albumItems = await _photoAlbumApiService.GetAlbumItemsAsync();
            var photoItems = await _photoAlbumApiService.GetPhotoItemsAsync();

            return CombinePhotoAlbums(albumItems, photoItems);
        }

        public async Task<PhotoAlbumItem> GetPhotoAlbumFromId(int id)
        {
            var albumItems = await _photoAlbumApiService.GetAlbumItemsAsync();
            var photoItems = await _photoAlbumApiService.GetPhotoItemsAsync();

            return CombinePhotoAlbumFromId(albumItems, photoItems, id);
        }

        public IEnumerable<PhotoAlbumItem> CombinePhotoAlbums(IEnumerable<AlbumItem> albumItems, IEnumerable<PhotoItem> photoItems)
        {
            var combinedPhotoAlbum = albumItems
                .Select(a => new PhotoAlbumItem
                {
                    AlbumItem = a,
                    PhotoItems = photoItems.Where(p => p.albumId == a.id).ToList()
                });
            return combinedPhotoAlbum;
        }

        public PhotoAlbumItem CombinePhotoAlbumFromId(IEnumerable<AlbumItem> albumItems, IEnumerable<PhotoItem> photoItems, int id)
        {
            return new PhotoAlbumItem
            {
                AlbumItem = albumItems.Where(a => a.id == id).FirstOrDefault(),
                PhotoItems = photoItems.Where(p => p.albumId == id).ToList()
            };
        }
    }
}
