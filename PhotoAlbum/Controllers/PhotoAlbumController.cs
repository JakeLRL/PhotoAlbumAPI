using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoAlbumAPI.Abstractions.Services;
using PhotoAlbumAPI.Data;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Get()
        {
            var response = await _combiningService.GetAllPhotoAlbums();
            if(response == null || !response.Any())
            {
                return NoContent();
            }
            return Ok(response);
        }

        [HttpGet("albumId/{id}")]
        public async Task<IActionResult> GetAlbumId(int id)
        {
            var response = await _combiningService.GetPhotoAlbumFromAlbumId(id);
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }

        [HttpGet("userId/{id}")]
        public async Task<IActionResult> GetUserId(int id)
        {
            var response = await _combiningService.GetPhotoAlbumsFromUserId(id);
            if (response == null || !response.Any())
            {
                return NoContent();
            }
            return Ok(response);
        }
    }
}
