using Kol2.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kol2.Services
{
    public interface IDbService
    {
        public Task<IEnumerable<SomeSortOfAlbums>> GetAlbum(int id);
        public Task<bool> CheckAlbum(int id);
        public Task<bool> DeleteMusician(int id);
        public Task<bool> CheckMusician(int id);
        public Task<bool> DoMusicianExists(int id);
    }
}
