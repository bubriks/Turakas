using System.Runtime.Serialization;

namespace DataTier
{
    public class PlayList
    {
        [DataMember]
        public int ActivityId { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}