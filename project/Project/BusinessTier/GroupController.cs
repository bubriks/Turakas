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
        private IProfileController profileController;
        public GroupController()
        {
            dbGroup = new DbGroup();
            profileController = new ProfileController();
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
        
        public bool AddMember(String memberName, int groupId)
        {
            try
            {
                Profile profile = profileController.ReadProfile(memberName, 4);
                if (profile == null)
                {//user not found
                    return false;
                }
                else
                {//user found
                    if (dbGroup.UserIsMemberOfGroup(profile.ProfileID, groupId))
                    {//user isnt in group
                        if (dbGroup.AddMember(profile.ProfileID, groupId) < 2)
                        {//not added
                            return false;
                        }
                        //added
                        return true;
                    }
                    else
                    {//user already in group
                        return false;
                    }
                }
            }
            catch
            {//problem in db
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

        public List<Profile> GetOnlineMembers(int groupId)
        {
            List<Profile> onlineMembers = new List<Profile>();
            foreach (Profile member in GetUsers(groupId))
            {
                Profile user = profileController.GetUser(member.ProfileID);
                if(user != null)
                {
                    onlineMembers.Add(user);
                }
            }
            return onlineMembers;
        }
    }
}
