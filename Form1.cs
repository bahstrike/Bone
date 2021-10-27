using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Bone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void hostButton_Click(object sender, EventArgs e)
        {
            bool ret = BoneRPlay.Host();

            if(!ret)
            {
                MessageBox.Show("we shit ourselves hosting");
            }
        }

        private void queryButton_Click(object sender, EventArgs e)
        {
            BoneRPlay.QuerySession(remoteAddress.Text);


        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("doesnt work yet");


            // BoneRPlay.QuerySession()  to get instance GUID


            BoneRPlay.Join(IntPtr.Zero/*needInstanceGUID*/, remoteAddress.Text);


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


            dplayRegisteredLabel.Text = $"registered: {IsRegisteredAtAll}";
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

        bool IsRegisteredAtAll
        {
            get
            {
                return (Registry.GetValue(RegistryFinalRoot, "Guid", null)!=null);
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
    }
}
