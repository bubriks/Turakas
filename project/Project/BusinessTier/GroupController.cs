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

        public bool CreateGroup(String name, int profileId)
        {
            try
            {
                if(dbGroup.CreateGroup(name, profileId) == 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteGroup(int groupId)
        {
            try
            {
                if(dbGroup.DeleteGroup(groupId) == 0)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateGroup(String name, int groupId)
        {
            try
            {
                if (dbGroup.UpdateGroup(name, groupId) == 0)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Group> GetUsersGroups(int profileId)
        {
            try
            {
                return dbGroup.GetUsersGroups(profileId);
            }
            catch (Exception)
            {
                return new List<Group>();
            }
        }

        
        public bool AddMember(int profileId, int groupId)
        {
            try
            {
                if(dbGroup.AddMember(profileId, groupId) < 2)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveMember(int profileId, int groupId)
        {
            try
            {
                if (dbGroup.RemoveMember(profileId, groupId) == 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Profile> GetUsers(int groupId)
        {
            try
            {
                return dbGroup.GetUsers(groupId);
            }
            catch
            {
                return new List<Profile>();
            }
        }
    }
}
