﻿using DataTier;
using System;
using System.Collections;
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
        public Chat CreateChat(Chat chat)
        {
            try
            {
                string stmt = "INSERT INTO Chat(name, type) OUTPUT INSERTED.chatID values ('" + chat.Name + "', " + Convert.ToInt32(chat.Type) + ")";
                SqlCommand cmd = new SqlCommand(stmt, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                chat.Id = Int32.Parse(reader["chatID"].ToString());
                return chat;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public Chat GetChat(int id)
        {
            try
            {
                string stmt = "SELECT * FROM Chat where chatID = " + id;
                SqlCommand cmd = new SqlCommand(stmt, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Chat chat = new Chat(id, reader["name"].ToString(), (bool)reader["type"]);
                    reader.Close();
                    return chat;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool UpdateChat(Chat chat)
        {
            try
            {
                string stmt = "UPDATE Chat SET name = '" + chat.Name + "', type = '" + Convert.ToInt32(chat.Type) + "' WHERE chatID= " + chat.Id;
                SqlCommand cmd = new SqlCommand(stmt, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteChat(int id)
        {
            try
            {
                string stmt = "DELETE FROM Chat WHERE chatID = " + id;
                SqlCommand cmd = new SqlCommand(stmt, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region chat users
        public String GetPersonsInChat(int chatId)
        {
            string stmt = "SELECT Profile.nickname FROM PersonsChats INNER JOIN Profile ON PersonsChats.profileID = Profile.profileID where chatID = " + chatId;
            SqlCommand cmd = new SqlCommand(stmt, con);
            SqlDataReader reader = cmd.ExecuteReader();
            String names = "";
            while (reader.Read())
            {
                names+= reader["nickname"].ToString()+" ";
            }
            return names;
        }

        public void AddPersonToChat(int chatId, int personId)
        {
            string stmt = "INSERT INTO PersonsChats(chatID, profileID) values (" + chatId + ", " + personId + ")";
            SqlCommand cmd = new SqlCommand(stmt, con);
            cmd.ExecuteNonQuery();
        }

        public void RemovePersonFromChat(int chatId, int personId)
        {
            string stmt = "DELETE FROM PersonsChats where chatID= " + chatId + " AND profileID= "+ personId;
            SqlCommand cmd = new SqlCommand(stmt, con);
            cmd.ExecuteNonQuery();
        }
        #endregion
    }
}
