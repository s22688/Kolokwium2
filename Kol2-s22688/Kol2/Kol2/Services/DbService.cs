using Kol2.Models;
using Kol2.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kol2.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;

        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckAlbum(int id)
        {
            var album = await _dbContext.Album.Where(e => e.IdAlbum == id).FirstOrDefaultAsync();
            if (album is null) return true;
            return false;
        }

        public async Task<bool> CheckMusician(int id)
        {
            var tracks = await _dbContext.Track.ToListAsync();
            foreach(Track track in tracks)
            {
                if (track.Album is null) continue;
                var musicInTrack = await _dbContext.Musician_Track.Where(e => e.IdTrack == track.IdTrack).ToListAsync();
                foreach(Musician_Track music in musicInTrack)
                {
                    if (music.IdMusician == id) return true;
                }
            }
            return false;
        }

        public async Task<bool> DeleteMusician(int id)
        {
            using (var tran = await _dbContext.Database.BeginTransactionAsync())
            {

                var musician = await _dbContext.Musician.Where(e => e.IdMusician == id).FirstOrDefaultAsync();

                _dbContext.Remove(musician);

                await _dbContext.SaveChangesAsync();
                await tran.CommitAsync();
                return true;
            }
        }

        public async Task<bool> DoMusicianExists(int id)
        {
            var musician = await _dbContext.Musician.Where(e => e.IdMusician == id).FirstOrDefaultAsync();
            if (musician is null) return true;
            return false;
        }

        public async Task<IEnumerable<SomeSortOfAlbums>> GetAlbum(int id)
        {
            return await _dbContext.Album.Where(e => e.IdAlbum == id)
                .Select(e => new SomeSortOfAlbums
                {
                    AlbumName = e.AlbumName,
                    PublishDate = e.PublishDate,

                    label = new Label { Name = e.MusicLabel.Name},

                    tracks = e.Track.Select(e => new SomeSortOfTracks
                    {
                        TrackName = e.TrackName,
                        Duration = e.Duration
                    }).OrderBy(e => e.Duration).ToList()
                }).ToListAsync();
        }
    }
}
