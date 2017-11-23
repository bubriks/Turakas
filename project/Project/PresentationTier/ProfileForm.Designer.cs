namespace PresentationTier
{
    partial class ProfileForm
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
            this.username_lbl = new System.Windows.Forms.Label();
            this.password_lbl = new System.Windows.Forms.Label();
            this.confirmPassword_lbl = new System.Windows.Forms.Label();
            this.email_lbl = new System.Windows.Forms.Label();
            this.nickname_lbl = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.nickname_txt = new System.Windows.Forms.TextBox();
            this.email_txt = new System.Windows.Forms.TextBox();
            this.confirmPassword_txt = new System.Windows.Forms.TextBox();
            this.password_txt = new System.Windows.Forms.TextBox();
            this.username_txt = new System.Windows.Forms.TextBox();
            this.friendsList_listvw = new System.Windows.Forms.ListView();
            this.usernameError_lbl = new System.Windows.Forms.Label();
            this.passwordError_lbl = new System.Windows.Forms.Label();
            this.confirmPasswordError_lbl = new System.Windows.Forms.Label();
            this.emailError_lbl = new System.Windows.Forms.Label();
            this.nicknameError_lbl = new System.Windows.Forms.Label();
            this.saveError_lbl = new System.Windows.Forms.Label();
            this.back_btn = new System.Windows.Forms.Button();
            this.deleteAccount_btn = new System.Windows.Forms.Button();
            this.deleteError_lbl = new System.Windows.Forms.Label();
            this.btnGroups = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // username_lbl
            // 
            this.username_lbl.AutoSize = true;
            this.username_lbl.Location = new System.Drawing.Point(17, 16);
            this.username_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.username_lbl.Name = "username_lbl";
            this.username_lbl.Size = new System.Drawing.Size(77, 17);
            this.username_lbl.TabIndex = 0;
            this.username_lbl.Text = "Username:";
            // 
            // password_lbl
            // 
            this.password_lbl.AutoSize = true;
            this.password_lbl.Location = new System.Drawing.Point(20, 62);
            this.password_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.password_lbl.Name = "password_lbl";
            this.password_lbl.Size = new System.Drawing.Size(73, 17);
            this.password_lbl.TabIndex = 1;
            this.password_lbl.Text = "Password:";
            // 
            // confirmPassword_lbl
            // 
            this.confirmPassword_lbl.AutoSize = true;
            this.confirmPassword_lbl.Location = new System.Drawing.Point(16, 114);
            this.confirmPassword_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.confirmPassword_lbl.Name = "confirmPassword_lbl";
            this.confirmPassword_lbl.Size = new System.Drawing.Size(121, 17);
            this.confirmPassword_lbl.TabIndex = 2;
            this.confirmPassword_lbl.Text = "ConfirmPassword:";
            this.confirmPassword_lbl.Visible = false;
            // 
            // email_lbl
            // 
            this.email_lbl.AutoSize = true;
            this.email_lbl.Location = new System.Drawing.Point(16, 160);
            this.email_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.email_lbl.Name = "email_lbl";
            this.email_lbl.Size = new System.Drawing.Size(46, 17);
            this.email_lbl.TabIndex = 3;
            this.email_lbl.Text = "Email:";
            // 
            // nickname_lbl
            // 
            this.nickname_lbl.AutoSize = true;
            this.nickname_lbl.Location = new System.Drawing.Point(20, 206);
            this.nickname_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nickname_lbl.Name = "nickname_lbl";
            this.nickname_lbl.Size = new System.Drawing.Size(74, 17);
            this.nickname_lbl.TabIndex = 4;
            this.nickname_lbl.Text = "Nickname:";
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(240, 386);
            this.save_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(100, 28);
            this.save_btn.TabIndex = 5;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // nickname_txt
            // 
            this.nickname_txt.Location = new System.Drawing.Point(147, 202);
            this.nickname_txt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nickname_txt.Name = "nickname_txt";
            this.nickname_txt.Size = new System.Drawing.Size(132, 22);
            this.nickname_txt.TabIndex = 6;
            // 
            // email_txt
            // 
            this.email_txt.Location = new System.Drawing.Point(147, 156);
            this.email_txt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.email_txt.Name = "email_txt";
            this.email_txt.Size = new System.Drawing.Size(132, 22);
            this.email_txt.TabIndex = 7;
            // 
            // confirmPassword_txt
            // 
            this.confirmPassword_txt.Location = new System.Drawing.Point(147, 111);
            this.confirmPassword_txt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.confirmPassword_txt.Name = "confirmPassword_txt";
            this.confirmPassword_txt.Size = new System.Drawing.Size(132, 22);
            this.confirmPassword_txt.TabIndex = 8;
            this.confirmPassword_txt.Visible = false;
            this.confirmPassword_txt.TextChanged += new System.EventHandler(this.confirmPassword_txt_TextChanged);
            // 
            // password_txt
            // 
            this.password_txt.Location = new System.Drawing.Point(147, 58);
            this.password_txt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.password_txt.Name = "password_txt";
            this.password_txt.Size = new System.Drawing.Size(132, 22);
            this.password_txt.TabIndex = 9;
            this.password_txt.TextChanged += new System.EventHandler(this.password_txt_TextChanged);
            // 
            // username_txt
            // 
            this.username_txt.Location = new System.Drawing.Point(147, 12);
            this.username_txt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.username_txt.Name = "username_txt";
            this.username_txt.Size = new System.Drawing.Size(132, 22);
            this.username_txt.TabIndex = 10;
            // 
            // friendsList_listvw
            // 
            this.friendsList_listvw.Location = new System.Drawing.Point(391, 16);
            this.friendsList_listvw.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.friendsList_listvw.Name = "friendsList_listvw";
            this.friendsList_listvw.Size = new System.Drawing.Size(160, 118);
            this.friendsList_listvw.TabIndex = 11;
            this.friendsList_listvw.UseCompatibleStateImageBehavior = false;
            // 
            // usernameError_lbl
            // 
            this.usernameError_lbl.AutoSize = true;
            this.usernameError_lbl.Location = new System.Drawing.Point(143, 32);
            this.usernameError_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameError_lbl.Name = "usernameError_lbl";
            this.usernameError_lbl.Size = new System.Drawing.Size(125, 17);
            this.usernameError_lbl.TabIndex = 12;
            this.usernameError_lbl.Text = "usernameError_lbl";
            this.usernameError_lbl.Visible = false;
            // 
            // passwordError_lbl
            // 
            this.passwordError_lbl.AutoSize = true;
            this.passwordError_lbl.Location = new System.Drawing.Point(147, 87);
            this.passwordError_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordError_lbl.Name = "passwordError_lbl";
            this.passwordError_lbl.Size = new System.Drawing.Size(122, 17);
            this.passwordError_lbl.TabIndex = 13;
            this.passwordError_lbl.Text = "passwordError_lbl";
            this.passwordError_lbl.Visible = false;
            // 
            // confirmPasswordError_lbl
            // 
            this.confirmPasswordError_lbl.AutoSize = true;
            this.confirmPasswordError_lbl.Location = new System.Drawing.Point(147, 139);
            this.confirmPasswordError_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.confirmPasswordError_lbl.Name = "confirmPasswordError_lbl";
            this.confirmPasswordError_lbl.Size = new System.Drawing.Size(169, 17);
            this.confirmPasswordError_lbl.TabIndex = 14;
            this.confirmPasswordError_lbl.Text = "confirmPasswordError_lbl";
            this.confirmPasswordError_lbl.Visible = false;
            // 
            // emailError_lbl
            // 
            this.emailError_lbl.AutoSize = true;
            this.emailError_lbl.Location = new System.Drawing.Point(147, 185);
            this.emailError_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailError_lbl.Name = "emailError_lbl";
            this.emailError_lbl.Size = new System.Drawing.Size(95, 17);
            this.emailError_lbl.TabIndex = 15;
            this.emailError_lbl.Text = "emailError_lbl";
            this.emailError_lbl.Visible = false;
            // 
            // nicknameError_lbl
            // 
            this.nicknameError_lbl.AutoSize = true;
            this.nicknameError_lbl.Location = new System.Drawing.Point(151, 235);
            this.nicknameError_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nicknameError_lbl.Name = "nicknameError_lbl";
            this.nicknameError_lbl.Size = new System.Drawing.Size(122, 17);
            this.nicknameError_lbl.TabIndex = 16;
            this.nicknameError_lbl.Text = "nicknameError_lbl";
            this.nicknameError_lbl.Visible = false;
            // 
            // saveError_lbl
            // 
            this.saveError_lbl.AutoSize = true;
            this.saveError_lbl.Location = new System.Drawing.Point(240, 363);
            this.saveError_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.saveError_lbl.Name = "saveError_lbl";
            this.saveError_lbl.Size = new System.Drawing.Size(92, 17);
            this.saveError_lbl.TabIndex = 17;
            this.saveError_lbl.Text = "saveError_lbl";
            this.saveError_lbl.Visible = false;
            // 
            // back_btn
            // 
            this.back_btn.Location = new System.Drawing.Point(17, 386);
            this.back_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(100, 28);
            this.back_btn.TabIndex = 18;
            this.back_btn.Text = "Back";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // deleteAccount_btn
            // 
            this.deleteAccount_btn.Location = new System.Drawing.Point(452, 386);
            this.deleteAccount_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteAccount_btn.Name = "deleteAccount_btn";
            this.deleteAccount_btn.Size = new System.Drawing.Size(100, 28);
            this.deleteAccount_btn.TabIndex = 19;
            this.deleteAccount_btn.Text = "Delete Account";
            this.deleteAccount_btn.UseVisualStyleBackColor = true;
            this.deleteAccount_btn.Click += new System.EventHandler(this.deleteAccount_btn_Click);
            // 
            // deleteError_lbl
            // 
            this.deleteError_lbl.AutoSize = true;
            this.deleteError_lbl.Location = new System.Drawing.Point(448, 364);
            this.deleteError_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.deleteError_lbl.Name = "deleteError_lbl";
            this.deleteError_lbl.Size = new System.Drawing.Size(101, 17);
            this.deleteError_lbl.TabIndex = 20;
            this.deleteError_lbl.Text = "deleteError_lbl";
            this.deleteError_lbl.Visible = false;
            // 
            // btnGroups
            // 
            this.btnGroups.Location = new System.Drawing.Point(449, 270);
            this.btnGroups.Margin = new System.Windows.Forms.Padding(4);
            this.btnGroups.Name = "btnGroups";
            this.btnGroups.Size = new System.Drawing.Size(100, 28);
            this.btnGroups.TabIndex = 21;
            this.btnGroups.Text = "Groups";
            this.btnGroups.UseVisualStyleBackColor = true;
            this.btnGroups.Click += new System.EventHandler(this.btnGroups_Click);
            // 
            // ProfileForm
            // 
            this.AcceptButton = this.save_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 430);
            this.Controls.Add(this.btnGroups);
            this.Controls.Add(this.deleteError_lbl);
            this.Controls.Add(this.deleteAccount_btn);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.saveError_lbl);
            this.Controls.Add(this.nicknameError_lbl);
            this.Controls.Add(this.emailError_lbl);
            this.Controls.Add(this.confirmPasswordError_lbl);
            this.Controls.Add(this.passwordError_lbl);
            this.Controls.Add(this.usernameError_lbl);
            this.Controls.Add(this.friendsList_listvw);
            this.Controls.Add(this.username_txt);
            this.Controls.Add(this.password_txt);
            this.Controls.Add(this.confirmPassword_txt);
            this.Controls.Add(this.email_txt);
            this.Controls.Add(this.nickname_txt);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.nickname_lbl);
            this.Controls.Add(this.email_lbl);
            this.Controls.Add(this.confirmPassword_lbl);
            this.Controls.Add(this.password_lbl);
            this.Controls.Add(this.username_lbl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProfileForm";
            this.Text = "ProfileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label username_lbl;
        private System.Windows.Forms.Label password_lbl;
        private System.Windows.Forms.Label confirmPassword_lbl;
        private System.Windows.Forms.Label email_lbl;
        private System.Windows.Forms.Label nickname_lbl;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.TextBox nickname_txt;
        private System.Windows.Forms.TextBox email_txt;
        private System.Windows.Forms.TextBox confirmPassword_txt;
        private System.Windows.Forms.TextBox password_txt;
        private System.Windows.Forms.TextBox username_txt;
        private System.Windows.Forms.ListView friendsList_listvw;
        private System.Windows.Forms.Label usernameError_lbl;
        private System.Windows.Forms.Label passwordError_lbl;
        private System.Windows.Forms.Label confirmPasswordError_lbl;
        private System.Windows.Forms.Label emailError_lbl;
        private System.Windows.Forms.Label nicknameError_lbl;
        private System.Windows.Forms.Label saveError_lbl;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Button deleteAccount_btn;
        private System.Windows.Forms.Label deleteError_lbl;
        private System.Windows.Forms.Button btnGroups;
    }
}