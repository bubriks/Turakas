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
        private static DbLogin dbLogin=null;
        private static DbProfile dbProfile = null;

        public UserController()
        {
            dbLogin = new DbLogin();
            dbProfile = new DbProfile();
        }

        static void Main(string[] args)
        {
            dbLogin = new DbLogin();
            dbProfile = new DbProfile();

            Console.WriteLine(dbLogin.Login(new Login("test", "admin", "")).Item2);
            Console.WriteLine(dbProfile.GetProfile(1).Nickname);
        }
    }
}
