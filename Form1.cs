using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


            //BoneRPlay.Join(needInstanceGUID, remoteAddress.Text);


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
            detectGameLabel.Text = $"active game: {(!BoneRPlay.HasGameExited()?"YES":"NO")}";

        }
    }
}
