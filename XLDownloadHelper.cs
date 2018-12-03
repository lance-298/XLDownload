using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XunleiDownloadDemo
{
    public class XLApiDownloadHelper
    {
        private const string dllName = "xldl.dll";
        public XLApiDownloadHelper()
        {
            if (System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\XL"))
            {
                Win32API.LoadDllFile(AppDomain.CurrentDomain.BaseDirectory + "\\XL", dllName);
            }
        }

    }
}
