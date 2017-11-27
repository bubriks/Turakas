using System.Windows.Forms;

namespace PresentationTier
{
    partial class ChatForm
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
            this.chatListView = new System.Windows.Forms.ListView();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.chatGroupBox = new System.Windows.Forms.GroupBox();
            this.nrLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.nrOfUsersLable = new System.Windows.Forms.Label();
            this.nrOfUsersTrackBar = new System.Windows.Forms.TrackBar();
            this.privateCheckBox = new System.Windows.Forms.CheckBox();
            this.chatNameTextBox = new System.Windows.Forms.TextBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.chatNameLabel = new System.Windows.Forms.Label();
            this.viewProfileButton = new System.Windows.Forms.Button();
            this.inviteListBox = new System.Windows.Forms.ListBox();
            this.clearEventsButton = new System.Windows.Forms.Button();
            this.youtubeButton = new System.Windows.Forms.Button();
            this.chatGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrOfUsersTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // chatListView
            // 
            this.chatListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatListView.FullRowSelect = true;
            this.chatListView.Location = new System.Drawing.Point(12, 39);
            this.chatListView.MultiSelect = false;
            this.chatListView.Name = "chatListView";
            this.chatListView.Size = new System.Drawing.Size(386, 255);
            this.chatListView.TabIndex = 0;
            this.chatListView.UseCompatibleStateImageBehavior = false;
            this.chatListView.View = System.Windows.Forms.View.Details;
            this.chatListView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ChatListView_ColumnWidthChanging);
            this.chatListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ChatListView_MouseDoubleClick);
            this.chatListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChatListView_MouseDown);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(324, 10);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Refresh";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Location = new System.Drawing.Point(12, 13);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(305, 20);
            this.searchBox.TabIndex = 2;
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyDown);
            // 
            // chatGroupBox
            // 
            this.chatGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chatGroupBox.Controls.Add(this.nrLabel);
            this.chatGroupBox.Controls.Add(this.saveButton);
            this.chatGroupBox.Controls.Add(this.nrOfUsersLable);
            this.chatGroupBox.Controls.Add(this.nrOfUsersTrackBar);
            this.chatGroupBox.Controls.Add(this.privateCheckBox);
            this.chatGroupBox.Controls.Add(this.chatNameTextBox);
            this.chatGroupBox.Controls.Add(this.typeLabel);
            this.chatGroupBox.Controls.Add(this.chatNameLabel);
            this.chatGroupBox.Location = new System.Drawing.Point(405, 10);
            this.chatGroupBox.Name = "chatGroupBox";
            this.chatGroupBox.Size = new System.Drawing.Size(200, 158);
            this.chatGroupBox.TabIndex = 3;
            this.chatGroupBox.TabStop = false;
            this.chatGroupBox.Text = "Chat";
            // 
            // nrLabel
            // 
            this.nrLabel.AutoSize = true;
            this.nrLabel.Location = new System.Drawing.Point(6, 90);
            this.nrLabel.Name = "nrLabel";
            this.nrLabel.Size = new System.Drawing.Size(13, 13);
            this.nrLabel.TabIndex = 7;
            this.nrLabel.Text = "2";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(9, 129);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(179, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Create chat";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // nrOfUsersLable
            // 
            this.nrOfUsersLable.AutoSize = true;
            this.nrOfUsersLable.Location = new System.Drawing.Point(6, 77);
            this.nrOfUsersLable.Name = "nrOfUsersLable";
            this.nrOfUsersLable.Size = new System.Drawing.Size(58, 13);
            this.nrOfUsersLable.TabIndex = 6;
            this.nrOfUsersLable.Text = "Nr of users";
            // 
            // nrOfUsersTrackBar
            // 
            this.nrOfUsersTrackBar.Location = new System.Drawing.Point(70, 77);
            this.nrOfUsersTrackBar.Name = "nrOfUsersTrackBar";
            this.nrOfUsersTrackBar.Size = new System.Drawing.Size(124, 45);
            this.nrOfUsersTrackBar.TabIndex = 5;
            this.nrOfUsersTrackBar.ValueChanged += new System.EventHandler(this.NrOfUsersTrackBar_ValueChanged);
            // 
            // privateCheckBox
            // 
            this.privateCheckBox.AutoSize = true;
            this.privateCheckBox.Location = new System.Drawing.Point(70, 53);
            this.privateCheckBox.Name = "privateCheckBox";
            this.privateCheckBox.Size = new System.Drawing.Size(58, 17);
            this.privateCheckBox.TabIndex = 3;
            this.privateCheckBox.Text = "private";
            this.privateCheckBox.UseVisualStyleBackColor = true;
            // 
            // chatNameTextBox
            // 
            this.chatNameTextBox.Location = new System.Drawing.Point(70, 19);
            this.chatNameTextBox.Name = "chatNameTextBox";
            this.chatNameTextBox.Size = new System.Drawing.Size(124, 20);
            this.chatNameTextBox.TabIndex = 2;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(6, 54);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(31, 13);
            this.typeLabel.TabIndex = 1;
            this.typeLabel.Text = "Type";
            // 
            // chatNameLabel
            // 
            this.chatNameLabel.AutoSize = true;
            this.chatNameLabel.Location = new System.Drawing.Point(6, 22);
            this.chatNameLabel.Name = "chatNameLabel";
            this.chatNameLabel.Size = new System.Drawing.Size(58, 13);
            this.chatNameLabel.TabIndex = 0;
            this.chatNameLabel.Text = "Chat name";
            // 
            // viewProfileButton
            // 
            this.viewProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.viewProfileButton.Location = new System.Drawing.Point(414, 271);
            this.viewProfileButton.Name = "viewProfileButton";
            this.viewProfileButton.Size = new System.Drawing.Size(75, 23);
            this.viewProfileButton.TabIndex = 4;
            this.viewProfileButton.Text = "View Profile";
            this.viewProfileButton.UseVisualStyleBackColor = true;
            this.viewProfileButton.Click += new System.EventHandler(this.ViewProfileButton_Click);
            // 
            // inviteListBox
            // 
            this.inviteListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inviteListBox.DisplayMember = "Name";
            this.inviteListBox.FormattingEnabled = true;
            this.inviteListBox.Location = new System.Drawing.Point(405, 175);
            this.inviteListBox.Name = "inviteListBox";
            this.inviteListBox.Size = new System.Drawing.Size(200, 82);
            this.inviteListBox.TabIndex = 5;
            this.inviteListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.InviteListBox_MouseDoubleClick);
            // 
            // clearEventsButton
            // 
            this.clearEventsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearEventsButton.Location = new System.Drawing.Point(530, 271);
            this.clearEventsButton.Name = "clearEventsButton";
            this.clearEventsButton.Size = new System.Drawing.Size(75, 23);
            this.clearEventsButton.TabIndex = 6;
            this.clearEventsButton.Text = "Clear events";
            this.clearEventsButton.UseVisualStyleBackColor = true;
            this.clearEventsButton.Click += new System.EventHandler(this.ClearEventsButton_Click);
            // 
            // youtubeButton
            // 
            this.youtubeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.youtubeButton.Location = new System.Drawing.Point(496, 271);
            this.youtubeButton.Name = "youtubeButton";
            this.youtubeButton.Size = new System.Drawing.Size(29, 23);
            this.youtubeButton.TabIndex = 7;
            this.youtubeButton.Text = "YT";
            this.youtubeButton.UseVisualStyleBackColor = true;
            this.youtubeButton.Click += new System.EventHandler(this.YoutubeButton_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 306);
            this.Controls.Add(this.youtubeButton);
            this.Controls.Add(this.clearEventsButton);
            this.Controls.Add(this.inviteListBox);
            this.Controls.Add(this.viewProfileButton);
            this.Controls.Add(this.chatGroupBox);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.chatListView);
            this.Name = "ChatForm";
            this.Text = "Chat form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_Closing);
            this.chatGroupBox.ResumeLayout(false);
            this.chatGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrOfUsersTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView chatListView;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchBox;
        private GroupBox chatGroupBox;
        private CheckBox privateCheckBox;
        private TextBox chatNameTextBox;
        private Label typeLabel;
        private Label chatNameLabel;
        private Button saveButton;
        private Label nrOfUsersLable;
        private TrackBar nrOfUsersTrackBar;
        private Label nrLabel;
        private Button viewProfileButton;
        private ListBox inviteListBox;
        private Button clearEventsButton;
        private Button youtubeButton;
    }
}