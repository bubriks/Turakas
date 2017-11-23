using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    [DataContract]
    public class Group
    {
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public Profile Creator { get; set; }
        [DataMember]
        public List<Profile> AllUsers { get; set; }
        [DataMember]
        public List<Profile> OnlineUsers { get; set; }
        public void SetName(String name)
        {
            Name = name;
        }
        public void SetCreator(Profile creator)
        {
            Creator = creator;
        }
    }
}
