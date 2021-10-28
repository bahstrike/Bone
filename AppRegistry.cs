using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace Bone
{
    public static class AppRegistry
    {
        const string Registry_DPlayApps = @"SOFTWARE\Wow6432Node\Microsoft\DirectPlay\Applications";
        const string Registry_AppName = "Jedi Knight 1.0";

        static string RegistryFinalRoot
        {
            get
            {
                return $@"HKEY_LOCAL_MACHINE\{Registry_DPlayApps}\{Registry_AppName}";
            }
        }

        public static string EXEPath
        {
            get
            {
                string path = Registry.GetValue(RegistryFinalRoot, "Path", null) as string;
                string file = Registry.GetValue(RegistryFinalRoot, "File", null) as string;
                if (path == null || file == null)
                    return string.Empty;

                return Path.Combine(path, file);
            }

            set
            {
                string path, file;

                if(string.IsNullOrEmpty(value))
                {
                    path = string.Empty;
                    file = string.Empty;
                } else
                {
                    path = Path.GetDirectoryName(value);
                    file = Path.GetFileName(value);
                }

                Registry.SetValue(RegistryFinalRoot, "File", file);
                Registry.SetValue(RegistryFinalRoot, "Path", path);
                Registry.SetValue(RegistryFinalRoot, "CurrentDirectory", path);
            }
        }

        [Flags]
        public enum CmdLine
        {
            windowgui = 0x01,
            devmode = 0x02,
            framerate = 0x04,
            dispstats = 0x08,
            nohud = 0x10,
        }

        public static CmdLine CommandLine
        {
            get
            {
                string cmdline = Registry.GetValue(RegistryFinalRoot, "CommandLine", string.Empty) as string;
                if (string.IsNullOrEmpty(cmdline))
                    return 0;

                string[] args = cmdline.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                CmdLine c = 0;
                foreach(string arg in args)
                {
                    if (arg.Equals("-windowgui", StringComparison.InvariantCultureIgnoreCase))
                        c |= CmdLine.windowgui;

                    if (arg.Equals("-devmode", StringComparison.InvariantCultureIgnoreCase))
                        c |= CmdLine.devmode;

                    if (arg.Equals("-framerate", StringComparison.InvariantCultureIgnoreCase))
                        c |= CmdLine.framerate;

                    if (arg.Equals("-dispstats", StringComparison.InvariantCultureIgnoreCase))
                        c |= CmdLine.dispstats;

                    if (arg.Equals("-nohud", StringComparison.InvariantCultureIgnoreCase))
                        c |= CmdLine.nohud;
                }

                return c;
            }

            set
            {
                List<string> args = new List<string>();

                if ((value & CmdLine.windowgui) != 0)
                    args.Add("-windowgui");

                if ((value & CmdLine.devmode) != 0)
                    args.Add("-devmode");

                if ((value & CmdLine.framerate) != 0)
                    args.Add("-framerate");

                if ((value & CmdLine.dispstats) != 0)
                    args.Add("-dispstats");

                if ((value & CmdLine.nohud) != 0)
                    args.Add("-nohud");

                string str = string.Empty;
                for(int x=0; x<args.Count; x++)
                {
                    str += args[x];

                    if (x < (args.Count - 1))
                        str += " ";
                }

                Registry.SetValue(RegistryFinalRoot, "CommandLine", str);
            }
        }

        public static bool IsJKRegistered
        {
            get
            {
                if (Registry.GetValue(RegistryFinalRoot, "Guid", null) == null)
                    return false;

                return File.Exists(EXEPath);
            }
        }

        public static void RegisterGUID()
        {
            Registry.SetValue(RegistryFinalRoot, "Guid", "{BF0613C0-DE79-11D0-99C9-00A02476AD4B}");
        }


        public static void UnregisterAll()
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
