﻿using DataTier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier
{
    public class DbChat
    {
        private DbConnection con = null;

        public DbChat()
        {
            con = DbConnection.GetInstance();
        }

        public Chat CreateChat(Chat chat)
        {
            string stmt = "DECLARE @activityID int; " +

            " INSERT INTO Activity(profileID, timeStamp) VALUES(@0, @1); " +
            " SET @activityID = @@IDENTITY;" +

            " INSERT INTO Chat(activityID, name, type, nrOfUsers) values (@activityID, @2, @3, @4);" +
             
            " Select activityID, timeStamp from Activity where activityID = @activityID;";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", chat.OwnerID);
            cmd.Parameters.AddWithValue("@1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            cmd.Parameters.AddWithValue("@2", chat.Name);
            cmd.Parameters.AddWithValue("@3", Convert.ToInt32(chat.Type));
            cmd.Parameters.AddWithValue("@4", chat.MaxNrOfUsers);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                chat.Id = Int32.Parse(reader["activityID"].ToString());
                chat.Time = Convert.ToDateTime(reader["timeStamp"].ToString());
            }
            reader.Close();
            return chat;
        }

        public Chat GetChat(int id)
        {
            string stmt = "SELECT " +
                            " Profile.profileID, " +
                            " timeStamp, " +
                            " name, " +
                            " type, " +
                            " nrOfUsers " +
                        " FROM Profile " +
                        " INNER JOIN Activity " +
                            " on Profile.profileID = Activity.profileID " +
                        " INNER JOIN Chat " +
                            " on Activity.activityID = chat.activityID " +
                        " where Activity.activityID = @0 ;";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", id);
            SqlDataReader reader = cmd.ExecuteReader();
            Chat chat = null;
            if(reader.Read())
            {
                chat = new Chat
                {
                    Id = id,
                    OwnerID = Int32.Parse(reader["profileID"].ToString()),
                    Time = Convert.ToDateTime(reader["timeStamp"].ToString()),
                    Name = reader["name"].ToString(),
                    Type = (bool)reader["type"],
                    MaxNrOfUsers = Int32.Parse(reader["nrOfUsers"].ToString())
                };
            }
            reader.Close();
            return chat;
        }

        public Chat UpdateChat(Chat chat)
        {
            string stmt = "UPDATE Chat SET name = @0, type = @1, nrOfUsers= @2 WHERE activityID= @3;";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", chat.Name);
            cmd.Parameters.AddWithValue("@1", Convert.ToInt32(chat.Type));
            cmd.Parameters.AddWithValue("@2", chat.MaxNrOfUsers);
            cmd.Parameters.AddWithValue("@3", chat.Id);
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                return chat;
            }
            return null;
        }

        public List<Chat> GetChatsByName(String name, int profileId)
        {
            string stmt = " SELECT " +
                            " Profile.profileID, " +
                            " timeStamp, " +
                            " Activity.activityID, " +
                            " name, " +
                            " type, " +
                            " nrOfUsers " +
                        " FROM Chat " +
                        " INNER JOIN Activity " +
                            " on Chat.activityID = Activity.activityID " +
                        " INNER JOIN Profile " +
                            " on Activity.profileID = Profile.profileID " +
                        " where name like '%' +@0+ '%' AND type = 1  OR Profile.profileID = @1; ";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", name);
            cmd.Parameters.AddWithValue("@1", profileId);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Chat> chats = new List<Chat>();
            while (reader.Read())
            {
                Chat chat = new Chat
                {
                    Id = Int32.Parse(reader["activityID"].ToString()),
                    OwnerID = Int32.Parse(reader["profileID"].ToString()),
                    Time = Convert.ToDateTime(reader["timeStamp"].ToString()),
                    Name = reader["name"].ToString(),
                    Type = (bool)reader["type"],
                    MaxNrOfUsers = Int32.Parse(reader["nrOfUsers"].ToString())
                };
                chats.Add(chat);
            }
            reader.Close();
            return chats;
        }

        public int DeleteChat(int id)
        {
            string stmt = "DELETE FROM Activity WHERE activityID = @0";
            SqlCommand cmd = new SqlCommand(stmt, con.GetConnection(), con.GetTransaction());
            cmd.Parameters.AddWithValue("@0", id);
            int rows = cmd.ExecuteNonQuery();
            return rows;
        }
    }
}
