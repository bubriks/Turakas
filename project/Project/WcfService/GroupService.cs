using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using BusinessTier;

namespace WcfService
{
    public class GroupService : IGroupService
    {
        IGroupController gc = new GroupController();
        public bool AddMember(Profile profile)
        {
            return gc.AddMember(profile);
        }

        public bool CreateGroup(String name, Profile profile)
        {
            return gc.CreateGroup(name, profile);
        }

        public bool DeleteGroup(Profile profile)
        {
            return gc.DeleteGroup(profile);
        }

        public List<Profile> GetAllUsers()
        {
            return gc.GetAllUsers();
        }

        public List<Profile> GetOnlineUsers()
        {
            return gc.GetOnlineUsers();
        }

        public bool RemoveMember(Profile profile)
        {
            return gc.RemoveMember(profile);
        }
    }
}
