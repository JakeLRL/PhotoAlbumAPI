using PhotoAlbumAPI.Data;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.Abstractions.Clients
{
    public interface IPhotoAlbumAPIClient
    {
        Task<string> GetResponseFromApiAsync(string query);
    }
}
