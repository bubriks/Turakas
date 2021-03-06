﻿namespace PresentationTier
{
    partial class SignIn_SignUp_ForgotDetailsForm
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
            this.usernameSignIn_lbl = new System.Windows.Forms.Label();
            this.passwordSignIn_lbl = new System.Windows.Forms.Label();
            this.usernameSignIn_txt = new System.Windows.Forms.TextBox();
            this.passwordSignIn_txt = new System.Windows.Forms.TextBox();
            this.signIn_btn = new System.Windows.Forms.Button();
            this.signUp_btn = new System.Windows.Forms.Button();
            this.SignUp_grp = new System.Windows.Forms.GroupBox();
            this.registerError_lbl = new System.Windows.Forms.Label();
            this.nicknameSignUpError_lbl = new System.Windows.Forms.Label();
            this.emailSignUpError_lbl = new System.Windows.Forms.Label();
            this.usernameSignUpError_lbl = new System.Windows.Forms.Label();
            this.register_btn = new System.Windows.Forms.Button();
            this.nicknameSignUp_txt = new System.Windows.Forms.TextBox();
            this.emailSignUp_txt = new System.Windows.Forms.TextBox();
            this.usernameSignUp_txt = new System.Windows.Forms.TextBox();
            this.nicknameSignUp_lbl = new System.Windows.Forms.Label();
            this.emailSignUp_lbl = new System.Windows.Forms.Label();
            this.usernameSignUp_lbl = new System.Windows.Forms.Label();
            this.forgotDetails_lbl = new System.Windows.Forms.Label();
            this.or_lbl = new System.Windows.Forms.Label();
            this.SignIn_grp = new System.Windows.Forms.GroupBox();
            this.signInError_lbl = new System.Windows.Forms.Label();
            this.ForgotDetails_grp = new System.Windows.Forms.GroupBox();
            this.emailForgotError_lbl = new System.Windows.Forms.Label();
            this.emailForgot_txt = new System.Windows.Forms.TextBox();
            this.sendForgot_btn = new System.Windows.Forms.Button();
            this.emailForgot_lbl = new System.Windows.Forms.Label();
            this.SignUp_grp.SuspendLayout();
            this.SignIn_grp.SuspendLayout();
            this.ForgotDetails_grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameSignIn_lbl
            // 
            this.usernameSignIn_lbl.AutoSize = true;
            this.usernameSignIn_lbl.Location = new System.Drawing.Point(3, 14);
            this.usernameSignIn_lbl.Name = "usernameSignIn_lbl";
            this.usernameSignIn_lbl.Size = new System.Drawing.Size(58, 13);
            this.usernameSignIn_lbl.TabIndex = 0;
            this.usernameSignIn_lbl.Text = "Username:";
            // 
            // passwordSignIn_lbl
            // 
            this.passwordSignIn_lbl.AutoSize = true;
            this.passwordSignIn_lbl.Location = new System.Drawing.Point(6, 38);
            this.passwordSignIn_lbl.Name = "passwordSignIn_lbl";
            this.passwordSignIn_lbl.Size = new System.Drawing.Size(56, 13);
            this.passwordSignIn_lbl.TabIndex = 1;
            this.passwordSignIn_lbl.Text = "Password:";
            // 
            // usernameSignIn_txt
            // 
            this.usernameSignIn_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameSignIn_txt.Location = new System.Drawing.Point(62, 14);
            this.usernameSignIn_txt.Name = "usernameSignIn_txt";
            this.usernameSignIn_txt.Size = new System.Drawing.Size(155, 20);
            this.usernameSignIn_txt.TabIndex = 2;
            // 
            // passwordSignIn_txt
            // 
            this.passwordSignIn_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordSignIn_txt.Location = new System.Drawing.Point(62, 35);
            this.passwordSignIn_txt.Name = "passwordSignIn_txt";
            this.passwordSignIn_txt.Size = new System.Drawing.Size(155, 20);
            this.passwordSignIn_txt.TabIndex = 3;
            // 
            // signIn_btn
            // 
            this.signIn_btn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.signIn_btn.Location = new System.Drawing.Point(6, 107);
            this.signIn_btn.Name = "signIn_btn";
            this.signIn_btn.Size = new System.Drawing.Size(85, 23);
            this.signIn_btn.TabIndex = 4;
            this.signIn_btn.Text = "Sign In";
            this.signIn_btn.UseVisualStyleBackColor = true;
            this.signIn_btn.Click += new System.EventHandler(this.SignIn_btn_Click);
            // 
            // signUp_btn
            // 
            this.signUp_btn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.signUp_btn.Location = new System.Drawing.Point(132, 109);
            this.signUp_btn.Name = "signUp_btn";
            this.signUp_btn.Size = new System.Drawing.Size(85, 23);
            this.signUp_btn.TabIndex = 5;
            this.signUp_btn.Text = "Sign Up";
            this.signUp_btn.UseVisualStyleBackColor = true;
            this.signUp_btn.Click += new System.EventHandler(this.SignUp_btn_Click);
            // 
            // SignUp_grp
            // 
            this.SignUp_grp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SignUp_grp.Controls.Add(this.registerError_lbl);
            this.SignUp_grp.Controls.Add(this.nicknameSignUpError_lbl);
            this.SignUp_grp.Controls.Add(this.emailSignUpError_lbl);
            this.SignUp_grp.Controls.Add(this.usernameSignUpError_lbl);
            this.SignUp_grp.Controls.Add(this.register_btn);
            this.SignUp_grp.Controls.Add(this.nicknameSignUp_txt);
            this.SignUp_grp.Controls.Add(this.emailSignUp_txt);
            this.SignUp_grp.Controls.Add(this.usernameSignUp_txt);
            this.SignUp_grp.Controls.Add(this.nicknameSignUp_lbl);
            this.SignUp_grp.Controls.Add(this.emailSignUp_lbl);
            this.SignUp_grp.Controls.Add(this.usernameSignUp_lbl);
            this.SignUp_grp.Location = new System.Drawing.Point(240, 12);
            this.SignUp_grp.Name = "SignUp_grp";
            this.SignUp_grp.Size = new System.Drawing.Size(203, 238);
            this.SignUp_grp.TabIndex = 6;
            this.SignUp_grp.TabStop = false;
            this.SignUp_grp.Visible = false;
            // 
            // registerError_lbl
            // 
            this.registerError_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.registerError_lbl.AutoSize = true;
            this.registerError_lbl.Location = new System.Drawing.Point(79, 176);
            this.registerError_lbl.Name = "registerError_lbl";
            this.registerError_lbl.Size = new System.Drawing.Size(79, 13);
            this.registerError_lbl.TabIndex = 18;
            this.registerError_lbl.Text = "registerError_lbl";
            this.registerError_lbl.Visible = false;
            // 
            // nicknameSignUpError_lbl
            // 
            this.nicknameSignUpError_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nicknameSignUpError_lbl.AutoSize = true;
            this.nicknameSignUpError_lbl.Location = new System.Drawing.Point(79, 114);
            this.nicknameSignUpError_lbl.Name = "nicknameSignUpError_lbl";
            this.nicknameSignUpError_lbl.Size = new System.Drawing.Size(126, 13);
            this.nicknameSignUpError_lbl.TabIndex = 17;
            this.nicknameSignUpError_lbl.Text = "nicknameSignUpError_lbl";
            this.nicknameSignUpError_lbl.Visible = false;
            // 
            // emailSignUpError_lbl
            // 
            this.emailSignUpError_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailSignUpError_lbl.AutoSize = true;
            this.emailSignUpError_lbl.Location = new System.Drawing.Point(82, 77);
            this.emailSignUpError_lbl.Name = "emailSignUpError_lbl";
            this.emailSignUpError_lbl.Size = new System.Drawing.Size(104, 13);
            this.emailSignUpError_lbl.TabIndex = 16;
            this.emailSignUpError_lbl.Text = "emailSignUpError_lbl";
            this.emailSignUpError_lbl.Visible = false;
            // 
            // usernameSignUpError_lbl
            // 
            this.usernameSignUpError_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameSignUpError_lbl.AutoSize = true;
            this.usernameSignUpError_lbl.Location = new System.Drawing.Point(79, 33);
            this.usernameSignUpError_lbl.Name = "usernameSignUpError_lbl";
            this.usernameSignUpError_lbl.Size = new System.Drawing.Size(126, 13);
            this.usernameSignUpError_lbl.TabIndex = 14;
            this.usernameSignUpError_lbl.Text = "usernameSignUpError_lbl";
            this.usernameSignUpError_lbl.Visible = false;
            // 
            // register_btn
            // 
            this.register_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.register_btn.Location = new System.Drawing.Point(79, 196);
            this.register_btn.Name = "register_btn";
            this.register_btn.Size = new System.Drawing.Size(71, 23);
            this.register_btn.TabIndex = 13;
            this.register_btn.Text = "Register";
            this.register_btn.UseVisualStyleBackColor = true;
            this.register_btn.Click += new System.EventHandler(this.Register_btn_Click);
            // 
            // nicknameSignUp_txt
            // 
            this.nicknameSignUp_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nicknameSignUp_txt.Location = new System.Drawing.Point(79, 94);
            this.nicknameSignUp_txt.Name = "nicknameSignUp_txt";
            this.nicknameSignUp_txt.Size = new System.Drawing.Size(96, 20);
            this.nicknameSignUp_txt.TabIndex = 12;
            // 
            // emailSignUp_txt
            // 
            this.emailSignUp_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailSignUp_txt.Location = new System.Drawing.Point(79, 61);
            this.emailSignUp_txt.Name = "emailSignUp_txt";
            this.emailSignUp_txt.Size = new System.Drawing.Size(96, 20);
            this.emailSignUp_txt.TabIndex = 11;
            // 
            // usernameSignUp_txt
            // 
            this.usernameSignUp_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameSignUp_txt.Location = new System.Drawing.Point(79, 15);
            this.usernameSignUp_txt.Name = "usernameSignUp_txt";
            this.usernameSignUp_txt.Size = new System.Drawing.Size(96, 20);
            this.usernameSignUp_txt.TabIndex = 9;
            // 
            // nicknameSignUp_lbl
            // 
            this.nicknameSignUp_lbl.AutoSize = true;
            this.nicknameSignUp_lbl.Location = new System.Drawing.Point(20, 97);
            this.nicknameSignUp_lbl.Name = "nicknameSignUp_lbl";
            this.nicknameSignUp_lbl.Size = new System.Drawing.Size(58, 13);
            this.nicknameSignUp_lbl.TabIndex = 9;
            this.nicknameSignUp_lbl.Text = "Nickname:";
            // 
            // emailSignUp_lbl
            // 
            this.emailSignUp_lbl.AutoSize = true;
            this.emailSignUp_lbl.Location = new System.Drawing.Point(17, 64);
            this.emailSignUp_lbl.Name = "emailSignUp_lbl";
            this.emailSignUp_lbl.Size = new System.Drawing.Size(35, 13);
            this.emailSignUp_lbl.TabIndex = 8;
            this.emailSignUp_lbl.Text = "Email:";
            // 
            // usernameSignUp_lbl
            // 
            this.usernameSignUp_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameSignUp_lbl.AutoSize = true;
            this.usernameSignUp_lbl.Location = new System.Drawing.Point(15, 18);
            this.usernameSignUp_lbl.Name = "usernameSignUp_lbl";
            this.usernameSignUp_lbl.Size = new System.Drawing.Size(58, 13);
            this.usernameSignUp_lbl.TabIndex = 1;
            this.usernameSignUp_lbl.Text = "Username:";
            // 
            // forgotDetails_lbl
            // 
            this.forgotDetails_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.forgotDetails_lbl.AutoSize = true;
            this.forgotDetails_lbl.Location = new System.Drawing.Point(108, 58);
            this.forgotDetails_lbl.Name = "forgotDetails_lbl";
            this.forgotDetails_lbl.Size = new System.Drawing.Size(76, 13);
            this.forgotDetails_lbl.TabIndex = 7;
            this.forgotDetails_lbl.Text = "Forgot details?";
            this.forgotDetails_lbl.Click += new System.EventHandler(this.ForgotDetails_lbl_Click);
            // 
            // or_lbl
            // 
            this.or_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.or_lbl.AutoSize = true;
            this.or_lbl.Location = new System.Drawing.Point(108, 91);
            this.or_lbl.Name = "or_lbl";
            this.or_lbl.Size = new System.Drawing.Size(18, 13);
            this.or_lbl.TabIndex = 8;
            this.or_lbl.Text = "Or";
            // 
            // SignIn_grp
            // 
            this.SignIn_grp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SignIn_grp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SignIn_grp.Controls.Add(this.signInError_lbl);
            this.SignIn_grp.Controls.Add(this.usernameSignIn_lbl);
            this.SignIn_grp.Controls.Add(this.or_lbl);
            this.SignIn_grp.Controls.Add(this.passwordSignIn_lbl);
            this.SignIn_grp.Controls.Add(this.forgotDetails_lbl);
            this.SignIn_grp.Controls.Add(this.signUp_btn);
            this.SignIn_grp.Controls.Add(this.usernameSignIn_txt);
            this.SignIn_grp.Controls.Add(this.signIn_btn);
            this.SignIn_grp.Controls.Add(this.passwordSignIn_txt);
            this.SignIn_grp.Location = new System.Drawing.Point(11, 12);
            this.SignIn_grp.Name = "SignIn_grp";
            this.SignIn_grp.Size = new System.Drawing.Size(223, 141);
            this.SignIn_grp.TabIndex = 9;
            this.SignIn_grp.TabStop = false;
            // 
            // signInError_lbl
            // 
            this.signInError_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signInError_lbl.AutoSize = true;
            this.signInError_lbl.Location = new System.Drawing.Point(45, 73);
            this.signInError_lbl.Name = "signInError_lbl";
            this.signInError_lbl.Size = new System.Drawing.Size(75, 13);
            this.signInError_lbl.TabIndex = 9;
            this.signInError_lbl.Text = "SignInError_lbl";
            this.signInError_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.signInError_lbl.Visible = false;
            // 
            // ForgotDetails_grp
            // 
            this.ForgotDetails_grp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ForgotDetails_grp.Controls.Add(this.emailForgotError_lbl);
            this.ForgotDetails_grp.Controls.Add(this.emailForgot_txt);
            this.ForgotDetails_grp.Controls.Add(this.sendForgot_btn);
            this.ForgotDetails_grp.Controls.Add(this.emailForgot_lbl);
            this.ForgotDetails_grp.Location = new System.Drawing.Point(11, 159);
            this.ForgotDetails_grp.Name = "ForgotDetails_grp";
            this.ForgotDetails_grp.Size = new System.Drawing.Size(223, 91);
            this.ForgotDetails_grp.TabIndex = 10;
            this.ForgotDetails_grp.TabStop = false;
            this.ForgotDetails_grp.Visible = false;
            // 
            // emailForgotError_lbl
            // 
            this.emailForgotError_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailForgotError_lbl.AutoSize = true;
            this.emailForgotError_lbl.Location = new System.Drawing.Point(6, 39);
            this.emailForgotError_lbl.Name = "emailForgotError_lbl";
            this.emailForgotError_lbl.Size = new System.Drawing.Size(99, 13);
            this.emailForgotError_lbl.TabIndex = 4;
            this.emailForgotError_lbl.Text = "emailForgotError_lbl";
            this.emailForgotError_lbl.Visible = false;
            // 
            // emailForgot_txt
            // 
            this.emailForgot_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailForgot_txt.Location = new System.Drawing.Point(47, 16);
            this.emailForgot_txt.Name = "emailForgot_txt";
            this.emailForgot_txt.Size = new System.Drawing.Size(170, 20);
            this.emailForgot_txt.TabIndex = 2;
            // 
            // sendForgot_btn
            // 
            this.sendForgot_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendForgot_btn.Location = new System.Drawing.Point(135, 49);
            this.sendForgot_btn.Name = "sendForgot_btn";
            this.sendForgot_btn.Size = new System.Drawing.Size(82, 23);
            this.sendForgot_btn.TabIndex = 1;
            this.sendForgot_btn.Text = "Send Email";
            this.sendForgot_btn.UseVisualStyleBackColor = true;
            this.sendForgot_btn.Click += new System.EventHandler(this.SendForgot_btn_Click);
            // 
            // emailForgot_lbl
            // 
            this.emailForgot_lbl.AutoSize = true;
            this.emailForgot_lbl.Location = new System.Drawing.Point(6, 16);
            this.emailForgot_lbl.Name = "emailForgot_lbl";
            this.emailForgot_lbl.Size = new System.Drawing.Size(35, 13);
            this.emailForgot_lbl.TabIndex = 0;
            this.emailForgot_lbl.Text = "Email:";
            // 
            // SignIn_SignUp_ForgotDetailsForm
            // 
            this.AcceptButton = this.signIn_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(455, 261);
            this.Controls.Add(this.ForgotDetails_grp);
            this.Controls.Add(this.SignIn_grp);
            this.Controls.Add(this.SignUp_grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SignIn_SignUp_ForgotDetailsForm";
            this.Text = "Login";
            this.SignUp_grp.ResumeLayout(false);
            this.SignUp_grp.PerformLayout();
            this.SignIn_grp.ResumeLayout(false);
            this.SignIn_grp.PerformLayout();
            this.ForgotDetails_grp.ResumeLayout(false);
            this.ForgotDetails_grp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label usernameSignIn_lbl;
        private System.Windows.Forms.Label passwordSignIn_lbl;
        private System.Windows.Forms.TextBox usernameSignIn_txt;
        private System.Windows.Forms.TextBox passwordSignIn_txt;
        private System.Windows.Forms.Button signIn_btn;
        private System.Windows.Forms.Button signUp_btn;
        private System.Windows.Forms.GroupBox SignUp_grp;
        private System.Windows.Forms.Label emailSignUp_lbl;
        private System.Windows.Forms.Label usernameSignUp_lbl;
        private System.Windows.Forms.Label nicknameSignUp_lbl;
        private System.Windows.Forms.Label forgotDetails_lbl;
        private System.Windows.Forms.Label or_lbl;
        private System.Windows.Forms.TextBox nicknameSignUp_txt;
        private System.Windows.Forms.TextBox emailSignUp_txt;
        private System.Windows.Forms.TextBox usernameSignUp_txt;
        private System.Windows.Forms.Button register_btn;
        private System.Windows.Forms.GroupBox SignIn_grp;
        private System.Windows.Forms.GroupBox ForgotDetails_grp;
        private System.Windows.Forms.Label emailForgot_lbl;
        private System.Windows.Forms.TextBox emailForgot_txt;
        private System.Windows.Forms.Button sendForgot_btn;
        private System.Windows.Forms.Label nicknameSignUpError_lbl;
        private System.Windows.Forms.Label emailSignUpError_lbl;
        private System.Windows.Forms.Label usernameSignUpError_lbl;
        private System.Windows.Forms.Label registerError_lbl;
        private System.Windows.Forms.Label signInError_lbl;
        private System.Windows.Forms.Label emailForgotError_lbl;
    }
}