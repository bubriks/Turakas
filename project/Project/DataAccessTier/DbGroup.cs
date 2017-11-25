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

        public int CreateGroup(String name, int profileId)
        {
            string stmt = " DECLARE @activityID int; " +

                " INSERT INTO Activity(profileID, timeStamp) VALUES(@0, @1); " +
                " SET @activityID = @@IDENTITY;" +

                " INSERT INTO Groups(activityID, name) OUTPUT INSERTED.activityID values(@activityID, @2);";

            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", profileId);
            cmd.Parameters.AddWithValue("@1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            cmd.Parameters.AddWithValue("@2", name);
            return cmd.ExecuteNonQuery();
        }

        public int DeleteGroup(int groupId)
        {
            string stmt = "DELETE FROM Activity WHERE activityID = @0";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", groupId);
            return cmd.ExecuteNonQuery();
        }

        public int UpdateGroup(String name, int groupId)
        {
            string stmt = " UPDATE Groups SET name = @0 WHERE activityID= @1;";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", name);
            cmd.Parameters.AddWithValue("@1", groupId);
            return cmd.ExecuteNonQuery();
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
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", profileId);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Group> groups = new List<Group>();
            while (reader.Read())
            {
                Group group = new Group
                {
                    GroupId = Int32.Parse(reader["activityID"].ToString()),
                    Name = reader["name"].ToString(),
                    CreatorId = Int32.Parse(reader["profileID"].ToString()),
                    Time = Convert.ToDateTime(reader["timeStamp"].ToString())
                };
                groups.Add(group);
            }
            reader.Close();
            return groups;
        }

        public int AddMember(int profileId, int groupId)
        {
            String stmt = " DECLARE @activityID int; " +
                    " INSERT INTO Activity(profileID, timeStamp) VALUES(@0, @1); " +
                    " SET @activityID = @@IDENTITY; " +
                    " INSERT INTO GroupMembers(activityID, groupID) values(@activityID, @2); ";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", profileId);
            cmd.Parameters.AddWithValue("@1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            cmd.Parameters.AddWithValue("@2", groupId);
            return cmd.ExecuteNonQuery();
        }

        public int RemoveMember(int profileId, int groupId)
        {
            string stmt = "delete from Activity where activityId in " +
                " (select Activity.activityId from groupMembers " +
                " inner join Activity on Activity.activityId = GroupMembers.activityId " +
                " where (Activity.profileId = @1 and GroupMembers.groupID = @0))";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", groupId);
            cmd.Parameters.AddWithValue("@1", profileId);
            return cmd.ExecuteNonQuery();
        }

        public List<Profile> GetUsers(int groupId)
        {
            string stmt = " SELECT " +
                      " Profile.profileID," +
                      " Profile.nickname " +
                  " FROM GroupMembers " +
                 " INNER JOIN Activity " +
                      " on Activity.activityID = GroupMembers.activityID " +
                 " INNER JOIN Profile " +
                     "  on Profile.profileID = Activity.profileID " +
                  " where GroupMembers.groupID = @0;";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", groupId);
            SqlDataReader reader = cmd.ExecuteReader();
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
            reader.Close();
            return profiles;
        }
    }
}