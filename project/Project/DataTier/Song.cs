using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Runtime.Serialization;

namespace DataTier
{
    public class Song
    {
        
        [DataMember]
        public int SongId { get; set; }

        [DataMember]
        public int ActivityId { get; set; }

        [DataMember]
        public int ArtistId { get; set; }

        [DataMember]
        public int GenreId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Duration { get; set; }

        [DataMember]
        public string Url { get; set; }
    }
}