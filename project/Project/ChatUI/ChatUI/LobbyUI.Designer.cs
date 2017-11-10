namespace ChatUI
{
    partial class LobbyUI
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
            this.lbAllChats = new System.Windows.Forms.ListBox();
            this.btnPublicChats = new System.Windows.Forms.Button();
            this.btnGroupChats = new System.Windows.Forms.Button();
            this.btnPrivateChats = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNCName = new System.Windows.Forms.TextBox();
            this.txtNCPeopleLimit = new System.Windows.Forms.TextBox();
            this.btnNewGroupChat = new System.Windows.Forms.Button();
            this.btnNewPrivateChat = new System.Windows.Forms.Button();
            this.txtNotifications = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbAllChats
            // 
            this.lbAllChats.FormattingEnabled = true;
            this.lbAllChats.ItemHeight = 16;
            this.lbAllChats.Location = new System.Drawing.Point(50, 100);
            this.lbAllChats.Name = "lbAllChats";
            this.lbAllChats.Size = new System.Drawing.Size(450, 420);
            this.lbAllChats.TabIndex = 0;
            // 
            // btnPublicChats
            // 
            this.btnPublicChats.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublicChats.Location = new System.Drawing.Point(50, 75);
            this.btnPublicChats.Name = "btnPublicChats";
            this.btnPublicChats.Size = new System.Drawing.Size(150, 25);
            this.btnPublicChats.TabIndex = 1;
            this.btnPublicChats.Text = "Public";
            this.btnPublicChats.UseVisualStyleBackColor = true;
            this.btnPublicChats.Click += new System.EventHandler(this.btnPublicChats_Click);
            // 
            // btnGroupChats
            // 
            this.btnGroupChats.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroupChats.Location = new System.Drawing.Point(200, 75);
            this.btnGroupChats.Name = "btnGroupChats";
            this.btnGroupChats.Size = new System.Drawing.Size(150, 25);
            this.btnGroupChats.TabIndex = 2;
            this.btnGroupChats.Text = "Group";
            this.btnGroupChats.UseVisualStyleBackColor = true;
            this.btnGroupChats.Click += new System.EventHandler(this.btnGroupChats_Click);
            // 
            // btnPrivateChats
            // 
            this.btnPrivateChats.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrivateChats.Location = new System.Drawing.Point(350, 75);
            this.btnPrivateChats.Name = "btnPrivateChats";
            this.btnPrivateChats.Size = new System.Drawing.Size(150, 25);
            this.btnPrivateChats.TabIndex = 3;
            this.btnPrivateChats.Text = "Private";
            this.btnPrivateChats.UseVisualStyleBackColor = true;
            this.btnPrivateChats.Click += new System.EventHandler(this.btnPrivateChats_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoin.Location = new System.Drawing.Point(50, 526);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(150, 67);
            this.btnJoin.TabIndex = 5;
            this.btnJoin.Text = "Join";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(566, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Create new chatroom";
            // 
            // txtNCName
            // 
            this.txtNCName.Location = new System.Drawing.Point(570, 130);
            this.txtNCName.Name = "txtNCName";
            this.txtNCName.Size = new System.Drawing.Size(165, 22);
            this.txtNCName.TabIndex = 7;
            this.txtNCName.Text = "Chat name";
            // 
            // txtNCPeopleLimit
            // 
            this.txtNCPeopleLimit.Location = new System.Drawing.Point(570, 165);
            this.txtNCPeopleLimit.Name = "txtNCPeopleLimit";
            this.txtNCPeopleLimit.Size = new System.Drawing.Size(165, 22);
            this.txtNCPeopleLimit.TabIndex = 8;
            this.txtNCPeopleLimit.Text = "Max people";
            // 
            // btnNewGroupChat
            // 
            this.btnNewGroupChat.Location = new System.Drawing.Point(570, 200);
            this.btnNewGroupChat.Name = "btnNewGroupChat";
            this.btnNewGroupChat.Size = new System.Drawing.Size(80, 25);
            this.btnNewGroupChat.TabIndex = 9;
            this.btnNewGroupChat.Text = "Group";
            this.btnNewGroupChat.UseVisualStyleBackColor = true;
            this.btnNewGroupChat.Click += new System.EventHandler(this.btnNewGroupChat_Click);
            // 
            // btnNewPrivateChat
            // 
            this.btnNewPrivateChat.Location = new System.Drawing.Point(655, 200);
            this.btnNewPrivateChat.Name = "btnNewPrivateChat";
            this.btnNewPrivateChat.Size = new System.Drawing.Size(80, 25);
            this.btnNewPrivateChat.TabIndex = 10;
            this.btnNewPrivateChat.Text = "Private";
            this.btnNewPrivateChat.UseVisualStyleBackColor = true;
            this.btnNewPrivateChat.Click += new System.EventHandler(this.btnNewPrivateChat_Click);
            // 
            // txtNotifications
            // 
            this.txtNotifications.Location = new System.Drawing.Point(570, 430);
            this.txtNotifications.Multiline = true;
            this.txtNotifications.Name = "txtNotifications";
            this.txtNotifications.Size = new System.Drawing.Size(165, 164);
            this.txtNotifications.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(566, 406);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Notifications";
            // 
            // LobbyUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 653);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNotifications);
            this.Controls.Add(this.btnNewPrivateChat);
            this.Controls.Add(this.btnNewGroupChat);
            this.Controls.Add(this.txtNCPeopleLimit);
            this.Controls.Add(this.txtNCName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.btnPrivateChats);
            this.Controls.Add(this.btnGroupChats);
            this.Controls.Add(this.btnPublicChats);
            this.Controls.Add(this.lbAllChats);
            this.Name = "LobbyUI";
            this.Text = "LobbyUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbAllChats;
        private System.Windows.Forms.Button btnPublicChats;
        private System.Windows.Forms.Button btnGroupChats;
        private System.Windows.Forms.Button btnPrivateChats;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNCName;
        private System.Windows.Forms.TextBox txtNCPeopleLimit;
        private System.Windows.Forms.Button btnNewGroupChat;
        private System.Windows.Forms.Button btnNewPrivateChat;
        private System.Windows.Forms.TextBox txtNotifications;
        private System.Windows.Forms.Label label2;
    }
}