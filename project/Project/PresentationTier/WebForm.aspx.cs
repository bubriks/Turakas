using PresentationTier.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationTier
{
    public partial class WebForm : Page
    {
        private ServiceClient service = new ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Chat> chats = service.GetChatsByName(TextBox1.Text).ToList();
                foreach (Chat chat in chats)
                {
                    ListBox1.Items.Add(chat.Name);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            List<Chat> chats = service.GetChatsByName(TextBox1.Text).ToList();
            foreach(Chat chat in chats)
            {
                ListBox1.Items.Add(chat.Name);
            }
        }

        protected void VideoInfoButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}