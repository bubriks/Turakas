using DataTier;
namespace BusinessTier
{
    public interface ILoginController
    {
        /// <summary>
        /// Creates account, sends email with temporary password
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Returns true if succeded, false otherwise, transaction rollsback and prints error message in console</returns>
        int CreateLogin(Login login);

        /// <summary>
        /// Authenticates given login info
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Returns the ID of that Login</returns>
        int Authenticate(Login login);

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
        Login FindLogin(string what, int by);

        /// <summary>
        /// Updates LoginInfo
        /// </summary>
        /// <param name="id">The ID of the info you want to change</param>
        /// <param name="login">New LoginInfo</param>
        /// <returns>Returns true if succeded, false otherwise and prints error in console</returns>
        bool UpdateLogin(int id, Login login);

        /// <summary>
        /// Deletes LoginInfo
        /// !!! Deleteing Login, WILL ALSO DELETE LINKED PROFILE AND ALL THE ACTIONS THAT PROFILE HAS MADE
        /// </summary>
        /// <param name="login">info you want to delete</param>
        /// <returns>Returns true if succedes, false otherwise and prints error in console</returns>
        bool DeleteLogin(Login login);
    }
}
