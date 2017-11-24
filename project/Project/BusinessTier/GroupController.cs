using BusinessTier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using DataAccessTier;

namespace BusinessTier
{
    public class GroupController : IGroupController
    {
        private DbGroup dbGroup;
        public GroupController()
        {
            dbGroup = new DbGroup();
        }
        public void SomethingWentWrong()
        {
            Console.WriteLine("Something went wrong!");
        }
        public void AddMember(int profileId)
        {
            try
            {
                dbGroup.AddMember(profileId);
            }
            catch { SomethingWentWrong(); }
        }

        public void CreateGroup(String name, int profileId)
        {
            try
            {
                dbGroup.CreateGroup(name, profileId);
            }
            catch { SomethingWentWrong(); }
        }

        public void DeleteGroup(String name)
        {
            try
            {
                dbGroup.DeleteGroup(name);
            }
            catch { SomethingWentWrong(); }
        }

        public List<int> GetAllUsers()
        {
            try
            {
                return dbGroup.GetAllUsers();
            }
            catch { return null; }
        }

        public List<int> GetOnlineUsers()
        {
            try
            {
                return dbGroup.GetOnlineUsers();
            }
            catch { return null; }
        }

        public void RemoveMember(int profileId)
        {
            try
            {
                dbGroup.RemoveMember(profileId);
            }
            catch { SomethingWentWrong(); }
        }
    }
}
