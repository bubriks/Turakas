using DataTier;
using System;
using System.Collections.Generic;

namespace BusinessTier
{
    public interface IProfileController
    {
        /// <summary>
        /// Creates account, sends email with temporary password
        /// </summary>
        /// <param name="profile"></param>
        /// <returns>Returns true if succeded, false otherwise, prints error message in console</returns>
        int CreateProfile(Profile profile);

        /// <summary>
        /// Authenticates given login info
        /// </summary>
        /// <param name="profile"></param>
        /// <returns>Returns the ID of that Login</returns>
        int Authenticate(Profile profile);

        /// <summary>
        /// Sets user's password to a unique random string and sends the new details via email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool ForgotDetails(string email);

        /// <summary>
        /// Can find account
        /// </summary>
        /// <param name="what">string of what you are looking for</param>
        /// <param name="by">type by which the search should be done (1 = id, 2 = username, 3 = email)</param>
        /// <returns></returns>
        Profile ReadProfile(string what, int by);

        /// <summary>
        /// Updates LoginInfo
        /// </summary>
        /// <param name="id">The ID of the info you want to change</param>
        /// <param name="profile">New LoginInfo</param>
        /// <returns>Returns true if succeded, false otherwise and prints error in console</returns>
        bool UpdateProfile(int id, Profile profile);

        /// <summary>
        /// Deletes LoginInfo
        /// !!! Deleteing Login, WILL ALSO DELETE LINKED PROFILE AND ALL THE ACTIONS THAT PROFILE HAS MADE
        /// </summary>
        /// <param name="profileId">info you want to delete</param>
        /// <returns>Returns true if succedes, false otherwise and prints error in console</returns>
        bool DeleteProfile(int profileId);

        bool Online(int profileId, object obj);

        bool Offline(int profileId);

        Profile GetUser(string name);

        Profile GetUser(int profiled);
    }
}
