using System.Collections.Generic;

namespace PhotoAlbumAPI.Data
{
    public class PhotoAlbumItem
    {
        AlbumItem AlbumItem { get; set; }
        List<PhotoItem> PhotoItems { get; set; }
    }
}
