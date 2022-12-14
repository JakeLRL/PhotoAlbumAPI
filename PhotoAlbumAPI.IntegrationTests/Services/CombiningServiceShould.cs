using FluentAssertions;
using NUnit.Framework;
using PhotoAlbumAPI.Services;
using PhotoAlbumAPI.Services.Clients;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.IntegrationTests.Services
{
    [TestFixture]
    class CombiningServiceShould
    {
        private HttpClient _httpClient;
        private PhotoAlbumAPIClient _photoAlbumApiClient;
        private PhotoAlbumAPIService _photoAlbumApiService;
        private CombiningService _sut;

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
            _photoAlbumApiClient = new PhotoAlbumAPIClient(_httpClient);
            _photoAlbumApiService = new PhotoAlbumAPIService(_photoAlbumApiClient);
            _sut = new CombiningService(_photoAlbumApiService);
        }

        [Test]
        public async Task GivenGetAllPhotoAlbums_ShouldReturnListOfPhotoAlbumItems()
        {
            var photoAlbumItems = await _sut.GetAllPhotoAlbums();
            photoAlbumItems.Should().NotBeNullOrEmpty();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public async Task GivenGetPhotoAlbumsFromUserId_WhenValidUserId_ShouldReturnPhotoAlbumItemsWithUserId(int id)
        {
            var photoAlbumItems = await _sut.GetPhotoAlbumsFromUserId(id);

            foreach(var photoAlbumItem in photoAlbumItems)
            {
                photoAlbumItem.AlbumItem.userId.Should().Be(id);
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public async Task GivenGetPhotoAlbumFromAlbumId_WhenValidUserId_ShouldReturnPhotoAlbumItemWithAlbumId(int id)
        {
            var photoAlbumItem = await _sut.GetPhotoAlbumFromAlbumId(id);

            photoAlbumItem.AlbumItem.id.Should().Be(id);
            foreach(var photoItem in photoAlbumItem.PhotoItems)
            {
                photoItem.albumId.Should().Be(id);
            }
        }
    }
}
