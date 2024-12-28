using musicDB.models;

namespace musicDB.models
{
    public class TrackArtist
    {
        public int Id { get; set; }
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
