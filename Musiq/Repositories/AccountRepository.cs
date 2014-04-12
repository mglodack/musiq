using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Microsoft.AspNet.Identity.EntityFramework;
using Musiq.Controllers;

namespace Jukebox.Repositories
{
    public class AccountRepository
    {
        private IdentityDbContext _context { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AccountRepository()
        {
            _context = new IdentityDbContext();
            //Starts the links to the dbsets to call and go through them
        }


        public async Task<bool> AccountExists(string username, string password)
        {
            AccountController controller = new AccountController();
            var user = await controller.UserManager.FindAsync(username,password);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}