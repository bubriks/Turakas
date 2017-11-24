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
        public void AddMember(int profileId)
        {
            gc.AddMember(profileId);
        }

        public void CreateGroup(String name, int profileId)
        {
            gc.CreateGroup(name, profileId);
        }

        public void DeleteGroup(String name)
        {
            gc.DeleteGroup(name);
        }

        public List<int> GetAllUsers()
        {
            return gc.GetAllUsers();
        }

        public List<int> GetOnlineUsers()
        {
            return gc.GetOnlineUsers();
        }

        public void RemoveMember(int profileId)
        {
            gc.RemoveMember(profileId);
        }
    }
}
