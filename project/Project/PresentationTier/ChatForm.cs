using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PresentationTier.ChatServiceReference;
using System.ServiceModel;
using System.ComponentModel;
using System.Collections.Generic;

namespace PresentationTier
{
    public partial class ChatForm : Form, IChatServiceCallback
    {
        private int chatId, profileId;
        private InstanceContext instanceContext = null;
        private ChatServiceClient client;
        private ContextMenu cm;
        private MenuItem joinWithGroup;
        public ChatForm(int profileId)
        {
            #region initialize
            chatId = 0;
            this.profileId = profileId;

            InitializeComponent();
            instanceContext = new InstanceContext(this);
            client = new ChatServiceClient(instanceContext);
            cm = new ContextMenu();

            chatListView.Columns.Add("Id", 0, HorizontalAlignment.Left);
            chatListView.Columns.Add("Name", 100, HorizontalAlignment.Left);
            chatListView.Columns.Add("Type", 60, HorizontalAlignment.Left);
            chatListView.Columns.Add("Users", 60, HorizontalAlignment.Left);
            chatListView.Columns.Add("Room size", 80, HorizontalAlignment.Left);
            chatListView.Columns.Add("Owner", 0, HorizontalAlignment.Left);
            chatListView.Columns.Add("Time of creation", 150, HorizontalAlignment.Left);

            nrOfUsersTrackBar.Minimum = 2;
            nrOfUsersTrackBar.Maximum = 10;
            nrOfUsersTrackBar.TickFrequency = 1;
            #endregion
            viewProfileButton.BackColor = Color.Pink;
            client.Online(profileId);

            SearchButton_Click(null, null);
        }

