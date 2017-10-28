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
        private int id;
        private string text, creator;
        private DateTime time;

        public Message(int id, string text, string creator, DateTime time)
        {
            this.id = id;
            this.text = text;
            this.creator = creator;
            this.time = time;
        }

        [DataMember]
        public int Id { get => id; set => id = value; }
        [DataMember]
        public string Text { get => text; set => text = value; }
        [DataMember]
        public string Creator { get => creator; set => creator = value; }
        [DataMember]
        public DateTime Time { get => time; set => time = value; }
    }
}
