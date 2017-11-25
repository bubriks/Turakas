using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessTier;
using DataTier;
using System.Collections.Generic;

namespace TestTier
{
    [TestClass]
    public class GroupTests
    {
        private Group group = null;
        private GroupController gc = null;
        private int profileId, groupId;
        private String name;

        public GroupTests()
        {
            group = new Group();
            gc = new GroupController();

            profileId = 1;
        }
        [TestMethod]
        public void CreateGroupTest()
        {
            name = "TestGroup1";
            groupId = gc.CreateGroup(name, profileId);
            Assert.AreNotEqual(-1, groupId);
        }
        [TestMethod]
        public void AddMemberTestProfile2Group598()
        {
            Assert.AreEqual(true, gc.AddMember(2, groupId));
        }
        [TestMethod]
        public void GetAllUsersTestGroup598()
        {
            List<Profile> profiles = new List<Profile>();
            profiles = gc.GetAllUsers(groupId);
            Assert.AreNotEqual(0, profiles.Count);
        }
        [TestMethod]
        public void GetOnlineUsersTestGroup598()
        {
            List<Profile> profiles = new List<Profile>();
            profiles = gc.GetOnlineUsers(groupId);
            Assert.AreNotEqual(null, profiles);
        }
        [TestMethod]
        public void RemoveMemberTest()
        {
            Assert.AreEqual(true, gc.RemoveMember(2, groupId));
        }
        [TestMethod]
        public void DeleteGroupTest()
        {
            Assert.AreEqual(true, gc.DeleteGroup(groupId));
        }
    }
}
