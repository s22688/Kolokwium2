using Microsoft.EntityFrameworkCore;
using System;

namespace Kol2.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Album> Album { get; set; }
        public DbSet<Musician> Musician { get; set; }
        public DbSet<Musician_Track> Musician_Track { get; set; }
        public DbSet<MusicLabel> MusicLabel { get; set; }
        public DbSet<Track> Track { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musician>(e =>
            {
                e.HasKey(e => e.IdMusician);
                e.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                e.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                e.Property(e => e.NickName).HasMaxLength(20);

                e.HasData(
                    new Musician {IdMusician = 1, FirstName = "Jakub", LastName = "Leniwy", NickName = "Tuba" },
                    new Musician {IdMusician = 2, FirstName = "Stefan", LastName = "Twardy", NickName = "Buba" },
                    new Musician {IdMusician = 3, FirstName = "Stefan", LastName = "Zeromski", NickName = "Kuba" }
                    );
              
            });

            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).IsRequired().HasMaxLength(50);

                e.HasData(
                    new MusicLabel { IdMusicLabel = 1, Name = "SPRecords1"},
                    new MusicLabel { IdMusicLabel = 2, Name = "SPRecords2"},
                    new MusicLabel { IdMusicLabel = 3, Name = "SPRecords3"}
                    );
                
            });

            modelBuilder.Entity<Album>(e =>
            {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                e.Property(e => e.PublishDate).IsRequired();

                e.HasOne(e => e.MusicLabel).WithMany(e => e.Album).HasForeignKey(e => e.IdMusicLabel);

                e.HasData(
                    new Album { IdAlbum = 1, AlbumName = "Duze miasto w wannie", PublishDate = DateTime.Parse("2000-01-25"), IdMusicLabel = 2 },
                    new Album { IdAlbum = 2, AlbumName = "Slon w smietanie", PublishDate = DateTime.Parse("2013-09-27"), IdMusicLabel = 3 }
                    );
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                e.Property(e => e.Duration).IsRequired();

                e.HasOne(e => e.Album).WithMany(e => e.Track).HasForeignKey(e => e.IdMusicAlbum);

                e.HasData(
                    new Track { IdTrack = 1, TrackName = "Zoo1", Duration = 4.7f, IdMusicAlbum = 2},
                    new Track { IdTrack = 2, TrackName = "Zoo4", Duration = 3.7f, IdMusicAlbum = 1}
                    );

            });

            modelBuilder.Entity<Musician_Track>(e =>
            {
                e.HasKey(e => new { e.IdMusician, e.IdTrack});

                e.HasOne(e => e.Musician).WithMany(e => e.Musician_Track).HasForeignKey(e => e.IdMusician);
                e.HasOne(e => e.Track).WithMany(e => e.Musician_Track).HasForeignKey(e => e.IdTrack);

                e.HasData(
                    new Musician_Track { IdTrack = 1, IdMusician = 1},
                    new Musician_Track { IdTrack = 2, IdMusician = 2}
                    );
            });

        }


    }
}
