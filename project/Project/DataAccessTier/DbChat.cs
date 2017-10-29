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
        private SqlConnection con = null;

        public DbChat()
        {
            con = DbConnection.GetInstance().GetConnection();
        }

        #region manage chat
        public Chat CreateChat(Chat chat, SqlTransaction transaction)
        {
            string stmt = "INSERT INTO Chat(name, type) OUTPUT INSERTED.chatID values ('" + chat.Name + "', " + Convert.ToInt32(chat.Type) + ")";
            SqlCommand cmd = new SqlCommand(stmt, con, transaction);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                chat.Id = Int32.Parse(reader["chatID"].ToString());
            }
            reader.Close();
            return chat;
        }
        
        public Chat GetChat(int id)
        {
            string stmt = "SELECT name, type FROM Chat where chatID = " + id;
            SqlCommand cmd = new SqlCommand(stmt, con);
            SqlDataReader reader = cmd.ExecuteReader();
            Chat chat=null;
            if (reader.Read())
            {
                chat = new Chat(id, reader["name"].ToString(), (bool)reader["type"]);
            }
            reader.Close();
            return chat;
        }

        public List<Chat> GetChatsByName(String name)
        {
            string stmt = "Select chatID, name, type FROM Chat where name like '%" + name + "%' AND type=1;";
            SqlCommand cmd = new SqlCommand(stmt, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Chat> chats = new List<Chat>();
            while (reader.Read())
            {
                chats.Add(new Chat(Int32.Parse(reader["chatID"].ToString()), reader["name"].ToString(), (bool)reader["type"]));
            }
            reader.Close();
            return chats;
        }

        public int UpdateChat(Chat chat)
        {
            string stmt = "UPDATE Chat SET name = '" + chat.Name + "', type = '" + Convert.ToInt32(chat.Type) + "' WHERE chatID= " + chat.Id;
            SqlCommand cmd = new SqlCommand(stmt, con);
            int rows = cmd.ExecuteNonQuery();
            return rows;
        }

        public int DeleteChat(int id)
        {
            string stmt = "DELETE FROM Chat WHERE chatID = " + id;
            SqlCommand cmd = new SqlCommand(stmt, con);
            int rows = cmd.ExecuteNonQuery();
            return rows;
        }
        #endregion
        
        #region chat users
        public List<Profile> GetPersonsInChat(int chatId)
        {
            string stmt = "SELECT Profile.profileID, "+
                            "Profile.statusID, " +
                            "Profile.nickname " +
                            "FROM PersonsChats INNER JOIN Profile ON PersonsChats.profileID = Profile.profileID where chatID =" + chatId;
            SqlCommand cmd = new SqlCommand(stmt, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Profile> perons = new List<Profile>();
            while (reader.Read())
            {
                perons.Add(new Profile(Int32.Parse(reader["profileID"].ToString()), Int32.Parse(reader["statusID"].ToString()), reader["nickname"].ToString()));
            }
            reader.Close();
            return perons;
        }

        public void AddPersonToChat(int chatId, int profileId, SqlTransaction transaction)
        {
            string stmt = "INSERT INTO PersonsChats(chatID, profileID) values (" + chatId + ", " + profileId + ")";
            SqlCommand cmd = new SqlCommand(stmt, con, transaction);
            cmd.ExecuteNonQuery();
        }

        public int RemovePersonFromChat(int chatId, int profileId)
        {
            string stmt = "DELETE FROM PersonsChats where chatID= " + chatId + " AND profileID= "+ profileId;
            SqlCommand cmd = new SqlCommand(stmt, con);
            int rows = cmd.ExecuteNonQuery();
            return rows;
        }
        #endregion
    }
}
