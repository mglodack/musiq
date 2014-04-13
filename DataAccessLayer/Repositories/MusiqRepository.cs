using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class MusiqRepository
    {
        private MusiqEntities _context { get; set; }

        public MusiqRepository()
        {
            _context = new MusiqEntities();
        }

        public IQueryable<SongModel> GetSongs()
        {
            return _context.Songs.Select(s => new SongModel
            {
                SongID = s.Id,
                SongTitle = s.Title,
                Artist = s.Artist,
                Album = s.Album,
                Genre = s.Genre,
                FilePath = s.FilePath,
                Length = s.Length,
                Likes = s.Likes,
                ArtworkURL = s.ArtworkURL
            });
        }
    }
}
