using DataAccessLayer.BusinessLogicLayer;
using DataAccessLayer.Models;
using Jukebox.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Services;

namespace Musiq.Controllers
{
    [RoutePrefix("api/music")]
    public class MusicAPIController : ApiController
    {
        [Route("")]
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<SongModel> GetSongs()
        {
            BusinessLogicLayer _context = new BusinessLogicLayer();
            return _context.GetSongs().OrderByDescending(s => s.SongID).Take(500).ToList();
        }

        [Route("{numberOfSongs}")]
        [HttpGet]
        public List<SongModel> GetSongs(int numberOfSongs)
        {
            BusinessLogicLayer _context = new BusinessLogicLayer();
            return _context.GetSongs(numberOfSongs);
        }
    }
}