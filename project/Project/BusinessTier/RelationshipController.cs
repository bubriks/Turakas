using System;
using System.Collections.Generic;
using System.Linq;
using DataTier;
using DataAccessTier;

namespace BusinessTier
{
    public class RelationshipController : IRelationshipController
    {
        private DbActivity dbActivity;
        private DbRelationships dbRelationship;
        public RelationshipController()
        {
            dbActivity = new DbActivity();
            dbRelationship = new DbRelationships();
        }

        public void CreateRelationship(int profileId, RelationShip relationShip)
        {
            int activityId;

            dbActivity.CreateActivity(profileId);
            activityId = dbActivity.FindActivities(profileId).LastOrDefault();

            relationShip.ActivityId = activityId;
            dbRelationship.CreateRelationship(relationShip);
        }

        public List<RelationShip> ReadRelationship(string what, int by)
        {
            return dbRelationship.ReadRelationship(what, by);
        }

        public bool UpdateRelationship(int id, RelationShip newRelationship)
        {
            return dbRelationship.UpdateRelationship(id, newRelationship);
        }
        
        public bool DeleteRelationship(RelationShip relationShip)
        {
            return dbActivity.DeleteActivity(relationShip.ActivityId);
        }
    }
}
