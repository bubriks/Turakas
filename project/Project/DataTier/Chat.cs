using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataTier
{
    [DataContract]
    public class Chat
    {
        private int id;
        private string name;
        private bool type;
        
        public Chat(int id, string name, bool type)
        {
            this.id = id;
            this.name = name;
            this.type = type;
        }

        [DataMember]
        public int Id { get => id; set => id = value; }
        [DataMember]
        public string Name { get => name; set => name = value; }
        [DataMember]
        public bool Type { get => type; set => type = value; }
    }
}
