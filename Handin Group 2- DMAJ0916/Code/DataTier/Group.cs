using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    [DataContract]
    public class Group: Activity
    {
        [DataMember]
        public String Name { get; set; }
    }
}
