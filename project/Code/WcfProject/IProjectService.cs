using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfProject
{
    [ServiceContract]
    public interface IProjectService
    {
        [OperationContract]
        string SendText(String text);
    }
}
