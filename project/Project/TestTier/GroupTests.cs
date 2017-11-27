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

            profileId = 2; //Profile named hanes
            groupId = 645; //Group named lol
        }
        [TestMethod]
        public void CreateGroupTestWrongProfileID()
        {
            name = "TestGroup2";
            profileId = 99;
            Assert.AreNotEqual(true, gc.CreateGroup(name, profileId));
        }
        [TestMethod]
        public void CreateGroupTest()
        {
            name = "TestGroup1";
            Assert.AreEqual(true, gc.CreateGroup(name, profileId));
        }
        [TestMethod]
        public void AddMemberTestWrongProfile()
        {
            String userName = "XxXxX";
            Assert.AreNotEqual(true, gc.AddMember(userName, 4));
        }
        [TestMethod]
        public void AddMemberTestWrongByType()
        {
            String userName = "Uganda";
            Assert.AreNotEqual(true, gc.AddMember(userName, 1));
        }
        [TestMethod]
        public void AddMemberTest()
        {
            String userName = "Uganda";
            Assert.AreEqual(true, gc.AddMember(userName, groupId));
        }
        [TestMethod]
        public void GetAllUsersTestWrongGroupID()
        {
            groupId = 100;
            List<Profile> profiles = new List<Profile>();
            profiles = gc.GetUsers(groupId);
            Assert.AreEqual(0, profiles.Count);
        }
        [TestMethod]
        public void GetAllUsersTest()
        {
            List<Profile> profiles = new List<Profile>();
            profiles = gc.GetUsers(groupId);
            Assert.AreNotEqual(0, profiles.Count);
        }
        [TestMethod]
        public void GetOnlineMembersTestWrongGroupID()
        {
            groupId = 100;
            List<Profile> profiles = new List<Profile>();
            profiles = gc.GetOnlineMembers(groupId);
            Assert.AreNotEqual(null, profiles);
        }
        [TestMethod]
        public void GetOnlineMembersTest()
        {
            List<Profile> profiles = new List<Profile>();
            profiles = gc.GetOnlineMembers(groupId);
            Assert.AreNotEqual(null, profiles);
        }
        [TestMethod]
        public void RemoveMemberTestNoSuchProfileInGroup()
        {
            profileId = 20;
            Assert.AreNotEqual(true, gc.RemoveMember(profileId, groupId));
        }
        [TestMethod]
        public void RemoveMemberTestNoSuchGroup()
        {
            groupId = 100;
            Assert.AreNotEqual(true, gc.RemoveMember(2, groupId));
        }
        [TestMethod]
        public void RemoveMemberTest()
        {
            Assert.AreNotEqual(true, gc.RemoveMember(profileId, groupId));
        }
        [TestMethod]
        public void DeleteGroupTestNoSuchGroup()
        {
            groupId = 100;
            Assert.AreNotEqual(true, gc.DeleteGroup(groupId));
        }
        [TestMethod]
        public void DeleteGroupTest()
        {
            Assert.AreEqual(true, gc.DeleteGroup(groupId));
        }
        [TestMethod]
        public void UpdateGroupTestWrongGroupID()
        {
            String groupName = "NewGroupName";
            groupId = 100;
            Assert.AreNotEqual(true, gc.UpdateGroup(groupName, groupId));
        }
        [TestMethod]
        public void UpdateGroupTest()
        {
            String groupName = "NewGroupName";
            Assert.AreEqual(true, gc.UpdateGroup(groupName, groupId));
        }
    }
}
