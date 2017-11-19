using System;
using DataTier;
using DataAccessTier;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;

namespace BusinessTier
{
    public class LoginController : ILoginController
    {
        IProfileController profileController = new ProfileController();
        private DbLogin dbLogin;
        public LoginController()
        {
            dbLogin = new DbLogin();
        }

        public int CreateLogin(Login login, string nickname)
        {
            string tempPass = RandomPassword();
            login.Password = tempPass;
            string subject = ("Your Temporary Password is:");
            string body = "Hello "+ login.Username +", " + "\nYour temporary password is: " + tempPass + "\n\nTHIS PASSWORD WILL BE VALID ONLY FOR 1 WEEK, PLEASE MAKE SURE YOU WILL CHANGE IT.\n\n" + "\nPlease do not reply to this email.\nWith kind regards,\nDigitalDose";

            try
            {
                sendEmail(login.Email, subject, body);
                int loginId = dbLogin.CreateLogin(login);
                Profile profile = new Profile
                {
                    Nickname = nickname,
                    ProfileID = loginId,
                    StatusID = 2,
                };
                profileController.CreateProfile(profile);
                return loginId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
            
        }

        public int Authenticate(Login login)
        {
            int loginId = dbLogin.Authenticate(login);
            Profile profile = new Profile {StatusID = 1, };
            profileController.UpdateProfile(loginId, profile);
            return loginId;
        }

        /// <summary>
        /// Changes
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ForgotDetails(string email)
        {
            try
            {
                Login logins = dbLogin.ReadLogin(email, 3);
            string tempPass = RandomPassword();
            string subject = ("Your Login Details are:");
            string body = "Hello, " + "\nYour username is: " + logins.Username + "\nYour temporary password is: " + tempPass + "\n\nTHIS PASSWORD WILL BE VALID ONLY FOR 1 WEEK, PLEASE MAKE SURE YOU WILL CHANGE IT.\n\n" + "\nPlease do not reply to this email.\nWith kind regards,\nDigitalDose";

                //Creates new starnsaction
                try
                {
                    logins.Password = tempPass;
                    sendEmail(logins.Email, subject, body);
                    dbLogin.UpdateLogin(logins.LoginId, logins);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public Login FindLogin(string what, int by)
        {
            return dbLogin.ReadLogin(what, by);
        }
        
        public bool UpdateLogin(int id, Login login)
        {
            return dbLogin.UpdateLogin(id, login);
        }

        public bool DeleteLogin(int loginId)
        {
            return dbLogin.DeleteLogin(loginId);
        }

        /// <summary>
        /// Sends email with the temporary login code
        /// </summary>
        /// <param name="email">address to which the email should be sent</param>
        /// <param name="subject">subject for the email</param>
        /// <param name ="body">body for the email</param>param>
        /// <returns>true if succeded, false otherwise and prints error in console</returns>
        private  void sendEmail(string email, string subject, string body)
        {
            try
            {
                var fromAddress = new MailAddress("uchouseemail@gmail.com", "noreply_DigitalDose");
                var toAddress = new MailAddress(email, "To User");
                const string fromPassword = "UcHousePassword1234";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                     UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw (e);
            }
        }

        /// <summary>
        /// Generates the temporaryPassword.
        /// </summary>
        /// <note>because it uses the GUID, it guarantees that in 10 million generated strings, there wont be any repetition</note>
        /// <returns></returns>
        private string RandomPassword()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");

            return GuidString;
        }

    }
}
