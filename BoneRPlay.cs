using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Bone
{
    public static class BoneRPlay
    {
        const string DLLFile = "BoneRPlay.dll";

        public enum Result : int
        {
            Success,
            NoDirectPlay,
            AppNotRegistered,
            CantCreateProcess,
            UnknownFailure,
        }

        [Flags]
        public enum MatchFlags
        {
            UseTimeLimit = 8,
            UseScoreLimit = 16,
            SingleLevelOnly = 128,
            TeamPlay = 259//256
        }

        public class SessionInfo
        {
            public Guid guidInstance;
            public int maxPlayers;
            public int curPlayers;
            public string sessionName;
            public uint user1;
            public uint user2;
            public uint user3;
            public uint user4;

            private void SplitSessionValues(out string name, out string gobfile, out string jklfile)
            {
                string[] sessionValues = sessionName.Split(':');
                if(sessionValues.Length != 3)
                {
                    name = string.Empty;
                    gobfile = string.Empty;
                    jklfile = string.Empty;
                    return;
                }

                name = sessionValues[0];
                gobfile = sessionValues[1] + ".gob";
                jklfile = sessionValues[2];
            }

            public string SessionName
            {
                get
                {
                    string name, gobfile, jklfile;
                    SplitSessionValues(out name, out gobfile, out jklfile);

                    return name;
                }
            }

            public string GOBFile
            {
                get
                {
                    string name, gobfile, jklfile;
                    SplitSessionValues(out name, out gobfile, out jklfile);

                    return gobfile;
                }
            }

            public string JKLFile
            {
                get
                {
                    string name, gobfile, jklfile;
                    SplitSessionValues(out name, out gobfile, out jklfile);

                    return jklfile;
                }
            }

            public MatchFlags MatchFlags
            {
                get
                {
                    return (MatchFlags)user2;
                }
            }

            public int TickRateMSEC
            {
                get
                {
                    return (int)user4;
                }
            }
        }

        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall, EntryPoint = "QuerySession")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool _QuerySession(string szAddress, string szPassword, out Guid pGuidInstance, out int pnMaxPlayers, out int pnCurPlayers, IntPtr wcSessionName, out uint puUser1, out uint puUser2, out uint puUser3, out uint puUser4);
        public static SessionInfo QuerySession(string szAddress, string szPassword=null)
        {
            SessionInfo info = new SessionInfo();

            IntPtr pSessionName = Marshal.AllocHGlobal(512);

            try
            {
                if (_QuerySession(szAddress, szPassword, out info.guidInstance, out info.maxPlayers, out info.curPlayers, pSessionName, out info.user1, out info.user2, out info.user3, out info.user4))
                {
                    info.sessionName = Marshal.PtrToStringUni(pSessionName);
                }
                else
                    // bad query;  dont return anything
                    return null;


                // if host is setting up or loading or something, but session is not ready,  all values are 0 except
                // GUID is valid, and curPlayers=1.  lets check for this and pretend like we didnt get anything
                if (info.maxPlayers <= 0)
                    return null;


                return info;
            }
            finally
            {
                Marshal.FreeHGlobal(pSessionName);
            }
        }


        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall)]
        public static extern void Shutdown();

        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall)]
        public static extern Result Host();

        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall)]
        public static extern Result Join(ref Guid pInstanceGUID, string szAddresss, string szPassword=null);

        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HasGameExited();

        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall)]
        public static extern void test();
    }
}
