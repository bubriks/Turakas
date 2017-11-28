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
        private static GroupForm instance;
        private int profileId, groupId = 0;
        private Form chatForm;
        private ContextMenu cmGroups, cmMembers;
        private GroupServiceClient client;

        public static GroupForm GetInstance(int profileId, Form chatForm)
        {
            if (instance == null)
            {
                instance = new GroupForm(profileId, chatForm);
            }
            return instance;
        }

        private GroupForm(int profileId, Form chatForm)
        {
            #region Initialize
            InitializeComponent();
            client = new GroupServiceClient();
            cmGroups = new ContextMenu();
            cmGroups.MenuItems.Add(new MenuItem("Remove", MenuItemNewRemoveGroup_Click));
            cmMembers = new ContextMenu();
            cmMembers.MenuItems.Add(new MenuItem("Remove", MenuItemNewRemoveMember_Click));
            this.profileId = profileId;
            this.chatForm = chatForm;
            #endregion

            ButtonRefresh_Click(null, null);
            GetUsers(onlineCheckBox.Checked == true);
            txtUserName.Enabled = false;
            BtnAddUser.Enabled = false;
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
                if (!txtName.Text.Equals("") && client.UpdateGroup(txtName.Text, groupId))
                {
                    txtName.Text = "";
                    groupId = 0;
                    BtnCreate.Text = "Create new group";
                    txtUserName.Enabled = false;
                    BtnAddUser.Enabled = false;
                }
            }
            else
            {
                if (!txtName.Text.Equals("") && client.CreateGroup(txtName.Text, profileId))
                {
                    txtName.Text = "";
                    txtUserName.Enabled = false;
                    BtnAddUser.Enabled = false;
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
                    GetUsers(onlineCheckBox.Checked == true);
                    BtnCreate.Text = "Update group";
                    txtUserName.Enabled = true;
                    BtnAddUser.Enabled = true;
                }
                else
                {
                    lbAllGroups.SelectedIndex = -1;
                    groupId = 0;
                    lbGroupMembers.Items.Clear();
                    BtnCreate.Text = "Create new group";
                    txtUserName.Enabled = false;
                    BtnAddUser.Enabled = false;
                }
            }
        }

        private void MenuItemNewRemoveGroup_Click(Object sender, EventArgs e)//Right cick menu button clicked
        {
            client.DeleteGroup((lbAllGroups.SelectedItem as Group).GroupId);
            groupId = 0;
            BtnCreate.Text = "Create new group";
            txtUserName.Enabled = false;
            BtnAddUser.Enabled = false;
            ButtonRefresh_Click(null, null);
        }
        #endregion

        #region Manage members

        private void LbGroupMembers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int item = lbGroupMembers.IndexFromPoint(e.Location);
                if (item >= 0)
                {
                    lbGroupMembers.SelectedIndex = item;
                    if((lbGroupMembers.SelectedItem as Profile).ProfileID != profileId)
                    {
                        cmMembers.Show(lbGroupMembers, e.Location);
                    }
                }
            }
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            if(client.AddMember(txtUserName.Text, groupId))
            {
                txtUserName.Text = "";
                GetUsers(onlineCheckBox.Checked == true);
            }
        }

        private void GetOnlineUsers()
        {
            lbGroupMembers.Items.Clear();
            foreach (Profile profile in client.GetOnlineMembers(groupId))
            {
                lbGroupMembers.Items.Add(profile);
            }
        }

        private void GetAllUsers()
        {
            lbGroupMembers.Items.Clear();
            foreach (Profile profile in client.GetUsers(groupId))
            {
                lbGroupMembers.Items.Add(profile);
            }
        }

        private void OnlineCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            GetUsers(onlineCheckBox.Checked == true);
        }

        public void GetUsers(bool result)
        {
            if (result == true)
            {
                GetOnlineUsers();
            }
            else
            {
                GetAllUsers();
            }
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            chatForm.Show();
            Close();
            instance = null;
        }

        private void MenuItemNewRemoveMember_Click(Object sender, EventArgs e)//Right cick menu button clicked
        {
            if(client.RemoveMember((lbGroupMembers.SelectedItem as Profile).ProfileID, groupId))
            {
                GetUsers(onlineCheckBox.Checked == true);
            }
        }
        #endregion

        private void GroupForm_Closing(object sender, CancelEventArgs e)//on close event
        {
            instance = null;
        }
    }
}