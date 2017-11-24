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
        void DeleteGroup(String name);
        [OperationContract]
        void AddMember(int profileId);
        [OperationContract]
        void RemoveMember(int profileId);
        [OperationContract]
        List<int> GetOnlineUsers();
        [OperationContract]
        List<int> GetAllUsers();

    }
}
