using System.Windows.Forms;

namespace PresentationTier
{
    partial class MessageForm
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
            this.sendButton = new System.Windows.Forms.Button();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.messageListBox = new System.Windows.Forms.ListBox();
            this.userListBox = new System.Windows.Forms.ListBox();
            this.peopleInChatLabel = new System.Windows.Forms.Label();
            this.inviteFriendGroupBox = new System.Windows.Forms.GroupBox();
            this.addButton = new System.Windows.Forms.Button();
            this.friendNameTextBox = new System.Windows.Forms.TextBox();
            this.rps_btn = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.inviteFriendGroupBox.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.Location = new System.Drawing.Point(276, 211);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageTextBox.Location = new System.Drawing.Point(12, 214);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(258, 20);
            this.messageTextBox.TabIndex = 4;
            this.messageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageTextBox_KeyDown);
            // 
            // messageListBox
            // 
            this.messageListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageListBox.DisplayMember = "Text";
            this.messageListBox.FormattingEnabled = true;
            this.messageListBox.Location = new System.Drawing.Point(12, 11);
            this.messageListBox.Name = "messageListBox";
            this.messageListBox.Size = new System.Drawing.Size(258, 199);
            this.messageListBox.TabIndex = 5;
            this.messageListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListBox1_MouseDown);
            this.messageListBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MessageListBox_MouseMove);
            // 
            // userListBox
            // 
            this.userListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userListBox.DisplayMember = "Nickname";
            this.userListBox.Enabled = false;
            this.userListBox.FormattingEnabled = true;
            this.userListBox.Location = new System.Drawing.Point(276, 38);
            this.userListBox.Name = "userListBox";
            this.userListBox.Size = new System.Drawing.Size(75, 69);
            this.userListBox.TabIndex = 6;
            // 
            // peopleInChatLabel
            // 
            this.peopleInChatLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.peopleInChatLabel.Location = new System.Drawing.Point(271, 9);
            this.peopleInChatLabel.Name = "peopleInChatLabel";
            this.peopleInChatLabel.Size = new System.Drawing.Size(91, 23);
            this.peopleInChatLabel.TabIndex = 8;
            this.peopleInChatLabel.Text = " ";
            this.peopleInChatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // inviteFriendGroupBox
            // 
            this.inviteFriendGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inviteFriendGroupBox.Controls.Add(this.addButton);
            this.inviteFriendGroupBox.Controls.Add(this.friendNameTextBox);
            this.inviteFriendGroupBox.Location = new System.Drawing.Point(276, 113);
            this.inviteFriendGroupBox.Name = "inviteFriendGroupBox";
            this.inviteFriendGroupBox.Size = new System.Drawing.Size(75, 97);
            this.inviteFriendGroupBox.TabIndex = 9;
            this.inviteFriendGroupBox.TabStop = false;
            this.inviteFriendGroupBox.Text = "Invite Friend";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 55);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(63, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.InviteButton_Click);
            // 
            // friendNameTextBox
            // 
            this.friendNameTextBox.Location = new System.Drawing.Point(6, 29);
            this.friendNameTextBox.Name = "friendNameTextBox";
            this.friendNameTextBox.Size = new System.Drawing.Size(63, 20);
            this.friendNameTextBox.TabIndex = 0;
            this.friendNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FriendNameTextBox_KeyDown);
            // 
            // rps_btn
            // 
            this.rps_btn.Location = new System.Drawing.Point(276, 237);
            this.rps_btn.Name = "rps_btn";
            this.rps_btn.Size = new System.Drawing.Size(75, 23);
            this.rps_btn.TabIndex = 11;
            this.rps_btn.Text = "PlayRPS";
            this.rps_btn.UseVisualStyleBackColor = true;
            this.rps_btn.Visible = false;
            this.rps_btn.Click += new System.EventHandler(this.Rps_btn_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 237);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(363, 22);
            this.statusStrip.TabIndex = 10;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(101, 17);
            this.toolStripStatusLabel1.Text = "Nobody is writing";
            // 
            // timer
            // 
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 259);
            this.Controls.Add(this.rps_btn);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.inviteFriendGroupBox);
            this.Controls.Add(this.peopleInChatLabel);
            this.Controls.Add(this.userListBox);
            this.Controls.Add(this.messageListBox);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.sendButton);
            this.Name = "MessageForm";
            this.Text = "Message Box";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessageForm_Closing);
            this.inviteFriendGroupBox.ResumeLayout(false);
            this.inviteFriendGroupBox.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.ListBox messageListBox;
        private ListBox userListBox;
        private Label peopleInChatLabel;
        private GroupBox inviteFriendGroupBox;
        private Button addButton;
        private TextBox friendNameTextBox;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Timer timer;
        private Button rps_btn;
    }
}

