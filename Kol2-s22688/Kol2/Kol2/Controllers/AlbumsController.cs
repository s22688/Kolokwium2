using Kol2.Models.DTO;
using Kol2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kol2.Controllers
{
    [Route("api")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public AlbumsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<SomeSortOfAlbums>> GetAlbum(int id)
        {
            if(id == null) return null;
            if (await _dbService.CheckAlbum(id)) return null;

            return await _dbService.GetAlbum(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusician(int id)
        {
            if(id == null) return BadRequest("Nie podano id!");
            if (await _dbService.DoMusicianExists(id)) return BadRequest("Muzyk o podanym id nie istnieje!");
            if (await _dbService.CheckMusician(id)) return BadRequest("Muzyk ma już zapisane utwory w albumach!");
            if (await _dbService.DeleteMusician(id)) return BadRequest("Usunieto muzyka z bazy");
            else return BadRequest("Operacja usuwania sie nie powiodla!");

        } 
    }
}
