using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Runtime.Serialization;

namespace DataTier
{
    public class Song
    {
        private int songID;
        private int activityID;
        private int artistID;
        private int genreID;
        private string name;
        private int duration;
        private string url;
        
        [DataMember]
        public int SongId
        {
            get => songID;
            set => songID = value;
        }
        
        [DataMember]
        public int ActivityId
        {
            get => activityID;
            set => activityID = value;
        }
        
        [DataMember]
        public int ArtistId
        {
            get => artistID;
            set => artistID = value;
        }
        
        [DataMember]
        public int GenreId
        {
            get => genreID;
            set => genreID = value;
        }

        [DataMember]
        public string Name
        {
            get => name;
            set => name = value;
        }
        
        [DataMember]
        public int Duration
        {
            get => duration;
            set => duration = value;
        }
        
        [DataMember]
        public string Url
        {
            get => url;
            set => url = value;
        }
        
    }
}