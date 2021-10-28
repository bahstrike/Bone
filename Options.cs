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


            // pick sensible defaults if first run?
            string defaultIPMethod = "off";
            if(Program.HadNoConfigINI)
            {
                argWindowGui.Checked = true;// this usually helps fix ppl.. so default on;  i mean they can turn off
                defaultIPMethod = "ipinfo";// most ppl prolly want to see their external IP without havin to look externally;  i mean they can turn off

                // search steam folder for path?   otherwise we just leave blank, and its up to them

            }


            DetermineIPMethod ipmethod;
            if (!Enum.TryParse<DetermineIPMethod>(Program.ConfigINI.GetKey("Bone", "DetermineIPMethod", defaultIPMethod), true, out ipmethod))
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
            if (!File.Exists(jkExePath.Text))
            {
                if (Program.HadNoConfigINI)
                {
                    if (MessageBox.Show("Closing Options without a valid EXE will exit the program.", "Bone", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    {
                        e.Cancel = true;
                        return;
                    }

                    // if its first launch then we should just exit without doing anything to INI or registry;  leave no trace.. maybe dude doesnt care yet
                    Program.WantQuit = true;
                    return;
                }


                MessageBox.Show("Closing Options without a valid EXE will render this application useless.", "Bone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            DetermineIPMethod ipmethod = (DetermineIPMethod)showIp.SelectedIndex;
            Program.ConfigINI.WriteKey("Bone", "DetermineIPMethod", ipmethod.ToString());


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

        }

        private void enableDplayDISM_Click(object sender, EventArgs e)
        {
            Process.Start("dism.exe", "/Online /enable-feature /FeatureName:\"LegacyComponents\" /NoRestart").WaitForExit();
            Process.Start("dism.exe", "/Online /enable-feature /FeatureName:\"DirectPlay\" /NoRestart").WaitForExit();
        }
    }
}
