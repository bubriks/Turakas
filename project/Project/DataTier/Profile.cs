using System;
using System.Runtime.Serialization;

namespace DataTier
{
    [DataContract]
    public class Profile
    {

        [DataMember]
        public int ProfileID { get; set; }
        [DataMember]
        public int StatusID { get; set; }
        [DataMember]
        public string Nickname { get; set; }
        [DataMember]
        public object CallBack { get; set; }
    }
}
