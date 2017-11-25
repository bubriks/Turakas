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
        public List<int> allUsers = new List<int>();
        public List<int> onlineUsers = new List<int>();

        public DbGroup()
        {
            con = DbConnection.GetInstance();
        }
        public int CreateGroup(String name, int profileId)
        {
            int id = -1;
            try
            {
                string stmt = " DECLARE @activityID int; " +

                " INSERT INTO Activity(profileID, timeStamp) VALUES(@0, @1); " +
                " SET @activityID = @@IDENTITY;" +

                " INSERT INTO Groups(activityID, name) OUTPUT INSERTED.activityID values(@activityID, @2); ";
                
                using (SqlCommand cmd = con.GetConnection().CreateCommand())
                {
                    cmd.CommandText = stmt;
                    cmd.Parameters.AddWithValue("@0", profileId);
                    cmd.Parameters.AddWithValue("@1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    cmd.Parameters.AddWithValue("@2", name);
                    cmd.Parameters.AddWithValue("@3", name);
                    cmd.Transaction = con.GetTransaction();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        id = reader.GetInt32(0);
                    }
                }
                AddMember(profileId, id);
            }
            catch ( Exception e )
            {
                Console.WriteLine(e) ;
            }
            return id;
        }
        
        public bool AddMember(int profileId, int groupId)
        {
            bool b;
            try
            {
                String stmt = " DECLARE @activityID1 int; " +
                " INSERT INTO Activity(profileID, timeStamp) VALUES(@0, @1); " +
                " SET @activityID1 = @@IDENTITY;"+
                "INSERT INTO GroupMembers(activityID, groupID) values(@activityID1, @2);";

                using (SqlCommand cmd = con.GetConnection().CreateCommand())
                {
                    cmd.CommandText = stmt;
                    cmd.Parameters.AddWithValue("@0", profileId);
                    cmd.Parameters.AddWithValue("@1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    cmd.Parameters.AddWithValue("@2", groupId);
                    cmd.Transaction = con.GetTransaction();
                    
                    cmd.ExecuteNonQuery();
                }
                b = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                b = false;
            }
            return b;
        }
        public bool RemoveMember(int profileId)
        {
            try
            {
                allUsers.Remove(profileId);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Group> GetAllGroupsByProfileId(int profileId)
        {
            String stmt = " SELECT " +
                    " Profile.profileID, " +
                    " Activity.activityID, " +
                    " Groups.name, " +
                    " Activity.timeStamp " +
                    " FROM Groups " +
                " INNER JOIN Activity " +
                    " on Profile.profileID = Activity.profileID " +
                " INNER JOIN Groups " +
                    " on Activity.activityID = Groups.activityID " +
                " where Profile.profileID = @0 ";
            SqlCommand cmd = con.GetConnection().CreateCommand();
            cmd.CommandText = stmt;
            cmd.Parameters.AddWithValue("@0", profileId);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Group> groups = new List<Group>();
            while (reader.Read())
            {
                Group group = new Group
                {
                    Name = reader["name"].ToString(),
                    CreatorId = Int32.Parse(reader["profileID"].ToString()),
                    GroupId = Int32.Parse(reader["ActivityID"].ToString()),
                };
                groups.Add(group);
            }
            reader.Close();
            return groups;
        }
        public Group GetChatByID(int groupId)
        {
            String stmt = " SELECT " +
                    " Profile.profileID, " +
                    " Activity.activityID, " +
                    " Groups.name, " +
                    " Activity.timeStamp " +
                    " FROM Groups " +
                " INNER JOIN Activity " +
                    " on Profile.profileID = Activity.profileID " +
                " INNER JOIN Groups " +
                    " on Activity.activityID = Groups.activityID " +
                " where Activity.activityID = @0 ";
            SqlCommand cmd = con.GetConnection().CreateCommand();
            cmd.CommandText = stmt;
            cmd.Parameters.AddWithValue("@0", groupId);
            SqlDataReader reader = cmd.ExecuteReader();
            Group group = null;
            while (reader.Read())
            {
                group = new Group
                {
                    Name = reader["name"].ToString(),
                    CreatorId = Int32.Parse(reader["profileID"].ToString()),
                    GroupId = Int32.Parse(reader["ActivityID"].ToString()),
                };
            }
            reader.Close();
            return group;
        }
        public List<int> GetAllUsers(int groupId)
        {
            String stmt = " SELECT " +
                    " Profile.profileID, " +
                    " Activity.activityID, " +
                    " Groups.name, " +
                    " Activity.timeStamp " +
                    " FROM Groups " +
                " INNER JOIN Activity " +
                    " on Profile.profileID = Activity.profileID " +
                " INNER JOIN Groups " +
                    " on Activity.activityID = Groups.activityID " +
                " where Activity.activityID = @0 ";
            SqlCommand cmd = con.GetConnection().CreateCommand();
            cmd.CommandText = stmt;
            cmd.Parameters.AddWithValue("@0", groupId);
            SqlDataReader reader = cmd.ExecuteReader();
            Group group = null;
            while (reader.Read())
            {
                group = new Group
                {
                    Name = reader["name"].ToString(),
                    CreatorId = Int32.Parse(reader["profileID"].ToString()),
                    GroupId = Int32.Parse(reader["ActivityID"].ToString()),
                };
            }
            reader.Close();
            return allUsers;
        }
        public List<int> GetOnlineUsers()
        {
            foreach (int p in allUsers)
            {
                onlineUsers.Add(p);
            }
            return onlineUsers;
        }
        public bool DeleteGroup(String name)
        {
            try
            {
                String stmt = " SELECT " +
                    " Profile.nickname, " +
                    " Activity.activityID, " +
                    " Groups.name, " +
                    " Activity.timeStamp " +
                    " FROM Profile " +
                " INNER JOIN Activity " +
                    " on Profile.profileID = Activity.profileID " +
                " INNER JOIN Groups " +
                    " on Activity.activityID = Groups.activityID " +
                " where Activity.activityID = @activityID ";
                return true;
            }
            catch { return false; }
        }
    }
    /*         " SELECT " +
                    " Profile.nickname, " +
                    " Activity.activityID, " +
                    " Groups.name, " +
                    " Activity.timeStamp " +
                    " FROM Profile " +
                " INNER JOIN Activity " +
                    " on Profile.profileID = Activity.profileID " +
                " INNER JOIN Groups " +
                    " on Activity.activityID = Groups.activityID " +
                " where Activity.activityID = @activityID ";
                */
}