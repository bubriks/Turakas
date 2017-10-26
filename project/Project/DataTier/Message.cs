using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
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

        public int Id { get => id; set => id = value; }
        public string Text { get => text; set => text = value; }
        public string Creator { get => creator; set => creator = value; }
        public DateTime Time { get => time; set => time = value; }
    }
}
