using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLogicLayer
{
    public class BusinessLogicLayer
    {
        private MusiqRepository _context { get; set; }

        public BusinessLogicLayer()
        {
            _context = new MusiqRepository();
        }

        public List<SongModel> GetSongs()
        {
            var list = _context.GetSongs().ToList();
            return list;
        }

        public List<SongModel> GetSongs(int numberOfSongs)
        {
            var list = _context.GetSongs().Take(numberOfSongs).ToList();
            return list;
        }
    }
}
