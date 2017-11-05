using System.Runtime.Serialization;

namespace DataTier
{
    [DataContract]
    public class Notification
    {
        private int activityId, profileId;

        public Notification(int activityId, int profileId)
        {
            this.ActivityId = activityId;
            this.ProfileId = profileId;
        }

        [DataMember]
        public int ActivityId { get => activityId; set => activityId = value; }
        [DataMember]
        public int ProfileId { get => profileId; set => profileId = value; }
    }
}
