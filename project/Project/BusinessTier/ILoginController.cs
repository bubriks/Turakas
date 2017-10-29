using System;
using DataTier;
namespace BusinessTier
{
    interface ILoginController
    {
        bool CreateAccount(Login login);
        bool Authenticate(Login login);
        bool ForgotDetails(Login login);
    }
}
