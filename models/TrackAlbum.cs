using musicDB.models;

namespace musicDB.models
{
    public class TrackAlbum
    {
        public int Id { get; set; }
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}

