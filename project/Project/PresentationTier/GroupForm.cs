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
        private int profileId, groupId;
        private Form profileform;
        private GroupServiceClient client;
        public GroupForm(int profileId, Form profileform)
        {
            this.profileId = profileId;
            this.profileform = profileform;
            groupId = 1;
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            client.CreateGroup(name, profileId);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            client.DeleteGroup(groupId);
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            client.AddMember(profileId, groupId);
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            client.RemoveMember(profileId, groupId);
        }

        private void BntAllUsers_Click(object sender, EventArgs e)
        {
            lbGroupMembers.Text = client.GetAllUsers(groupId).ToString();
        }

        private void BtnOnlineUsers_Click(object sender, EventArgs e)
        {
            lbGroupMembers.Text = client.GetOnlineUsers(groupId).ToString();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Hide();
            profileform.Show();
            Close();
        }
    }
}
