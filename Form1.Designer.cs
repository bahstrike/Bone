﻿namespace Bone
{
    partial class Form1
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
            this.hostButton = new System.Windows.Forms.Button();
            this.joinButton = new System.Windows.Forms.Button();
            this.queryButton = new System.Windows.Forms.Button();
            this.remoteAddress = new System.Windows.Forms.TextBox();
            this.shutdownButton = new System.Windows.Forms.Button();
            this.processTimer = new System.Windows.Forms.Timer(this.components);
            this.gameExitedLabel = new System.Windows.Forms.Label();
            this.registerDplayApp = new System.Windows.Forms.Button();
            this.dplayRegisteredLabel = new System.Windows.Forms.Label();
            this.UNregisterDplayApp = new System.Windows.Forms.Button();
            this.sessionDetailsLabel = new System.Windows.Forms.Label();
            this.remotePassword = new System.Windows.Forms.TextBox();
            this.enableDPlayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hostButton
            // 
            this.hostButton.Location = new System.Drawing.Point(38, 129);
            this.hostButton.Name = "hostButton";
            this.hostButton.Size = new System.Drawing.Size(75, 23);
            this.hostButton.TabIndex = 0;
            this.hostButton.Text = "host";
            this.hostButton.UseVisualStyleBackColor = true;
            this.hostButton.Click += new System.EventHandler(this.hostButton_Click);
            // 
            // joinButton
            // 
            this.joinButton.Location = new System.Drawing.Point(222, 186);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(75, 23);
            this.joinButton.TabIndex = 1;
            this.joinButton.Text = "join";
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // queryButton
            // 
            this.queryButton.Location = new System.Drawing.Point(222, 157);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(75, 23);
            this.queryButton.TabIndex = 2;
            this.queryButton.Text = "query";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.queryButton_Click);
            // 
            // remoteAddress
            // 
            this.remoteAddress.Location = new System.Drawing.Point(222, 131);
            this.remoteAddress.Name = "remoteAddress";
            this.remoteAddress.Size = new System.Drawing.Size(100, 20);
            this.remoteAddress.TabIndex = 3;
            this.remoteAddress.Text = "192.168.5.3";
            // 
            // shutdownButton
            // 
            this.shutdownButton.Location = new System.Drawing.Point(38, 328);
            this.shutdownButton.Name = "shutdownButton";
            this.shutdownButton.Size = new System.Drawing.Size(75, 23);
            this.shutdownButton.TabIndex = 4;
            this.shutdownButton.Text = "shutdown";
            this.shutdownButton.UseVisualStyleBackColor = true;
            this.shutdownButton.Click += new System.EventHandler(this.shutdownButton_Click);
            // 
            // processTimer
            // 
            this.processTimer.Enabled = true;
            this.processTimer.Tick += new System.EventHandler(this.processTimer_Tick);
            // 
            // gameExitedLabel
            // 
            this.gameExitedLabel.AutoSize = true;
            this.gameExitedLabel.Location = new System.Drawing.Point(241, 282);
            this.gameExitedLabel.Name = "gameExitedLabel";
            this.gameExitedLabel.Size = new System.Drawing.Size(27, 13);
            this.gameExitedLabel.TabIndex = 5;
            this.gameExitedLabel.Text = "blah";
            // 
            // registerDplayApp
            // 
            this.registerDplayApp.Location = new System.Drawing.Point(388, 31);
            this.registerDplayApp.Name = "registerDplayApp";
            this.registerDplayApp.Size = new System.Drawing.Size(99, 23);
            this.registerDplayApp.TabIndex = 6;
            this.registerDplayApp.Text = "register dplay app";
            this.registerDplayApp.UseVisualStyleBackColor = true;
            this.registerDplayApp.Click += new System.EventHandler(this.registerDplayApp_Click);
            // 
            // dplayRegisteredLabel
            // 
            this.dplayRegisteredLabel.AutoSize = true;
            this.dplayRegisteredLabel.Location = new System.Drawing.Point(493, 36);
            this.dplayRegisteredLabel.Name = "dplayRegisteredLabel";
            this.dplayRegisteredLabel.Size = new System.Drawing.Size(27, 13);
            this.dplayRegisteredLabel.TabIndex = 7;
            this.dplayRegisteredLabel.Text = "blah";
            // 
            // UNregisterDplayApp
            // 
            this.UNregisterDplayApp.Location = new System.Drawing.Point(366, 60);
            this.UNregisterDplayApp.Name = "UNregisterDplayApp";
            this.UNregisterDplayApp.Size = new System.Drawing.Size(121, 23);
            this.UNregisterDplayApp.TabIndex = 8;
            this.UNregisterDplayApp.Text = "UNregister dplay app";
            this.UNregisterDplayApp.UseVisualStyleBackColor = true;
            this.UNregisterDplayApp.Click += new System.EventHandler(this.UNregisterDplayApp_Click);
            // 
            // sessionDetailsLabel
            // 
            this.sessionDetailsLabel.AutoSize = true;
            this.sessionDetailsLabel.Location = new System.Drawing.Point(363, 157);
            this.sessionDetailsLabel.Name = "sessionDetailsLabel";
            this.sessionDetailsLabel.Size = new System.Drawing.Size(27, 13);
            this.sessionDetailsLabel.TabIndex = 9;
            this.sessionDetailsLabel.Text = "blah";
            // 
            // remotePassword
            // 
            this.remotePassword.Location = new System.Drawing.Point(328, 131);
            this.remotePassword.Name = "remotePassword";
            this.remotePassword.Size = new System.Drawing.Size(100, 20);
            this.remotePassword.TabIndex = 10;
            // 
            // enableDPlayButton
            // 
            this.enableDPlayButton.Location = new System.Drawing.Point(558, 213);
            this.enableDPlayButton.Name = "enableDPlayButton";
            this.enableDPlayButton.Size = new System.Drawing.Size(118, 23);
            this.enableDPlayButton.TabIndex = 11;
            this.enableDPlayButton.Text = "enable directplay";
            this.enableDPlayButton.UseVisualStyleBackColor = true;
            this.enableDPlayButton.Click += new System.EventHandler(this.enableDPlayButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 458);
            this.Controls.Add(this.enableDPlayButton);
            this.Controls.Add(this.remotePassword);
            this.Controls.Add(this.sessionDetailsLabel);
            this.Controls.Add(this.UNregisterDplayApp);
            this.Controls.Add(this.dplayRegisteredLabel);
            this.Controls.Add(this.registerDplayApp);
            this.Controls.Add(this.gameExitedLabel);
            this.Controls.Add(this.shutdownButton);
            this.Controls.Add(this.remoteAddress);
            this.Controls.Add(this.queryButton);
            this.Controls.Add(this.joinButton);
            this.Controls.Add(this.hostButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button hostButton;
        private System.Windows.Forms.Button joinButton;
        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.TextBox remoteAddress;
        private System.Windows.Forms.Button shutdownButton;
        private System.Windows.Forms.Timer processTimer;
        private System.Windows.Forms.Label gameExitedLabel;
        private System.Windows.Forms.Button registerDplayApp;
        private System.Windows.Forms.Label dplayRegisteredLabel;
        private System.Windows.Forms.Button UNregisterDplayApp;
        private System.Windows.Forms.Label sessionDetailsLabel;
        private System.Windows.Forms.TextBox remotePassword;
        private System.Windows.Forms.Button enableDPlayButton;
    }
}

