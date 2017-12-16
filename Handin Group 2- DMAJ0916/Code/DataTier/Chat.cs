using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataTier
{
    [DataContract]
    public class Chat: Activity
    {
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
