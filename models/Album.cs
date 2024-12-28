using musicDB.models;
using System.Collections.Generic;

namespace musicDB.models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TrackCount { get; set; }
        public int Duration { get; set; }
        public ICollection<AlbumArtist> AlbumArtists { get; set; }
        public ICollection<TrackAlbum> TrackAlbums { get; set; }
    }
}

