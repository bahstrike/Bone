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
using System.Net;

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
            Cursor = Cursors.WaitCursor;
            Enabled = false;
            Update();

            try
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
            finally
            {
                Cursor = Cursors.Default;
                Enabled = true;
            }

        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            if (!BoneRPlay.HasGameExited())
            {
                MessageBox.Show("A session is already active. Exit Jedi Knight first.", "Bone", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            BoneRPlay.SessionInfo info = null;


            Cursor = Cursors.WaitCursor;
            Enabled = false;
            Update();

            try
            {

                info = BoneRPlay.QuerySession(remoteAddress.Text, remotePassword.Text);
                if (info == null)
                {
                    MessageBox.Show("Couldn't find session.", "Bone", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            finally
            {
                Cursor = Cursors.Default;
                Enabled = true;
            }


            if (info == null)
                return;

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

#if DEBUG
            remoteAddress.Text = "192.168.5.3";
#endif

            sessionDetailsLabel.Text = string.Empty;



            if(!AppRegistry.IsJKRegistered || Program.HadNoConfigINI)
            {
                optionsButton_Click(null, new EventArgs());
            }

            processTimer_Tick(null, new EventArgs());



            UpdateLocalIPAddress();
        }

        public void UpdateLocalIPAddress()
        {
            Options.DetermineIPMethod ipmethod;
            if (!Enum.TryParse<Options.DetermineIPMethod>(Program.ConfigINI.GetKey("Bone", "DetermineIPMethod", "off"), true, out ipmethod))
                ipmethod = Options.DetermineIPMethod.OFF;

            string queryhost = null;
            switch(ipmethod)
            {
                case Options.DetermineIPMethod.ipinfo:
                    queryhost = "http://ipinfo.io/ip";
                    break;

                case Options.DetermineIPMethod.whatismyipaddress:
                    queryhost = "http://bot.whatismyipaddress.com";
                    break;

                case Options.DetermineIPMethod.icanhazip:
                    queryhost = "http://icanhazip.com";
                    break;
            }

            if(string.IsNullOrEmpty(queryhost))
            {
                localAddress.Text = "-disabled-";
                localAddress.Enabled = false;
                return;
            }

            try
            {
                string ipaddress = new WebClient().DownloadString(queryhost).Replace("\\r\\n", "").Replace("\\n", "").Trim();

                IPAddress dummy;
                if (!IPAddress.TryParse(ipaddress, out dummy))
                    throw new Exception();//cheap shortcut to "failed" scenario

                localAddress.Text = ipaddress;
                localAddress.Enabled = true;
            }
            catch
            {
                localAddress.Text = "-failed-";
                localAddress.Enabled = false;
            }
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            Options opt = new Options();

            opt.ShowDialog(this);

            // re-query after changing options
            UpdateLocalIPAddress();
        }

        private void localAddress_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(localAddress.Text);
            }
            catch
            {

            }
        }

        private void localAddress_Click_1(object sender, EventArgs e)
        {
            localAddress.SelectAll();
        }

        private void localAddress_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(localAddress.Text);

                //localAddress.DeselectAll();
            }
            catch
            {

            }
        }

    }
}
