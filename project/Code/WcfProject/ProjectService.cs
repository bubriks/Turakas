using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Project;

namespace WcfProject
{
    public class ProjectService : IProjectService
    {
        private static IChatController chatObj = new ChatController();
        public string SendText(string text)
        {
            return chatObj.SendText(text);
        }
    }
}
