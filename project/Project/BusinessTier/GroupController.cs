using BusinessTier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;
using DataAccessTier;
using System.Data.SqlClient;
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
            Profile profile = profileController.ReadProfile(profileId.ToString(), 1, null);
            if (profile != null && !name.Equals(""))
            {
                using (IDbTransaction tran = DbConnection.GetInstance().GetConnection().BeginTransaction())
                {
                    try
                    {
                        int activityId = dbActivity.CreateActivity(profileId, (SqlTransaction)tran);
                        int groupId = dbGroup.CreateGroup(activityId, name, (SqlTransaction)tran);
                        if (AddMember(profile.Nickname, groupId, (SqlTransaction)tran))
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
                if (dbActivity.DeleteActivity(profileId, groupId, null) == 1)
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
                if (!name.Equals("") && dbGroup.UpdateGroup(groupId, name, null) == 1)
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
                return dbGroup.GetUsersGroups(profileId, null);
            }
            catch (Exception)
            {
                return new List<Group>();
            }
        }
        
        public bool AddMember(string memberName, int groupId, SqlTransaction transaction)
        {
            try
            {
                Profile profile = profileController.ReadProfile(memberName, 4, transaction);
                if (profile == null)
                {//user not found
                    return false;
                }
                else
                {//user found
                    if (dbGroup.UserIsMemberOfGroup(profile.ProfileID, groupId, transaction))
                    {//user isnt in group
                        if (dbGroup.AddMember(dbActivity.CreateActivity(profile.ProfileID, transaction), groupId, transaction) == 0)
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
                if (dbGroup.RemoveMember(profileId, groupId, null) == 0)
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
                return dbGroup.GetUsers(groupId, null);
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
