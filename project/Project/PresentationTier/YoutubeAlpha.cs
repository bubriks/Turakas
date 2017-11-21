﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationTier
{
    public partial class YoutubeAlpha : Form
    {
        private YoutubeService.YoutubeServiceClient youtubeServiceClient = new YoutubeService.YoutubeServiceClient();
        public YoutubeAlpha()
        {
            InitializeComponent();
            
        }

        string ytUrl;

        public string VideoId
        {
            get
            {
                var ytMatch = new Regex(@"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)").Match(ytUrl);
                return ytMatch.Success ? ytMatch.Groups[1].Value : string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ytUrl = textBox1.Text;
            string vidTitle = youtubeServiceClient.GetVideoInfo(VideoId);
            label1.Text = vidTitle;
            //Console.WriteLine(VideoId);
            //Console.ReadLine();
            webBrowser1.Navigate($"https//www.youtube.com/watch?v={VideoId}");
            /*
            var page = $@"
        <html>
            <body>
                <iframe width='560' height='315'
                    src='https//www.youtube.com/embed/{VideoId}' frameborder='0'>
                </iframe>
            </body>
        <html>";
            webBrowser1.DocumentText = page;
            webBrowser1.ScriptErrorsSuppressed = true;*/
        }
    }
}
