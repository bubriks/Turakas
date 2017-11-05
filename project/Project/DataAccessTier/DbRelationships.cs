using System;
using System.Data.SqlClient;
using DataTier;
using System.Collections.Generic;

namespace DataAccessTier
{
    /// <summary>
    /// Takes care of both Relationships and RelationshipTypes
    /// </summary>
    public class DbRelationships
    {
        private SqlConnection con = null;
        public DbRelationships()
        {
            con = DbConnection.GetInstance().GetConnection();
        }

        #region Relationship
        /// <summary>
        /// Creates new Relationship between 2 profiles
        /// </summary>
        /// <param name="relationShip">Relationship object that must be inserted in database</param>
        /// <returns>Returns true if succesful</returns>
        public bool CreateRelationship(RelationShip relationShip)
        {
            try
            {
                string stmt = "INSERT INTO RelationShips (activityId, partnerID, typeID) VALUES(" + relationShip.ActivityId + " " + relationShip.PartnerId + " " + relationShip.TypeId + ");";

                SqlCommand cmd = new SqlCommand(stmt, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Can find all relationship between 2 profiles, by multiple atributes
        /// </summary>
        /// <param name="what">string of what you are looking for</param>
        /// <param name="by">type by which the search should be done (1 = activityId, 2 = partnerId, 3 = typeId)</param>
        /// <returns>Returns Relationship object</returns>
        public List<RelationShip> ReadRelationship(string what, int by)
        {
            List<RelationShip> relationShips = new List<RelationShip>();

            string stmt;
            switch (by)
            {
                case 1:
                    stmt = "SELECT * FROM RelationShips WHERE activityId = " + what;
                    break;
                case 2:
                    stmt = "SELECT * FROM RelationShips WHERE partnerId = " + what;
                    break;
                case 3:
                    stmt = "SELECT * FROM RelationShips WHERE typeId = "+ what;
                    break;
                default:
                    throw new Exception("'by' parameter must be either 1, 2 or 3");
            }

            try
            {
                SqlCommand cmd = new SqlCommand(stmt, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RelationShip relationShip = new RelationShip(reader.GetInt32(1), reader.GetInt32(2));
                    relationShip.ActivityId = reader.GetInt32(0);

                    relationShips.Add(relationShip);
                }
                return relationShips;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Updates a relationship between 2 profiles
        /// </summary>
        /// <param name="id">Current id of the relationship</param>
        /// <param name="newRelationship">new information</param>
        /// <returns>Returns true if succesful</returns>
        public bool UpdateRelationship(int id, RelationShip newRelationship)
        {
            try
            {
                
                string stmt = "UPDATE RelationShips SET activityId = '" + newRelationship.ActivityId + "', partnerId = '" + newRelationship.PartnerId + "', typeId = '" + newRelationship.TypeId + "' WHERE activityId = " + id;
                SqlCommand cmd = new SqlCommand(stmt, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        #endregion

        #region RelationshipType

        // !!!DO NOT USE OTSIDE TEST/Database preparing PURPOSES

        /// <summary>
        /// Creates new relationship type
        /// </summary>
        /// <param name="name">Name of the relationshipType</param>
        /// <returns>Returns true, if succesfull</returns>
        public bool CreateRelationshipType(string name)
        {
            try
            {
                string stmt = "INSERT INTO RelationshipType(name)" + " VALUES (" + name + "')";
                SqlCommand cmd = new SqlCommand(stmt, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets the Id of the relationshipType, if name matches
        /// </summary>
        /// <param name="name">Name of the relationshipType</param>
        /// <returns>Returns integer</returns>
        public int ReadRelationhipTypeByName(string name)
        {
            string stmt = "SELECT * FROM RelationshipType WHERE name = " + name;
            try
            {
                SqlCommand cmd = new SqlCommand(stmt, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Updates the name of a relationshipType
        /// </summary>
        /// <param name="relationshipTypeId">The relationshipType ID</param>
        /// <param name="newName">The new name</param>
        /// <returns>Returns true if succesfull</returns>
        public bool UpdateRelationshipType(int relationshipTypeId, string newName)
        {
            try
            {
                string stmt = "UPDATE RelationshipType SET name ="+newName + " WHERE typeID = "+ relationshipTypeId;
                SqlCommand cmd = new SqlCommand(stmt, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Deletes a relationshipType
        /// </summary>
        /// <param name="relationshipTypeId"></param>
        /// <returns>Returns true if succesful</returns>
        public bool DeleteRelationshipType(int relationshipTypeId)
        {
            try
            {
                string stmt = "DELETE FROM RelationshipType WHERE typeID = " + relationshipTypeId;
                SqlCommand cmd = new SqlCommand(stmt, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
