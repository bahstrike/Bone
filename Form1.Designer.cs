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
            this.optionsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.localAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // hostButton
            // 
            this.hostButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostButton.Location = new System.Drawing.Point(12, 56);
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
            this.joinButton.Location = new System.Drawing.Point(168, 56);
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
            this.queryButton.Location = new System.Drawing.Point(168, 103);
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
            // 
            // processTimer
            // 
            this.processTimer.Enabled = true;
            this.processTimer.Tick += new System.EventHandler(this.processTimer_Tick);
            // 
            // sessionDetailsLabel
            // 
            this.sessionDetailsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sessionDetailsLabel.AutoEllipsis = true;
            this.sessionDetailsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sessionDetailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.sessionDetailsLabel.Location = new System.Drawing.Point(265, 66);
            this.sessionDetailsLabel.Name = "sessionDetailsLabel";
            this.sessionDetailsLabel.Size = new System.Drawing.Size(236, 106);
            this.sessionDetailsLabel.TabIndex = 9;
            this.sessionDetailsLabel.Text = "blah\r\nblerr\r\nbloo\r\nblee\r\nbluh";
            // 
            // optionsButton
            // 
            this.optionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsButton.Location = new System.Drawing.Point(410, 12);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(91, 41);
            this.optionsButton.TabIndex = 13;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Remote IP Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "My IP Address";
            // 
            // localAddress
            // 
            this.localAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.localAddress.Location = new System.Drawing.Point(12, 24);
            this.localAddress.Name = "localAddress";
            this.localAddress.ReadOnly = true;
            this.localAddress.Size = new System.Drawing.Size(131, 26);
            this.localAddress.TabIndex = 18;
            this.localAddress.Click += new System.EventHandler(this.localAddress_Click_1);
            this.localAddress.DoubleClick += new System.EventHandler(this.localAddress_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 181);
            this.Controls.Add(this.localAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.optionsButton);
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
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox localAddress;
    }
}

