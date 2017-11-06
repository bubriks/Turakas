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

        public bool CreateProfile(Profile profile)
        {
            return profileController.CreateProfile(profile);
        }
        public Profile ReadProfile(string what, int by)
        {
            return profileController.ReadProfile(what, by);
        }
        public bool UpdateProfile(int profileId, Profile profile)
        {
            return profileController.UpdateProfile(profileId, profile);
        }
    }
}
