using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentationTier.MessageServiceReference;
using System.ServiceModel;

namespace PresentationTier
{
    public partial class MessageForm : Form, IMessageServiceCallback
    {
        private int profileId = 1;
        private int chatId = 11;

        private InstanceContext instanceContext = null;
        private MessageServiceClient client;
        public MessageForm()
        {
            InitializeComponent();
            instanceContext = new InstanceContext(this);
            client = new MessageServiceClient(instanceContext);
            client.Register();
            foreach (MessageServiceReference.Message message in client.GetMessages(chatId).Reverse())
            {
                listBox1.Items.Add(new ListItem() { Value = message.Id, Text = message.Creator + ": " + message.Text });
            }
            listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            client.CreateMessage(profileId,textBox2.Text, chatId);
            textBox2.Text = "";
        }

        public void CallBackMessage(MessageServiceReference.Message message)
        {
            listBox1.Items.Add(new ListItem() { Value = message.Id, Text = message.Creator + ": " + message.Text });
        }
    }

    public class ListItem
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
//textBox2.Text = (listBox1.SelectedItem as ListItem).Value.ToString();