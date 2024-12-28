using Microsoft.EntityFrameworkCore;
using musicDB.models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace musicDB.data
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<TrackAlbum> TrackAlbums { get; set; }
        public DbSet<AlbumArtist> AlbumArtists { get; set; }
        public DbSet<TrackArtist> TrackArtists { get; set; }

        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrackAlbum>()
                .HasOne(ta => ta.Track)
                .WithMany(t => t.TrackAlbums)
                .HasForeignKey(ta => ta.TrackId);

            modelBuilder.Entity<TrackAlbum>()
                .HasOne(ta => ta.Album)
                .WithMany(a => a.TrackAlbums)
                .HasForeignKey(ta => ta.AlbumId);

            modelBuilder.Entity<AlbumArtist>()
                .HasOne(aa => aa.Album)
                .WithMany(a => a.AlbumArtists)
                .HasForeignKey(aa => aa.AlbumId);

            modelBuilder.Entity<AlbumArtist>()
                .HasOne(aa => aa.Artist)
                .WithMany(ar => ar.AlbumArtists)
                .HasForeignKey(aa => aa.ArtistId);

            modelBuilder.Entity<TrackArtist>()
                .HasOne(ta => ta.Track)
                .WithMany(t => t.TrackArtists)
                .HasForeignKey(ta => ta.TrackId);

            modelBuilder.Entity<TrackArtist>()
                .HasOne(ta => ta.Artist)
                .WithMany(ar => ar.TrackArtists)
                .HasForeignKey(ta => ta.ArtistId);
        }
    }
}

