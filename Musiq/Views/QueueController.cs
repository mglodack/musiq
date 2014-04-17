using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Musiq.Views
{
    public class QueueController : Controller
    {
        //
        // GET: /Queue/
        public PartialViewResult Index()
        {
            return PartialView("_QueuePartial");
        }
	}
}