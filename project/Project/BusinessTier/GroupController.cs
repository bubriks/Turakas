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
        public bool AddMember(Profile profile)
        {
            try
            {
                return dbGroup.AddMember(profile);
            }
            catch { return false; }
        }

        public bool CreateGroup(String name, Profile profile)
        {
            try
            {
                return dbGroup.CreateGroup(name, profile);
            }
            catch { return false; }
        }

        public bool DeleteGroup(Profile profile)
        {
            try
            {
                return dbGroup.DeleteGroup(profile);
            }
            catch { return false; }
        }

        public List<Profile> GetAllUsers()
        {
            try
            {
                return dbGroup.GetAllUsers();
            }
            catch { return null; }
        }

        public List<Profile> GetOnlineUsers()
        {
            try
            {
                return dbGroup.GetOnlineUsers();
            }
            catch { return null; }
        }

        public bool RemoveMember(Profile profile)
        {
            try
            {
                return dbGroup.RemoveMember(profile);
            }
            catch { return false; }
        }
    }
}
