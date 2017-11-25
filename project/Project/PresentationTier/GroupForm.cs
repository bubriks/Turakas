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
        private int profileId, groupId = 0;
        private Form profileform;
        private ContextMenu cmGroups, cmMembers;
        private GroupServiceClient client;
        public GroupForm(int profileId, Form profileform)
        {
            #region Initialize
            InitializeComponent();
            client = new GroupServiceClient();
            cmGroups = new ContextMenu();
            cmGroups.MenuItems.Add(new MenuItem("Remove", MenuItemNewRemoveGroup_Click));
            cmMembers = new ContextMenu();
            cmMembers.MenuItems.Add(new MenuItem("Remove", MenuItemNewRemoveMember_Click));
            this.profileId = profileId;
            this.profileform = profileform;
            #endregion

            ButtonRefresh_Click(null, null);
        }

        #region Manage groups
        private void ButtonRefresh_Click(object sender, EventArgs e)//Refreshes
        {
            lbAllGroups.Items.Clear();
            foreach (Group group in client.GetUsersGroups(profileId))
            {
                lbAllGroups.Items.Add(group);
            }
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)//Enter pressed
        {
            if (e.KeyValue == Convert.ToInt16(Keys.Enter))
            {
                BtnCreate_Click(null, null);
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)//Create group pressed
        {
            if(groupId != 0)
            {
                if (client.UpdateGroup(txtName.Text, groupId))
                {
                    txtName.Text = "";
                    groupId = 0;
                    BtnCreate.Text = "Create new group";
                }
            }
            else
            {
                if (client.CreateGroup(txtName.Text, profileId))
                {
                    txtName.Text = "";
                }
            }
            ButtonRefresh_Click(null, null);
        }

        private void LbAllGroups_SelectObject(object sender, MouseEventArgs e)//right click clicked
        {
            if (e.Button == MouseButtons.Right)
            {
                int item = lbAllGroups.IndexFromPoint(e.Location);
                if (item >= 0)
                {
                    lbAllGroups.SelectedIndex = item;
                    cmGroups.Show(lbAllGroups, e.Location);
                }
            }
            else
            {
                int item = lbAllGroups.IndexFromPoint(e.Location);
                if (item >= 0)
                {
                    lbAllGroups.SelectedIndex = item;
                    groupId = (lbAllGroups.SelectedItem as Group).GroupId;
                    ButtonRefreshGroupMembers_Click(null, null);
                    BtnCreate.Text = "Update group";
                }
                else
                {
                    lbAllGroups.SelectedIndex = -1;
                    groupId = 0;
                    lbGroupMembers.Items.Clear();
                    BtnCreate.Text = "Create new group";
                }
            }
        }

        private void MenuItemNewRemoveGroup_Click(Object sender, EventArgs e)//Right cick menu button clicked
        {
            client.DeleteGroup((lbAllGroups.SelectedItem as Group).GroupId);
            groupId = 0;
            BtnCreate.Text = "Create new group";
        }
        #endregion 

        private void ButtonRefreshGroupMembers_Click(object sender, EventArgs e)
        {
            lbGroupMembers.Items.Clear();
            foreach(Profile profile in client.GetUsers(groupId))
            {
                lbGroupMembers.Items.Add(profile);
            }
        }

        private void LbGroupMembers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int item = lbGroupMembers.IndexFromPoint(e.Location);
                if (item >= 0)
                {
                    lbGroupMembers.SelectedIndex = item;
                    cmMembers.Show(lbGroupMembers, e.Location);
                }
            }
        }

        private void MenuItemNewRemoveMember_Click(Object sender, EventArgs e)//Right cick menu button clicked
        {
            if(client.RemoveMember((lbGroupMembers.SelectedItem as Profile).ProfileID, groupId))
            {
                ButtonRefreshGroupMembers_Click(null, null);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Hide();
            profileform.Show();
            Close();
        }
    }
}