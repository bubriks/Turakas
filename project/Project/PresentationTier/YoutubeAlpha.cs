using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PresentationTier
{
    public partial class YoutubeAlpha : Form
    {
        private YoutubeService.YoutubeServiceClient youtubeServiceClient = new YoutubeService.YoutubeServiceClient();
        public YoutubeAlpha()
        {
            SetBrowserFeatureControl();

            InitializeComponent();

        }

        string ytUrl;

        private string VideoId
        {
            get
            {
                var ytMatch = new Regex(@"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)").Match(ytUrl);
                return ytMatch.Success ? ytMatch.Groups[1].Value : string.Empty;
            }
        }

        private void playVideo(string videoId)
        {
            const string page1 = "<html><head><title></title></head><body>{0}</body></html>";
            webBrowser1.DocumentText = string.Format(page1, $"<iframe width=\"300\" height=\"240\" src=\"http://www.youtube.com/embed/{videoId}?autoplay=1\" frameborder=\"0\" allowfullscreen></iframe>");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ytUrl = textBox1.Text;
            string vidTitle = youtubeServiceClient.GetVideoTitle(VideoId);
            label1.Text = vidTitle;

            if (String.IsNullOrEmpty(vidTitle))
            {
                MessageBox.Show("Failed to add song. Probably the song already exists or the URL is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (youtubeServiceClient.AddSong(VideoId))
            {
                MessageBox.Show("Song successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                playVideo(VideoId);
                
            }
            else
            {
                MessageBox.Show("Failed to add song. Probably the song already exists or the URL is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            listBox1.DataSource = youtubeServiceClient.FindSongsByName(textBox2.Text);
            listBox1.ValueMember = "Url";
            listBox1.DisplayMember = "Name";
        }

        private void textBox2_GotFocus(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals("Search..."))
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_LostFocus(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "Search...";
            }
        }

        private void textBox3_GotFocus(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals("Search..."))
            {
                textBox3.Text = "";
            }
        }

        private void textBox3_LostFocus(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Text = "Search...";
            }
        }


        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            playVideo(listBox1.SelectedValue.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selected = listBox1.SelectedIndex;
            if (selected != -1 && selected + 1 < listBox1.Items.Count)
            {
                listBox1.SetSelected(selected + 1, true);
                playVideo(listBox1.SelectedValue.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selected = listBox1.SelectedIndex;
            if (selected != -1 && selected != 0)
            {
                listBox1.SetSelected(selected - 1, true);
                playVideo(listBox1.SelectedValue.ToString());
            }
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {

        }



        private void SetBrowserFeatureControlKey(string feature, string appName, uint value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(
                String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
                RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
            }
        }

        private void SetBrowserFeatureControl()
        {

            // FeatureControl settings are per-process
            var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

            // make sure the control is not running inside Visual Studio Designer
            if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
                return;

            SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, GetBrowserEmulationMode()); // Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode.
            SetBrowserFeatureControlKey("FEATURE_AJAX_CONNECTIONEVENTS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_MANAGE_SCRIPT_CIRCULAR_REFS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_DOMSTORAGE ", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_GPU_RENDERING ", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_IVIEWOBJECTDRAW_DMLT9_WITH_GDI  ", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_LEGACY_COMPRESSION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_LOCALMACHINE_LOCKDOWN", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_OBJECT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_SCRIPT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_NAVIGATION_SOUNDS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_SCRIPTURL_MITIGATION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_SPELLCHECKING", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_STATUS_BAR_THROTTLING", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_TABBED_BROWSING", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_VALIDATE_NAVIGATE_URL", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_DOCUMENT_ZOOM", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_POPUPMANAGEMENT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_MOVESIZECHILD", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_ADDON_MANAGEMENT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_WEBSOCKET", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WINDOW_RESTRICTIONS ", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_XMLHTTP", fileName, 1);
        }

        private UInt32 GetBrowserEmulationMode()
        {
            int browserVersion = 7;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
            RegistryKeyPermissionCheck.ReadSubTree,
            System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }

            UInt32 mode = 11000; // Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode. Default value for Internet Explorer 11.
            switch (browserVersion)
            {
                case 7:
                    mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control.
                    break;
                case 8:
                    mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8
                    break;
                case 9:
                    mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.
                    break;
                case 10:
                    mode = 10000; // Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 mode. Default value for Internet Explorer 10.
                    break;
                default:
                    // use IE11 mode by default
                    break;
            }

            return mode;
        }

        
    }
}