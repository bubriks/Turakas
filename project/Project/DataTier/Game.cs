using System.Runtime.Serialization;

namespace DataTier
{
    public class Game
    {
        [DataMember]
        public int GameId { get; set; }

        [DataMember]
        public int Score1 { get; set; }
        [DataMember]
        public int Score2 { get; set; }
        [DataMember]
        public Profile Player1 { get; set; }
        [DataMember]
        public Profile Player2 { get; set; }
        [DataMember]
        public int Choice1 { get; set; }
        [DataMember]
        public int Choice2 { get; set; }
    }
}
