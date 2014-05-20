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
            var list = _context.GetSongs();
            if (list != null)
            {
                return list.ToList();
            }        
            else
            {
                return null;
            }
        }

        public List<SongModel> GetSongs(int numberOfSongs)
        {
            var list = _context.GetSongs().Take(numberOfSongs).ToList();
            return list;
        }

        public bool SongExists(string filename)
        {
            return GetSongs().Any(s => s.FilePath == filename);
        }

        public void Add(SongModel song)
        {
            _context.Add(song);
        }

        public SongModel GetSong(string fileName)
        {
            SongModel song = _context.GetSongs().FirstOrDefault(s => s.FilePath == fileName);
            return song;
        }

        /**Login**/
        public bool AccountExist(string username)
        {
            return GetAccounts().Any(s => s.Username == username);
        }
        public bool AccountExist(string username, string password)
        {
            return GetAccounts().Any(s => s.Username == username && s.Password == password);
        }
        public List<AccountModel> GetAccounts()
        {
            var list = _context.GetAccounts().ToList();
            return list;
        }

        public AccountModel GetAccount(string username)
        {
            AccountModel account = _context.GetAccounts().Single(a => a.Username == username);
            return account;
        }
        public bool AddAccount(AccountModel account)
        {
            if (!AccountExist(account.Username))
            {
                _context.AddAccount(account);
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
