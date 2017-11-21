using DataTier;
using System;
using System.Collections.Generic;

namespace BusinessTier
{
    public interface IProfileController
    {
        bool Online(int profileId, object obj);
        bool Offline(int profileId);
        Profile GetUser(String name);
        bool CreateProfile(Profile profile);
        Profile ReadProfile(string what, int by);
        bool UpdateProfile(int profileId, Profile profile);
    }
}
