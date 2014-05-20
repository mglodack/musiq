using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Musiq.Models;
using DataAccessLayer.Models;
using DataAccessLayer.BusinessLogicLayer;
using System.Web.Security;
using Newtonsoft.Json;
using DataAccessLayer.LuceneSearch;


namespace Musiq.Controllers
{
    public class LoginController : Controller
    {
        BusinessLogicLayer _BusinessLogicLayer = new BusinessLogicLayer();
        //
        // GET: /Login/
        public ActionResult Index()
        {
            LuceneSearch.AddUpdateLuceneIndex(_BusinessLogicLayer.GetSongs());
            return View();
        }
        public ActionResult Verify(AccountModel account, string returnUrl)
        {
            if (account.login)
            {
                return Login(account, returnUrl);
            }
            else
            {
                if (Register(account, returnUrl))
                {
                    return Login(account, returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        [HttpPost]
        public ActionResult Login(AccountModel account, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_BusinessLogicLayer.AccountExist(account.Username, account.Password))
                {
                    account = _BusinessLogicLayer.GetAccount(account.Username);
                    string userData = JsonConvert.SerializeObject(account);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, account.Username, DateTime.Now, DateTime.Now.AddMonths(1), true, userData);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public bool Register(AccountModel account, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                if(_BusinessLogicLayer.AddAccount(account))
                {
                   return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
	    }
    }
}