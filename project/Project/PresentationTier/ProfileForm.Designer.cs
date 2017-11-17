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
            this.SuspendLayout();
            // 
            // username_lbl
            // 
            this.username_lbl.AutoSize = true;
            this.username_lbl.Location = new System.Drawing.Point(13, 13);
            this.username_lbl.Name = "username_lbl";
            this.username_lbl.Size = new System.Drawing.Size(58, 13);
            this.username_lbl.TabIndex = 0;
            this.username_lbl.Text = "Username:";
            // 
            // password_lbl
            // 
            this.password_lbl.AutoSize = true;
            this.password_lbl.Location = new System.Drawing.Point(16, 42);
            this.password_lbl.Name = "password_lbl";
            this.password_lbl.Size = new System.Drawing.Size(56, 13);
            this.password_lbl.TabIndex = 1;
            this.password_lbl.Text = "Password:";
            // 
            // confirmPassword_lbl
            // 
            this.confirmPassword_lbl.AutoSize = true;
            this.confirmPassword_lbl.Location = new System.Drawing.Point(13, 73);
            this.confirmPassword_lbl.Name = "confirmPassword_lbl";
            this.confirmPassword_lbl.Size = new System.Drawing.Size(91, 13);
            this.confirmPassword_lbl.TabIndex = 2;
            this.confirmPassword_lbl.Text = "ConfirmPassword:";
            this.confirmPassword_lbl.Visible = false;
            // 
            // email_lbl
            // 
            this.email_lbl.AutoSize = true;
            this.email_lbl.Location = new System.Drawing.Point(13, 106);
            this.email_lbl.Name = "email_lbl";
            this.email_lbl.Size = new System.Drawing.Size(35, 13);
            this.email_lbl.TabIndex = 3;
            this.email_lbl.Text = "Email:";
            // 
            // nickname_lbl
            // 
            this.nickname_lbl.AutoSize = true;
            this.nickname_lbl.Location = new System.Drawing.Point(16, 145);
            this.nickname_lbl.Name = "nickname_lbl";
            this.nickname_lbl.Size = new System.Drawing.Size(58, 13);
            this.nickname_lbl.TabIndex = 4;
            this.nickname_lbl.Text = "Nickname:";
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(176, 286);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 5;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // nickname_txt
            // 
            this.nickname_txt.Location = new System.Drawing.Point(110, 142);
            this.nickname_txt.Name = "nickname_txt";
            this.nickname_txt.Size = new System.Drawing.Size(100, 20);
            this.nickname_txt.TabIndex = 6;
            this.nickname_txt.TextChanged += new System.EventHandler(this.nickname_txt_TextChanged);
            // 
            // email_txt
            // 
            this.email_txt.Location = new System.Drawing.Point(110, 103);
            this.email_txt.Name = "email_txt";
            this.email_txt.Size = new System.Drawing.Size(100, 20);
            this.email_txt.TabIndex = 7;
            this.email_txt.TextChanged += new System.EventHandler(this.email_txt_TextChanged);
            // 
            // confirmPassword_txt
            // 
            this.confirmPassword_txt.Location = new System.Drawing.Point(110, 73);
            this.confirmPassword_txt.Name = "confirmPassword_txt";
            this.confirmPassword_txt.Size = new System.Drawing.Size(100, 20);
            this.confirmPassword_txt.TabIndex = 8;
            this.confirmPassword_txt.Visible = false;
            this.confirmPassword_txt.TextChanged += new System.EventHandler(this.confirmPassword_txt_TextChanged);
            // 
            // password_txt
            // 
            this.password_txt.Location = new System.Drawing.Point(110, 39);
            this.password_txt.Name = "password_txt";
            this.password_txt.Size = new System.Drawing.Size(100, 20);
            this.password_txt.TabIndex = 9;
            this.password_txt.TextChanged += new System.EventHandler(this.password_txt_TextChanged);
            // 
            // username_txt
            // 
            this.username_txt.Location = new System.Drawing.Point(110, 10);
            this.username_txt.Name = "username_txt";
            this.username_txt.Size = new System.Drawing.Size(100, 20);
            this.username_txt.TabIndex = 10;
            this.username_txt.TextChanged += new System.EventHandler(this.username_txt_TextChanged);
            // 
            // friendsList_listvw
            // 
            this.friendsList_listvw.Location = new System.Drawing.Point(293, 13);
            this.friendsList_listvw.Name = "friendsList_listvw";
            this.friendsList_listvw.Size = new System.Drawing.Size(121, 97);
            this.friendsList_listvw.TabIndex = 11;
            this.friendsList_listvw.UseCompatibleStateImageBehavior = false;
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 349);
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
    }
}