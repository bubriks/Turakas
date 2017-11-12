using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentationTier.ChatServiceReference;

namespace PresentationTier
{
    public partial class ChatForm : Form
    {
        private int chatId = 0;

        private ChatServiceClient client;
        private ContextMenu cm;
        public ChatForm()
        {
            #region initialize
            InitializeComponent();
            client = new ChatServiceClient();
            cm = new ContextMenu();
            cm.MenuItems.Add(new MenuItem("Remove", MenuItemNew_Click));

            listView1.Columns.Add("Id", 0, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("Type", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("Users", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("Room size", 60, HorizontalAlignment.Left);

            trackBar1.Minimum = 2;
            trackBar1.Maximum = 10;
            trackBar1.TickFrequency = 1;
            #endregion

            Button1_Click(null, null);
        }

        private void Button1_Click(object sender, EventArgs e)//search button
        {
            listView1.Items.Clear();
            foreach (Chat chat in client.GetChatsByName(textBox1.Text))
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
                listView1.Items.Add(row);
            }
        }

        private void ListView1_MouseDown(object sender, MouseEventArgs e)//Click on listView item
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo lvhti = this.listView1.HitTest(e.X, e.Y);
                if (lvhti.Item != null)
                {
                    lvhti.Item.Selected = true;
                    cm.Show(this.listView1, new Point(e.X, e.Y));
                }
            }
            else
            {
                ListViewHitTestInfo lvhti = this.listView1.HitTest(e.X, e.Y);
                if (lvhti.Item != null)
                {
                    chatId = Int32.Parse(lvhti.Item.Text);
                    textBox2.Text = lvhti.Item.SubItems[1].Text;
                    if (lvhti.Item.SubItems[2].Text.Equals("True"))
                    {
                        checkBox2.Checked = true;
                        checkBox1.Checked = false;
                    }
                    else
                    {
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                    }
                    trackBar1.Value = Int32.Parse(lvhti.Item.SubItems[4].Text);
                }
                else
                {
                    chatId = 2;
                    textBox2.Text = "";
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    trackBar1.Value = 2;
                }
            }
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)//change max value of users
        {
            label4.Text = (Math.Round(trackBar1.Value / 1.0)).ToString();
        }

        private void Button2_Click(object sender, EventArgs e)//change chat
        {
            Chat chat = new Chat();
            chat.Name = textBox2.Text;
            chat.MaxNrOfUsers = trackBar1.Value;
            chat.Id = chatId;
            if (checkBox2.Checked == true)
            {
                chat.Type = true;
            }
            else
            {
                chat.Type = false;
            }
            client.SaveChat(chat);
            Button1_Click(null, null);
        }

        private void MenuItemNew_Click(Object sender, EventArgs e)//Right cick menu button clicked
        {
            client.DeleteChat(Int32.Parse(listView1.SelectedItems[0].Text));
            Button1_Click(null, null);
        }
    }
}
