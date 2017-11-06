using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;

namespace WcfService
{
    [ServiceContract]
    public interface IRelationshipService
    {
        [OperationContract]
        void CreateRelationship(int profileId, RelationShip relationShip);

        [OperationContract]
        List<RelationShip> ReadRelationship(string what, int by);

        [OperationContract]
        bool UpdateRelationship(int id, RelationShip newRelationship);

        [OperationContract]
        bool DeleteRelationship(RelationShip relationShip);
    }
}
