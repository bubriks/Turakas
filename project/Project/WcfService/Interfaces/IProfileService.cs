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
    public interface IProfileService
    {
        [OperationContract]
        bool CreateProfile(Profile profile);
        [OperationContract]
        Profile ReadProfile(string what, int by);
        [OperationContract]
        bool UpdateProfile(int profileId, Profile profile);
    }
}
