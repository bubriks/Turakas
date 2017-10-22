using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class Profile
    {
        private int profileID, statusID;
        private String nickname;

        public Profile(int profileID, int statusID, String nickname)
        {
            this.profileID = profileID;
            this.statusID = statusID;
            this.nickname = nickname;
        }

        public int ProfileID { get => profileID; set => profileID = value; }
        public int StatusID { get => statusID; set => statusID = value; }
        public string Nickname { get => nickname; set => nickname = value; }
    }
}
