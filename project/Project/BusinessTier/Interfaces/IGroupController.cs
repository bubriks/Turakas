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
        void CreateGroup(String name, int profileId);
        void DeleteGroup(String name);
        void AddMember(int profileId);
        void RemoveMember(int profileId);
        List<int> GetOnlineUsers();
        List<int> GetAllUsers();
    }
}
