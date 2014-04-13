using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class PlaylistModel
    {
        public int PlaylistID { get; set; }

        public string PlaylistName { get; set; }

        public List<SongModel> Songs { get; set; }
    }
}
