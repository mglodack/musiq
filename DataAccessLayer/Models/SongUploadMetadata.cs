using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class SongUploadMetadata
    {
        public string SongTitle { get; set; }
        public int size { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }

        public string Length { get; set; }

    }
}
