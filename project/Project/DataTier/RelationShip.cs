using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    [DataContract]
    public class RelationShip
    {
        private int activityId, partnerId, typeId;

        public RelationShip(int partnerId, int typeId)
        {
            this.activityId = activityId;
            this.partnerId = partnerId;
            this.typeId = typeId;
        }

        [DataMember]
        public int ActivityId { get => activityId; set => activityId = value; }
        [DataMember]
        public int PartnerId { get => partnerId; set => partnerId = value; }
        [DataMember]
        public int TypeId { get => typeId; set => typeId = value; }
    }
}
