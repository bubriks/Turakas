using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    [DataContract]
    public class Message: Activity
    {
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public string Creator { get; set; }
    }
}
