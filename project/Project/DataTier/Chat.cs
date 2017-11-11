using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataTier
{
    [DataContract]
    public class Chat
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Type { get; set; }
        [DataMember]
        public int MaxNrOfUsers { get; set; }
        [DataMember]
        public List<User> Users { get; set; }
    }

    [DataContract]
    public class User
    {
        [DataMember]
        public Profile Profile { get; set; }
        [DataMember]
        public object CallBack { get; set; }
    }
}
