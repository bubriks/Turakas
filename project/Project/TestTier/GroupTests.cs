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
        private int profileId = 1;

        public GroupTests()
        {
            group = new Group();
            gc = new GroupController();
        }

        #region Create group
        [TestMethod]
        public void CreateGroupWorking()
        {
            Assert.AreEqual(true, gc.CreateGroup("Group Name", profileId));
        }

        [TestMethod]
        public void CreateGroupWrongProfileID()
        {
            Assert.AreEqual(false, gc.CreateGroup("Group Name", 0));
        }

        [TestMethod]
        public void CreateGroupEmptyName()
        {
            Assert.AreEqual(false, gc.CreateGroup("", profileId));
        }
        #endregion

        #region Delete group
        [TestMethod]
        public void DeleteGroupWorking()
        {
            List<Group> groups = gc.GetUsersGroups(profileId);
            Assert.AreEqual(true, gc.DeleteGroup(profileId, groups[0].GroupId));
        }

        [TestMethod]
        public void DeleteGroupWrongProfileID()
        {
            List<Group> groups = gc.GetUsersGroups(profileId);
            Assert.AreEqual(false, gc.DeleteGroup(groups[0].GroupId, 0));
        }

        [TestMethod]
        public void DeleteGroupWrongGroupID()
        {
            Assert.AreEqual(false, gc.DeleteGroup(0, profileId));
        }
        #endregion

        #region Update group
        [TestMethod]
        public void UpdateGroupWorking()
        {
            List<Group> groups = gc.GetUsersGroups(profileId);
            Assert.AreEqual(true, gc.UpdateGroup("Test group", groups[0].GroupId));
        }

        [TestMethod]
        public void UpdateGroupEmptyName()
        {
            List<Group> groups = gc.GetUsersGroups(profileId);
            Assert.AreEqual(false, gc.UpdateGroup("", groups[0].GroupId));
        }

        [TestMethod]
        public void UpdateGroupWrongGroupID()
        {
            Assert.AreEqual(false, gc.UpdateGroup("Test group", 0));
        }
        #endregion

        #region Get groups
        [TestMethod]
        public void GetGroupsWorking()
        {
            Assert.AreNotEqual(0, gc.GetUsersGroups(profileId).Count);
        }

        [TestMethod]
        public void GetGroupsWrongProfileId()
        {
            Assert.AreEqual(0, gc.GetUsersGroups(0).Count);
        }
        #endregion

        #region Add group member
        [TestMethod]
        public void AddMemberToGroupWorking()
        {
            List<Group> groups = gc.GetUsersGroups(profileId);
            gc.RemoveMember(profileId, groups[0].GroupId);
            Assert.AreEqual(true, gc.AddMember("Uganda", groups[0].GroupId));
        }

        [TestMethod]
        public void AddMemberToGroupWrongProfileName()
        {
            List<Group> groups = gc.GetUsersGroups(profileId);
            Assert.AreEqual(false, gc.AddMember("", groups[0].GroupId));
        }

        [TestMethod]
        public void AddMemberToGroupWrongGroupId()
        {
            Assert.AreEqual(false, gc.AddMember("Uganda", 0));
        }

        [TestMethod]
        public void AddMemberToGroupWhenHeIsMember()
        {
            List<Group> groups = gc.GetUsersGroups(profileId);
            gc.AddMember("Uganda", groups[0].GroupId);
            Assert.AreEqual(false, gc.AddMember("Uganda", groups[0].GroupId));
        }
        #endregion

        #region Remove member
        [TestMethod]
        public void RemoveMemberFromGroupWorking()
        {
            List<Group> groups = gc.GetUsersGroups(profileId);
            Assert.AreEqual(true, gc.RemoveMember(profileId, groups[0].GroupId));
        }

        [TestMethod]
        public void RemoveMemberFromGroupWrongProfileId()
        {
            List<Group> groups = gc.GetUsersGroups(profileId);
            Assert.AreEqual(false, gc.RemoveMember(0, groups[0].GroupId));
        }

        [TestMethod]
        public void RemoveMemberFromGroupWrongGroupId()
        {
            Assert.AreEqual(false, gc.RemoveMember(profileId, 0));
        }
        #endregion

        #region Get group members
        [TestMethod]
        public void GetGroupMembersWorking()
        {
            List<Group> groups = gc.GetUsersGroups(profileId);
            Assert.AreNotEqual(0, gc.GetUsers(groups[groups.Count - 1].GroupId).Count);
        }

        [TestMethod]
        public void GetGroupMembersWrongGroupId()
        {
            Assert.AreEqual(0, gc.GetUsers(0).Count);
        }
        #endregion

        #region Get online members
        [TestMethod]
        public void GetOnlineGroupMembersWorking()
        {
            List<Group> groups = gc.GetUsersGroups(profileId);
            new ProfileController().Online(profileId, new object());
            Assert.AreNotEqual(0, gc.GetOnlineMembers(groups[groups.Count -1].GroupId).Count);
        }

        [TestMethod]
        public void GetOnlineGroupMembersWrongGroupId()
        {
            Assert.AreEqual(0, gc.GetOnlineMembers(0).Count);
        }

        [TestMethod]
        public void GetOnlineGroupMembersNoOneOnline()
        {
            List<Group> groups = gc.GetUsersGroups(profileId);
            Assert.AreEqual(0, gc.GetOnlineMembers(groups[0].GroupId).Count);
        }
        #endregion
    }
}
