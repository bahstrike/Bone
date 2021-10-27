using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;

namespace Bone
{
    static class Program
    {
        public static bool IsRunningAsAdministrator
        {
            get
            {
                return (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if(!IsRunningAsAdministrator)
            {
                MessageBox.Show("This program does not work unless run as Administrator");
                return;
            }

            string[] args = Environment.GetCommandLineArgs();
            for(int i=1; i<args.Length; i++)
            {
                string arg = args[i];

                if(arg.Equals("-test", StringComparison.InvariantCultureIgnoreCase))
                {
                    BoneRPlay.test();

                    // just bail after done invoking test func
                    return;
                }
            }

            Application.Run(new Form1());
        }
    }
}
