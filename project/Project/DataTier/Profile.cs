using System.Runtime.Serialization;

namespace DataTier
{
    [DataContract]
    public class Profile
    {
        [DataMember]
        public int ProfileID { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Nickname { get; set; }
        [DataMember]
        public object CallBack { get; set; }
    }
}