using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentationTier.ServiceReference;
using System.ServiceModel;

namespace PresentationTier
{
    public partial class Form1 : Form, IMessageServiceCallback
    {
        private InstanceContext instanceContext = null;
        private MessageServiceClient client = null;
        
        public Form1()
        {
            InitializeComponent();
            instanceContext = new InstanceContext(this);
            client = new MessageServiceClient(instanceContext);
            client.Register();//registers user in list of clients that will recive the message
            foreach(ServiceReference.Message message in client.GetMessages(11))//adds last 20 messages to listbox
            {
                listBox1.Items.Add(message.Text);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            client.CreateMessage(1, textBox1.Text, 11);
        }

        public void GetMessage(string message)
        {
            listBox1.Items.Add(message);
        }
    }
}
