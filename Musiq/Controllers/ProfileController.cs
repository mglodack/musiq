using DataAccessLayer.BusinessLogicLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Musiq.Controllers
{
    public class ProfileController : Controller
    {
        private BusinessLogicLayer _context { get; set; }

        public ProfileController()
        {
            _context = new BusinessLogicLayer();
        }
        //
        // GET: /Profile/
        public ActionResult Index()
        {
            return View();
        }
	}
}