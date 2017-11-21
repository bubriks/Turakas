using PresentationTier.LoginServiceReference;
using PresentationTier.ProfileServiceReference;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;

namespace PresentationTier
{
    public partial class ProfileForm : Form
    {
        private ILoginService loginService = new LoginServiceClient();
        private IProfileService profileService = new ProfileServiceClient();
        private int profileId;

        private Profile profile;
        private Login login;
        private Form chat;

        public ProfileForm(int profileId, Form chat)
        {
            this.chat = chat;
            this.profileId = profileId;
            InitializeComponent();

            password_txt.PasswordChar = '☭';
            confirmPassword_txt.PasswordChar = '卐';

            profile = profileService.ReadProfile(profileId.ToString(), 1);
            login = loginService.FindLogin(profileId.ToString(), 1);

        username_txt.Text = login.Username;
            email_txt.Text = login.Email;
            nickname_txt.Text = profile.Nickname;
        }

        private void password_txt_TextChanged(object sender, System.EventArgs e)
        {
            formatPassword(false);
        }

        private void confirmPassword_txt_TextChanged(object sender, System.EventArgs e)
        {
            formatPassword(true);
        }

        private void save_btn_Click(object sender, System.EventArgs e)
        {
            if (CheckTheValues())
            {
                string username = username_txt.Text;
                string password = password_txt.Text;
                string email = email_txt.Text;
                string nickname = nickname_txt.Text;

                if (!username.Equals(login.Username) || !password.Equals("") || !email.Equals(login.Email))
                {

                    Login login = new Login
                    {
                        Username = username,
                        Password = password,
                        Email = email,
                    };
                    if (loginService.UpdateLogin(profileId, login))
                    {
                        saveError_lbl.Visible = true;
                        saveError_lbl.Text = "New info succesfuly saved!";
                        saveError_lbl.ForeColor = Color.Green;
                    }
                    else
                    {
                        saveError_lbl.Visible = true;
                        saveError_lbl.Text = "Something went wrong with LoginInfo!";
                        saveError_lbl.ForeColor = Color.Red;
                    }
                }

                if (!nickname.Equals(profile.Nickname))
                {

                    Profile profile = new Profile
                    {
                        Nickname = nickname,
                    };
                    if (profileService.UpdateProfile(profileId, profile))
                    {
                        saveError_lbl.Visible = true;
                        saveError_lbl.Text = "New info succesfuly saved!";
                        saveError_lbl.ForeColor = Color.Green;
                    }
                    else
                    {
                        saveError_lbl.Visible = true;
                        saveError_lbl.Text = "Something went wrong with ProfileInfo!!";
                        saveError_lbl.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                saveError_lbl.Visible = false;
            }
        }

        #region Checking Values

        private void formatPassword(bool confirm)
        {
            confirmPassword_lbl.Visible = true;
            confirmPassword_txt.Visible = true;

            if (password_txt.Text.Equals(confirmPassword_txt.Text))
            {
                confirmPassword_txt.BackColor = Color.White;
                password_txt.BackColor = Color.White;
                confirmPassword_lbl.ForeColor = Color.Black;
                password_lbl.ForeColor = Color.Black;
            }
            else
            {
                confirmPassword_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
                password_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
                confirmPassword_lbl.ForeColor = Color.Red;
                password_lbl.ForeColor = Color.Red;
            }

            if (password_txt.Text.Equals(""))
                password_txt.Visible = false;

            if (confirmPassword_txt.Text.Equals("") && confirm)
                confirmPassword_txt.Visible = false;
        }

        private bool CheckTheValues()
        {
            bool ok = true;
            string passwordError = CheckPassword(username_txt.Text, password_txt.Text);

            #region username checking
            if (!login.Username.Equals(username_txt.Text))
            {
                string usernameError = CheckUsername(username_txt.Text);
                if (!usernameError.Equals(""))
                {
                    ok = false;
                    username_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
                    usernameError_lbl.Visible = true;
                    usernameError_lbl.ForeColor = Color.Red;
                    usernameError_lbl.Text = usernameError;
                }
                else
                {
                    usernameError_lbl.Visible = false;
                    username_txt.BackColor = Color.White;
                }
            }
            #endregion
            #region password checking
            if (!passwordError.Equals(""))
            {
                ok = false;
                password_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
                passwordError_lbl.Visible = true;
                passwordError_lbl.ForeColor = Color.Red;
                passwordError_lbl.Text = passwordError;
            }
            else
            {
                passwordError_lbl.Visible = false;
                password_txt.BackColor = Color.White;
            }
            #endregion
            #region email checking
            if (!login.Email.Equals(email_txt.Text))
            {
                string emailError = CheckEmail(email_txt.Text);
                if (!emailError.Equals(""))
                {
                    ok = false;
                    emailError_lbl.Text = emailError;
                    emailError_lbl.ForeColor = Color.Red;
                    emailError_lbl.Visible = true;

                    email_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
                }
                else
                {
                    emailError_lbl.Visible = false;
                    email_txt.BackColor = Color.White;
                }
            }
            #endregion
            #region nickname checking
            if (!profile.Nickname.Equals(nickname_txt.Text))
            {
                string nicknameError = CheckNickname(nickname_txt.Text);
                if (!nicknameError.Equals(""))
                {
                    ok = false;
                    nickname_txt.BackColor = Color.FromArgb(255, 214, 81, 81);
                    nicknameError_lbl.Visible = true;
                    nicknameError_lbl.Text = nicknameError;
                    nicknameError_lbl.ForeColor = Color.Red;
                }
                else
                {
                    nickname_txt.BackColor = Color.White;
                    nicknameError_lbl.Visible = false;
                }
            }
            #endregion

            return ok;
        }

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
            if (!password.Equals(""))
            {
                if (password.Length < 6)
                    error += "Password must be at least 6!";
                else
                if (!password.Any(char.IsDigit))
                    error += "Password must contain at least one digit!";
                else
                if (username != "")
                    if (password.Equals(username))
                        error += "Password and Username cannot be the same!";
            }
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
        #endregion

        private void back_btn_Click(object sender, System.EventArgs e)
        {
            Hide();
            chat.Show();
            Close();
        }

        private void deleteAccount_btn_Click(object sender, System.EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this Account?\nWARNIGN: DELETING AN ACCOUNT WILL RESULT IN COMPLETE DELETION OF ALL OF ITS ACTIONS, INCLUDING OWNED CHATS AND MESSAGES!!!\n\nNOTE: YOU WILL BE TAKEN TO THE LOGIN SCREEN IF SUCCESFULLY DELETED.",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (loginService.DeleteLogin(profileId))
                { 
                    deleteError_lbl.ForeColor = Color.Green;
                    deleteError_lbl.Text = "Succesfull!";

                    SignIn_SignUp_ForgotDetailsForm signIn = new SignIn_SignUp_ForgotDetailsForm();
                    Hide();
                    signIn.ShowDialog();
                    Close();
                }
                else
                {
                    deleteError_lbl.ForeColor = Color.Red;
                    deleteError_lbl.Text = "Something went wrong!";
                }
                deleteError_lbl.Visible = true;
            }
        }
    }
}
