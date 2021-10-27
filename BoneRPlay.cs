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
        }

        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall, EntryPoint = "QuerySession")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool _QuerySession(string szAddress, string szPassword, out Guid pGuidInstance, out int pnMaxPlayers, out int pnCurPlayers, IntPtr wcSessionName, out uint puUser1, out uint puUser2, out uint puUser3, out uint puUser4);
        public static SessionInfo QuerySession(string szAddress, string szPassword=null)
        {
            SessionInfo info = new SessionInfo();

            IntPtr pSessionName = Marshal.AllocHGlobal(512);

            if (_QuerySession(szAddress, szPassword, out info.guidInstance, out info.maxPlayers, out info.curPlayers, pSessionName, out info.user1, out info.user2, out info.user3, out info.user4))
            {
                info.sessionName = Marshal.PtrToStringUni(pSessionName);
            }
            else
                // bad query;  dont return anything
                info = null;

            Marshal.FreeHGlobal(pSessionName);

            return info;
        }


        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall)]
        public static extern void Shutdown();

        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Host();

        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Join(ref Guid pInstanceGUID, string szAddresss, string szPassword=null);

        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HasGameExited();

        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall)]
        public static extern void test();
    }
}
