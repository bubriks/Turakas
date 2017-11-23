using DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    [ServiceContract]
    public interface IProfileService
    {
        [OperationContract]
        int CreateProfile(Profile profile);
        [OperationContract]
        int Authenticate(Profile profile);
        [OperationContract]
        bool ForgotDetails(string email);
        [OperationContract]
        Profile ReadProfile(string what, int by);
        [OperationContract]
        bool UpdateProfile(int id, Profile profile);
        [OperationContract]
        bool DeleteProfile(int profileId);
    }
}
