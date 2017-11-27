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
            this.lbAllGroups = new System.Windows.Forms.ListBox();
            this.lbGroupMembers = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnAddUser = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.onlineCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(49, 11);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(76, 20);
            this.txtName.TabIndex = 1;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtName_KeyDown);
            // 
            // BtnCreate
            // 
            this.BtnCreate.Location = new System.Drawing.Point(9, 44);
            this.BtnCreate.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(114, 20);
            this.BtnCreate.TabIndex = 2;
            this.BtnCreate.Text = "Create new group";
            this.BtnCreate.UseVisualStyleBackColor = true;
            this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // lbAllGroups
            // 
            this.lbAllGroups.DisplayMember = "Name";
            this.lbAllGroups.FormattingEnabled = true;
            this.lbAllGroups.Location = new System.Drawing.Point(223, 11);
            this.lbAllGroups.Margin = new System.Windows.Forms.Padding(2);
            this.lbAllGroups.Name = "lbAllGroups";
            this.lbAllGroups.Size = new System.Drawing.Size(188, 108);
            this.lbAllGroups.TabIndex = 4;
            this.lbAllGroups.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbAllGroups_SelectObject);
            // 
            // lbGroupMembers
            // 
            this.lbGroupMembers.DisplayMember = "Nickname";
            this.lbGroupMembers.FormattingEnabled = true;
            this.lbGroupMembers.Location = new System.Drawing.Point(223, 206);
            this.lbGroupMembers.Margin = new System.Windows.Forms.Padding(2);
            this.lbGroupMembers.Name = "lbGroupMembers";
            this.lbGroupMembers.Size = new System.Drawing.Size(187, 108);
            this.lbGroupMembers.TabIndex = 5;
            this.lbGroupMembers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbGroupMembers_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 206);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name";
            // 
            // BtnAddUser
            // 
            this.BtnAddUser.Location = new System.Drawing.Point(9, 240);
            this.BtnAddUser.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAddUser.Name = "BtnAddUser";
            this.BtnAddUser.Size = new System.Drawing.Size(114, 20);
            this.BtnAddUser.TabIndex = 9;
            this.BtnAddUser.Text = "Add User";
            this.BtnAddUser.UseVisualStyleBackColor = true;
            this.BtnAddUser.Click += new System.EventHandler(this.BtnAddUser_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(49, 206);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(76, 20);
            this.txtUserName.TabIndex = 10;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(335, 124);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 13;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // onlineCheckBox
            // 
            this.onlineCheckBox.AutoSize = true;
            this.onlineCheckBox.Location = new System.Drawing.Point(223, 184);
            this.onlineCheckBox.Name = "onlineCheckBox";
            this.onlineCheckBox.Size = new System.Drawing.Size(134, 17);
            this.onlineCheckBox.TabIndex = 14;
            this.onlineCheckBox.Text = "Show only online users";
            this.onlineCheckBox.UseVisualStyleBackColor = true;
            this.onlineCheckBox.CheckStateChanged += new System.EventHandler(this.OnlineCheckBox_CheckStateChanged);
            // 
            // GroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 349);
            this.Controls.Add(this.onlineCheckBox);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.BtnAddUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbGroupMembers);
            this.Controls.Add(this.lbAllGroups);
            this.Controls.Add(this.BtnCreate);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GroupForm";
            this.Text = "GroupForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button BtnCreate;
        private System.Windows.Forms.ListBox lbAllGroups;
        private System.Windows.Forms.ListBox lbGroupMembers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnAddUser;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.CheckBox onlineCheckBox;
    }
}