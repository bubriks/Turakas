using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataTier
{
    [DataContract]
    public class Chat
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int OwnerID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Type { get; set; }
        [DataMember]
        public int MaxNrOfUsers { get; set; }
        [DataMember]
        public List<Profile> Users { get; set; }
    }
}
