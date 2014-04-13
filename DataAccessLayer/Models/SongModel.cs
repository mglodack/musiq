using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class SongModel
    {
        public SongModel ()
        {

            Username = null;
            FilePath = null;
            SongTitle = null;
            Artist = null;
            Album = null;
            Genre = null;
            Length = null;
            Likes = 0;
            NumberOfPlays = 0;
            
        }
        public SongModel(string username, string filePath, string songTitle, string artist, string album, string genre, string length, int likes)
        {
            Username = username;
            FilePath = filePath;
            SongTitle = songTitle;
            Artist = artist;
            Album = album;
            Genre = genre;
            Length = length;
            Likes = likes;
            NumberOfPlays = 0;
        }

        public void IncrementLikes()
        {
            Likes = Likes + 1;
        }
        public int SongID { get; set;}

        public int AccountID { get; set; }

        public string FilePath;
        public string SongTitle { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public string Length { get; set; }
        //public List<AccountModel> Accounts {get; set; }
        public string Username { get; set; }
        public int Likes { get; set; }

        public int NumberOfPlays { get; set; }

        public Boolean isAdded { get; set; }

        public string ArtworkURL { get; set; }

        public DateTime DatePlayed { get; set; }
    }
}
