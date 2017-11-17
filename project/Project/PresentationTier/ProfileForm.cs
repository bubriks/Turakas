using PresentationTier.LoginServiceReference;
using PresentationTier.ProfileServiceReference;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationTier
{
    public partial class ProfileForm : Form
    {
        private ILoginService loginService = new LoginServiceClient();
        private IProfileService profileService = new ProfileServiceClient();

        public ProfileForm(int profileId)
        {
            InitializeComponent();

            password_txt.PasswordChar = '☭';
            confirmPassword_txt.PasswordChar = '卐';

            Profile profile = profileService.ReadProfile(profileId.ToString(), 1);
            Login login = loginService.FindLogin(profileId.ToString(), 1);

            username_txt.Text = login.Username;
            password_txt.Text = "DefaultPassword";
            email_txt.Text = login.Email;
            nickname_txt.Text = profile.Nickname;
        }

        private void username_txt_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void password_txt_TextChanged(object sender, System.EventArgs e)
        {
            confirmPassword_lbl.Visible = true;
            confirmPassword_txt.Visible = true;

            if (password_txt.Text.Equals(confirmPassword_txt.Text))
            {
                confirmPassword_txt.BackColor = Color.Black;
                password_txt.BackColor = Color.Black;
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
        }

        private void confirmPassword_txt_TextChanged(object sender, System.EventArgs e)
        {
            confirmPassword_txt_TextChanged(sender, e);
        }

        private void email_txt_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void nickname_txt_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void save_btn_Click(object sender, System.EventArgs e)
        {

        }
    }
}
