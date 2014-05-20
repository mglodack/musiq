using DataAccessLayer.BusinessLogicLayer;
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
    [RoutePrefix("api")]
    public class AccountAPIController : ApiController
    {
        [Route("login/{username}/{password}")]
        [HttpGet]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object AccountExists(string username, string password)
        {
            BusinessLogicLayer _context = new BusinessLogicLayer();
            if (_context.AccountExist(username, password))
            {
                var result = new { loginValid = true };
                return result;
            }
            else
            {
                var result = new { loginValid = false };
                return result;
            }

        }
    }
}