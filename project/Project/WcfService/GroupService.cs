using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using BusinessTier;
using System.ServiceModel;

namespace WcfService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public class GroupService : IGroupService
    {
        private IGroupController groupController = new GroupController();

        public bool CreateGroup(string name, int profileId)
        {
            return groupController.CreateGroup(name, profileId);
        }

        public bool DeleteGroup(int profileId, int groupId)
        {
            return groupController.DeleteGroup(profileId, groupId);
        }

        public bool UpdateGroup(string name, int groupId)
        {
            return groupController.UpdateGroup(name, groupId);
        }

        public List<Group> GetUsersGroups(int profileId)
        {
            return groupController.GetUsersGroups(profileId);
        }

        public bool AddMember(string memberName, int groupId)
        {
            return groupController.AddMember(memberName, groupId, null);
        }

        public bool RemoveMember(int profileId, int groupId)
        {
            return groupController.RemoveMember(profileId, groupId);
        }

        public List<Profile> GetUsers(int groupId)
        {
            return groupController.GetUsers(groupId);
        }

        public List<Profile> GetOnlineMembers(int groupId)
        {
            return groupController.GetOnlineMembers(groupId);
        }
    }
}
