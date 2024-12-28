using musicDB.models;
using System.Collections.Generic;

namespace musicDB.models
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public ICollection<TrackAlbum> TrackAlbums { get; set; }
        public ICollection<TrackArtist> TrackArtists { get; set; }
    }
}

