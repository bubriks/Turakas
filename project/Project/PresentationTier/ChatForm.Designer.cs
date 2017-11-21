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
            this.ChatListView = new System.Windows.Forms.ListView();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.ChatGroupBox = new System.Windows.Forms.GroupBox();
            this.NrLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.NrOfUsersLable = new System.Windows.Forms.Label();
            this.NrOfUsersTrackBar = new System.Windows.Forms.TrackBar();
            this.PrivateCheckBox = new System.Windows.Forms.CheckBox();
            this.ChatNameTextBox = new System.Windows.Forms.TextBox();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.ChatNameLabel = new System.Windows.Forms.Label();
            this.ViewProfileButton = new System.Windows.Forms.Button();
            this.InviteListBox = new System.Windows.Forms.ListBox();
            this.ClearEventsButton = new System.Windows.Forms.Button();
            this.ChatGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NrOfUsersTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ChatListView
            // 
            this.ChatListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatListView.FullRowSelect = true;
            this.ChatListView.Location = new System.Drawing.Point(12, 39);
            this.ChatListView.MultiSelect = false;
            this.ChatListView.Name = "ChatListView";
            this.ChatListView.Size = new System.Drawing.Size(388, 250);
            this.ChatListView.TabIndex = 0;
            this.ChatListView.UseCompatibleStateImageBehavior = false;
            this.ChatListView.View = System.Windows.Forms.View.Details;
            this.ChatListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ChatListView_MouseDoubleClick);
            this.ChatListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChatListView_MouseDown);
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.Location = new System.Drawing.Point(326, 10);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Refresh";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBox.Location = new System.Drawing.Point(12, 13);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(307, 20);
            this.SearchBox.TabIndex = 2;
            this.SearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyDown);
            // 
            // ChatGroupBox
            // 
            this.ChatGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatGroupBox.Controls.Add(this.NrLabel);
            this.ChatGroupBox.Controls.Add(this.SaveButton);
            this.ChatGroupBox.Controls.Add(this.NrOfUsersLable);
            this.ChatGroupBox.Controls.Add(this.NrOfUsersTrackBar);
            this.ChatGroupBox.Controls.Add(this.PrivateCheckBox);
            this.ChatGroupBox.Controls.Add(this.ChatNameTextBox);
            this.ChatGroupBox.Controls.Add(this.TypeLabel);
            this.ChatGroupBox.Controls.Add(this.ChatNameLabel);
            this.ChatGroupBox.Location = new System.Drawing.Point(407, 10);
            this.ChatGroupBox.Name = "ChatGroupBox";
            this.ChatGroupBox.Size = new System.Drawing.Size(200, 158);
            this.ChatGroupBox.TabIndex = 3;
            this.ChatGroupBox.TabStop = false;
            this.ChatGroupBox.Text = "Chat";
            // 
            // NrLabel
            // 
            this.NrLabel.AutoSize = true;
            this.NrLabel.Location = new System.Drawing.Point(6, 90);
            this.NrLabel.Name = "NrLabel";
            this.NrLabel.Size = new System.Drawing.Size(13, 13);
            this.NrLabel.TabIndex = 7;
            this.NrLabel.Text = "2";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(9, 129);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(179, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Create chat";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // NrOfUsersLable
            // 
            this.NrOfUsersLable.AutoSize = true;
            this.NrOfUsersLable.Location = new System.Drawing.Point(6, 77);
            this.NrOfUsersLable.Name = "NrOfUsersLable";
            this.NrOfUsersLable.Size = new System.Drawing.Size(58, 13);
            this.NrOfUsersLable.TabIndex = 6;
            this.NrOfUsersLable.Text = "Nr of users";
            // 
            // NrOfUsersTrackBar
            // 
            this.NrOfUsersTrackBar.Location = new System.Drawing.Point(70, 77);
            this.NrOfUsersTrackBar.Name = "NrOfUsersTrackBar";
            this.NrOfUsersTrackBar.Size = new System.Drawing.Size(124, 45);
            this.NrOfUsersTrackBar.TabIndex = 5;
            this.NrOfUsersTrackBar.ValueChanged += new System.EventHandler(this.NrOfUsersTrackBar_ValueChanged);
            // 
            // PrivateCheckBox
            // 
            this.PrivateCheckBox.AutoSize = true;
            this.PrivateCheckBox.Location = new System.Drawing.Point(70, 53);
            this.PrivateCheckBox.Name = "PrivateCheckBox";
            this.PrivateCheckBox.Size = new System.Drawing.Size(58, 17);
            this.PrivateCheckBox.TabIndex = 3;
            this.PrivateCheckBox.Text = "private";
            this.PrivateCheckBox.UseVisualStyleBackColor = true;
            // 
            // ChatNameTextBox
            // 
            this.ChatNameTextBox.Location = new System.Drawing.Point(70, 19);
            this.ChatNameTextBox.Name = "ChatNameTextBox";
            this.ChatNameTextBox.Size = new System.Drawing.Size(124, 20);
            this.ChatNameTextBox.TabIndex = 2;
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(6, 54);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(31, 13);
            this.TypeLabel.TabIndex = 1;
            this.TypeLabel.Text = "Type";
            // 
            // ChatNameLabel
            // 
            this.ChatNameLabel.AutoSize = true;
            this.ChatNameLabel.Location = new System.Drawing.Point(6, 22);
            this.ChatNameLabel.Name = "ChatNameLabel";
            this.ChatNameLabel.Size = new System.Drawing.Size(58, 13);
            this.ChatNameLabel.TabIndex = 0;
            this.ChatNameLabel.Text = "Chat name";
            // 
            // ViewProfileButton
            // 
            this.ViewProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewProfileButton.Location = new System.Drawing.Point(416, 266);
            this.ViewProfileButton.Name = "ViewProfileButton";
            this.ViewProfileButton.Size = new System.Drawing.Size(75, 23);
            this.ViewProfileButton.TabIndex = 4;
            this.ViewProfileButton.Text = "View Profile";
            this.ViewProfileButton.UseVisualStyleBackColor = true;
            this.ViewProfileButton.Click += new System.EventHandler(this.ViewProfileButton_Click);
            // 
            // InviteListBox
            // 
            this.InviteListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InviteListBox.DisplayMember = "Name";
            this.InviteListBox.FormattingEnabled = true;
            this.InviteListBox.Location = new System.Drawing.Point(407, 175);
            this.InviteListBox.Name = "InviteListBox";
            this.InviteListBox.Size = new System.Drawing.Size(200, 82);
            this.InviteListBox.TabIndex = 5;
            this.InviteListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.InviteListBox_MouseDoubleClick);
            // 
            // ClearEventsButton
            // 
            this.ClearEventsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearEventsButton.Location = new System.Drawing.Point(532, 266);
            this.ClearEventsButton.Name = "ClearEventsButton";
            this.ClearEventsButton.Size = new System.Drawing.Size(75, 23);
            this.ClearEventsButton.TabIndex = 6;
            this.ClearEventsButton.Text = "Clear events";
            this.ClearEventsButton.UseVisualStyleBackColor = true;
            this.ClearEventsButton.Click += new System.EventHandler(this.ClearEventsButton_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 301);
            this.Controls.Add(this.ClearEventsButton);
            this.Controls.Add(this.InviteListBox);
            this.Controls.Add(this.ViewProfileButton);
            this.Controls.Add(this.ChatGroupBox);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.ChatListView);
            this.Name = "ChatForm";
            this.Text = "Chat form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_Closing);
            this.ChatGroupBox.ResumeLayout(false);
            this.ChatGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NrOfUsersTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ChatListView;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchBox;
        private GroupBox ChatGroupBox;
        private CheckBox PrivateCheckBox;
        private TextBox ChatNameTextBox;
        private Label TypeLabel;
        private Label ChatNameLabel;
        private Button SaveButton;
        private Label NrOfUsersLable;
        private TrackBar NrOfUsersTrackBar;
        private Label NrLabel;
        private Button ViewProfileButton;
        private ListBox InviteListBox;
        private Button ClearEventsButton;
    }
}