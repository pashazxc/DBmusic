﻿using musicDB.models;

namespace musicDB.models
{
    public class AlbumArtist
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}

