using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XunleiDownloadDemo
{
    public class Win32API
    {       
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetDllDirectory(string lpPathName);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int GetDllDirectory(int bufsize, StringBuilder buf);

        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr LoadLibrary(string librayName);

        public static void LoadDllFile(string dllfolder, string libname)
        {
            //var currentpath = new StringBuilder(255);
            //GetDllDirectory(currentpath.Length, currentpath);

            // use new path
            SetDllDirectory(dllfolder);

            LoadLibrary(libname);

            // restore old path
            //SetDllDirectory(currentpath.ToString());

        }
    }
}
