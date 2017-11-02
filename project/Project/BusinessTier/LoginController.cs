using System;
using DataTier;
using DataAccessTier;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessTier
{
    public class LoginController : ILoginController
    {
        private DbLogin dbLogin;
        private SqlTransaction ts = null;
        public LoginController()
        {
            dbLogin = new DbLogin();
        }

            public bool CreateAccount(Login login)
        {
            string tempPass = RandomPassword();
            string subject = ("Your Temporary Password is:");
            string body = "Hello, " + "\nYour temporary password is: " + tempPass + "\n\nTHIS PASSWORD WILL BE VALID ONLY FOR 1 WEEK, PLEASE MAKE SURE YOU WILL CHANGE IT.\n\n" + "\nPlease do not reply to this email.\nWith kind regards,\nDigitalDose";
            //Creates new starnsaction
            ts = DbConnection.GetInstance().GetConnection().BeginTransaction();
            try
                {
                    login.Password = tempPass;
                    sendEmail(login.Email, subject, body);
                    dbLogin.CreateLogin(login, ts);
                    ts.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    ts.Rollback();
                    Console.WriteLine(e);
                    return false;
                }
            
        }

        public bool Authenticate(Login login)
        {
            switch (dbLogin.Authenticate(login))
            {
                case -1:
                    return false;
                case -2:
                    return false;
                default:
                    return true;
            }
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
                Tuple<Login, int> tuple = dbLogin.ReadLogin(email, 3);
            string tempPass = RandomPassword();
            string subject = ("Your Login Details are:");
            string body = "Hello, " + "\nYour username is: " + tuple.Item1.Username + "\nYour temporary password is: " + tempPass + "\n\nTHIS PASSWORD WILL BE VALID ONLY FOR 1 WEEK, PLEASE MAKE SURE YOU WILL CHANGE IT.\n\n" + "\nPlease do not reply to this email.\nWith kind regards,\nDigitalDose";

            //Creates new starnsaction
            ts = DbConnection.GetInstance().GetConnection().BeginTransaction();
            try
            {
                tuple.Item1.Password = tempPass;
                sendEmail(tuple.Item1.Email, subject, body);
                dbLogin.CreateLogin(tuple.Item1, ts);
                ts.Commit();
                return true;
            }
            catch (Exception e)
            {
                ts.Rollback();
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

        public Tuple<Login, int> FindAccount(string what, int by)
        {
            return dbLogin.ReadLogin(what, by);
        }
        
        public bool UpdateAccount(int id, Login login)
        {
            return dbLogin.UpdateLogin(id, login);
        }

        public bool DeleteAccount(Login login)
        {
            int id = dbLogin.ReadLogin(login.Email, 3).Item2;

            return dbLogin.DeleteLogin(id);
        }

        /// <summary>
        /// Sends email with the temporary login code
        /// </summary>
        /// <param name="email">address to which the email should be sent</param>
        /// <param name="subject">subject for the email</param>
        /// <param name ="body">body for the email</param>param>
        /// <returns>true if succeded, false otherwise and prints error in console</returns>
        private  bool sendEmail(string email, string subject, string body)
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

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
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
