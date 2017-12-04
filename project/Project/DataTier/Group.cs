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
        public int GroupId { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public int CreatorId { get; set; }
        [DataMember]
        public DateTime Time { get; set; }
    }
}
