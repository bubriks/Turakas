using System;
using System.Runtime.Serialization;

namespace DataTier
{
    [DataContract]
    public class Activity
    {
        [DataMember]
        public int ActivityId { get; set; }
        [DataMember]
        public int ProfileId { get; set; }
        [DataMember]
        public DateTime TimeStamp { get; set; }
    }
}
