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
using Microsoft.Win32;

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
                    $"session: {info.SessionName}\n" +
                    $"gob: {info.GOBFile}\n" +
                    $"jkl: {info.JKLFile}\n" +
                    $"players: {info.curPlayers}/{info.maxPlayers}\n" +
                    $"match flags: {info.MatchFlags}\n" +
                    $"tick rate (msec): {info.TickRateMSEC}" /*+
                    $"\n" +
                    $"user1: {info.user1}\n" +
                    $"user2: {info.user2}\n" +
                    $"user3: {info.user3}\n" +
                    $"user4: {info.user4}"*/;
        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            BoneRPlay.SessionInfo info = BoneRPlay.QuerySession(remoteAddress.Text, remotePassword.Text);
            if(info == null)
            {
                MessageBox.Show("Couldn't find session");
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
            gameExitedLabel.Text = $"game exited: {BoneRPlay.HasGameExited()}";


            dplayRegisteredLabel.Text = $"registered: {IsJKRegistered}";
        }


        const string Registry_DPlayApps = @"SOFTWARE\Wow6432Node\Microsoft\DirectPlay\Applications";
        const string Registry_AppName = "Jedi Knight 1.0";

        string RegistryFinalRoot
        {
            get
            {
                return $@"HKEY_LOCAL_MACHINE\{Registry_DPlayApps}\{Registry_AppName}";
            }
        }

        bool IsJKRegistered
        {
            get
            {
                if (Registry.GetValue(RegistryFinalRoot, "Guid", null) == null)
                    return false;

                string path = Registry.GetValue(RegistryFinalRoot, "Path", null) as string;
                string file = Registry.GetValue(RegistryFinalRoot, "File", null) as string;
                if (path == null || file == null)
                    return false;

                string exepath = Path.Combine(path, file);
                if (!File.Exists(exepath))
                    return false;

                return true;
            }
        }

        private void registerDplayApp_Click(object sender, EventArgs e)
        {
            string jkPath = @"C:\Users\Strike\Desktop\JK";

            Registry.SetValue(RegistryFinalRoot, "Guid", "{BF0613C0-DE79-11D0-99C9-00A02476AD4B}");
            Registry.SetValue(RegistryFinalRoot, "File", "JK.EXE");
            Registry.SetValue(RegistryFinalRoot, "CommandLine", "-windowgui");
            Registry.SetValue(RegistryFinalRoot, "Path", jkPath);
            Registry.SetValue(RegistryFinalRoot, "CurrentDirectory", jkPath);
        }

        private void UNregisterDplayApp_Click(object sender, EventArgs e)
        {
            RegistryKey jkKey = Registry.LocalMachine.OpenSubKey(Registry_DPlayApps, true);
            if (jkKey == null)
                return;
            try
            {
                jkKey.DeleteSubKeyTree(Registry_AppName);
            }
            catch
            {

            }

        }

        private void enableDPlayButton_Click(object sender, EventArgs e)
        {
            Process.Start("dism.exe", "/Online /enable-feature /FeatureName:\"LegacyComponents\" /NoRestart").WaitForExit();
            Process.Start("dism.exe", "/Online /enable-feature /FeatureName:\"DirectPlay\" /NoRestart").WaitForExit();
        }
    }
}
