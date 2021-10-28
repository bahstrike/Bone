using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;

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

        static void ExtractFile(string filename, bool replace = true)
        {
            if (replace && File.Exists(filename))
            {
                try
                {
                    File.Delete(filename);
                }
                catch
                {
                    //Log.Warning($"Could not update {filename}; might be in use");
                    return;
                }
            }

            Stream file = null;
            try
            {
                file = Assembly.GetExecutingAssembly().GetManifestResourceStream("Bone." + filename);
            }
            catch
            {

            }

            if (file == null)
            {
                //Log.Error("Could not extract " + filename);
            }
            else
                using (BinaryReader br = new BinaryReader(file))
                    File.WriteAllBytes(filename, br.ReadBytes((int)file.Length));
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

        public static bool WantQuit = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!IsRunningAsAdministrator)
            {
                MessageBox.Show("This program does not work unless run as Administrator.", "Bone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ExtractFile("BoneRPlay.dll");



                // handle single switch cmdline args (no params)
                string[] args = Environment.GetCommandLineArgs();
                for (int i = 1; i < args.Length; i++)
                {
                    string arg = args[i];
                    if (arg.Length < 1)
                        continue;

                    if (arg[0] != '-' && arg[0] != '/')
                        continue;

                    arg = arg.Substring(1).ToLowerInvariant();
                    switch(arg)
                    {
                        case "?":
                        case "help":
                            MessageBox.Show(
                                "-help : this message\n"
                                + "-unregister : remove directplay registry folder for jedi knight\n"
                                //+ "-test : development use\n"
                                , "Bone", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;

                        case "unregister":
                            AppRegistry.UnregisterAll();
                            MessageBox.Show("Unregistered Jedi Knight from DirectPlay registry.", "Bone", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;

                        case "test":
                            BoneRPlay.test();
                            return;
                    }

                }




                HadNoConfigINI = !System.IO.File.Exists(INIPath);
                ConfigINI = new Smith.INIFile(INIPath);

                Application.Run(new Form1());

                ConfigINI.Dispose();
            }
            finally
            {
                // only try to delete files if we're the only process running  (just to avoid annoying exception during debugging)
                List<Process> boneProcesses = new List<Process>();
                boneProcesses.AddRange(Process.GetProcessesByName("Bone.vshost"));
                boneProcesses.AddRange(Process.GetProcessesByName("Bone"));
                if (boneProcesses.Count <= 1)
                {
                    Process p = Process.GetCurrentProcess();
                    List<string> allDllsToCleanup = new List<string>(new string[] { "BoneRPlay.dll" });
                    foreach (string dllfile in allDllsToCleanup)
                    {
                        if (string.IsNullOrEmpty(dllfile))
                            continue;

                        foreach (ProcessModule m in p.Modules)
                        {
                            if (!string.IsNullOrEmpty(m.ModuleName) && m.ModuleName.Equals(dllfile, StringComparison.InvariantCultureIgnoreCase))
                            {
                                try
                                {
                                    FreeLibrary(m.BaseAddress);
                                }
                                catch
                                {

                                }
                                break;
                            }
                        }

                        try
                        {
                            File.Delete(dllfile);
                        }
                        catch
                        {

                        }
                    }

                }
            }
        }

        [DllImport("kernel32", SetLastError = true)]
        static extern bool FreeLibrary(IntPtr hModule);
    }
}
