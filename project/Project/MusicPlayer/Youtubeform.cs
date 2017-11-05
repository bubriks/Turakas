using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class Youtubeform : Form
    {
        public Youtubeform()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            string urlOriginal = ytUrlTxtBox.Text;
            string urlModified = urlOriginal.Replace("watch?v=", "v/");
            axShockwaveFlash1.Movie = urlModified;
        }
    }
}
