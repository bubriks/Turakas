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
using Microsoft.VisualBasic;

namespace PresentationTier
{
    public partial class YTForm : Form
    {
        private YoutubeService.YoutubeServiceClient youtubeServiceClient = new YoutubeService.YoutubeServiceClient();
        private static YTForm instance;
        private int profileId;
        private string ytUrl;

        public static YTForm GetInstance(int profileId, Form chatForm)
        {
            if (instance == null)
            {
                instance = new YTForm(profileId, chatForm);
            }
            return instance;
        }
        private YTForm(int profileId, Form chatForm)
        {
            this.profileId = profileId;
            SetBrowserFeatureControl();

            InitializeComponent();

        }

        private void YTForm_Closing(object sender, CancelEventArgs e)//on close event
        {
            instance = null;
        }

        private string VideoId
        {
            get
            {
                var ytMatch = new Regex(@"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)").Match(ytUrl);
                return ytMatch.Success ? ytMatch.Groups[1].Value : string.Empty;
            }
        }

        private void PlayVideo(string videoId)
        {
            const string page1 = "<html><head><title></title></head><body>{0}</body></html>";
            webBrowser1.DocumentText = string.Format(page1, $"<iframe width=\"300\" height=\"240\" src=\"http://www.youtube.com/embed/{videoId}?autoplay=1\" frameborder=\"0\" allowfullscreen></iframe>");

        }

        private void AddSongBtn_Click(object sender, EventArgs e)
        {
            ytUrl = addSongTxtBox.Text;
            string vidTitle = youtubeServiceClient.GetVideoTitle(VideoId);
            videoTitleLabel.Text = vidTitle;

            if (String.IsNullOrEmpty(vidTitle))
            {
                MessageBox.Show("Failed to add song. Probably the song already exists or the URL is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (youtubeServiceClient.AddSong(VideoId, profileId))
            {
                MessageBox.Show("Song successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                songListBox.DataSource = youtubeServiceClient.FindSongsByName(!songSearchTextBox.Text.Equals("Search...") ? songSearchTextBox.Text : " ");
                songListBox.ValueMember = "Url";
                songListBox.DisplayMember = "Name";
                PlayVideo(VideoId);
                
            }
            else
            {
                MessageBox.Show("Failed to add song. Probably the song already exists or the URL is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void TextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            songListBox.DataSource = youtubeServiceClient.FindSongsByName(songSearchTextBox.Text);
            songListBox.ValueMember = "Url";
            songListBox.DisplayMember = "Name";
        }

        private void TextBox2_GotFocus(object sender, EventArgs e)
        {
            if (songSearchTextBox.Text.Equals("Search..."))
            {
                songSearchTextBox.Text = "";
            }
        }

        private void TextBox2_LostFocus(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(songSearchTextBox.Text))
            {
                songSearchTextBox.Text = "Search...";
            }
        }

        private void TextBox3_GotFocus(object sender, EventArgs e)
        {
            if (playlistSearchTxtBox.Text.Equals("Search..."))
            {
                playlistSearchTxtBox.Text = "";
            }
        }

        private void TextBox3_LostFocus(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(playlistSearchTxtBox.Text))
            {
                playlistSearchTxtBox.Text = "Search...";
            }
        }

        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            PlayVideo(songListBox.SelectedValue.ToString());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int selected = songListBox.SelectedIndex;
            if (selected != -1 && selected + 1 < songListBox.Items.Count)
            {
                songListBox.SetSelected(selected + 1, true);
                PlayVideo(songListBox.SelectedValue.ToString());
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int selected = songListBox.SelectedIndex;
            if (selected != -1 && selected != 0)
            {
                songListBox.SetSelected(selected - 1, true);
                PlayVideo(songListBox.SelectedValue.ToString());
            }
        }

        private void AddSongToPlaylistToolStripMenu_Click(object sender, EventArgs e)
        {
            if(songListBox.SelectedIndex>-1&&youtubeServiceClient.AddSongToPlayList(songListBox.SelectedValue.ToString(),
                playlistListBox.SelectedValue.ToString(), profileId))
            {
                MessageBox.Show("Song added to playlist.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                songListBox.DataSource = youtubeServiceClient.GetSongsFromPlayList(playlistListBox.SelectedValue.ToString());
                songListBox.ValueMember = "Url";
                songListBox.DisplayMember = "Name";
            }
            else
            {
                MessageBox.Show("Operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox3_KeyUp(object sender, KeyEventArgs e)
        {
            playlistListBox.DataSource = youtubeServiceClient.FindPlayListsByName(playlistSearchTxtBox.Text);
            playlistListBox.ValueMember = "ActivityId";
            playlistListBox.DisplayMember = "Name";
        }

        private void RemovePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playlistListBox.SelectedIndex>-1&&youtubeServiceClient.RemovePlaylist(playlistListBox.SelectedValue.ToString(), profileId))
            {
                MessageBox.Show("Playlist removed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                playlistListBox.DataSource = youtubeServiceClient.FindPlayListsByName(!songSearchTextBox.Text.Equals("Search...") ? playlistSearchTxtBox.Text : " ");
                playlistListBox.ValueMember = "ActivityId";
                playlistListBox.DisplayMember = "Name";
            }
            else
            {
                MessageBox.Show("Operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string plName = Interaction.InputBox("Add song", "Enter song name: ", "Default", -1, -1);
            if (!String.IsNullOrEmpty(plName)&&youtubeServiceClient.AddPlayList(plName, profileId))
            {
                MessageBox.Show("Playlist added.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                playlistListBox.DataSource = youtubeServiceClient.FindPlayListsByName(!songSearchTextBox.Text.Equals("Search...") ? playlistSearchTxtBox.Text : " ");
                playlistListBox.ValueMember = "ActivityId";
                playlistListBox.DisplayMember = "Name";
            }
            else
            {
                MessageBox.Show("Operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveSongFromPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (songListBox.SelectedIndex>-1&&youtubeServiceClient.RemoveSongFromPlaylist(songListBox.SelectedValue.ToString(), playlistListBox.SelectedValue.ToString(), profileId))
            {
                MessageBox.Show("Song removed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                songListBox.DataSource = youtubeServiceClient.GetSongsFromPlayList(playlistListBox.SelectedValue.ToString());
                songListBox.ValueMember = "Url";
                songListBox.DisplayMember = "Name";

            }
            else
            {
                MessageBox.Show("Operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ListBox2_DoubleClick(object sender, EventArgs e)
        {
            songListBox.DataSource = youtubeServiceClient.GetSongsFromPlayList(playlistListBox.SelectedValue.ToString());
            songListBox.ValueMember = "Url";
            songListBox.DisplayMember = "Name";
        }

        private void SetBrowserFeatureControlKey(string feature, string appName, uint value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(
                String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
                RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                key.SetValue(appName, value, RegistryValueKind.DWord);
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