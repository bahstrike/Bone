namespace Bone
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
            this.processTimer = new System.Windows.Forms.Timer(this.components);
            this.sessionDetailsLabel = new System.Windows.Forms.Label();
            this.remotePassword = new System.Windows.Forms.TextBox();
            this.optionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hostButton
            // 
            this.hostButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostButton.Location = new System.Drawing.Point(12, 103);
            this.hostButton.Name = "hostButton";
            this.hostButton.Size = new System.Drawing.Size(91, 41);
            this.hostButton.TabIndex = 0;
            this.hostButton.Text = "Host";
            this.hostButton.UseVisualStyleBackColor = true;
            this.hostButton.Click += new System.EventHandler(this.hostButton_Click);
            // 
            // joinButton
            // 
            this.joinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.joinButton.Location = new System.Drawing.Point(168, 103);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(91, 41);
            this.joinButton.TabIndex = 1;
            this.joinButton.Text = "Join";
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // queryButton
            // 
            this.queryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.queryButton.Location = new System.Drawing.Point(168, 56);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(91, 41);
            this.queryButton.TabIndex = 2;
            this.queryButton.Text = "Query";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.queryButton_Click);
            // 
            // remoteAddress
            // 
            this.remoteAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.remoteAddress.Location = new System.Drawing.Point(168, 24);
            this.remoteAddress.Name = "remoteAddress";
            this.remoteAddress.Size = new System.Drawing.Size(131, 26);
            this.remoteAddress.TabIndex = 3;
            this.remoteAddress.Text = "192.168.5.3";
            // 
            // processTimer
            // 
            this.processTimer.Enabled = true;
            this.processTimer.Tick += new System.EventHandler(this.processTimer_Tick);
            // 
            // sessionDetailsLabel
            // 
            this.sessionDetailsLabel.AutoSize = true;
            this.sessionDetailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.sessionDetailsLabel.Location = new System.Drawing.Point(265, 66);
            this.sessionDetailsLabel.Name = "sessionDetailsLabel";
            this.sessionDetailsLabel.Size = new System.Drawing.Size(39, 20);
            this.sessionDetailsLabel.TabIndex = 9;
            this.sessionDetailsLabel.Text = "blah";
            // 
            // remotePassword
            // 
            this.remotePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.remotePassword.Location = new System.Drawing.Point(305, 24);
            this.remotePassword.Name = "remotePassword";
            this.remotePassword.Size = new System.Drawing.Size(131, 26);
            this.remotePassword.TabIndex = 10;
            // 
            // optionsButton
            // 
            this.optionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsButton.Location = new System.Drawing.Point(15, 17);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(91, 41);
            this.optionsButton.TabIndex = 13;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 289);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.remotePassword);
            this.Controls.Add(this.sessionDetailsLabel);
            this.Controls.Add(this.remoteAddress);
            this.Controls.Add(this.queryButton);
            this.Controls.Add(this.joinButton);
            this.Controls.Add(this.hostButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bone - BAH 2021";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button hostButton;
        private System.Windows.Forms.Button joinButton;
        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.TextBox remoteAddress;
        private System.Windows.Forms.Timer processTimer;
        private System.Windows.Forms.Label sessionDetailsLabel;
        private System.Windows.Forms.TextBox remotePassword;
        private System.Windows.Forms.Button optionsButton;
    }
}

