﻿namespace PresentationTier
{
    partial class RPSForm
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
            this.rockChoice_rb = new System.Windows.Forms.RadioButton();
            this.paperChoice_rb = new System.Windows.Forms.RadioButton();
            this.scissorChoice_rb = new System.Windows.Forms.RadioButton();
            this.choice_pnl = new System.Windows.Forms.GroupBox();
            this.anouncer_lbl = new System.Windows.Forms.Label();
            this.selectChoice_btn = new System.Windows.Forms.Button();
            this.player2_lbl = new System.Windows.Forms.Label();
            this.player1_lbl = new System.Windows.Forms.Label();
            this.palyer1Points_lbl = new System.Windows.Forms.Label();
            this.player2Points_lbl = new System.Windows.Forms.Label();
            this.history_listBox = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.player2_pnl = new System.Windows.Forms.Panel();
            this.player2_bar = new System.Windows.Forms.ProgressBar();
            this.player2_pic = new System.Windows.Forms.PictureBox();
            this.player1_pnl = new System.Windows.Forms.Panel();
            this.player1_bar = new System.Windows.Forms.ProgressBar();
            this.player1_pic = new System.Windows.Forms.PictureBox();
            this.points_lbl = new System.Windows.Forms.Label();
            this.choice_lbl = new System.Windows.Forms.Label();
            this.player_lbl = new System.Windows.Forms.Label();
            this.newGame_btn = new System.Windows.Forms.Button();
            this.newGame_lbl = new System.Windows.Forms.Label();
            this.choice_pnl.SuspendLayout();
            this.player2_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player2_pic)).BeginInit();
            this.player1_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player1_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // rockChoice_rb
            // 
            this.rockChoice_rb.AutoSize = true;
            this.rockChoice_rb.Location = new System.Drawing.Point(10, 25);
            this.rockChoice_rb.Name = "rockChoice_rb";
            this.rockChoice_rb.Size = new System.Drawing.Size(51, 17);
            this.rockChoice_rb.TabIndex = 0;
            this.rockChoice_rb.TabStop = true;
            this.rockChoice_rb.Text = "Rock";
            this.rockChoice_rb.UseVisualStyleBackColor = true;
            this.rockChoice_rb.CheckedChanged += new System.EventHandler(this.RockRB_CheckedChanged);
            // 
            // paperChoice_rb
            // 
            this.paperChoice_rb.AutoSize = true;
            this.paperChoice_rb.Location = new System.Drawing.Point(10, 48);
            this.paperChoice_rb.Name = "paperChoice_rb";
            this.paperChoice_rb.Size = new System.Drawing.Size(53, 17);
            this.paperChoice_rb.TabIndex = 1;
            this.paperChoice_rb.TabStop = true;
            this.paperChoice_rb.Text = "Paper";
            this.paperChoice_rb.UseVisualStyleBackColor = true;
            this.paperChoice_rb.CheckedChanged += new System.EventHandler(this.RockRB_CheckedChanged);
            // 
            // scissorChoice_rb
            // 
            this.scissorChoice_rb.AutoSize = true;
            this.scissorChoice_rb.Location = new System.Drawing.Point(10, 71);
            this.scissorChoice_rb.Name = "scissorChoice_rb";
            this.scissorChoice_rb.Size = new System.Drawing.Size(64, 17);
            this.scissorChoice_rb.TabIndex = 2;
            this.scissorChoice_rb.TabStop = true;
            this.scissorChoice_rb.Text = "Scissors";
            this.scissorChoice_rb.UseVisualStyleBackColor = true;
            this.scissorChoice_rb.CheckedChanged += new System.EventHandler(this.RockRB_CheckedChanged);
            // 
            // choice_pnl
            // 
            this.choice_pnl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.choice_pnl.Controls.Add(this.anouncer_lbl);
            this.choice_pnl.Controls.Add(this.rockChoice_rb);
            this.choice_pnl.Controls.Add(this.scissorChoice_rb);
            this.choice_pnl.Controls.Add(this.selectChoice_btn);
            this.choice_pnl.Controls.Add(this.paperChoice_rb);
            this.choice_pnl.Location = new System.Drawing.Point(281, 36);
            this.choice_pnl.Name = "choice_pnl";
            this.choice_pnl.Size = new System.Drawing.Size(201, 109);
            this.choice_pnl.TabIndex = 4;
            this.choice_pnl.TabStop = false;
            this.choice_pnl.Text = "Make your choice!";
            // 
            // anouncer_lbl
            // 
            this.anouncer_lbl.AutoSize = true;
            this.anouncer_lbl.Location = new System.Drawing.Point(116, 84);
            this.anouncer_lbl.Name = "anouncer_lbl";
            this.anouncer_lbl.Size = new System.Drawing.Size(68, 13);
            this.anouncer_lbl.TabIndex = 4;
            this.anouncer_lbl.Text = "anouncer_lbl";
            this.anouncer_lbl.Visible = false;
            // 
            // selectChoice_btn
            // 
            this.selectChoice_btn.BackgroundImage = global::PresentationTier.Properties.Resources.Actions_go_jump_locationbar_icon;
            this.selectChoice_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectChoice_btn.FlatAppearance.BorderSize = 0;
            this.selectChoice_btn.Location = new System.Drawing.Point(119, 31);
            this.selectChoice_btn.Name = "selectChoice_btn";
            this.selectChoice_btn.Size = new System.Drawing.Size(50, 50);
            this.selectChoice_btn.TabIndex = 3;
            this.selectChoice_btn.UseVisualStyleBackColor = true;
            this.selectChoice_btn.Click += new System.EventHandler(this.SelectChoice_btn_Click);
            // 
            // player2_lbl
            // 
            this.player2_lbl.AutoSize = true;
            this.player2_lbl.Location = new System.Drawing.Point(10, 4);
            this.player2_lbl.Name = "player2_lbl";
            this.player2_lbl.Size = new System.Drawing.Size(57, 13);
            this.player2_lbl.TabIndex = 5;
            this.player2_lbl.Text = "player2_lbl";
            // 
            // player1_lbl
            // 
            this.player1_lbl.AutoSize = true;
            this.player1_lbl.Location = new System.Drawing.Point(10, 3);
            this.player1_lbl.Name = "player1_lbl";
            this.player1_lbl.Size = new System.Drawing.Size(57, 13);
            this.player1_lbl.TabIndex = 6;
            this.player1_lbl.Text = "player1_lbl";
            // 
            // palyer1Points_lbl
            // 
            this.palyer1Points_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.palyer1Points_lbl.AutoSize = true;
            this.palyer1Points_lbl.Location = new System.Drawing.Point(189, 19);
            this.palyer1Points_lbl.Name = "palyer1Points_lbl";
            this.palyer1Points_lbl.Size = new System.Drawing.Size(13, 13);
            this.palyer1Points_lbl.TabIndex = 11;
            this.palyer1Points_lbl.Text = "0";
            // 
            // player2Points_lbl
            // 
            this.player2Points_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.player2Points_lbl.AutoSize = true;
            this.player2Points_lbl.Location = new System.Drawing.Point(189, 20);
            this.player2Points_lbl.Name = "player2Points_lbl";
            this.player2Points_lbl.Size = new System.Drawing.Size(13, 13);
            this.player2Points_lbl.TabIndex = 12;
            this.player2Points_lbl.Text = "0";
            // 
            // history_listBox
            // 
            this.history_listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.history_listBox.FormattingEnabled = true;
            this.history_listBox.HorizontalScrollbar = true;
            this.history_listBox.Location = new System.Drawing.Point(19, 158);
            this.history_listBox.Name = "history_listBox";
            this.history_listBox.Size = new System.Drawing.Size(463, 95);
            this.history_listBox.TabIndex = 14;
            // 
            // player2_pnl
            // 
            this.player2_pnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player2_pnl.BackColor = System.Drawing.SystemColors.Control;
            this.player2_pnl.Controls.Add(this.player2_bar);
            this.player2_pnl.Controls.Add(this.player2_lbl);
            this.player2_pnl.Controls.Add(this.player2_pic);
            this.player2_pnl.Controls.Add(this.player2Points_lbl);
            this.player2_pnl.Location = new System.Drawing.Point(19, 101);
            this.player2_pnl.Name = "player2_pnl";
            this.player2_pnl.Size = new System.Drawing.Size(227, 49);
            this.player2_pnl.TabIndex = 20;
            // 
            // player2_bar
            // 
            this.player2_bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player2_bar.Location = new System.Drawing.Point(13, 20);
            this.player2_bar.Name = "player2_bar";
            this.player2_bar.Size = new System.Drawing.Size(100, 23);
            this.player2_bar.TabIndex = 26;
            // 
            // player2_pic
            // 
            this.player2_pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.player2_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player2_pic.Image = global::PresentationTier.Properties.Resources.scissor;
            this.player2_pic.InitialImage = null;
            this.player2_pic.Location = new System.Drawing.Point(138, 4);
            this.player2_pic.Name = "player2_pic";
            this.player2_pic.Size = new System.Drawing.Size(35, 36);
            this.player2_pic.TabIndex = 9;
            this.player2_pic.TabStop = false;
            // 
            // player1_pnl
            // 
            this.player1_pnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player1_pnl.Controls.Add(this.player1_lbl);
            this.player1_pnl.Controls.Add(this.player1_bar);
            this.player1_pnl.Controls.Add(this.player1_pic);
            this.player1_pnl.Controls.Add(this.palyer1Points_lbl);
            this.player1_pnl.Location = new System.Drawing.Point(19, 36);
            this.player1_pnl.Name = "player1_pnl";
            this.player1_pnl.Size = new System.Drawing.Size(227, 51);
            this.player1_pnl.TabIndex = 21;
            // 
            // player1_bar
            // 
            this.player1_bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player1_bar.Location = new System.Drawing.Point(13, 19);
            this.player1_bar.Name = "player1_bar";
            this.player1_bar.Size = new System.Drawing.Size(100, 23);
            this.player1_bar.TabIndex = 25;
            // 
            // player1_pic
            // 
            this.player1_pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.player1_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player1_pic.InitialImage = null;
            this.player1_pic.Location = new System.Drawing.Point(138, 6);
            this.player1_pic.Name = "player1_pic";
            this.player1_pic.Size = new System.Drawing.Size(35, 36);
            this.player1_pic.TabIndex = 8;
            this.player1_pic.TabStop = false;
            // 
            // points_lbl
            // 
            this.points_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.points_lbl.AutoSize = true;
            this.points_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.points_lbl.Location = new System.Drawing.Point(204, 9);
            this.points_lbl.Name = "points_lbl";
            this.points_lbl.Size = new System.Drawing.Size(42, 13);
            this.points_lbl.TabIndex = 24;
            this.points_lbl.Text = "Points";
            this.points_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // choice_lbl
            // 
            this.choice_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.choice_lbl.AutoSize = true;
            this.choice_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.choice_lbl.Location = new System.Drawing.Point(154, 9);
            this.choice_lbl.Name = "choice_lbl";
            this.choice_lbl.Size = new System.Drawing.Size(46, 13);
            this.choice_lbl.TabIndex = 25;
            this.choice_lbl.Text = "Choice";
            this.choice_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // player_lbl
            // 
            this.player_lbl.AutoSize = true;
            this.player_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.player_lbl.Location = new System.Drawing.Point(29, 9);
            this.player_lbl.Name = "player_lbl";
            this.player_lbl.Size = new System.Drawing.Size(42, 13);
            this.player_lbl.TabIndex = 26;
            this.player_lbl.Text = "Player";
            this.player_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // newGame_btn
            // 
            this.newGame_btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.newGame_btn.BackgroundImage = global::PresentationTier.Properties.Resources.Actions_edit_undo_icon;
            this.newGame_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newGame_btn.FlatAppearance.BorderSize = 0;
            this.newGame_btn.Location = new System.Drawing.Point(214, 260);
            this.newGame_btn.Name = "newGame_btn";
            this.newGame_btn.Size = new System.Drawing.Size(40, 36);
            this.newGame_btn.TabIndex = 22;
            this.newGame_btn.UseVisualStyleBackColor = true;
            this.newGame_btn.Click += new System.EventHandler(this.NewGame_btn_Click);
            // 
            // newGame_lbl
            // 
            this.newGame_lbl.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.newGame_lbl.AutoSize = true;
            this.newGame_lbl.Location = new System.Drawing.Point(260, 283);
            this.newGame_lbl.Name = "newGame_lbl";
            this.newGame_lbl.Size = new System.Drawing.Size(57, 13);
            this.newGame_lbl.TabIndex = 23;
            this.newGame_lbl.Text = "Play Again";
            // 
            // RPSForm
            // 
            this.AcceptButton = this.selectChoice_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(499, 308);
            this.Controls.Add(this.player_lbl);
            this.Controls.Add(this.choice_lbl);
            this.Controls.Add(this.points_lbl);
            this.Controls.Add(this.newGame_lbl);
            this.Controls.Add(this.newGame_btn);
            this.Controls.Add(this.player1_pnl);
            this.Controls.Add(this.player2_pnl);
            this.Controls.Add(this.history_listBox);
            this.Controls.Add(this.choice_pnl);
            this.MinimumSize = new System.Drawing.Size(515, 347);
            this.Name = "RPSForm";
            this.Text = "Piatra, Pergament, Foarfece";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RPSForm_Closing);
            this.choice_pnl.ResumeLayout(false);
            this.choice_pnl.PerformLayout();
            this.player2_pnl.ResumeLayout(false);
            this.player2_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player2_pic)).EndInit();
            this.player1_pnl.ResumeLayout(false);
            this.player1_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player1_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rockChoice_rb;
        private System.Windows.Forms.RadioButton paperChoice_rb;
        private System.Windows.Forms.RadioButton scissorChoice_rb;
        private System.Windows.Forms.Button selectChoice_btn;
        private System.Windows.Forms.GroupBox choice_pnl;
        private System.Windows.Forms.Label player1_lbl;
        private System.Windows.Forms.Label player2_lbl;
        private System.Windows.Forms.PictureBox player2_pic;
        private System.Windows.Forms.PictureBox player1_pic;
        private System.Windows.Forms.Label player2Points_lbl;
        private System.Windows.Forms.Label palyer1Points_lbl;
        private System.Windows.Forms.ListBox history_listBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel player2_pnl;
        private System.Windows.Forms.Panel player1_pnl;
        private System.Windows.Forms.Label points_lbl;
        private System.Windows.Forms.ProgressBar player1_bar;
        private System.Windows.Forms.ProgressBar player2_bar;
        private System.Windows.Forms.Label choice_lbl;
        private System.Windows.Forms.Label player_lbl;
        private System.Windows.Forms.Button newGame_btn;
        private System.Windows.Forms.Label newGame_lbl;
        private System.Windows.Forms.Label anouncer_lbl;
    }
}

