using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;

namespace BusinessTier
{
    public class UserController
    {
        private DbLogin dbLogin=null;
        private DbProfile dbProfile = null;//remove static

        public UserController()
        {
            dbLogin = new DbLogin();
            dbProfile = new DbProfile();
        }

    }
}
