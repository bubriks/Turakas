﻿using BusinessTier.Interfaces;
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
        private DbGroup dbGroup = null;
        private DbActivity dbActivity = null;
        private IProfileController profileController;
        public GroupController()
        {
            dbGroup = new DbGroup();
            dbActivity = new DbActivity();
            profileController = new ProfileController();
        }
        
        public bool CreateGroup(String name, int profileId)
        {
            try
            {
                Profile profile = profileController.ReadProfile(profileId.ToString(), 1);
                if (profile != null)
                {
                    if (AddMember(profile.Nickname, dbGroup.CreateGroup(dbActivity.CreateActivity(profileId), name)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;//profile doesnt exist
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteGroup(int groupId, int profileId)
        {
            try
            {
                if (dbActivity.DeleteActivity(profileId, groupId) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
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
                if (dbGroup.UpdateGroup(groupId, name) == 0)
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
                        if (dbGroup.AddMember(dbActivity.CreateActivity(profile.ProfileID), groupId) < 2)
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
                else
                {
                    return true;
                }
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
