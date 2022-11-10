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

        public async Task<IEnumerable<PhotoAlbumItem>> GetPhotoAlbumsFromUserId(int id)
        {
            var albumItems = await _photoAlbumApiService.GetAlbumItemsAsync();
            var photoItems = await _photoAlbumApiService.GetPhotoItemsAsync();

            return CombinePhotoAlbumFromUserId(albumItems, photoItems, id);
        }

        public async Task<PhotoAlbumItem> GetPhotoAlbumFromAlbumId(int id)
        {
            var albumItems = await _photoAlbumApiService.GetAlbumItemsAsync();
            var photoItems = await _photoAlbumApiService.GetPhotoItemsAsync();

            return CombinePhotoAlbumFromAlbumId(albumItems, photoItems, id);
        }

        public IEnumerable<PhotoAlbumItem> CombinePhotoAlbums(IEnumerable<AlbumItem> albumItems, IEnumerable<PhotoItem> photoItems)
        {
            var combinedPhotoAlbum = albumItems
                .Select(a => new PhotoAlbumItem
                {
                    AlbumItem = a,
                    PhotoItems = photoItems.Where(p => p.albumId == a.id).ToList()
                });
            if (combinedPhotoAlbum == null || !combinedPhotoAlbum.Any())
            {
                //TODO: Throw exception or a http not found response
            }
            return combinedPhotoAlbum;
        }

        public IEnumerable<PhotoAlbumItem> CombinePhotoAlbumFromUserId(IEnumerable<AlbumItem> albumItems, IEnumerable<PhotoItem> photoItems, int id)
        {
            var combinedPhotoAlbum = albumItems
                .Where(a => a.userId == id)
                .Select(a => new PhotoAlbumItem
                {
                    AlbumItem = a,
                    PhotoItems = photoItems.Where(p => p.albumId == a.id).ToList()
                });
            if (combinedPhotoAlbum == null || !combinedPhotoAlbum.Any())
            {
                //TODO: Throw exception or a http not found response
            }
            return combinedPhotoAlbum;
        }

        public PhotoAlbumItem CombinePhotoAlbumFromAlbumId(IEnumerable<AlbumItem> albumItems, IEnumerable<PhotoItem> photoItems, int id)
        {
            var photoAlbum = new PhotoAlbumItem
            {
                AlbumItem = albumItems.Where(a => a.id == id).FirstOrDefault(),
                PhotoItems = photoItems.Where(p => p.albumId == id).ToList()
            };
            if (photoAlbum == null)
            {
                //TODO: Throw exception or a http not found response
            }
            return photoAlbum;
        }


    }
}
