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
        bool CreateGroup(String name, Profile profile);
        [OperationContract]
        bool DeleteGroup(Profile profile);
        [OperationContract]
        bool AddMember(Profile profile);
        [OperationContract]
        bool RemoveMember(Profile profile);
        [OperationContract]
        List<Profile> GetOnlineUsers();
        [OperationContract]
        List<Profile> GetAllUsers();

    }
}
