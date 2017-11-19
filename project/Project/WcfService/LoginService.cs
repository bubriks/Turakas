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
    public class LoginService: ILoginService
    {
        ILoginController loginController = new LoginController();

        public int CreateLogin(Login login, string nickname)
        {
            return loginController.CreateLogin(login, nickname);
        }
        public int Authenticate(Login login)
        {
            return loginController.Authenticate(login);
        }
        public bool ForgotDetails(string email)
        {
            return loginController.ForgotDetails(email);
        }
        public Login FindLogin(string what, int by)
        {
            return loginController.FindLogin(what, by);
        }
        public bool UpdateLogin(int id, Login login)
        {
            return loginController.UpdateLogin(id, login);
        }
        public bool DeleteLogin(int loginId)
        {
            return loginController.DeleteLogin(loginId);
        }
    }
}
