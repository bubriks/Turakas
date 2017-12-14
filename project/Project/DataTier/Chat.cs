using System;
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
        public DateTime Time { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Type { get; set; }
        [DataMember]
        public int MaxNrOfUsers { get; set; }
        [DataMember]
        public List<Tuple<Profile, object, string>> Users { get; set; }
    }
}
