using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PresentationTier.ChatServiceReference;
using System.ServiceModel;
using System.ComponentModel;
using System.Threading;

namespace PresentationTier
{
    public partial class ChatForm : Form, IChatServiceCallback
    {
        #region Variables
        private int chatId, profileId;
        private InstanceContext instanceContext = null;
        private ChatServiceClient client;
        private ContextMenu cm;
        private MenuItem joinWithGroup;
        #endregion

        public ChatForm(int profileId)
        {
            #region Initialize
            chatId = 0;
            this.profileId = profileId;

            InitializeComponent();
            instanceContext = new InstanceContext(this);
            client = new ChatServiceClient(instanceContext);
            cm = new ContextMenu();

            nrOfUsersTrackBar.Minimum = 2;
            nrOfUsersTrackBar.Maximum = 10;
            nrOfUsersTrackBar.TickFrequency = 1;
            #endregion
            client.Online(profileId);

            SearchButton_Click(null, null);
        }

        #region Search
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
                row.SubItems.Add(chat.OwnerID.ToString());
                row.SubItems.Add(chat.Name);
                if (chat.Type)
                {
                    row.SubItems.Add("public");
                }
                else
                {
                    row.SubItems.Add("private");
                }
                if (chat.Users == null)
                {
                    row.SubItems.Add(0.ToString());
                }
                else
                {
                    row.SubItems.Add(chat.Users.Count().ToString());
                }
                row.SubItems.Add(chat.MaxNrOfUsers.ToString());
                row.SubItems.Add(chat.Time.ToString());
                chatListView.Items.Add(row);
            }
        }

        private void ChatListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)//doesnt allow row 0 and 1 to be resized
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                e.Cancel = true;
                e.NewWidth = chatListView.Columns[e.ColumnIndex].Width;
            }
        }
        #endregion

        #region Chat
        private void ChatListView_MouseDown(object sender, MouseEventArgs e)//Click on listView item
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo lvhti = this.chatListView.HitTest(e.X, e.Y);
                if (lvhti.Item != null)
                {
                    lvhti.Item.Selected = true;
                    chatId = Int32.Parse(lvhti.Item.Text);
                    if (Int32.Parse(lvhti.Item.SubItems[1].Text) == profileId) {
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
                    chatNameTextBox.Text = lvhti.Item.SubItems[2].Text;
                    if (lvhti.Item.SubItems[3].Text.Equals("False"))
                    {
                        privateCheckBox.Checked = true;
                    }
                    else
                    {
                        privateCheckBox.Checked = false;
                    }
                    nrOfUsersTrackBar.Value = Int32.Parse(lvhti.Item.SubItems[5].Text);
                    saveButton.Text = "Update chat";
                    if (Int32.Parse(lvhti.Item.SubItems[1].Text) == profileId)
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

        private void JoinWithGroup(int groupId)//menu item join with group clicked
        {
            client.JoinChatWhithGroup(groupId, chatId);
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

        public void JoinChat(int chatId)//joins the chat with the group
        {
            new MessageForm(chatId, profileId);
        }
        #endregion

        #region Invite
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

        #region Form control
        private void ViewProfileButton_Click(object sender, EventArgs e)//Goes to profile View
        {
            ProfileForm.GetInstance(profileId, this).Show();
        }

        private void YoutubeButton_Click(object sender, EventArgs e)//Goes to Youtube View
        {
            YoutubeAlpha.GetInstance(profileId).Visible = true;
        }

        private void BtnGroups_Click(object sender, EventArgs e)//Goes to Group View
        {
            GroupForm.GetInstance(profileId, this).Show();
        }

        private void LogOut_btn_Click(object sender, EventArgs e)//Goes to Login View
        {
            client.Offline(profileId);
            Application.Restart();
        }

        private void ChatForm_Closing(object sender, CancelEventArgs e)//on close event
        {
            client.Offline(profileId);
            Application.Exit();
        }
        #endregion
    }
}