        #region search
        private void SearchBox_KeyDown(object sender, KeyEventArgs e)//enter presed in search box
        {
            if (e.KeyValue == Convert.ToInt16(Keys.Enter))
            {
                SearchButton_Click(null, null);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)//search button clicked
        {
            chatListView.Items.Clear();
            foreach (Chat chat in client.GetChatsByName(searchBox.Text, profileId))
            {
                ListViewItem row = new ListViewItem(chat.Id.ToString());
                row.SubItems.Add(chat.Name);
                row.SubItems.Add(chat.Type.ToString());
                if (chat.Users == null)
                {
                    row.SubItems.Add(0.ToString());
                }
                else
                {
                    row.SubItems.Add(chat.Users.Count().ToString());
                }
                row.SubItems.Add(chat.MaxNrOfUsers.ToString());
                row.SubItems.Add(chat.OwnerID.ToString());
                row.SubItems.Add(chat.Time.ToString());
                chatListView.Items.Add(row);
            }
        }

        private void ChatListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)//doesnt allow row 0 and 5 to be resized
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 5)
            {
                e.Cancel = true;
                e.NewWidth = chatListView.Columns[e.ColumnIndex].Width;
            }
        }
        #endregion

        #region chat
        //fix this mae more efficient and bug free
        private void ChatListView_MouseDown(object sender, MouseEventArgs e)//Click on listView item
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo lvhti = this.chatListView.HitTest(e.X, e.Y);
                if (lvhti.Item != null)
                {
                    lvhti.Item.Selected = true;
                    chatId = Int32.Parse(lvhti.Item.Text);

                    if (Int32.Parse(lvhti.Item.SubItems[5].Text) == profileId) {
                        MenuItem removeItem = new MenuItem("Remove", RemoveMenuItem_Click);
                        cm.MenuItems.Add(removeItem);
                        Group[] groupList = client.GetUsersGroups(profileId);
                        if (groupList.Length > 0)
                        {
                            joinWithGroup = new MenuItem("Join with group");
                            cm.MenuItems.Add(joinWithGroup);
                            joinWithGroup.MenuItems.Clear();
                            foreach (Group group in client.GetUsersGroups(profileId))
                            {
                                MenuItem item = new MenuItem();
                                item.Text = group.Name;
                                item.Click += delegate { JoinWithGroup(group.GroupId); };
                                joinWithGroup.MenuItems.Add(item);
                            }
                            cm.Show(this.chatListView, new Point(e.X, e.Y));
                            cm.MenuItems.Remove(joinWithGroup);
                            cm.MenuItems.Remove(removeItem);
                        }
                        else
                        {
                            cm.Show(this.chatListView, new Point(e.X, e.Y));
                            cm.MenuItems.Remove(removeItem);
                        }
                    }
                    else
                    {
                        Group[] groupList = client.GetUsersGroups(profileId);
                        if (groupList.Length > 0)
                        {
                            joinWithGroup = new MenuItem("Join with group");
                            cm.MenuItems.Add(joinWithGroup);
                            joinWithGroup.MenuItems.Clear();
                            foreach (Group group in groupList)
                            {
                                MenuItem item = new MenuItem();
                                item.Text = group.Name;
                                item.Click += delegate { JoinWithGroup(group.GroupId); };
                                joinWithGroup.MenuItems.Add(item);
                            }
                            cm.MenuItems.Add(joinWithGroup);
                            cm.Show(this.chatListView, new Point(e.X, e.Y));
                            cm.MenuItems.Remove(joinWithGroup);
                        }
                    }
                }
            }
            else
            {
                ListViewHitTestInfo lvhti = this.chatListView.HitTest(e.X, e.Y);
                if (lvhti.Item != null)
                {
                    chatId = Int32.Parse(lvhti.Item.Text);
                    chatNameTextBox.Text = lvhti.Item.SubItems[1].Text;
                    if (lvhti.Item.SubItems[2].Text.Equals("False"))
                    {
                        privateCheckBox.Checked = true;
                    }
                    else
                    {
                        privateCheckBox.Checked = false;
                    }
                    nrOfUsersTrackBar.Value = Int32.Parse(lvhti.Item.SubItems[4].Text);
                    saveButton.Text = "Update chat";
                    if (Int32.Parse(lvhti.Item.SubItems[5].Text) == profileId)
                    {
                        chatNameTextBox.Enabled = true;
                        privateCheckBox.Enabled = true;
                        nrOfUsersTrackBar.Enabled = true;
                        saveButton.Enabled = true;
                    }
                    else
                    {
                        chatNameTextBox.Enabled = false;
                        privateCheckBox.Enabled = false;
                        nrOfUsersTrackBar.Enabled = false;
                        saveButton.Enabled = false;
                    }
                }
                else
                {
                    chatId = 0;
                    chatNameTextBox.Text = "";
                    privateCheckBox.Checked = false;
                    nrOfUsersTrackBar.Value = 2;
                    saveButton.Text = "Create chat";

                    chatNameTextBox.Enabled = true;
                    privateCheckBox.Enabled = true;
                    nrOfUsersTrackBar.Enabled = true;
                    saveButton.Enabled = true;
                }
            }
        }

        private void JoinWithGroup(int groupId)//change
        {
            client.joinChatWhithGroup(groupId, chatId);
        }

        private void NrOfUsersTrackBar_ValueChanged(object sender, EventArgs e)//change max value of users
        {
            nrLabel.Text = (Math.Round(nrOfUsersTrackBar.Value / 1.0)).ToString();
        }

        private void SaveButton_Click(object sender, EventArgs e)//save chat button clicked
        {
            Chat chat = new Chat
            {
                Name = chatNameTextBox.Text,
                MaxNrOfUsers = nrOfUsersTrackBar.Value,
                Id = chatId,
                OwnerID = profileId
            };
            if (privateCheckBox.Checked == true)
            {
                chat.Type = false;
            }
            else
            {
                chat.Type = true;
            }
            client.SaveChat(profileId, chat);

            chatId = 0;
            chatNameTextBox.Text = "";
            privateCheckBox.Checked = false;
            nrOfUsersTrackBar.Value = 2;
            saveButton.Text = "Create chat";

            SearchButton_Click(null, null);
        }

        private void RemoveMenuItem_Click(Object sender, EventArgs e)//Right cick remove menu button clicked
        {
            client.DeleteChat(profileId, chatId);
            SearchButton_Click(null, null);
        }

        private void ChatListView_MouseDoubleClick(object sender, MouseEventArgs e)//join chat room
        {
            if (e.Button == MouseButtons.Left)
            {
                ListViewHitTestInfo lvhti = this.chatListView.HitTest(e.X, e.Y);
                if (lvhti.Item != null)
                {
                    try
                    {
                        new MessageForm(chatId, profileId);
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        public void joinChat(int chatId)//joins the chat with the group
        {
            new MessageForm(chatId, profileId);
        }
        #endregion

        #region invite
        public void Notification(Chat chat)//adds new notifications to listbox
        {
            inviteListBox.Items.Add(chat);
        }

        private void InviteListBox_MouseDoubleClick(object sender, MouseEventArgs e)//Notification double clicked
        {
            if (e.Button == MouseButtons.Left)
            {
                int item = inviteListBox.IndexFromPoint(e.Location);
                if (item >= 0)
                {
                    try
                    {
                        inviteListBox.SelectedIndex = item;
                        new MessageForm((inviteListBox.SelectedItem as Chat).Id, profileId);
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void ClearEventsButton_Click(object sender, EventArgs e)//Clears events
        {
            inviteListBox.Items.Clear();
        }
        #endregion

        private void ViewProfileButton_Click(object sender, EventArgs e)//Goes to profile View
        {
            this.Visible = false;
            ProfileForm profile = new ProfileForm(profileId, this);
            profile.Show();
        }

        private void YoutubeButton_Click(object sender, EventArgs e)//youtube button pressed
        {
            new YoutubeAlpha();
        }

        private void btnGroups_Click(object sender, EventArgs e)
        {
            GroupForm group = new GroupForm(profileId, this);
            group.Show();
            this.Visible = false;
        }

        private void ChatForm_Closing(object sender, CancelEventArgs e)//on close event
        {
            client.Offline(profileId);
            Application.Exit();
        }
    }
}
