using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusinessTier.Interfaces;
using DataAccessTier;
using DataTier;

namespace BusinessTier
{
    public class PlayListController: IPlayListController
    {
        public void AddPlayList(string name)
        {
            DbPlayList dbPlayList = new DbPlayList();
            dbPlayList.AddPlayList(name);
        }

        public List<PlayList> FindPlayListsByName(string name)
        {
            DbPlayList dbPlayList = new DbPlayList();
            return dbPlayList.FindPlayListsByName(name);
        }

        public bool AddSongToPlayList(int songId, int playListId)
        {
            DbPlayList dbPlayList = new DbPlayList();
            if (dbPlayList.IsSongInPlayList(songId, playListId))
            {
                return false;
            }
            try
            {
                dbPlayList.AddSongToPlayList(songId, playListId);
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<Song> GetSongsFromPlayList(int playListId)
        {
            DbPlayList dbPlayList = new DbPlayList();
            return dbPlayList.GetSongsFromPlayList(playListId);
        }


    }
}