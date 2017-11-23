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
        bool CreateGroup(String name, Profile profile);
        bool DeleteGroup(Profile profile);
        bool AddMember(Profile profile);
        bool RemoveMember(Profile profile);
        List<Profile> GetOnlineUsers();
        List<Profile> GetAllUsers();
    }
}
