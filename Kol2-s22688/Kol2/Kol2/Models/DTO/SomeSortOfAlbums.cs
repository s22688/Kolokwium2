using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kol2.Models.DTO
{
    public class SomeSortOfAlbums
    {
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        
        public Label label { get; set; }
        public IEnumerable<SomeSortOfTracks> tracks { get; set; }
    }
}
