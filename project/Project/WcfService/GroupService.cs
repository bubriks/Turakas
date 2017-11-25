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
        public void AddMember(int profileId, int groupId)
        {
            gc.AddMember(profileId, groupId);
        }

        public void CreateGroup(String name, int profileId)
        {
            gc.CreateGroup(name, profileId);
        }

        public void DeleteGroup(int groupId)
        {
            gc.DeleteGroup(groupId);
        }

        public List<Profile> GetAllUsers(int groupId)
        {
            return gc.GetAllUsers(groupId);
        }

        public List<Profile> GetOnlineUsers(int groupId)
        {
            return gc.GetOnlineUsers(groupId);
        }

        public void RemoveMember(int profileId, int groupId)
        {
            gc.RemoveMember(profileId, groupId);
        }
    }
}
