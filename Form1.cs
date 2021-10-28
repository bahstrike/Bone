using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Bone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void ShowResultError(BoneRPlay.Result result)
        {
            string ermsg = null;

            switch(result)
            {
                case BoneRPlay.Result.Success:
                    return;// no message

                case BoneRPlay.Result.NoDirectPlay:
                    ermsg = "Failed to initialize DirectPlay.\n\nTry enabling legacy components in Options.\n\nIf that doesn't work, you may need to \"Turn Windows features on\" for Legacy Components->DirectPlay.";
                    break;

                case BoneRPlay.Result.AppNotRegistered:
                    ermsg = "DirectPlay didn't recognize Jedi Knight as a registered application.";
                    break;

                case BoneRPlay.Result.CantCreateProcess:
                    ermsg = "DirectPlay couldn't launch Jedi Knight.\n\nBone must be run as Administrator.\n\nAlso, verify that your Jedi Knight path/exe filenames are correct.";
                    break;
            }

            if (!string.IsNullOrEmpty(ermsg))
                MessageBox.Show(ermsg, "Bone", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void hostButton_Click(object sender, EventArgs e)
        {
            if(!BoneRPlay.HasGameExited())
            {
                MessageBox.Show("A session is already active. Exit Jedi Knight first.", "Bone", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BoneRPlay.Result result = BoneRPlay.Host();
            if (result != BoneRPlay.Result.Success)
                ShowResultError(result);
        }

        private void queryButton_Click(object sender, EventArgs e)
        {
            BoneRPlay.SessionInfo info = BoneRPlay.QuerySession(remoteAddress.Text, remotePassword.Text);

            if (info == null)
                sessionDetailsLabel.Text = "NO SESSION";
            else
                sessionDetailsLabel.Text =
                    //$"instance: {info.guidInstance}\n" +
                    //$"session: {info.sessionName}\n" +
                    $"Session: {info.SessionName}\n" +
                    $"Level: {info.GOBFile} ({info.JKLFile})\n" +
                    $"Players: {info.curPlayers}/{info.maxPlayers}\n" +
                    $"Settings: {(info.MatchFlags == 0 ? "None" : info.MatchFlags.ToString())}\n" +
                    $"Tick Rate (msec): {info.TickRateMSEC}" /*+
                    $"\n" +
                    $"user1: {info.user1}\n" +
                    $"user2: {info.user2}\n" +
                    $"user3: {info.user3}\n" +
                    $"user4: {info.user4}"*/;
        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            if (!BoneRPlay.HasGameExited())
            {
                MessageBox.Show("A session is already active. Exit Jedi Knight first.", "Bone", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BoneRPlay.SessionInfo info = BoneRPlay.QuerySession(remoteAddress.Text, remotePassword.Text);
            if(info == null)
            {
                MessageBox.Show("Couldn't find session.", "Bone", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            BoneRPlay.Result result = BoneRPlay.Join(ref info.guidInstance, remoteAddress.Text, remotePassword.Text);
            if (result != BoneRPlay.Result.Success)
                ShowResultError(result);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BoneRPlay.Shutdown();
        }

        private void shutdownButton_Click(object sender, EventArgs e)
        {
            BoneRPlay.Shutdown();
        }

        private void processTimer_Tick(object sender, EventArgs e)
        {

            // check if game is still active
            //gameExitedLabel.Text = $"game exited: {BoneRPlay.HasGameExited()}";


            //dplayRegisteredLabel.Text = $"registered: {AppRegistry.IsJKRegistered}";


            bool jkRegistered = AppRegistry.IsJKRegistered;
            bool hasExited = BoneRPlay.HasGameExited();
            optionsButton.Enabled = hasExited;
            hostButton.Enabled = jkRegistered && hasExited;
            joinButton.Enabled = jkRegistered && hasExited;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            AppRegistry.RegisterGUID();// who cares; we'll just do it every time we launch..  the rest of the values are manipulated elsewhere

#if !DEBUG
            devtools.Visible = false;
#endif

            sessionDetailsLabel.Text = string.Empty;



            if(!AppRegistry.IsJKRegistered)
            {
                optionsButton_Click(null, new EventArgs());
            }

            processTimer_Tick(null, new EventArgs());
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            Options opt = new Options();

            opt.ShowDialog(this);
        }
    }
}
