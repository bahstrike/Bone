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
    public partial class Options : Form
    {
        public enum DetermineIPMethod
        {
            OFF,
            ipinfo,
            whatismyipaddress,
            icanhazip
        }


        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {

            // try to load from registry
            jkExePath.Text = AppRegistry.EXEPath;


            AppRegistry.CmdLine cmd = AppRegistry.CommandLine;
            argWindowGui.Checked = (cmd & AppRegistry.CmdLine.windowgui) != 0;
            argDevmode.Checked = (cmd & AppRegistry.CmdLine.devmode) != 0;
            argFrameRate.Checked = (cmd & AppRegistry.CmdLine.framerate) != 0;
            argDispStats.Checked = (cmd & AppRegistry.CmdLine.dispstats) != 0;
            argNoHud.Checked = (cmd & AppRegistry.CmdLine.nohud) != 0;



            DetermineIPMethod ipmethod;
            if (!Enum.TryParse<DetermineIPMethod>(Program.ConfigINI.GetKey("Bone", "DetermineIPMethod", "ipinfo"), true, out ipmethod))
                ipmethod = DetermineIPMethod.OFF;

            showIp.SelectedIndex = (int)ipmethod;
        }

        private void jkExeBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Locate JK.EXE";
            ofd.FileName = jkExePath.Text;
            ofd.Filter = "Executable File (*.exe)|*.exe";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            if (!File.Exists(ofd.FileName))
                return;

            jkExePath.Text = ofd.FileName;
        }

        private void jkExePath_TextChanged(object sender, EventArgs e)
        {
            jkpathGood.BackColor = File.Exists(jkExePath.Text) ? Color.SpringGreen : Color.Tomato;
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            // write back to registry

            AppRegistry.EXEPath = jkExePath.Text;


            AppRegistry.CmdLine cmd = 0;
            if (argWindowGui.Checked)
                cmd |= AppRegistry.CmdLine.windowgui;
            if (argDevmode.Checked)
                cmd |= AppRegistry.CmdLine.devmode;
            if (argFrameRate.Checked)
                cmd |= AppRegistry.CmdLine.framerate;
            if (argDispStats.Checked)
                cmd |= AppRegistry.CmdLine.dispstats;
            if (argNoHud.Checked)
                cmd |= AppRegistry.CmdLine.nohud;
            AppRegistry.CommandLine = cmd;





            DetermineIPMethod ipmethod = (DetermineIPMethod)showIp.SelectedIndex;
            Program.ConfigINI.WriteKey("Bone", "DetermineIPMethod", ipmethod.ToString());
        }

        private void enableDplayDISM_Click(object sender, EventArgs e)
        {
            Process.Start("dism.exe", "/Online /enable-feature /FeatureName:\"LegacyComponents\" /NoRestart").WaitForExit();
            Process.Start("dism.exe", "/Online /enable-feature /FeatureName:\"DirectPlay\" /NoRestart").WaitForExit();
        }
    }
}
