using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;

namespace WcfService
{
    [ServiceContract]
    public interface IGroupService
    {
        [OperationContract]
        bool CreateGroup(String name, int profileId);

        [OperationContract]
        bool DeleteGroup(int profileId, int groupId);

        [OperationContract]
        bool UpdateGroup(String name, int groupId);

        [OperationContract]
        List<Group> GetUsersGroups(int profileId);

        [OperationContract]
        bool AddMember(String memberName, int groupId);

        [OperationContract]
        bool RemoveMember(int profileId, int groupId);

        [OperationContract]
        List<Profile> GetUsers(int groupId);

        [OperationContract]
        List<Profile> GetOnlineMembers(int groupId);
    }
}
