using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;
using BusinessTier;

namespace WcfService
{
    public class ProfileService: IProfileService
    {
        IProfileController profileController = new ProfileController();

        public int CreateProfile(Profile profile)
        {
            return profileController.CreateProfile(profile);
        }
        public int Authenticate(Profile profile)
        {
            int profileId = profileController.Authenticate(profile);
            if (profileId != -1)
                if (profileController.GetUser(profileId) != null)
                    return -3;
            return profileId;
        }
        public bool ForgotDetails(string email)
        {
            return profileController.ForgotDetails(email);
        }
        public Profile ReadProfile(string what, int by)
        {
            return profileController.ReadProfile(what, by);
        }
        public bool UpdateProfile(int id, Profile login)
        {
            return profileController.UpdateProfile(id, login);
        }
        public bool DeleteProfile(int loginId)
        {
            return profileController.DeleteProfile(loginId);
        }
    }
}
