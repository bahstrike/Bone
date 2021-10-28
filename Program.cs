using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.IO;
using System.Reflection;

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

        public static string ExecutableDirectory
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }

        public static string INIPath
        {
            get
            {
                return Path.Combine(ExecutableDirectory, "Bone.ini");
            }
        }
        public static bool HadNoConfigINI = false;
        public static Smith.INIFile ConfigINI = null;

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
                MessageBox.Show("This program does not work unless run as Administrator.", "Bone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


            HadNoConfigINI = !System.IO.File.Exists(INIPath);
            ConfigINI = new Smith.INIFile(INIPath);

            Application.Run(new Form1());

            ConfigINI.Dispose();
        }
    }
}
