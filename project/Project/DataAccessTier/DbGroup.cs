﻿using System;
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
        private SqlConnection con = null;
        public List<int> allUsers = new List<int>();
        public List<int> onlineUsers = new List<int>();

        public DbGroup()
        {
            con = DbConnection.GetInstance().GetConnection();
        }
        public bool CreateGroup(String name, int profileId)
        {
            Group group = new Group{Name = name, CreatorId = profileId};
            if (group == null)
                return false;
            else
                return true;
        }
        public bool AddMember(int profileId)
        {
            try
            {
                allUsers.Add(profileId);
                return true;
            }
            catch
            {
                return false;
            }
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
        public List<int> GetAllUsers()
        {
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
            return true;
        }
    }
}

/*public bool CreateGroup(Profile profile)
{

    try
    {
        string stmt = "INSERT INTO Group(creator, member)" +
            " VALUES (" + profile.ProfileID + ", " + profile.profileID + "');";
        using (SqlCommand cmd = new SqlCommand(stmt, con))
        {
            cmd.ExecuteNonQuery();
        }
        return true;
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        return false;
    }
}
public bool AddMember(Profile profile)
{
    try
    {
        string stmt = "INSERT INTO Group(member)" +
            " VALUES (" + profile.ProfileID + "');";
        using (SqlCommand cmd = new SqlCommand(stmt, con))
        {
            cmd.ExecuteNonQuery();
        }
        return true;
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        return false;
    }
}
public int RemoveMember(int profileID)
{
    string stmt = "DELETE FROM Group WHERE member = @0";
    SqlCommand cmd = new SqlCommand(stmt, con);
    cmd.Parameters.AddWithValue("@0", profileID);
    int rows = cmd.ExecuteNonQuery();
    return rows;
}
public List<Profile> GetOnlineUsers()
{
    string stmt = " SELECT members FROM Profile" +
                " INNER JOIN Activity" +
                    " on Profile.profileID = Activity.profileID" +
                " INNER JOIN Message" +
                    " on Activity.activityID = Message.activityID" +
                " where Message.chatID = @0";
    SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
    cmd.Parameters.AddWithValue("@0", chatId);
    SqlDataReader reader = cmd.ExecuteReader();
    List<Message> messages = new List<Message>();
    while (reader.Read())
    {
        Message message = new Message
        {
            Id = Int32.Parse(reader["activityID"].ToString()),
            Text = reader["message"].ToString(),
            Creator = reader["nickname"].ToString(),
            CreatorId = Int32.Parse(reader["profileID"].ToString()),
            Time = Convert.ToDateTime(reader["timeStamp"].ToString())
        };
        messages.Add(message);
    }
    reader.Close();
    return messages;
}
public bool DeleteGroup()
{
    return true;
}
public List<Profile> GetAllUsers(String name)
{
    string stmt = "Select members FROM Group where name = " + name;
    SqlCommand cmd = new SqlCommand(stmt, con);
    SqlDataReader reader = cmd.ExecuteReader();
    List<Profile> profiles = new List<Profile>();
    while (reader.Read())
    {
        Profile profile = new Profile();
        {

        }
        profiles.Add(profile);
    }
    reader.Close();
    return profiles;
}
}*/

