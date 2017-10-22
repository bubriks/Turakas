using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class Login
    {
        private String username, password, email;

        public Login(String username, String password, String email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
    }
}
