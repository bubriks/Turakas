using System;
using System.Runtime.Serialization;

namespace DataTier
{
    [DataContract]
    public class Login
    {
        private String username, password, email;
        private int loginId;

        public Login(String username, String password, String email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }

        [DataMember]
        public int LoginId { get => loginId; set => loginId = value; }
        [DataMember]
        public string Username { get => username; set => username = value; }
        [DataMember]
        public string Password { get => password; set => password = value; }
        [DataMember]
        public string Email { get => email; set => email = value; }
    }
}