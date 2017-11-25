using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using PresentationTier.MessageServiceReference;
using System.ServiceModel;
using System.Drawing;

namespace PresentationTier
{
    public partial class MessageForm : Form, IMessageServiceCallback
    {
        private int profileId, chatId;
        private InstanceContext instanceContext = null;
        private MessageServiceClient client;
        private ContextMenu cm;
        private ToolTip toolTip = new ToolTip();

        public MessageForm(int chatId, int profileId)
        {
            #region initialize
            InitializeComponent();
            instanceContext = new InstanceContext(this);
            client = new MessageServiceClient(instanceContext);

            cm = new ContextMenu();
            cm.MenuItems.Add(new MenuItem("Remove", MenuItemNew_Click));

            this.chatId = chatId;
            this.profileId = profileId;

            if (userListBox.Items.Count == 2)
                rps_btn.Visible = true;
            #endregion

            client.JoinChat(chatId, profileId);
        }

        #region info about chat
        public void GetChat(Chat chat)//gets chat
        {
            if (chat.Type == true)
            {
                this.Text = "Public chat: " + chat.Name;
            }
            else
            {
                this.Text = "Private chat: " + chat.Name;
            }

            peopleInChatLabel.Text = chat.Users.Count() + " out of " + chat.MaxNrOfUsers + " users";
        }

        public void GetMessages(MessageServiceReference.Message[] messages)//gets message in chat
        {
            foreach (MessageServiceReference.Message message in messages)
            {
                messageListBox.Items.Add(message);
            }
            this.messageListBox.SelectedIndex = this.messageListBox.Items.Count - 1;
        }

        public void GetOnlineProfiles(Profile[] profiles)//gets all users online
        {
            userListBox.Items.Clear();
            foreach (Profile profile in profiles)
            {
                userListBox.Items.Add(profile);
                if (profile.ProfileID == profileId)
                {
                    userListBox.SelectedIndex = userListBox.Items.Count - 1;
                }
            }

            String text = peopleInChatLabel.Text;
            peopleInChatLabel.Text = profiles.Count().ToString() + text.Substring(text.IndexOf(" ") -1 + " ".Length);

            if (userListBox.Items.Count == 2)
                rps_btn.Visible = true;
            else
                rps_btn.Visible = false;
        }
        #endregion

        #region Add message
        public void WritingMessage()//write message call back
        {
            toolStripStatusLabel1.Text = "Someone is writing";
            timer.Stop();
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)//timer if nobody writing than method runs
        {
            toolStripStatusLabel1.Text = "Nobody is writing";
        }

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)//Write or send
        {
            if (e.KeyValue == Convert.ToInt16(Keys.Enter))
            {
                SendButton_Click(null, null);
            }
            else
            {
                client.Writing(chatId);
            }
        }

        private void SendButton_Click(object sender, EventArgs e)//send message
        {
            if (!messageTextBox.Text.Equals(""))
            {
                client.CreateMessage(profileId, messageTextBox.Text, chatId);
                messageTextBox.Text = "";
            }
        }

        public void AddMessage(MessageServiceReference.Message message)//call back item message recieved
        {
            messageListBox.Items.Add(message);
        }
        #endregion

        #region Remove message

        private void ListBox1_MouseDown(object sender, MouseEventArgs e)//right click clicked on message
        {
            if (e.Button == MouseButtons.Right)
            {
                int item = messageListBox.IndexFromPoint(e.Location);
                if (item >= 0)
                {
                    messageListBox.SelectedIndex = item;
                    if ((messageListBox.SelectedItem as MessageServiceReference.Message).CreatorId == profileId)
                    {
                        cm.Show(messageListBox, e.Location);
                    }
                }
            }
        }

        private void MenuItemNew_Click(Object sender, EventArgs e)//Right cick menu button clicked
        {
            client.DeleteMessage (profileId, (messageListBox.SelectedItem as MessageServiceReference.Message).Id, chatId);
        }

        public void RemoveMessage(int id)//callBack method message removed
        {
            foreach (MessageServiceReference.Message message in messageListBox.Items)
            {
                if (message.Id == id)
                {
                    messageListBox.Items.Remove(message);
                    break;
                }
            }
        }
        #endregion

        private void MessageListBox_MouseMove(object sender, MouseEventArgs e)//Shows the rest of the info about message
        {
            int index = messageListBox.IndexFromPoint(e.Location);

            if (index >= 0)
            {
                messageListBox.SelectedIndex = index;
            }

            if (index != -1 && index < messageListBox.Items.Count)
            {
                MessageServiceReference.Message message = (messageListBox.SelectedItem as MessageServiceReference.Message);
                String text = message.Creator + " " + message.Time.ToString();
                if (toolTip.GetToolTip(messageListBox) != text)
                {
                    toolTip.SetToolTip(messageListBox, text);
                }
            }
            else
            {
                toolTip.SetToolTip(this.messageListBox, string.Empty);
            }
        }

        #region invite
        private void FriendNameTextBox_KeyDown(object sender, KeyEventArgs e)//if enter pressed then invite user
        {
            if (e.KeyValue == Convert.ToInt16(Keys.Enter))
            {
                InviteButton_Click(null, null);
            }
        }

        private void InviteButton_Click(object sender, EventArgs e)//invite button clicked
        {
            client.InviteToChat(chatId, friendNameTextBox.Text);
        }

        public void Invite(bool result)//returns if invite was successful
        {
            if (result)
            {
                friendNameTextBox.Text = "";
                addButton.BackColor = SystemColors.ButtonFace;
            }
            else
            {
                addButton.BackColor = Color.Red;
            }
        }
        #endregion

        private void Rps_btn_Click(object sender, EventArgs e)
        {
            RPSForm rPSForm = new RPSForm(chatId, profileId);
        }

        #region form control
        private void MessageForm_Closing(object sender, CancelEventArgs e)//on close event
        {
            client.LeaveChat(chatId, profileId);
        }

        public void Show(bool result)
        {
            if (result)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
        }
        #endregion
    }
}