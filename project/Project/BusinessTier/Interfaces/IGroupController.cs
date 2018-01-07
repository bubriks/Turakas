using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using DataAccessTier;
using System.Data.SqlClient;

namespace BusinessTier
{
    public interface IGroupController
    {
        bool CreateGroup(string name, int profileId);
        bool DeleteGroup(int profileId, int groupId);
        bool UpdateGroup(string name, int groupId);
        List<Group> GetUsersGroups(int profileId);
        bool AddMember(string memberName, int groupId, SqlTransaction transaction, SqlConnection con);
        bool RemoveMember(int profileId, int groupId);
        List<Profile> GetUsers(int groupId);
        List<Profile> GetOnlineMembers(int groupId);
    }
}
