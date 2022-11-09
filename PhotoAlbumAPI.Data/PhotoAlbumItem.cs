using System.Collections.Generic;

namespace PhotoAlbumAPI.Data
{
    public class PhotoAlbumItem
    {
        public AlbumItem AlbumItem { get; set; }
        public List<PhotoItem> PhotoItems { get; set; }
    }
}
