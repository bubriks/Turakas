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

                int loginId = loginService.CreateLogin(login, nickname);

                if (loginId != -1)
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
            string usernameError = CheckUsername(usernameSignUp_txt.Text);
            string passwordError = CheckPassword(usernameSignUp_txt.Text, passwordSignUp_txt.Text);
            string emailError = CheckEmail(emailSignUp_txt.Text);
            string nicknameError = CheckNickname(nicknameSignUp_txt.Text);

            #region username checking
            if (!usernameError.Equals(""))
            {
                ok = false;
                usernameSignUp_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
                usernameSignUpError_lbl.Visible = true;
                usernameSignUpError_lbl.ForeColor = Color.Red;
                usernameSignUpError_lbl.Text = usernameError;
            }
            else
            {
                usernameSignUpError_lbl.Visible = false;
                usernameSignUp_txt.BackColor = Color.White;
            }
            #endregion
            #region password checking
            if (!passwordError.Equals(""))
            {
                ok = false;
                passwordSignUp_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
                passwordSignUpError_lbl.Visible = true;
                passwordSignUpError_lbl.ForeColor = Color.Red;
                passwordSignUpError_lbl.Text = passwordError;
            }
            else
            {
                passwordSignUpError_lbl.Visible = false;
                passwordSignUp_txt.BackColor = Color.White;
            }
            #endregion
            #region email checking
            if (!emailError.Equals(""))
            {
                ok = false;
                emailSignUpError_lbl.Text = emailError;
                emailSignUpError_lbl.ForeColor = Color.Red;
                emailSignUpError_lbl.Visible = true;

                emailSignUp_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
            }
            else
            {
                emailSignUpError_lbl.Visible = false;
                emailSignUp_txt.BackColor = Color.White;
            }
            #endregion
            #region nickname checking
            if (!nicknameError.Equals(""))
            {
                ok = false;
                nicknameSignUp_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
                nicknameSignUpError_lbl.Visible = true;
                nicknameSignUpError_lbl.Text = nicknameError;
                nicknameSignUpError_lbl.ForeColor = Color.Red;
            }
            else
            {
                nicknameSignUp_txt.BackColor = Color.White;
                nicknameSignUpError_lbl.Visible = false;
            }
            #endregion

            return ok;
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
            String emailError = CheckEmail(emailForgot_txt.Text);

            if (emailError.Equals("Email allready in records!"))
            {
                emailForgot_txt.BackColor = Color.White;
                emailForgotError_lbl.Visible = false;

                loginService.ForgotDetails(emailForgot_txt.Text);
            }
            else
            {
                emailForgot_txt.BackColor = Color.FromArgb(255, 214, 81, 81);

                emailForgotError_lbl.Text = emailError + "Email not in our Records!";
                emailForgotError_lbl.ForeColor = Color.Red;
                emailForgotError_lbl.Visible = true;
            }
        }
        #endregion

        #region SinIn
        private void SignIn_btn_Click(object sender, EventArgs e)
        {
            //checking wheter the introduced data by user are ok from a criteria point of view
            string usernameError = CheckUsername(usernameSignIn_txt.Text);
            string passwordError = CheckPassword(usernameSignIn_txt.Text, passwordSignIn_txt.Text);

            
            if (usernameError.Equals("")) // if there is no error with username
            {
                //Reseting error label and text box
                signInError_lbl.Visible = false;
                usernameSignIn_txt.BackColor = Color.White;

                if (passwordError.Equals("")) //if there is no error with password
                {
                    //Reseting error label and text box
                    passwordSignIn_lbl.Visible = false;
                    passwordSignUp_txt.BackColor = Color.White;

                    //logging in
                    Login login = new Login
                    {
                        Username = usernameSignIn_txt.Text,
                        Password = passwordSignIn_txt.Text,
                    };
                    int loginId = loginService.Authenticate(login);
                    switch (loginId)
                    {
                        case -1: //no such info
                            signInError_lbl.ForeColor = Color.Red;
                            signInError_lbl.Text = "Invalid Username and Password combination!";
                            signInError_lbl.Visible = true;
                            break;
                        case -2: //sql exception occured
                            signInError_lbl.ForeColor = Color.Red;
                            signInError_lbl.Text = "An error has occured, please try again later!";
                            signInError_lbl.Visible = true;
                            break;
                        default: //loginId
                            //ListViewHitTestInfo lvhti = this.listView1.HitTest(e.X, e.Y);
                            signInError_lbl.Visible = false;
                            new ChatForm(loginId).Visible = true;
                            Hide();
                            break;
                    }
                }
                else
                {
                    //formating password label and textbox
                    signInError_lbl.Text = passwordError;
                    signInError_lbl.ForeColor = Color.Red;
                    signInError_lbl.Visible = true;

                    passwordSignIn_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
                }
            }
            else
            {
                //formating username label and textbox
                signInError_lbl.Text = usernameError;
                signInError_lbl.ForeColor = Color.Red;
                signInError_lbl.Visible = true;

                usernameSignIn_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
            }
        }
        
        #endregion

        private string CheckUsername(string username)
        {
            if (username.Length < 5 || username.Length > 16)
                return "Username's length must be between 5 and 16!";
            else
                return "";
        }

        private string CheckPassword(string username, string password)
        {
            string error = "";
            if (password.Length < 6)
                error += "Password must be at least 6!";
            else
            if (!password.Any(char.IsDigit))
                error += "Password must contain at least one digit!";
            else
            if (username != "")
                if (password.Equals(username))
                    error += "Password and Username cannot be the same!";
            return error;
        }

        private string CheckEmail(string email)
        {
            string error = "";
            if (email != "")
            {
                if (!(email.Contains('@') && email.Contains('.')))
                    error += "Invalid email!";
                else
                if (loginService.FindLogin(email, 3) != null)
                    error += "Email allready in records!";
            }
            else
                error += "Email field cannot be empty!";
            return error;
        }

        private string CheckNickname(string nickname)
        {
            string error = "";
            if (nickname.Length < 3)
                error += ("Nickname must be at least 3 characters!");
            else
            if (profileService.ReadProfile(nickname, 2) != null)
                error += ("Nickname already in use!");
            return error;
        }
    }
}
