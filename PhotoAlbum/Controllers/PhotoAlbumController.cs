using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoAlbumAPI.Abstractions.Services;
using PhotoAlbumAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoAlbumController : ControllerBase
    {

        private readonly ILogger<PhotoAlbumController> _logger;
        private readonly ICombiningService _combiningService;

        public PhotoAlbumController(ICombiningService combiningService, ILogger<PhotoAlbumController> logger)
        {
            _combiningService = combiningService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<PhotoAlbumItem>> Get()
        {
            return await _combiningService.GetAllPhotoAlbums();
        }

        [HttpGet("{id}")]
        public async Task<PhotoAlbumItem> Get(int id)
        {
            return await _combiningService.GetPhotoAlbumFromId(id);
        }
    }
}
