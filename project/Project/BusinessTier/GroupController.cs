using BusinessTier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using DataAccessTier;
using System.Data;

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

        public bool CreateGroup(string name, int profileId)
        {
            Profile profile = profileController.ReadProfile(profileId.ToString(), 1);
            if (profile != null && !name.Equals(""))
            {
                using (IDbTransaction tran = DbConnection.GetInstance().BeginTransaction())
                {
                    try
                    {
                        int activityId = dbActivity.CreateActivity(profileId);
                        int groupId = dbGroup.CreateGroup(activityId, name);
                        if (AddMember(profile.Nickname, groupId))
                        {
                            tran.Commit();
                            return true;
                        }
                        else
                        {
                            tran.Rollback();
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        return false;
                    }
                }
            }
            else
            {
                return false;//profile doesnt exist
            }
        }

        public bool DeleteGroup(int profileId, int groupId)
        {
            try
            {
                if (dbActivity.DeleteActivity(profileId, groupId) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateGroup(string name, int groupId)
        {
            try
            {
                if (!name.Equals("") && dbGroup.UpdateGroup(groupId, name) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
        
        public bool AddMember(string memberName, int groupId)
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
                        if (dbGroup.AddMember(dbActivity.CreateActivity(profile.ProfileID), groupId) == 0)
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
