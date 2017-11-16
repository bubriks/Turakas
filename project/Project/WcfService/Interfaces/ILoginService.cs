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
    public interface ILoginService
    {
        [OperationContract]
        int CreateLogin(Login login);
        [OperationContract]
        int Authenticate(Login login);
        [OperationContract]
        bool ForgotDetails(string email);
        [OperationContract]
        Login FindLogin(string what, int by);
        [OperationContract]
        bool UpdateLogin(int id, Login login);
        [OperationContract]
        bool DeleteLogin(Login login);
    }
}
