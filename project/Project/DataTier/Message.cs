using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public string Creator { get; set; }
        [DataMember]
        public int CreatorId { get; set; }
        [DataMember]
        public DateTime Time { get; set; }
    }
}
