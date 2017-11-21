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
            this.SendButton = new System.Windows.Forms.Button();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.MessageListBox = new System.Windows.Forms.ListBox();
            this.UserListBox = new System.Windows.Forms.ListBox();
            this.PeopleInChatLabel = new System.Windows.Forms.Label();
            this.InviteFriendGroupBox = new System.Windows.Forms.GroupBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.FriendNameTextBox = new System.Windows.Forms.TextBox();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.rps_btn = new System.Windows.Forms.Button();
            this.InviteFriendGroupBox.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendButton.Location = new System.Drawing.Point(276, 211);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 3;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageTextBox.Location = new System.Drawing.Point(12, 214);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(258, 20);
            this.MessageTextBox.TabIndex = 4;
            this.MessageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageTextBox_KeyDown);
            // 
            // MessageListBox
            // 
            this.MessageListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageListBox.DisplayMember = "Text";
            this.MessageListBox.FormattingEnabled = true;
            this.MessageListBox.Location = new System.Drawing.Point(12, 11);
            this.MessageListBox.Name = "MessageListBox";
            this.MessageListBox.Size = new System.Drawing.Size(258, 199);
            this.MessageListBox.TabIndex = 5;
            this.MessageListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListBox1_MouseDown);
            this.MessageListBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MessageListBox_MouseMove);
            // 
            // UserListBox
            // 
            this.UserListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserListBox.DisplayMember = "Nickname";
            this.UserListBox.FormattingEnabled = true;
            this.UserListBox.Location = new System.Drawing.Point(276, 38);
            this.UserListBox.Name = "UserListBox";
            this.UserListBox.Size = new System.Drawing.Size(75, 69);
            this.UserListBox.TabIndex = 6;
            // 
            // PeopleInChatLabel
            // 
            this.PeopleInChatLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PeopleInChatLabel.Location = new System.Drawing.Point(271, 9);
            this.PeopleInChatLabel.Name = "PeopleInChatLabel";
            this.PeopleInChatLabel.Size = new System.Drawing.Size(91, 23);
            this.PeopleInChatLabel.TabIndex = 8;
            this.PeopleInChatLabel.Text = " ";
            this.PeopleInChatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InviteFriendGroupBox
            // 
            this.InviteFriendGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InviteFriendGroupBox.Controls.Add(this.rps_btn);
            this.InviteFriendGroupBox.Controls.Add(this.AddButton);
            this.InviteFriendGroupBox.Controls.Add(this.FriendNameTextBox);
            this.InviteFriendGroupBox.Location = new System.Drawing.Point(276, 113);
            this.InviteFriendGroupBox.Name = "InviteFriendGroupBox";
            this.InviteFriendGroupBox.Size = new System.Drawing.Size(75, 97);
            this.InviteFriendGroupBox.TabIndex = 9;
            this.InviteFriendGroupBox.TabStop = false;
            this.InviteFriendGroupBox.Text = "Invite Friend";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(6, 55);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(63, 23);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.InviteButton_Click);
            // 
            // FriendNameTextBox
            // 
            this.FriendNameTextBox.Location = new System.Drawing.Point(6, 29);
            this.FriendNameTextBox.Name = "FriendNameTextBox";
            this.FriendNameTextBox.Size = new System.Drawing.Size(63, 20);
            this.FriendNameTextBox.TabIndex = 0;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.StatusStrip.Location = new System.Drawing.Point(0, 237);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(363, 22);
            this.StatusStrip.TabIndex = 10;
            this.StatusStrip.Text = "statusStrip1";
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
            // rps_btn
            // 
            this.rps_btn.Location = new System.Drawing.Point(0, 74);
            this.rps_btn.Name = "rps_btn";
            this.rps_btn.Size = new System.Drawing.Size(75, 23);
            this.rps_btn.TabIndex = 11;
            this.rps_btn.Text = "PlayRPS";
            this.rps_btn.UseVisualStyleBackColor = true;
            this.rps_btn.Visible = false;
            this.rps_btn.Click += new System.EventHandler(this.rps_btn_Click);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 259);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.InviteFriendGroupBox);
            this.Controls.Add(this.PeopleInChatLabel);
            this.Controls.Add(this.UserListBox);
            this.Controls.Add(this.MessageListBox);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.SendButton);
            this.Name = "MessageForm";
            this.Text = "Message Box";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessageForm_Closing);
            this.InviteFriendGroupBox.ResumeLayout(false);
            this.InviteFriendGroupBox.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.ListBox MessageListBox;
        private ListBox UserListBox;
        private Label PeopleInChatLabel;
        private GroupBox InviteFriendGroupBox;
        private Button AddButton;
        private TextBox FriendNameTextBox;
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Timer timer;
        private Button rps_btn;
    }
}

