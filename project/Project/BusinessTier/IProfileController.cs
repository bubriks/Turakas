using DataTier;

namespace BusinessTier
{
    public interface IProfileController
    {
        bool CreateProfile(Profile profile);
        Profile ReadProfile(string what, int by);
        bool UpdateProfile(int profileId, Profile profile);
    }
}
