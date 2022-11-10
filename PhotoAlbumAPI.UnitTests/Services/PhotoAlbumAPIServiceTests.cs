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

        }

        [Test]
        public async Task GetAlbumItemsAsync_GivenValidRequest_ShouldReturnListOfAlbumItemsAsync()
        {
            var query = "albums";
            var response = "[{\"userId\": 1,\"id\": 1,\"title\": \"quidem molestiae enim\"}]";
            var client = new Mock<IPhotoAlbumAPIClient>();
            client.Setup(x => x.GetResponseFromApiAsync(query)).ReturnsAsync(response);

            var sut = new PhotoAlbumAPIService(client.Object);
            var albumItem = await sut.GetAlbumItemsAsync();

            albumItem.Should().NotBeNullOrEmpty();
            albumItem.ToList().Count.Should().Be(1);
        }
    }
}
