using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using PresentationTier.MessageServiceReference;
using System.ServiceModel;

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
            #endregion

            client.JoinChat(chatId, profileId);
        }

        public void GetChat(Chat chat)
        {
            if (chat.Type == true)
            {
                this.Text = "Public chat: " + chat.Name;
            }
            else
            {
                this.Text = "Private chat: " + chat.Name;
            }

            PeopleInChatLabel.Text = chat.Users.Count() + " out of " + chat.MaxNrOfUsers + " users";
        }

        public void GetMessages(MessageServiceReference.Message[] messages)
        {
            foreach (MessageServiceReference.Message message in messages)
            {
                MessageListBox.Items.Add(message);
            }
            this.MessageListBox.SelectedIndex = this.MessageListBox.Items.Count - 1;
        }

        public void GetOnlineProfiles(Profile[] profiles)
        {
            UserListBox.Items.Clear();
            foreach (Profile profile in profiles)
            {
                UserListBox.Items.Add(profile);
            }
            this.UserListBox.SelectedIndex = this.UserListBox.Items.Count - 1;

            String text = PeopleInChatLabel.Text;
            PeopleInChatLabel.Text = profiles.Count().ToString() + text.Substring(text.IndexOf(" ") -1 + " ".Length);
        }

        #region Add message
        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
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

        public void WritingMessage()
        {
            toolStripStatusLabel1.Text = "Someone is writing";
            timer.Stop();
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Nobody is writing";
        }

        private void SendButton_Click(object sender, EventArgs e)//send message
        {
            client.CreateMessage(profileId, MessageTextBox.Text, chatId);
            MessageTextBox.Text = "";
        }

        public void AddMessage(MessageServiceReference.Message message)//call back item
        {
            MessageListBox.Items.Add(message);
        }
        #endregion

        #region Remove message

        private void ListBox1_MouseDown(object sender, MouseEventArgs e)//right click clicked
        {
            if (e.Button == MouseButtons.Right)
            {
                int item = MessageListBox.IndexFromPoint(e.Location);
                if (item >= 0)
                {
                    MessageListBox.SelectedIndex = item;
                    if ((MessageListBox.SelectedItem as MessageServiceReference.Message).CreatorId == profileId)
                    {
                        cm.Show(MessageListBox, e.Location);
                    }
                }
            }
        }

        private void MenuItemNew_Click(Object sender, EventArgs e)//Right cick menu button clicked
        {
            client.DeleteMessage((MessageListBox.SelectedItem as MessageServiceReference.Message).Id, chatId);
        }

        public void RemoveMessage(int id)//callBack method
        {
            foreach (MessageServiceReference.Message message in MessageListBox.Items)
            {
                if (message.Id == id)
                {
                    MessageListBox.Items.Remove(message);
                    break;
                }
            }
        }
        #endregion

        private void MessageListBox_MouseMove(object sender, MouseEventArgs e)//Shows the rest of the info
        {
            int index = MessageListBox.IndexFromPoint(e.Location);

            if (index >= 0)
            {
                MessageListBox.SelectedIndex = index;
            }

            if (index != -1 && index < MessageListBox.Items.Count)
            {
                MessageServiceReference.Message message = (MessageListBox.SelectedItem as MessageServiceReference.Message);
                String text = message.Creator + " " + message.Time.ToString();
                if (toolTip.GetToolTip(MessageListBox) != text)
                {
                    toolTip.SetToolTip(MessageListBox, text);
                }
            }
            else
            {
                toolTip.SetToolTip(this.MessageListBox, string.Empty);
            }
        }

        private void InviteButton_Click(object sender, EventArgs e)//invite button
        {
            
        }

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
    }
}