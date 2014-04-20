using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Musiq.ExtensionClasses
{
    public class MusiqPrincipal : IPrincipal
    {
        public MusiqPrincipal(IIdentity Identity, AccountModel UserInformation )
        {
            this.Identity = Identity;
            this.UserInformation = UserInformation;
        }
        public IIdentity Identity { get; set; }
        public AccountModel UserInformation { get; set; }

        public bool IsInRole(string role)
        {
            return false;
        }
    }
}