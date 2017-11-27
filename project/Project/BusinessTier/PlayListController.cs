using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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

        public bool AddSongToPlayList(string url, string playListIdString)
        {
            DbPlayList dbPlayList = new DbPlayList();
            int playListId = 0;
            try
            {
                int songId = new SongController().GetSongByUrl(url).ActivityId;
                playListId = Int32.Parse(playListIdString);
                if (dbPlayList.IsSongInPlayList(songId, playListId))
                {
                    return false;
                }
                
                if (dbPlayList.AddSongToPlayList(songId, playListId) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<Song> GetSongsFromPlayList(string playListIdString)
        {
            int playListId = 0;
            try
            {
                 playListId = Int32.Parse(playListIdString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
            DbPlayList dbPlayList = new DbPlayList();
            return dbPlayList.GetSongsFromPlayList(playListId);
        }

        public bool RemovePlaylist(string playlistIdString)
        {
            try
            {
                int playlistId = Int32.Parse(playlistIdString);
                DbPlayList dbPlayList = new DbPlayList();
                if (dbPlayList.RemovePlaylist(playlistId) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool RemoveSongFromPlaylist(string url, string playListIdString)
        {
            try
            {
                int playListId = Int32.Parse(playListIdString);
                int songId = new SongController().GetSongByUrl(url).ActivityId;
                DbPlayList dbPlayList = new DbPlayList();
                if (dbPlayList.RemoveSongFromPlaylist(songId, playListId) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }


    }
}