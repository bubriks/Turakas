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
            SqlConnection con = new DbConnection().GetConnection();
            try
            {
                Profile profile = profileController.ReadProfile(profileId.ToString(), 1, null, con);
                if (profile != null && !name.Equals(""))
                {
                        using (IDbTransaction tran = con.BeginTransaction())
                        {
                        try
                        {
                            int activityId = dbActivity.CreateActivity(profileId, (SqlTransaction)tran, con);
                            int groupId = dbGroup.CreateGroup(activityId, name, (SqlTransaction)tran, con);
                            if (AddMember(profile.Nickname, groupId, (SqlTransaction)tran, con))
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
            finally
            {
                con.Close();
            }
        }

        public bool DeleteGroup(int profileId, int groupId)
        {
            try
            {
                SqlConnection con = new DbConnection().GetConnection();
                try
                {
                    if (dbActivity.DeleteActivity(profileId, groupId, null, con) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                finally
                {
                    con.Close();
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
                SqlConnection con = new DbConnection().GetConnection();
                try
                {
                    if (!name.Equals("") && dbGroup.UpdateGroup(groupId, name, null, con) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                finally
                {
                    con.Close();
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
                SqlConnection con = new DbConnection().GetConnection();
                try
                {
                    return dbGroup.GetUsersGroups(profileId, null, con);
                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception)
            {
                return new List<Group>();
            }
        }
        
        public bool AddMember(string memberName, int groupId, SqlTransaction transaction, SqlConnection con)
        {
            try
            {
                Profile profile = profileController.ReadProfile(memberName, 4, transaction, con);
                if (profile == null)
                {//user not found
                    return false;
                }
                else
                {//user found
                    if (dbGroup.UserIsMemberOfGroup(profile.ProfileID, groupId, transaction, con))
                    {//user isnt in group
                        if (dbGroup.AddMember(dbActivity.CreateActivity(profile.ProfileID, transaction, con), groupId, transaction, con) == 0)
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
                SqlConnection con = new DbConnection().GetConnection();
                try
                {
                    if (dbGroup.RemoveMember(profileId, groupId, null, con) == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                finally
                {
                    con.Close();
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
                SqlConnection con = new DbConnection().GetConnection();
                try
                {
                    return dbGroup.GetUsers(groupId, null, con);
                }
                finally
                {
                    con.Close();
                }
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
