using DataTier;
using DataAccessTier;

namespace BusinessTier
{
    public class ProfileController : IProfileController
    {
        private DbProfile dbProfile;

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
