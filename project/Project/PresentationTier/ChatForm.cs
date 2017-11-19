using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PresentationTier.ChatServiceReference;

namespace PresentationTier
{
    public partial class ChatForm : Form
    {
        private int chatId, profileId;
        private ChatServiceClient client;
        private ContextMenu cm;
        public ChatForm(int profileId)
        {
            #region initialize
            chatId = 0;
            this.profileId = profileId;

            InitializeComponent();
            client = new ChatServiceClient();
            cm = new ContextMenu();
            cm.MenuItems.Add(new MenuItem("Remove", RemoveMenuItem_Click));

            ChatListView.Columns.Add("Id", 0, HorizontalAlignment.Left);
            ChatListView.Columns.Add("Name", 60, HorizontalAlignment.Left);
            ChatListView.Columns.Add("Type", 60, HorizontalAlignment.Left);
            ChatListView.Columns.Add("Users", 60, HorizontalAlignment.Left);
            ChatListView.Columns.Add("Room size", 80, HorizontalAlignment.Left);
            ChatListView.Columns.Add("Owner", 0, HorizontalAlignment.Left);

            NrOfUsersTrackBar.Minimum = 2;
            NrOfUsersTrackBar.Maximum = 10;
            NrOfUsersTrackBar.TickFrequency = 1;
            #endregion
            ViewProfileButton.BackColor = Color.Pink;
            SearchButton_Click(null, null);
        }

        private void SearchButton_Click(object sender, EventArgs e)//search button clicked
        {
            ChatListView.Items.Clear();
            foreach (Chat chat in client.GetChatsByName(SearchBox.Text, profileId))
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
                ChatListView.Items.Add(row);
            }
        }

        private void ChatListView_MouseDown(object sender, MouseEventArgs e)//Click on listView item
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo lvhti = this.ChatListView.HitTest(e.X, e.Y);
                if (lvhti.Item != null && Int32.Parse(lvhti.Item.SubItems[5].Text) == profileId)
                {
                    lvhti.Item.Selected = true;
                    cm.Show(this.ChatListView, new Point(e.X, e.Y));
                }
            }
            else
            {
                ListViewHitTestInfo lvhti = this.ChatListView.HitTest(e.X, e.Y);
                if (lvhti.Item != null)
                {
                    chatId = Int32.Parse(lvhti.Item.Text);
                    ChatNameTextBox.Text = lvhti.Item.SubItems[1].Text;
                    if (lvhti.Item.SubItems[2].Text.Equals("False"))
                    {
                        PrivateCheckBox.Checked = true;
                    }
                    else
                    {
                        PrivateCheckBox.Checked = false;
                    }
                    NrOfUsersTrackBar.Value = Int32.Parse(lvhti.Item.SubItems[4].Text);
                    SaveButton.Text = "Update chat";
                    if(Int32.Parse(lvhti.Item.SubItems[5].Text) == profileId)
                    {
                        ChatNameTextBox.Enabled = true;
                        PrivateCheckBox.Enabled = true;
                        NrOfUsersTrackBar.Enabled = true;
                        SaveButton.Enabled = true;
                    }
                    else
                    {
                        ChatNameTextBox.Enabled = false;
                        PrivateCheckBox.Enabled = false;
                        NrOfUsersTrackBar.Enabled = false;
                        SaveButton.Enabled = false;
                    }
                }
                else
                {
                    chatId = 0;
                    ChatNameTextBox.Text = "";
                    PrivateCheckBox.Checked = false;
                    NrOfUsersTrackBar.Value = 2;
                    SaveButton.Text = "Create chat";

                    ChatNameTextBox.Enabled = true;
                    PrivateCheckBox.Enabled = true;
                    NrOfUsersTrackBar.Enabled = true;
                    SaveButton.Enabled = true;
                }
            }
        }

        private void NrOfUsersTrackBar_ValueChanged(object sender, EventArgs e)//change max value of users
        {
            NrLabel.Text = (Math.Round(NrOfUsersTrackBar.Value / 1.0)).ToString();
        }

        private void SaveButton_Click(object sender, EventArgs e)//save chat button clicked
        {
            Chat chat = new Chat
            {
                Name = ChatNameTextBox.Text,
                MaxNrOfUsers = NrOfUsersTrackBar.Value,
                Id = chatId,
                OwnerID = profileId
            };
            if (PrivateCheckBox.Checked == true)
            {
                chat.Type = false;
            }
            else
            {
                chat.Type = true;
            }
            client.SaveChat(chat);

            chatId = 0;
            ChatNameTextBox.Text = "";
            PrivateCheckBox.Checked = false;
            NrOfUsersTrackBar.Value = 2;
            SaveButton.Text = "Create chat";

            SearchButton_Click(null, null);
        }

        private void RemoveMenuItem_Click(Object sender, EventArgs e)//Right cick remove menu button clicked
        {
            client.DeleteChat(Int32.Parse(ChatListView.SelectedItems[0].Text));
            SearchButton_Click(null, null);
        }

        private void ViewProfileButton_Click(object sender, EventArgs e)//Goes to profile View
        {
            ProfileForm chat = new ProfileForm(profileId);
            Hide();
        }

        private void ChatListView_MouseDoubleClick(object sender, MouseEventArgs e)//join chat room
        {
            if (e.Button == MouseButtons.Left)
            {
                ListViewHitTestInfo lvhti = this.ChatListView.HitTest(e.X, e.Y);
                if (lvhti.Item != null)
                {
                    try
                    {
                        new MessageForm(chatId, profileId);
                    }
                    catch (Exception)
                    {}
                }
            }
        }
    }
}
