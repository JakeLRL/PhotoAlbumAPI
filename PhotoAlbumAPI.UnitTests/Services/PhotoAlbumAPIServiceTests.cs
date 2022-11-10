using FluentAssertions;
using Moq;
using NUnit.Framework;
using PhotoAlbumAPI.Abstractions.Clients;
using PhotoAlbumAPI.Services;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.UnitTests.Services
{
    [TestFixture]
    class PhotoAlbumAPIServiceTests
    {
        [SetUp]
        public void Setup()
        {
            // would set up a mock telemetry here, but not implemented
        }

        [Test]
        public async Task GetAlbumItemsAsync_GivenValidRequest_ShouldReturnListOfAlbumItemsAsync()
        {
            var query = "albums";
            var albumId = 1;
            var response = $"[{{\"userId\": 1,\"id\": {albumId},\"title\": \"quidem molestiae enim\"}}]";
            var client = new Mock<IPhotoAlbumAPIClient>();
            client.Setup(x => x.GetResponseFromApiAsync(query)).ReturnsAsync(response);

            var sut = new PhotoAlbumAPIService(client.Object);
            var albumItems = await sut.GetAlbumItemsAsync();

            albumItems.Should().NotBeNullOrEmpty();
            albumItems.ToList().Count.Should().Be(1);
            albumItems.First().id.Should().Be(albumId);
        }

        [Test]
        public async Task GetPhotoItemsAsync_GivenValidRequest_ShouldReturnListOfPhotoItemsAsync()
        {
            var query = "photos";
            var photoId = 1;
            var response = $"[{{\"albumId\": 1,\"id\": {photoId},\"title\": \"a title\",\"url\": \"https://via.placeholder.com/600/92c952\",\"thumbnailUrl\": \"https://via.placeholder.com/150/92c952\"}}]";
            var client = new Mock<IPhotoAlbumAPIClient>();
            client.Setup(x => x.GetResponseFromApiAsync(query)).ReturnsAsync(response);

            var sut = new PhotoAlbumAPIService(client.Object);
            var photoItems = await sut.GetPhotoItemsAsync();

            photoItems.Should().NotBeNullOrEmpty();
            photoItems.ToList().Count.Should().Be(1);
            photoItems.First().id.Should().Be(photoId);
        }
    }
}
