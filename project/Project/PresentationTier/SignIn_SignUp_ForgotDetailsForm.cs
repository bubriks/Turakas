using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PresentationTier.ProfileServiceReference;

namespace PresentationTier
{
    public partial class SignIn_SignUp_ForgotDetailsForm: Form
    {
        private IProfileService profileService = new ProfileServiceClient();

        public SignIn_SignUp_ForgotDetailsForm()
        {
            InitializeComponent();

            passwordSignIn_txt.PasswordChar = '*';

            SignIn_grp.Top = 65;
            SignIn_grp.Left = 122;
        }

        #region SignUp
        private void SignUp_btn_Click(object sender, EventArgs e)
        {
            //make the SignUp part show up
            SignUp_grp.Visible = true;
            SignIn_grp.Top = 12;
            SignIn_grp.Left = 12;

            ForgotDetails_grp.Top = 158;
            ForgotDetails_grp.Left = 12;
        }
        
        private void Register_btn_Click(object sender, EventArgs e)
        {
            if (CheckTheValues()) //if the introduced values are valid
            {
                string username = usernameSignUp_txt.Text;
                string email = emailSignUp_txt.Text;
                string nickname = nicknameSignUp_txt.Text;

                Profile profile = new Profile
                {
                    Username = username,
                    Email = email,
                    Nickname = nickname,
                };

                int profileId = profileService.CreateProfile(profile); //create profile and get it's assigned Id

                if (profileId != -1) //if the profile was sucessfuly created
                {
                    //format labels
                    registerError_lbl.Visible = true;
                    registerError_lbl.Text = "Check your email for confirmation!";
                    registerError_lbl.ForeColor = Color.Green;
                }
                else
                {
                    registerError_lbl.Visible = true;
                    registerError_lbl.Text = "Something went wrong!";
                    registerError_lbl.ForeColor = Color.Red;
                }
            }
            else
            {
                registerError_lbl.Visible = false;
            }
        }

        private bool CheckTheValues()
        {
            bool ok = true;
            string usernameError = CheckUsername(usernameSignUp_txt.Text);
            string emailError = CheckEmail(emailSignUp_txt.Text);
            string nicknameError = CheckNickname(nicknameSignUp_txt.Text);

            #region username validation and displaying
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
            #region email validation and displaying
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
            #region nickname validation and displaying
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
                SignIn_grp.Top = 12;
                SignIn_grp.Left = 123;

                ForgotDetails_grp.Top = 158;
                ForgotDetails_grp.Left = 123;
                ForgotDetails_grp.Visible = true;
            }
            else
            {
                ForgotDetails_grp.Top = 158;
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

                profileService.ForgotDetails(emailForgot_txt.Text);
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
                    signInError_lbl.Visible = false;
                    passwordSignIn_txt.BackColor = Color.White;

                    //logging in
                    Profile profile = new Profile
                    {
                        Username = usernameSignIn_txt.Text,
                        Password = passwordSignIn_txt.Text,
                    };
                    int profileId = profileService.Authenticate(profile);
                    switch (profileId)
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
                            signInError_lbl.Visible = false;
                            ChatForm chat = new ChatForm(profileId);
                            Hide();
                            chat.ShowDialog();
                            Close();
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
                if (profileService.ReadProfile(email, 3) != null)
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
            if (profileService.ReadProfile(nickname, 4) != null)
                error += ("Nickname already in use!");
            return error;
        }
    }
}
