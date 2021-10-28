namespace Bone
{
    partial class Options
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
            this.jkGroup = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.jkExePath = new System.Windows.Forms.TextBox();
            this.jkExeBrowse = new System.Windows.Forms.Button();
            this.argWindowGui = new System.Windows.Forms.CheckBox();
            this.argDevmode = new System.Windows.Forms.CheckBox();
            this.argFrameRate = new System.Windows.Forms.CheckBox();
            this.argDispStats = new System.Windows.Forms.CheckBox();
            this.argNoHud = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.jkpathGood = new System.Windows.Forms.PictureBox();
            this.enableDplayDISM = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.showIp = new System.Windows.Forms.ComboBox();
            this.jkGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jkpathGood)).BeginInit();
            this.SuspendLayout();
            // 
            // jkGroup
            // 
            this.jkGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jkGroup.Controls.Add(this.jkpathGood);
            this.jkGroup.Controls.Add(this.label2);
            this.jkGroup.Controls.Add(this.argNoHud);
            this.jkGroup.Controls.Add(this.argDispStats);
            this.jkGroup.Controls.Add(this.argFrameRate);
            this.jkGroup.Controls.Add(this.argDevmode);
            this.jkGroup.Controls.Add(this.argWindowGui);
            this.jkGroup.Controls.Add(this.jkExeBrowse);
            this.jkGroup.Controls.Add(this.jkExePath);
            this.jkGroup.Controls.Add(this.label1);
            this.jkGroup.Location = new System.Drawing.Point(12, 12);
            this.jkGroup.Name = "jkGroup";
            this.jkGroup.Size = new System.Drawing.Size(480, 213);
            this.jkGroup.TabIndex = 0;
            this.jkGroup.TabStop = false;
            this.jkGroup.Text = "Jedi Knight";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Executable Path:";
            // 
            // jkExePath
            // 
            this.jkExePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jkExePath.Location = new System.Drawing.Point(35, 44);
            this.jkExePath.Name = "jkExePath";
            this.jkExePath.Size = new System.Drawing.Size(368, 20);
            this.jkExePath.TabIndex = 1;
            this.jkExePath.TextChanged += new System.EventHandler(this.jkExePath_TextChanged);
            // 
            // jkExeBrowse
            // 
            this.jkExeBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jkExeBrowse.Location = new System.Drawing.Point(409, 44);
            this.jkExeBrowse.Name = "jkExeBrowse";
            this.jkExeBrowse.Size = new System.Drawing.Size(65, 20);
            this.jkExeBrowse.TabIndex = 2;
            this.jkExeBrowse.Text = "Browse...";
            this.jkExeBrowse.UseVisualStyleBackColor = true;
            this.jkExeBrowse.Click += new System.EventHandler(this.jkExeBrowse_Click);
            // 
            // argWindowGui
            // 
            this.argWindowGui.AutoSize = true;
            this.argWindowGui.Location = new System.Drawing.Point(6, 98);
            this.argWindowGui.Name = "argWindowGui";
            this.argWindowGui.Size = new System.Drawing.Size(84, 17);
            this.argWindowGui.TabIndex = 3;
            this.argWindowGui.Text = "-windowGUI";
            this.argWindowGui.UseVisualStyleBackColor = true;
            // 
            // argDevmode
            // 
            this.argDevmode.AutoSize = true;
            this.argDevmode.Location = new System.Drawing.Point(6, 121);
            this.argDevmode.Name = "argDevmode";
            this.argDevmode.Size = new System.Drawing.Size(74, 17);
            this.argDevmode.TabIndex = 4;
            this.argDevmode.Text = "-devMode";
            this.argDevmode.UseVisualStyleBackColor = true;
            // 
            // argFrameRate
            // 
            this.argFrameRate.AutoSize = true;
            this.argFrameRate.Location = new System.Drawing.Point(6, 144);
            this.argFrameRate.Name = "argFrameRate";
            this.argFrameRate.Size = new System.Drawing.Size(78, 17);
            this.argFrameRate.TabIndex = 5;
            this.argFrameRate.Text = "-frameRate";
            this.argFrameRate.UseVisualStyleBackColor = true;
            // 
            // argDispStats
            // 
            this.argDispStats.AutoSize = true;
            this.argDispStats.Location = new System.Drawing.Point(6, 167);
            this.argDispStats.Name = "argDispStats";
            this.argDispStats.Size = new System.Drawing.Size(72, 17);
            this.argDispStats.TabIndex = 6;
            this.argDispStats.Text = "-dispStats";
            this.argDispStats.UseVisualStyleBackColor = true;
            // 
            // argNoHud
            // 
            this.argNoHud.AutoSize = true;
            this.argNoHud.Location = new System.Drawing.Point(6, 190);
            this.argNoHud.Name = "argNoHud";
            this.argNoHud.Size = new System.Drawing.Size(65, 17);
            this.argNoHud.TabIndex = 7;
            this.argNoHud.Text = "-noHUD";
            this.argNoHud.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Command-line Arguments:";
            // 
            // jkpathGood
            // 
            this.jkpathGood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jkpathGood.Location = new System.Drawing.Point(9, 44);
            this.jkpathGood.Name = "jkpathGood";
            this.jkpathGood.Size = new System.Drawing.Size(20, 20);
            this.jkpathGood.TabIndex = 1;
            this.jkpathGood.TabStop = false;
            // 
            // enableDplayDISM
            // 
            this.enableDplayDISM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableDplayDISM.Location = new System.Drawing.Point(12, 424);
            this.enableDplayDISM.Name = "enableDplayDISM";
            this.enableDplayDISM.Size = new System.Drawing.Size(177, 23);
            this.enableDplayDISM.TabIndex = 1;
            this.enableDplayDISM.Text = "Enable DirectPlay via DISM.EXE";
            this.enableDplayDISM.UseVisualStyleBackColor = true;
            this.enableDplayDISM.Click += new System.EventHandler(this.enableDplayDISM_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 45);
            this.label3.TabIndex = 2;
            this.label3.Text = "If you are experiencing DirectPlay problems, even after adding \"Legacy Components" +
    "->DirectPlay\" in \"Turn on Windows features\", try clicking this:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Show me my IP Address using:";
            // 
            // showIp
            // 
            this.showIp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.showIp.FormattingEnabled = true;
            this.showIp.Items.AddRange(new object[] {
            "-OFF-",
            "ipinfo.io/ip",
            "bot.whatismyipaddress.com",
            "icanhazip.com"});
            this.showIp.Location = new System.Drawing.Point(12, 289);
            this.showIp.Name = "showIp";
            this.showIp.Size = new System.Drawing.Size(165, 21);
            this.showIp.TabIndex = 4;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 459);
            this.Controls.Add(this.showIp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.enableDplayDISM);
            this.Controls.Add(this.jkGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            this.Load += new System.EventHandler(this.Options_Load);
            this.jkGroup.ResumeLayout(false);
            this.jkGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jkpathGood)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox jkGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox argNoHud;
        private System.Windows.Forms.CheckBox argDispStats;
        private System.Windows.Forms.CheckBox argFrameRate;
        private System.Windows.Forms.CheckBox argDevmode;
        private System.Windows.Forms.CheckBox argWindowGui;
        private System.Windows.Forms.Button jkExeBrowse;
        private System.Windows.Forms.TextBox jkExePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox jkpathGood;
        private System.Windows.Forms.Button enableDplayDISM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox showIp;
    }
}