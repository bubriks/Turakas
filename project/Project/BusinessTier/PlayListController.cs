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
        public bool AddPlayList(string name)
        {
            DbPlayList dbPlayList = new DbPlayList();

            if (dbPlayList.AddPlayList(name)>0)
            {
                return true;
            }

            return false;
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
                
                if (dbPlayList.AddSongToPlayList(songId, playListId) > 0)
                {
                    return true;
                }
                return false;
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

        public bool RemovePlaylist(int playlistId)
        {
            DbPlayList dbPlayList = new DbPlayList();
            if (dbPlayList.RemovePlaylist(playlistId) > 0)
            {
                return true;
            }
            return false;
        }

        public bool RemoveSongFromPlaylist(int songId)
        {
            DbPlayList dbPlayList = new DbPlayList();
            if (dbPlayList.RemoveSongFromPlaylist(songId) > 0)
            {
                return true;
            }
            return false;
        }


    }
}