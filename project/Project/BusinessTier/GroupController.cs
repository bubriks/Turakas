using BusinessTier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using DataAccessTier;

namespace BusinessTier
{
    public class GroupController : IGroupController
    {
        private DbGroup dbGroup;
        public GroupController()
        {
            dbGroup = new DbGroup();
        }
        public bool SomethingWentWrong()
        {
            return false;
        }
        public bool AddMember(int profileId, int groupId)
        {
            try
            {
                return dbGroup.AddMember(profileId, groupId);
            }
            catch { return SomethingWentWrong(); }
        }

        public int CreateGroup(String name, int profileId)
        {
            try
            {
                int i = dbGroup.CreateGroup(name, profileId);
                return i;
            }
            catch { return -5; }
        }

        public bool DeleteGroup(int groupId)
        {
            try
            {
                return dbGroup.DeleteGroup(groupId);
            }
            catch { return SomethingWentWrong(); }
        }

        public List<Profile> GetAllUsers(int groupId)
        {
            try
            {
                return dbGroup.GetAllUsers(groupId);
            }
            catch { return null; }
        }

        public List<Profile> GetOnlineUsers(int groupId)
        {
            List<Profile> allOnlineUsers = new List<Profile>();
            try
            {

                ProfileController pc = new ProfileController();
                List<Profile> onlineUsers = pc.GetOnlineUsers();
                List<Profile> allUsers = dbGroup.GetAllUsers(groupId);
                foreach(Profile p in allUsers)
                {
                    foreach(Profile prof in onlineUsers)
                    {
                        if(prof.Nickname == p.Nickname)
                        {
                            allOnlineUsers.Add(p);
                        }
                    }
                }
                return allOnlineUsers;
            }
            catch { return null; }
        }

        public bool RemoveMember(int profileId, int groupId)
        {
            try
            {
                return dbGroup.RemoveMember(profileId, groupId);
            }
            catch { return SomethingWentWrong(); }
        }
    }
}
