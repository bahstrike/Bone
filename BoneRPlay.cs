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

        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall)]
        public static extern void QuerySession(string szAddress);

        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall)]
        public static extern void Shutdown();

        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Host();

        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Join(IntPtr pInstanceGUID, string szAddresss);

        [DllImport(DLLFile, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HasGameExited();


    }
}
