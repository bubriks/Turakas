using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentationTier.GroupServiceReference;

namespace PresentationTier
{
    public partial class GroupForm : Form
    {
        private int profileId;
        private Form profileform;
        private GroupServiceClient client;
        public GroupForm(int profileId, Form profileform)
        {
            this.profileId = profileId;
            this.profileform = profileform;
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            client.CreateGroup(name, profileId);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            client.DeleteGroup(lbAllGroups.Text.ToString());
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            client.AddMember(profileId);
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            client.RemoveMember(profileId);
        }

        private void BntAllUsers_Click(object sender, EventArgs e)
        {
            lbGroupMembers.Text = client.GetAllUsers().ToString();
        }

        private void BtnOnlineUsers_Click(object sender, EventArgs e)
        {
            lbGroupMembers.Text = client.GetOnlineUsers().ToString();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Hide();
            profileform.Show();
            Close();
        }
    }
}
