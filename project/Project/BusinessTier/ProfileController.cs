using DataTier;
using DataAccessTier;
using System.Collections.Generic;
using System;

namespace BusinessTier
{
    public class ProfileController : IProfileController
    {
        private DbProfile dbProfile;
        private static List<Profile> users = new List<Profile>();

        public ProfileController()
        {
            dbProfile = new DbProfile();
        }

        public bool Online(int profileId, object obj)
        {
            try
            {
                Profile user = ReadProfile(profileId.ToString(), 1);
                user.CallBack = obj;
                users.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Offline(int profileId)
        {
            try
            {
                Profile user = users.Find(
                delegate (Profile u)
                {
                    return u.ProfileID == profileId;
                }
                );
                users.Remove(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Profile> OnlineUsers()
        {
            return users;
        }

        public bool CreateProfile(Profile profile)
        {
            return dbProfile.CreateProfile(profile);
        }

        public Profile ReadProfile(string what, int by)
        {
            return dbProfile.ReadProfile(what, by);
        }

        public bool UpdateProfile(int profileId, Profile profile)
        {
            return dbProfile.UpdateProfile(profileId, profile);
        }
    }
}
