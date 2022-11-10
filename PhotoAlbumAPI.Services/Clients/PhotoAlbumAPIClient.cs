using PhotoAlbumAPI.Abstractions.Clients;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.Services.Clients
{
    public class PhotoAlbumAPIClient : IPhotoAlbumAPIClient
    {
        private readonly HttpClient _httpClient;

        public PhotoAlbumAPIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetResponseFromApiAsync(string query)
        {
            try
            {
                var requestUri = new Uri($"http://jsonplaceholder.typicode.com/{query}");

                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);

                var response = await _httpClient.SendAsync(httpRequestMessage);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch(Exception ex)
            {
                // TODO: would ideally track or log the exception ex
                throw;
            }
        }
    }
}
