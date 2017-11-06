using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;
using BusinessTier;

namespace WcfService
{
    public class RelationshipService: IRelationshipService
    {
        IRelationshipController relationshipController = new RelationshipController();

        public void CreateRelationship(int profileId, RelationShip relationShip)
        {
            relationshipController.CreateRelationship(profileId, relationShip);
        }

        public List<RelationShip> ReadRelationship(string what, int by)
        {
            return relationshipController.ReadRelationship(what, by);
        }

        public bool UpdateRelationship(int id, RelationShip newRelationship)
        {
            return relationshipController.UpdateRelationship(id, newRelationship);
        }

        public bool DeleteRelationship(RelationShip relationShip)
        {
            return relationshipController.DeleteRelationship(relationShip);
        }
    }
}
