namespace PresentationTier
{
    partial class GroupForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.BtnCreate = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.lbAllGroups = new System.Windows.Forms.ListBox();
            this.lbGroupMembers = new System.Windows.Forms.ListBox();
            this.BntAllUsers = new System.Windows.Forms.Button();
            this.BtnOnlineUsers = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnAddUser = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.BtnDeleteUser = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(65, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 22);
            this.txtName.TabIndex = 1;
            // 
            // BtnCreate
            // 
            this.BtnCreate.Location = new System.Drawing.Point(12, 54);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(152, 25);
            this.BtnCreate.TabIndex = 2;
            this.BtnCreate.Text = "Create new group";
            this.BtnCreate.UseVisualStyleBackColor = true;
            this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(12, 88);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(152, 25);
            this.BtnDelete.TabIndex = 3;
            this.BtnDelete.Text = "Delete group";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // lbAllGroups
            // 
            this.lbAllGroups.FormattingEnabled = true;
            this.lbAllGroups.ItemHeight = 16;
            this.lbAllGroups.Location = new System.Drawing.Point(297, 13);
            this.lbAllGroups.Name = "lbAllGroups";
            this.lbAllGroups.Size = new System.Drawing.Size(250, 164);
            this.lbAllGroups.TabIndex = 4;
            this.lbAllGroups.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbAllGroups_SelectObject);
            // 
            // lbGroupMembers
            // 
            this.lbGroupMembers.FormattingEnabled = true;
            this.lbGroupMembers.ItemHeight = 16;
            this.lbGroupMembers.Location = new System.Drawing.Point(297, 254);
            this.lbGroupMembers.Name = "lbGroupMembers";
            this.lbGroupMembers.Size = new System.Drawing.Size(250, 164);
            this.lbGroupMembers.TabIndex = 5;
            // 
            // BntAllUsers
            // 
            this.BntAllUsers.Location = new System.Drawing.Point(297, 225);
            this.BntAllUsers.Name = "BntAllUsers";
            this.BntAllUsers.Size = new System.Drawing.Size(125, 23);
            this.BntAllUsers.TabIndex = 6;
            this.BntAllUsers.Text = "All users";
            this.BntAllUsers.UseVisualStyleBackColor = true;
            this.BntAllUsers.Click += new System.EventHandler(this.BntAllUsers_Click);
            // 
            // BtnOnlineUsers
            // 
            this.BtnOnlineUsers.Location = new System.Drawing.Point(428, 225);
            this.BtnOnlineUsers.Name = "BtnOnlineUsers";
            this.BtnOnlineUsers.Size = new System.Drawing.Size(119, 23);
            this.BtnOnlineUsers.TabIndex = 7;
            this.BtnOnlineUsers.Text = "Online users";
            this.BtnOnlineUsers.UseVisualStyleBackColor = true;
            this.BtnOnlineUsers.Click += new System.EventHandler(this.BtnOnlineUsers_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name";
            // 
            // BtnAddUser
            // 
            this.BtnAddUser.Location = new System.Drawing.Point(12, 295);
            this.BtnAddUser.Name = "BtnAddUser";
            this.BtnAddUser.Size = new System.Drawing.Size(152, 25);
            this.BtnAddUser.TabIndex = 9;
            this.BtnAddUser.Text = "Add User";
            this.BtnAddUser.UseVisualStyleBackColor = true;
            this.BtnAddUser.Click += new System.EventHandler(this.BtnAddUser_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(65, 254);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 22);
            this.txtUserName.TabIndex = 10;
            // 
            // BtnDeleteUser
            // 
            this.BtnDeleteUser.Location = new System.Drawing.Point(12, 324);
            this.BtnDeleteUser.Name = "BtnDeleteUser";
            this.BtnDeleteUser.Size = new System.Drawing.Size(152, 25);
            this.BtnDeleteUser.TabIndex = 11;
            this.BtnDeleteUser.Text = "Delete User";
            this.BtnDeleteUser.UseVisualStyleBackColor = true;
            this.BtnDeleteUser.Click += new System.EventHandler(this.BtnDeleteUser_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.Location = new System.Drawing.Point(16, 394);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(75, 23);
            this.BtnBack.TabIndex = 12;
            this.BtnBack.Text = "Back";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // GroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 430);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.BtnDeleteUser);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.BtnAddUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnOnlineUsers);
            this.Controls.Add(this.BntAllUsers);
            this.Controls.Add(this.lbGroupMembers);
            this.Controls.Add(this.lbAllGroups);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnCreate);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "GroupForm";
            this.Text = "GroupForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button BtnCreate;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.ListBox lbAllGroups;
        private System.Windows.Forms.ListBox lbGroupMembers;
        private System.Windows.Forms.Button BntAllUsers;
        private System.Windows.Forms.Button BtnOnlineUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnAddUser;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button BtnDeleteUser;
        private System.Windows.Forms.Button BtnBack;
    }
}