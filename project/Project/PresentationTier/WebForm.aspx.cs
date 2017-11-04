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
                List<Message> mesagges = service.GetMessages(11).ToList();
                foreach (Message message in mesagges)
                {
                    ListBox1.Items.Add(message.Text);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            service.CreateMessage(1, TextBox1.Text, 11);
            ListBox1.Items.Clear();
            List<Message> mesagges = service.GetMessages(11).ToList();
            foreach (Message message in mesagges)
            {
                ListBox1.Items.Add(message.Text);
            }
        }
    }
}