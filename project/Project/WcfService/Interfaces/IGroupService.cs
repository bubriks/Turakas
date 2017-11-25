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
        void CreateGroup(String name, int profileId);
        [OperationContract]
        void DeleteGroup(int groupId);
        [OperationContract]
        void AddMember(int profileId, int groupId);
        [OperationContract]
        void RemoveMember(int profileId, int groupId);
        [OperationContract]
        List<Profile> GetOnlineUsers(int groupId);
        [OperationContract]
        List<Profile> GetAllUsers(int groupId);

    }
}
