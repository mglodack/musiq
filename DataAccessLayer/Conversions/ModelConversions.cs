using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Conversions
{
    public class ModelConversions
    {
        public static Song SongModelToEntity(SongModel model)
        {
            Song entity = new Song();
            entity.Length = !string.IsNullOrEmpty(model.Length) ? model.Length : "(Unknown Length)";
            entity.FilePath = !string.IsNullOrEmpty(model.FilePath) ? model.FilePath : "(Unknown Filepath)";
            entity.Title = !string.IsNullOrEmpty(model.SongTitle) ? model.SongTitle : System.IO.Path.GetFileNameWithoutExtension(model.FilePath);
            entity.Genre = !string.IsNullOrEmpty(model.Genre) ? model.Genre : "(Unknown Genre)";
            entity.Artist = !string.IsNullOrEmpty(model.Artist) ? model.Artist : "(Unknown Artist)";
            entity.Album = !string.IsNullOrEmpty(model.Album) ? model.Album : "(Unknown Album)";
            entity.Likes = model.Likes;
            entity.NumberOfPlays = model.NumberOfPlays;
            return entity;
        }
    }
}
