using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using DataAccessTier;

namespace BusinessTier
{
    public interface IGroupController
    {
        int CreateGroup(String name, int profileId);
        bool DeleteGroup(int groupId);
        bool AddMember(int profileId, int groupId);
        bool RemoveMember(int profileId, int groupId);
        List<Profile> GetOnlineUsers(int groupId);
        List<Profile> GetAllUsers(int groupId);
    }
}
