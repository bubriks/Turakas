using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentationTier.LoginServiceReference;
using PresentationTier.ProfileServiceReference;
using System.ServiceModel;

namespace PresentationTier
{
    public partial class SignIn_SignUp_ForgotDetails: Form
    {
        private ILoginService loginService = new LoginServiceClient();
        private IProfileService profileService = new ProfileServiceClient();

        public SignIn_SignUp_ForgotDetails()
        {
            InitializeComponent();

            passwordSignIn_txt.PasswordChar = '卐';
            passwordSignUp_txt.PasswordChar = '☭';

            SignIn_grp.Top = 65;
            SignIn_grp.Left = 122;
        }
        #region SignUp
        private void SignUp_btn_Click(object sender, EventArgs e)
        {
            SignUp_grp.Visible = true;
            SignIn_grp.Top = 12;
            SignIn_grp.Left = 12;

            ForgotDetails_grp.Top = 133;
            ForgotDetails_grp.Left = 12;
        }
        
        private void Register_btn_Click(object sender, EventArgs e)
        {
            if (CheckTheValues())
            {
                string username = usernameSignUp_txt.Text;
                string password = passwordSignUp_txt.Text;
                string email = emailSignUp_txt.Text;
                string nickname = nicknameSignUp_txt.Text;

                Login login = new Login
                {
                    Username = username,
                    Password = password,
                    Email = email,
                };

                if (loginService.CreateLogin(login))
                {
                    registerError_lbl.Visible = true;
                    registerError_lbl.Text = "Check your email for confirmation!";
                    registerError_lbl.ForeColor = Color.Green;
                }
                else
                {

                }
            }
        }

        private bool CheckTheValues()
        {
            bool ok = true;
            string username = usernameSignUp_txt.Text;
            string password = passwordSignUp_txt.Text;
            string email = emailSignUp_txt.Text;
            string nickname = nicknameSignUp_txt.Text;

            #region username checking
            if (username.Length < 5)
            {
                ok = false;
                usernameSignUp_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
                usernameSignUpError_lbl.Visible = true;
                usernameSignUpError_lbl.ForeColor = Color.Red;
                usernameSignUpError_lbl.Text = "Username must contain at least 5 characters!";
            }
            else
            {
                ok = true;
                usernameSignUpError_lbl.Visible = false;
            }
            #endregion
            #region password checking
            if (password.Length < 6)
            {
                ok = false;
                formatPasswordError("Password must be at least 6!");
            }
            else
            {
                ok = true;
                passwordSignUpError_lbl.Visible = false;
            }

            if (!password.Any(char.IsDigit))
            {
                ok = false;
                formatPasswordError("Password must contain at least one digit!");
            }
            else
            {
                ok = true;
                passwordSignUpError_lbl.Visible = false;
            }

            if (password.Equals(username))
            {
                ok = false;
                formatPasswordError("Password and Username cannot be the same!");
            }
            else
            {
                ok = true;
                passwordSignUpError_lbl.Visible = false;
            }
            #endregion
            #region email checking
            if (email != "")
            {
                if (!(email.Contains('@') && email.Contains('.')))
                {
                    ok = false;
                    emailSignUpError_lbl.Text = "Invalid email!";
                    emailSignUpError_lbl.ForeColor = Color.Red;
                    emailSignUpError_lbl.Visible = true;
                }
                else
                {
                    ok = true;
                    emailSignUpError_lbl.Visible = false;
                }

                if (loginService.FindLogin(email, 3) != null)
                {
                    ok = false;
                    emailSignUp_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
                    emailSignUpError_lbl.Text = "Email allready in records!";
                    emailSignUpError_lbl.ForeColor = Color.Red;
                    emailSignUpError_lbl.Visible = true;
                }
                else
                {
                    ok = true;
                    emailSignUpError_lbl.Visible = false;
                }
            }
            else
            {
                ok = false;
                emailSignUp_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
                emailSignUpError_lbl.Visible = true;
                emailSignUpError_lbl.Text = "Email field cannot be empty!";
                emailSignUpError_lbl.ForeColor = Color.Red;
            }
            #endregion
            #region nickname checking
            if (nickname.Length < 3)
            {
                ok = false;
                formatNicknameError("Nickname must be at least 3 characters!");
            }
            else
                ok = true;

            if (profileService.ReadProfile(nickname, 2) != null)
            {
                ok = false;
                formatNicknameError("Nickname already in use!");
            }
            else
                ok = true;
            #endregion

            return ok;
        }
        private void formatPasswordError(string message)
        {
            passwordSignUp_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
            passwordSignUpError_lbl.Visible = true;
            passwordSignUpError_lbl.Text += message;
            passwordSignUpError_lbl.ForeColor = Color.Red;
        }
        private void formatNicknameError(string message)
        {
            nicknameSignUp_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
            nicknameSignUpError_lbl.Visible = true;
            nicknameSignUpError_lbl.Text = message;
            nicknameSignUpError_lbl.ForeColor = Color.Red;
        }

        #endregion

        #region ForgotDetails
        private void ForgotDetails_lbl_Click(object sender, EventArgs e)
        {
            if (!SignUp_grp.Visible)
            {
                SignIn_grp.Top = 7;
                SignIn_grp.Left = 123;

                ForgotDetails_grp.Top = 136;
                ForgotDetails_grp.Left = 119;
                ForgotDetails_grp.Visible = true;
            }
            else
            {
                ForgotDetails_grp.Top = 133;
                ForgotDetails_grp.Left = 12;
                ForgotDetails_grp.Visible = true;
            }
        }
        
        private void SendForgot_btn_Click(object sender, EventArgs e)
        {
            String email = EmailForgot_txt.Text;

            if (EmailForgot_txt.Text != "")
            {
                if (email.Contains('@') && email.Contains('.'))
                {
                    if (loginService.ForgotDetails(email))
                    {
                        emailError_lbl.Visible = true;
                        emailError_lbl.Text = "Email has been sent!";
                        emailError_lbl.ForeColor = Color.Green;
                    }
                    else
                    {
                        emailError_lbl.Text = "Email is not in our records!";
                        emailError_lbl.ForeColor = Color.Red;
                        emailError_lbl.Visible = true;
                    }
                    
                }
                else
                {
                    emailError_lbl.Text = "Invalid email!";
                    emailError_lbl.ForeColor = Color.Red;
                    emailError_lbl.Visible = true;
                }
            }
            else
            {
                EmailForgot_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
                emailError_lbl.Visible = true;
                emailError_lbl.Text = "Email field cannot be empty!";
                emailError_lbl.ForeColor = Color.Red;
            }
        }
        #endregion

        #region SinIn
        private void SignIn_btn_Click(object sender, EventArgs e)
        {
            string username = usernameSignIn_txt.Text;
            string password = passwordSignIn_txt.Text;

            Login login = loginService.FindLogin(username, 2);

            loginService.Authenticate(login);
        }
        #endregion
    }
}
