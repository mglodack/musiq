using DataAccessLayer.Conversions;
using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
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

        public void Add(SongModel model)
        {
            try
            {
                Account account;

                //Convert the SongModel into an entity to be pushed to the database.
                Song entity = ModelConversions.SongModelToEntity(model);

                //If there is an account that matches the given username, set account equal to it.
                if (_context.Accounts.Any(a => a.Username == model.Username))
                {
                    account = _context.Accounts.First(a => a.Username == model.Username);
                }
                //Else, create an Account with the username
                else
                {
                    account = new Account() { Username = model.Username };
                }

                //Add the account association to the song, and push the song to the database
                entity.Accounts.Add(account);
                _context.Songs.Add(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

    }
}
