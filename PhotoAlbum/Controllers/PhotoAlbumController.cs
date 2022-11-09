using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoAlbumAPI.Data;
using PhotoAlbumAPI.Services;
using System;
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
        private readonly PhotoAlbumAPIService _photoAlbumApiService;

        public PhotoAlbumController(PhotoAlbumAPIService photoAlbumApiService, ILogger<PhotoAlbumController> logger)
        {
            _photoAlbumApiService = photoAlbumApiService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PhotoAlbumItem> Get()
        {
            return new List<PhotoAlbumItem>();
        }

        [HttpGet("{id}")]
        public PhotoAlbumItem Get(int id)
        {
            return new PhotoAlbumItem();
        }
    }
}
