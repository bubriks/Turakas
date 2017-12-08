using System;
using System.Windows.Forms;

namespace PresentationTier
{
    partial class YTForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.addSongBtn = new System.Windows.Forms.Button();
            this.addSongTxtBox = new System.Windows.Forms.TextBox();
            this.videoTitleLabel = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.songListBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSongFromPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSongToPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songSearchTextBox = new System.Windows.Forms.TextBox();
            this.nextSongBtn = new System.Windows.Forms.Button();
            this.previousSongBtn = new System.Windows.Forms.Button();
            this.playlistListBox = new System.Windows.Forms.ListBox();
            this.playlistMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistSearchTxtBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip2.SuspendLayout();
            this.playlistMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // addSongBtn
            // 
            this.addSongBtn.Location = new System.Drawing.Point(12, 12);
            this.addSongBtn.Name = "addSongBtn";
            this.addSongBtn.Size = new System.Drawing.Size(75, 23);
            this.addSongBtn.TabIndex = 0;
            this.addSongBtn.Text = "Add Song";
            this.addSongBtn.UseVisualStyleBackColor = true;
            this.addSongBtn.Click += new System.EventHandler(this.AddSongBtn_Click);
            // 
            // addSongTxtBox
            // 
            this.addSongTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addSongTxtBox.Location = new System.Drawing.Point(94, 12);
            this.addSongTxtBox.Name = "addSongTxtBox";
            this.addSongTxtBox.Size = new System.Drawing.Size(113, 20);
            this.addSongTxtBox.TabIndex = 1;
            // 
            // videoTitleLabel
            // 
            this.videoTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.videoTitleLabel.AutoSize = true;
            this.videoTitleLabel.Location = new System.Drawing.Point(214, 15);
            this.videoTitleLabel.Name = "videoTitleLabel";
            this.videoTitleLabel.Size = new System.Drawing.Size(0, 13);
            this.videoTitleLabel.TabIndex = 2;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(12, 41);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(275, 274);
            this.webBrowser1.TabIndex = 3;
            // 
            // songListBox
            // 
            this.songListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.songListBox.ContextMenuStrip = this.contextMenuStrip2;
            this.songListBox.FormattingEnabled = true;
            this.songListBox.Location = new System.Drawing.Point(511, 41);
            this.songListBox.Name = "songListBox";
            this.songListBox.Size = new System.Drawing.Size(215, 290);
            this.songListBox.TabIndex = 4;
            this.songListBox.DoubleClick += new System.EventHandler(this.ListBox1_DoubleClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSongFromPlaylistToolStripMenuItem,
            this.addSongToPlaylistToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(216, 48);
            // 
            // removeSongFromPlaylistToolStripMenuItem
            // 
            this.removeSongFromPlaylistToolStripMenuItem.Name = "removeSongFromPlaylistToolStripMenuItem";
            this.removeSongFromPlaylistToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.removeSongFromPlaylistToolStripMenuItem.Text = "Remove song from playlist";
            this.removeSongFromPlaylistToolStripMenuItem.Click += new System.EventHandler(this.RemoveSongFromPlaylistToolStripMenuItem_Click);
            // 
            // addSongToPlaylistToolStripMenuItem
            // 
            this.addSongToPlaylistToolStripMenuItem.Name = "addSongToPlaylistToolStripMenuItem";
            this.addSongToPlaylistToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.addSongToPlaylistToolStripMenuItem.Text = "Add song to playlist";
            this.addSongToPlaylistToolStripMenuItem.Click += new System.EventHandler(this.AddSongToPlaylistToolStripMenu_Click);
            // 
            // songSearchTextBox
            // 
            this.songSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.songSearchTextBox.Location = new System.Drawing.Point(511, 339);
            this.songSearchTextBox.Name = "songSearchTextBox";
            this.songSearchTextBox.Size = new System.Drawing.Size(215, 20);
            this.songSearchTextBox.TabIndex = 5;
            this.songSearchTextBox.Text = "Search...";
            this.songSearchTextBox.GotFocus += new System.EventHandler(this.TextBox2_GotFocus);
            this.songSearchTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox2_KeyUp);
            this.songSearchTextBox.LostFocus += new System.EventHandler(this.TextBox2_LostFocus);
            // 
            // nextSongBtn
            // 
            this.nextSongBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nextSongBtn.Location = new System.Drawing.Point(128, 336);
            this.nextSongBtn.Name = "nextSongBtn";
            this.nextSongBtn.Size = new System.Drawing.Size(75, 23);
            this.nextSongBtn.TabIndex = 6;
            this.nextSongBtn.Text = "Next";
            this.nextSongBtn.UseVisualStyleBackColor = true;
            this.nextSongBtn.Click += new System.EventHandler(this.Button2_Click);
            // 
            // previousSongBtn
            // 
            this.previousSongBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previousSongBtn.Location = new System.Drawing.Point(50, 336);
            this.previousSongBtn.Name = "previousSongBtn";
            this.previousSongBtn.Size = new System.Drawing.Size(75, 23);
            this.previousSongBtn.TabIndex = 7;
            this.previousSongBtn.Text = "Previous";
            this.previousSongBtn.UseVisualStyleBackColor = true;
            this.previousSongBtn.Click += new System.EventHandler(this.Button3_Click);
            // 
            // playlistListBox
            // 
            this.playlistListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistListBox.ContextMenuStrip = this.playlistMenuStrip;
            this.playlistListBox.FormattingEnabled = true;
            this.playlistListBox.Location = new System.Drawing.Point(293, 41);
            this.playlistListBox.Name = "playlistListBox";
            this.playlistListBox.Size = new System.Drawing.Size(210, 290);
            this.playlistListBox.TabIndex = 8;
            this.playlistListBox.DoubleClick += new System.EventHandler(this.ListBox2_DoubleClick);
            // 
            // playlistMenuStrip
            // 
            this.playlistMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removePlaylistToolStripMenuItem,
            this.addPlaylistToolStripMenuItem});
            this.playlistMenuStrip.Name = "playlistMenuStrip";
            this.playlistMenuStrip.Size = new System.Drawing.Size(158, 48);
            // 
            // removePlaylistToolStripMenuItem
            // 
            this.removePlaylistToolStripMenuItem.Name = "removePlaylistToolStripMenuItem";
            this.removePlaylistToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.removePlaylistToolStripMenuItem.Text = "Remove Playlist";
            this.removePlaylistToolStripMenuItem.Click += new System.EventHandler(this.RemovePlaylistToolStripMenuItem_Click);
            // 
            // addPlaylistToolStripMenuItem
            // 
            this.addPlaylistToolStripMenuItem.Name = "addPlaylistToolStripMenuItem";
            this.addPlaylistToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.addPlaylistToolStripMenuItem.Text = "Add Playlist";
            this.addPlaylistToolStripMenuItem.Click += new System.EventHandler(this.AddPlaylistToolStripMenuItem_Click);
            // 
            // playlistSearchTxtBox
            // 
            this.playlistSearchTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistSearchTxtBox.Location = new System.Drawing.Point(293, 339);
            this.playlistSearchTxtBox.Name = "playlistSearchTxtBox";
            this.playlistSearchTxtBox.Size = new System.Drawing.Size(210, 20);
            this.playlistSearchTxtBox.TabIndex = 9;
            this.playlistSearchTxtBox.Text = "Search...";
            this.playlistSearchTxtBox.GotFocus += new System.EventHandler(this.TextBox3_GotFocus);
            this.playlistSearchTxtBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox3_KeyUp);
            this.playlistSearchTxtBox.LostFocus += new System.EventHandler(this.TextBox3_LostFocus);
            // 
            // YTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 371);
            this.Controls.Add(this.playlistSearchTxtBox);
            this.Controls.Add(this.playlistListBox);
            this.Controls.Add(this.previousSongBtn);
            this.Controls.Add(this.nextSongBtn);
            this.Controls.Add(this.songSearchTextBox);
            this.Controls.Add(this.songListBox);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.videoTitleLabel);
            this.Controls.Add(this.addSongTxtBox);
            this.Controls.Add(this.addSongBtn);
            this.MinimumSize = new System.Drawing.Size(754, 410);
            this.Name = "YTForm";
            this.Text = "Youtube";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.YTForm_Closing);
            this.contextMenuStrip2.ResumeLayout(false);
            this.playlistMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addSongBtn;
        private System.Windows.Forms.TextBox addSongTxtBox;
        private System.Windows.Forms.Label videoTitleLabel;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ListBox songListBox;
        private System.Windows.Forms.TextBox songSearchTextBox;
        private System.Windows.Forms.Button nextSongBtn;
        private System.Windows.Forms.Button previousSongBtn;
        private ListBox playlistListBox;
        private TextBox playlistSearchTxtBox;
        private ContextMenuStrip playlistMenuStrip;
        private ToolStripMenuItem removePlaylistToolStripMenuItem;
        private ToolStripMenuItem addPlaylistToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem removeSongFromPlaylistToolStripMenuItem;
        private ToolStripMenuItem addSongToPlaylistToolStripMenuItem;
    }
}