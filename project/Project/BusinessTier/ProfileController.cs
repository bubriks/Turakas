using System;
using DataTier;
using DataAccessTier;
using System.Net.Mail;
using System.Net;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace BusinessTier
{
    public class ProfileController : IProfileController
    {
        private DbProfile dbProfile;
        private static List<Profile> users = new List<Profile>();
        public ProfileController()
        {
            dbProfile = new DbProfile();
        }

        public int CreateProfile(Profile profile)
        {
            if (CheckTheValues(profile, true))
            {
                string tempPass = RandomPassword();
                profile.Password = tempPass;
                string subject = ("Your Temporary Password is:");
                string body = "Hello " + profile.Nickname + ", " + "\nYour USERNAME IS: " + profile.Username + "\nYour temporary password is: " + tempPass + "\n\nTHIS PASSWORD WILL BE VALID ONLY FOR 1 WEEK, PLEASE MAKE SURE YOU WILL CHANGE IT.\n\n" + "\nPlease do not reply to this email.\nWith kind regards,\nDigitalDose";

                try
                {
                    Thread thread = new Thread(() => SendEmail(profile.Email, subject, body));
                    thread.Start();
                    int loginId = dbProfile.CreateProfile(profile);
                    return loginId;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return -1;
                }
            }
            return -1;

        }

        public int Authenticate(Profile profile)
        {
            int profileId = dbProfile.Authenticate(profile);
            return profileId;
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
                Profile profiles = dbProfile.ReadProfile(email, 3);
                string tempPass = RandomPassword();
                string subject = ("Your Login Details are:");
                string body = "Hello, " + "\nYour username is: " + profiles.Nickname + "\nYour USERNAME IS: " + profiles.Username + "\nYour temporary password is: " + tempPass + "\n\nTHIS PASSWORD WILL BE VALID ONLY FOR 1 WEEK, PLEASE MAKE SURE YOU WILL CHANGE IT.\n\n" + "\nPlease do not reply to this email.\nWith kind regards,\nDigitalDose";

                //Creates new starnsaction
                try
                {
                    profiles.Password = tempPass;

                    Thread thread = new Thread(() => SendEmail(profiles.Email, subject, body));
                    thread.Start();
                    dbProfile.UpdateProfile(profiles.ProfileID, profiles);
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

        public Profile ReadProfile(string what, int by)
        {
            return dbProfile.ReadProfile(what, by);
        }
        
        public bool UpdateProfile(int id, Profile profile)
        {
            if(CheckTheValues(profile, false))
            {
                if (dbProfile.UpdateProfile(id, profile))
                {
                    Profile user = GetUser(id);
                    user.Email = profile.Email;
                    user.Nickname = profile.Nickname;
                    user.Password = profile.Password;
                    user.Username = profile.Username;
                    return true;
                }
                else
                {
                    return false;//didnt update
                }
            }
            else
            {
                return false;//incorrect details
            }
        }

        public bool DeleteProfile(int profileId)
        {
            return dbProfile.DeleteProfile(profileId);
        }

        /// <summary>
        /// Sends email with the temporary login code
        /// </summary>
        /// <param name="email">address to which the email should be sent</param>
        /// <param name="subject">subject for the email</param>
        /// <param name ="body">body for the email</param>param>
        /// <returns>true if succeded, false otherwise and prints error in console</returns>
        private  void SendEmail(string email, string subject, string body)
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

        public bool Online(int profileId, object obj)
        {
            try
            {
                Profile user = ReadProfile(profileId.ToString(), 1);
                user.CallBack = obj;
                users.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Offline(int profileId)
        {
            try
            {
                Profile user = users.Find(
                delegate (Profile u)
                {
                    return u.ProfileID == profileId;
                }
                );
                users.Remove(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Profile GetUser(String name)
        {
            Profile user = users.Find(
            delegate (Profile u)
            {
                return u.Nickname.Equals(name);
            }
            );
            return user;
        }

        public Profile GetUser(int profiled)
        {
            Profile user = users.Find(
            delegate (Profile u)
            {
                return u.ProfileID == profiled;
            }
            );
            return user;
        }

        private bool CheckTheValues(Profile profile, bool create)
        {
            bool ok = true;
                

            if (create)
            {
                #region username checking
                if (profile.Username.Equals(""))
                {
                    ok = false;
                }

                if (profile.Username.Length < 5 || profile.Username.Length > 16)
                    ok = false;

                #endregion
                #region email checking
                if (profile.Email.Equals(""))
                {
                    ok = false;
                }

                if (ReadProfile(profile.Email, 3) != null)
                    ok = false;
                if (!(profile.Email.Contains("@") && profile.Email.Contains(".")))
                    ok = false;

                #endregion
                #region nickname checking
                if (profile.Nickname.Equals(""))
                {
                    ok = false;
                }

                if (profile.Nickname.Length < 3)
                    ok = false;

                if (ReadProfile(profile.Nickname, 4) != null)
                    ok = false;

                #endregion
            }
            else
            {
                if (!profile.Username.Equals("") && (profile.Username.Length < 5 || profile.Username.Length > 16))
                    ok = false;

                if(!profile.Password.Equals("") && (profile.Password.Length < 6 && !profile.Password.Any(char.IsDigit)))
                
                if (!profile.Email.Equals("") && (!(profile.Email.Contains("@") && profile.Email.Contains("."))))
                    ok = false;
                
                if (!profile.Nickname.Equals("") && (profile.Nickname.Length < 3))
                    ok = false;
            }
            return ok;
        }
    }
}
