using DataAccessLayer.BusinessLogicLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;

namespace Musiq.Controllers
{
    public class MusicController : Controller
    {
        private BusinessLogicLayer _context { get; set; }

        public MusicController()
        {
            _context = new BusinessLogicLayer();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public JsonResult Upload()
        {
            int songsUploadedSucessfully = 0;
            var results = new List<SongUploadMetadata>();
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                string fileName = System.IO.Path.GetFileName(file.FileName);
                string fileExtension = System.IO.Path.GetExtension(file.FileName);
                bool isValidFormat = fileExtension == ".mp3" || fileExtension == ".m4a" ? true : false;
                if (isValidFormat)
                {
                    SongModel song = Add(User.Identity.Name, fileName, file);
                    ++songsUploadedSucessfully;
                    if (song != null)
                    {
                        SongUploadMetadata metadata = new SongUploadMetadata() { SongTitle = song.SongTitle, size = file.ContentLength, Album = song.Album, Artist = song.Artist, Length = song.Length };
                        results.Add(metadata);
                    }
                    else
                    {
                        SongUploadMetadata metadata = new SongUploadMetadata() { size = file.ContentLength };
                        results.Add(metadata);
                    }
                }

            }
            var json = Json(results, JsonRequestBehavior.AllowGet);
            return json;
        }

        public SongModel Add(string username, string fileName, HttpPostedFileBase file)
        {
            SongModel song;

            //Declaring the directory that the song will be uploaded to and performing upload.
            string MusicDirectory = HttpContext.Server.MapPath("~/Music/") + fileName;

            file.SaveAs(MusicDirectory);
            TagLib.File metadata = TagLib.File.Create(MusicDirectory);
            string Duration = metadata.Properties.Duration.ToString(@"mm\:ss");
            string Artist;
            if (metadata.Tag.FirstAlbumArtist != null)
            {
                Artist = metadata.Tag.FirstAlbumArtist;
            }
            else
            {
                Artist = metadata.Tag.FirstArtist;
            }
            song = new SongModel(username, fileName, metadata.Tag.Title, Artist, metadata.Tag.Album, metadata.Tag.Genres.FirstOrDefault(), Duration, 0);
            _context.Add(song);
            return song;
        }

	}
}