using Newtonsoft.Json;
using PhotoAlbumAPI.Abstractions.Clients;
using PhotoAlbumAPI.Abstractions.Services;
using PhotoAlbumAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.Services
{
    public class PhotoAlbumAPIService : IPhotoAlbumAPIService
    {
        private readonly IPhotoAlbumAPIClient _photoAlbumApiClient;

        public PhotoAlbumAPIService(IPhotoAlbumAPIClient photoAlbumApiClient)
        {
            _photoAlbumApiClient = photoAlbumApiClient;
        }

        public async Task<IEnumerable<AlbumItem>> GetAlbumItemsAsync()
        {
            try
            {
                var responseContent = await _photoAlbumApiClient.GetResponseFromApiAsync("albums");
                return JsonConvert.DeserializeObject<List<AlbumItem>>(responseContent);
            }
            catch (Exception ex)
            {
                // TODO: track exception here 
                throw;
            }
        }

        public async Task<IEnumerable<PhotoItem>> GetPhotoItemsAsync()
        {
            try
            {
                var responseContent = await _photoAlbumApiClient.GetResponseFromApiAsync("photos");
                return JsonConvert.DeserializeObject<List<PhotoItem>>(responseContent);
            }
            catch (Exception ex)
            {
                // TODO: track exception here 
                throw;
            }
        }
    }
}
