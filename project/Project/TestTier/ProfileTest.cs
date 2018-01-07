using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataTier;
using BusinessTier;
using DataAccessTier;

namespace TestTier
{
    /// <summary>
    /// Summary description for ProfileTest
    /// </summary>
    [TestClass]
    public class ProfileTest
    {
        private ProfileController profileController;
        public ProfileTest()
        {
            profileController = new ProfileController();
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestCreateProfileSuccess()
        {
            Profile profile = new Profile
            {
                Username = "Uganda",
                Email = "asdf@.",
                Nickname = "TestingAccountsPleaseDontDelete"
            };
            Assert.AreNotEqual(-1, profileController.CreateProfile(profile));
        }
        [TestMethod]
        public void TestCreateProfileFail()
        {
            Profile profile = new Profile
            {
                Username = "asd",
                Email = "asdf@.",
                Nickname = "TestingAccountsPleaseDontDelete",
            };
            Assert.AreEqual(-1, profileController.CreateProfile(profile));
        }

        [TestMethod]
        public void TestReadProfileIdSuccess()
        {
            int profileId = profileController.ReadProfile("TestingAccountsPleaseDontDelete", 4, null, new DbConnection().GetConnection()).ProfileID;
            Assert.AreNotEqual(null, profileController.ReadProfile(profileId.ToString(), 1, null, new DbConnection().GetConnection()));
        }
        [TestMethod]
        public void TestReadProfileIdFail()
        {
            Assert.AreEqual(null, profileController.ReadProfile("0", 1, null, new DbConnection().GetConnection()));
        }
        [TestMethod]
        public void TestReadProfileUsernameSuccess()
        {
            Assert.AreNotEqual(null, profileController.ReadProfile("Uganda", 2, null, new DbConnection().GetConnection()));
        }
        [TestMethod]
        public void TestReadProfileUsernameFail()
        {
            Assert.AreNotEqual(null, profileController.ReadProfile("Uganda", 2, null, new DbConnection().GetConnection()));
        }
        [TestMethod]
        public void TestReadProfileEmailSuccess()
        {
            Assert.AreNotEqual(null, profileController.ReadProfile("asdf@.", 3, null, new DbConnection().GetConnection()));
        }
        [TestMethod]
        public void TestReadProfileEmailFail()
        {
            Assert.AreEqual(null, profileController.ReadProfile("asdf", 3, null, new DbConnection().GetConnection()));
        }
        [TestMethod]
        public void TestReadProfileNicknameSuccess()
        {
            Assert.AreNotEqual(null, profileController.ReadProfile("TestingAccountsPleaseDontDelete", 4, null, new DbConnection().GetConnection()));
        }
        [TestMethod]
        public void TestReadProfileNicknameFail()
        {
            Assert.AreEqual(null, profileController.ReadProfile("TestingAccountsPleaseDontsDelete", 4, null, new DbConnection().GetConnection()));
        }

        [TestMethod]
        public void TestUpdateProfileSuccess()
        {
            Profile profile = new Profile
            {
                Username = "Uganda",
                Password = "123456",
                Email = "",
                Nickname = "Changed",
            };
            int profileId = profileController.ReadProfile("TestingAccountsPleaseDontDelete", 4, null, new DbConnection().GetConnection()).ProfileID;
            Assert.AreEqual(true, profileController.UpdateProfile(profileId, profile));
        }
        [TestMethod]
        public void TestUpdateProfileFail()
        {
            Profile profile = new Profile
            {
                Username = "fd",
                Password = "123456",
                Email = "",
                Nickname = "as",
            };
            int profileId = profileController.ReadProfile("TestingAccountsPleaseDontDelete", 4, null, new DbConnection().GetConnection()).ProfileID;
            Assert.AreNotEqual(true, profileController.UpdateProfile(profileId, profile));
        }
        [TestMethod]
        public void TestAuthenticateSuccess()
        {
            Profile profile = new Profile
            {
                Username = "Uganda",
                Password = "123456",
            };
            Assert.AreNotEqual(-1, profileController.Authenticate(profile));
        }
        [TestMethod]
        public void TestAuthenticateFail()
        {
            Profile profile = new Profile
            {
                Username = "Uganda",
                Password = "none",
            };
            Assert.AreEqual(-1, profileController.Authenticate(profile));
        }
        [TestMethod]
        public void TestForgotDetailsSuccess()
        {
            Assert.AreEqual(true, profileController.ForgotDetails("asdf@."));
        }
        [TestMethod]
        public void TestForgotDetailsFail()
        {
            Assert.AreNotEqual(true, profileController.ForgotDetails("sdf."));
        }
        [TestMethod]
        public void TestDeleteProfileSuccess()
        {
            int profileId = profileController.ReadProfile("TestingAccountsPleaseDontDelete", 4, null, new DbConnection().GetConnection()).ProfileID;
            Assert.AreEqual(true, profileController.DeleteProfile(profileId));
        }
        [TestMethod]
        public void TestDeleteProfileFail()
        {
            Assert.AreNotEqual(true, profileController.DeleteProfile(0));
        }
    }
}
