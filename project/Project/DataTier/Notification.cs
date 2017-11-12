using System.Runtime.Serialization;

namespace DataTier
{
    [DataContract]
    public class Notification
    {

        [DataMember]
        public int ActivityId { get; set; }
        [DataMember]
        public int ProfileId { get; set; }
    }
}
