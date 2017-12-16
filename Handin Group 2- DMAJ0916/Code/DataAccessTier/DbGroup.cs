using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using DataAccessTier;

namespace DataAccessTier
{
    public class DbGroup
    {
        private DbConnection con = null;

        public DbGroup()
        {
            con = DbConnection.GetInstance();
        }

        public int CreateGroup(int activityId, String name)
        {
            string stmt = "INSERT INTO Groups(activityID, name) OUTPUT INSERTED.activityID values(@0, @1);";

            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction()))
            {
                cmd.Parameters.AddWithValue("@0", activityId);
                cmd.Parameters.AddWithValue("@1", name);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    return reader.GetInt32(0);
                }
            }
        }

        public int UpdateGroup(int groupId, String name)
        {
            string stmt = " UPDATE Groups SET name = @0 WHERE activityID= @1;";
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction()))
            {
                cmd.Parameters.AddWithValue("@0", name);
                cmd.Parameters.AddWithValue("@1", groupId);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Group> GetUsersGroups(int profileId)
        {
            string stmt = " SELECT " +
                     " Groups.name, " +
                     " Groups.activityID, " +
                     " Activity.profileID, " +
                     " Activity.timeStamp " +
                 " FROM Groups " +
                 " INNER JOIN Activity " +
                     " on Groups.activityID = Activity.activityID " +
                " INNER JOIN Profile " +
                     " on Profile.profileID = Activity.profileID " +
                 " where Profile.profileID = @0; ";
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction()))
            {
                cmd.Parameters.AddWithValue("@0", profileId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Group> groups = new List<Group>();
                    while (reader.Read())
                    {
                        Group group = new Group
                        {
                            ActivityId = Int32.Parse(reader["activityID"].ToString()),
                            Name = reader["name"].ToString(),
                            ProfileId = profileId,
                            TimeStamp = Convert.ToDateTime(reader["timeStamp"].ToString())
                        };
                        groups.Add(group);
                    }
                    return groups;
                }
            }
        }

        public bool UserIsMemberOfGroup(int profileId, int groupId)
        {
            bool canJoin = true;
            string stmt = " select Activity.activityId " +
                          " from groupMembers " +
                                " inner join Activity " +
                                " on Activity.activityId = GroupMembers.activityId " +
                          " where (Activity.profileId = @0 and GroupMembers.groupID = @1)";
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction()))
            {
                cmd.Parameters.AddWithValue("@0", profileId);
                cmd.Parameters.AddWithValue("@1", groupId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        canJoin = false;
                    }
                    reader.Close();
                    return canJoin;
                }
            }
        }

        public int AddMember(int id, int groupId)
        {
            String stmt = " INSERT INTO GroupMembers(activityID, groupID) values(@0, @1); ";
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction()))
            {
                cmd.Parameters.AddWithValue("@0", id);
                cmd.Parameters.AddWithValue("@1", groupId);
                return cmd.ExecuteNonQuery();
            }
        }

        public int RemoveMember(int profileId, int groupId)
        {
            string stmt = "delete from Activity where activityId in " +
                " (select Activity.activityId from groupMembers " +
                " inner join Activity on Activity.activityId = GroupMembers.activityId " +
                " where (Activity.profileId = @1 and GroupMembers.groupID = @0))";
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction()))
            {
                cmd.Parameters.AddWithValue("@0", groupId);
                cmd.Parameters.AddWithValue("@1", profileId);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Profile> GetUsers(int groupId)
        {
            string stmt = " SELECT Profile.profileID," +
                                " Profile.nickname " +
                            " FROM GroupMembers " +
                            " INNER JOIN Activity " +
                                " on Activity.activityID = GroupMembers.activityID " +
                            " INNER JOIN Profile " +
                                " on Profile.profileID = Activity.profileID " +
                            " where GroupMembers.groupID = @0;";
            using (SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction()))
            {
                cmd.Parameters.AddWithValue("@0", groupId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Profile> profiles = new List<Profile>();
                    while (reader.Read())
                    {
                        Profile profile = new Profile
                        {
                            ProfileID = Int32.Parse(reader["profileID"].ToString()),
                            Nickname = reader["nickname"].ToString()
                        };
                        profiles.Add(profile);
                    }
                    return profiles;
                }
            }
        }
    }
}