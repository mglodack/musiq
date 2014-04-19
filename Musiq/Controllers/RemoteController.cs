using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Musiq.Controllers
{
    public class RemoteController : Controller
    {
        //
        // GET: /Remote/
        public PartialViewResult Index()
        {
            return PartialView("_RemotePartial");
        }
	}
}