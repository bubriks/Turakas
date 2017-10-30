﻿using System;
using DataTier;
using DataAccessTier;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;

namespace BusinessTier
{
    class LoginController: ILoginController
    {
        DBLogin dbLogin;
        public LoginController()
        {
            dbLogin = new DBLogin();
        }

        public bool CreateAccount(Login login)
        {
            string tempPass = RandomPassword();
            string subject = ("Your Temporary Password is:");
            string body = "Hello, " + "\nYour temporary password is: " + tempPass + "\n\nTHIS PASSWORD WILL BE VALID ONLY FOR 1 WEEK, PLEASE MAKE SURE YOU WILL CHANGE IT.\n\n" + "\nPlease do not reply to this email.\nWith kind regards,\nDigitalDose";
            try
            {
                login.Password = tempPass;
                sendEmail(login.Email, subject, body);
                dbLogin.CreateLogin(login);
                return true;
            }
            catch (Exception e)
            {
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

        public bool ForgotDetails(Login login)
        {
            return false;
        }

        /// <summary>
        /// Sends email with the temporary login code
        /// </summary>
        /// <param name="email">address to which the email should be sent</param>
        /// <param name="tempPass">temporary auto-generated password</param>param>
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
