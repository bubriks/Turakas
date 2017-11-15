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

            label2.Text = chat.Users.Count() + " out of " + chat.MaxNrOfUsers + " users";
        }

        public void GetMessages(MessageServiceReference.Message[] messages)
        {
            foreach (MessageServiceReference.Message message in messages.Reverse())
            {
                listBox1.Items.Add(message);
            }
            this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
        }

        public void GetOnlineProfiles(Profile[] profiles)
        {
            listBox2.Items.Clear();
            foreach (Profile profile in profiles)
            {
                listBox2.Items.Add(profile);
            }
            this.listBox2.SelectedIndex = this.listBox2.Items.Count - 1;

            String text = label2.Text;
            label2.Text = profiles.Count().ToString() + text.Substring(text.IndexOf(" ") -1 + " ".Length);
        }

        #region Add message
        private void Button1_Click(object sender, EventArgs e)//send message
        {
            client.CreateMessage(profileId, textBox2.Text, chatId);
            textBox2.Text = "";
        }

        public void AddMessage(MessageServiceReference.Message message)//call back item
        {
            listBox1.Items.Add(message);
        }
        #endregion

        #region Remove message

        private void ListBox1_MouseDown(object sender, MouseEventArgs e)//right click clicked
        {
            if (e.Button == MouseButtons.Right)
            {
                int item = listBox1.IndexFromPoint(e.Location);
                if (item >= 0)
                {
                    listBox1.SelectedIndex = item;
                    if ((listBox1.SelectedItem as MessageServiceReference.Message).CreatorId == profileId)
                    {
                        cm.Show(listBox1, e.Location);
                    }
                }
            }
        }

        private void MenuItemNew_Click(Object sender, EventArgs e)//Right cick menu button clicked
        {
            client.DeleteMessage((listBox1.SelectedItem as MessageServiceReference.Message).Id, chatId);
        }

        public void RemoveMessage(int id)//callBack method
        {
            foreach (MessageServiceReference.Message message in listBox1.Items)
            {
                if (message.Id == id)
                {
                    listBox1.Items.Remove(message);
                    break;
                }
            }
        }
        #endregion

        private void ListBox1_MouseMove(object sender, MouseEventArgs e)//Shows the rest of the info
        {
            int index = listBox1.IndexFromPoint(e.Location);

            if (index >= 0)
            {
                listBox1.SelectedIndex = index;
            }

            if (index != -1 && index < listBox1.Items.Count)
            {
                MessageServiceReference.Message message = (listBox1.SelectedItem as MessageServiceReference.Message);
                String text = message.Creator + " " + message.Time.ToString();
                if (toolTip.GetToolTip(listBox1) != text)
                {
                    toolTip.SetToolTip(listBox1, text);
                }
            }
            else
            {
                toolTip.SetToolTip(this.listBox1, string.Empty);
            }
        }

        private void Button2_Click(object sender, EventArgs e)//invite button
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