using DataTier;
using System.Collections.Generic;

namespace BusinessTier
{
    public interface IRelationshipController
    {

        /// <summary>
        /// Creates new Relationship between 2 profiles
        /// </summary>
        /// <param name="relationShip">Relationship object that must be inserted in database</param>
        /// <returns>Returns true if succesful</returns>
        void CreateRelationship(int profileId, RelationShip relationShip);

        /// <summary>
        /// Can find all relationship between 2 profiles, by multiple atributes
        /// </summary>
        /// <param name="what">string of what you are looking for</param>
        /// <param name="by">type by which the search should be done (1 = activityId, 2 = partnerId, 3 = typeId)</param>
        /// <returns>Returns Relationship object</returns>
        List<RelationShip> ReadRelationship(string what, int by);
        
        /// <summary>
        /// Updates a relationship between 2 profiles
        /// </summary>
        /// <param name="id">Current id of the relationship</param>
        /// <param name="newRelationship">new information</param>
        /// <returns>Returns true if succesful</returns>
        bool UpdateRelationship(int id, RelationShip newRelationship);

        /// <summary>
        /// Deletes the Activity, which will cascade delete the relationship
        /// </summary>
        /// <param name="relationShip"></param>
        /// <returns>Returns true, if succesful</returns>
        bool DeleteRelationship(RelationShip relationShip);
        
    }
}
