using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    //-----------began to add lists to the constructors
    public class AccountModel
    {
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<SongModel> Songs { get; set; }
        public List<PlaylistModel> Playlists { get; set; }
        public string ProfilePicURL { get; set; }
        public bool login {get; set;}


    }
}
