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
        public const int WM_USER = 0x400;
        public const int WM_CLOSE = 0x10;
        public const int WM_GETTEXT = 0x000D;
        public const int WM_SETTEXT = 0x000C;
        public const int WM_KEYDOWN = 0x100;
        public const int WM_SHOWWINDOW = 0x18;//当隐藏或显示窗口是发送此消息给这个窗口

        public const int STANDARD_RIGHTS_REQUIRED = 0xF0000;
        public const int SYNCHRONIZE = 0x100000;
        public const int PROCESS_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFF;
        public const int PROCESS_TERMINATE = 0x1;

        public const int PROCESS_VM_OPERATION = 0x8;
        public const int PROCESS_VM_READ = 0x10;
        public const int PROCESS_VM_WRITE = 0x20;

        public const int MEM_RESERVE = 0x2000;
        public const int MEM_COMMIT = 0x1000;
        public const int MEM_RELEASE = 0x8000;

        public const int PAGE_READWRITE = 0x4;

        public const int TB_BUTTONCOUNT = (WM_USER + 24);
        public const int TB_HIDEBUTTON = (WM_USER + 4);
        public const int TB_GETBUTTON = (WM_USER + 23);
        public const int TB_GETBUTTONTEXT = WM_USER + 75;
        public const int TB_GETBITMAP = (WM_USER + 44);
        public const int TB_DELETEBUTTON = (WM_USER + 22);
        public const int TB_ADDBUTTONS = (WM_USER + 20);
        public const int TB_INSERTBUTTON = (WM_USER + 21);
        public const int TB_ISBUTTONHIDDEN = (WM_USER + 12);
        public const int ILD_NORMAL = 0x0;
        public const int TPM_NONOTIFY = 0x80;

        public const int WS_VISIBLE = 268435456;//窗体可见 
        public const int WS_MINIMIZEBOX = 131072;//有最小化按钮 
        public const int WS_MAXIMIZEBOX = 65536;//有最大化按钮 
        public const int WS_BORDER = 8388608;//窗体有边框 
        public const int GWL_STYLE = (-16);//窗体样式 

        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;

        public const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        public const int APPCOMMAND_VOLUME_UP = 0x0a0000;
        public const int APPCOMMAND_VOLUME_DOWN = 0x090000;
        public const int WM_APPCOMMAND = 0x319;

        public const int GW_HWNDFIRST = 0; //{同级别第一个}
        public const int GW_HWNDLAST = 1; //{同级别最后一个}
        public const int GW_HWNDNEXT = 2; //{同级别下一个}
        public const int GW_HWNDPREV = 3; //{同级别上一个}
        public const int GW_OWNER = 4; //{属主窗口}
        public const int GW_CHILD = 5; // {子窗口}

        public const int WM_SIZE = 0;

        public const int GWL_EXSTYLE = (-20);
        public const int WS_POPUP = 0x80000;
        public const int WS_CLIPCHILDREN = 0x020000;

        //

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("User32.Dll")]
        public static extern void GetClassName(IntPtr hwnd, StringBuilder s, int nMaxCount);

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow", SetLastError = true)]
        public static extern void SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll", EntryPoint = "GetDlgItem", SetLastError = true)]
        public static extern IntPtr GetDlgItem(int nID, IntPtr phWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int RegisterWindowMessage(string msg);

        [DllImport("kernel32", EntryPoint = "OpenProcess")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, IntPtr bInheritHandle, IntPtr dwProcessId);

        [DllImport("kernel32", EntryPoint = "CloseHandle")]
        public static extern int CloseHandle(IntPtr hObject);

        [DllImport("user32", EntryPoint = "GetWindowThreadProcessId")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hwnd, ref IntPtr lpdwProcessId);

        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int PostThreadMessage(int threadId, uint msg, int wParam, int lParam);

        //[return: MarshalAs(UnmanagedType.Bool)]
        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern bool PostThreadMessage(uint threadId, uint msg, UIntPtr wParam, IntPtr lParam);

        [DllImport("user32", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32", EntryPoint = "ReadProcessMemory")]
        public static extern int ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref IntPtr lpBuffer, int nSize, int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemoryEx(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);

        [DllImport("kernel32", EntryPoint = "ReadProcessMemory")]
        public static extern int ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, int lpNumberOfBytesWritten);

        [DllImport("kernel32", EntryPoint = "WriteProcessMemory")]
        public static extern int WriteProcessMemory(IntPtr hProcess, ref int lpBaseAddress, ref int lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

        [DllImport("kernel32", EntryPoint = "VirtualAllocEx")]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, int lpAddress, int dwSize, int flAllocationType, int flProtect);

        [DllImport("kernel32", EntryPoint = "VirtualFreeEx")]
        public static extern int VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, int dwFreeType);

        [DllImport("User32.dll")]
        public extern static int GetWindow(int hWnd, int wCmd);

        [DllImport("User32.dll")]
        public extern static int GetWindowLongA(int hWnd, int wIndx);

        [DllImport("user32.dll")]
        public static extern bool GetWindowText(int hWnd, StringBuilder title, int maxBufSize);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static int GetWindowTextLength(IntPtr hWnd);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="hWnd">希望控制的窗体句柄</param>
        /// <param name="nCmdShow">ShowWindow 的第二参数， 1 表示显示， 0 表示隐藏</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        /// <summary>
        /// 禁用窗体
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="fEnable"></param>
        /// <returns></returns>
        [DllImport("user32.dll ", EntryPoint = "EnableWindow")]
        public static extern int EnableWindow(IntPtr hwnd, bool fEnable);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hWndInsertAfter">hWndInsertAfter的可能取值 功能某一窗口的句柄 将窗口放在该句柄指定的窗口后面 HWND_BOTTOM(1) 把窗口放在Z轴的最后，即所有窗口的后面 HWND_TOP(0) 将窗口放在Z轴的前面，即所有窗口的前面 HWND_TOPMOST(-1) 使窗口成为“TopMost”类型的窗口，这种类型 的窗口总是在其它窗口的前面，真到它被关闭 HWND_NOTOPMOST(-2) 将窗口放在所有“TopMost”类型</param>
        /// <param name="x">x 相当于窗口的Left属性</param>
        /// <param name="Y">相当于窗口的Top属性</param>
        /// <param name="cx">相当于窗口的Right属性</param>
        /// <param name="cy">相当于窗口的Bottom属性</param>
        /// <param name="wFlags">如何移动窗口的标记 SWP_DRAWFRAME(&H20) 移动窗口后重画窗口及其上的所有内容 SWP_SHOWWINDOW(&H40) 显示窗口 SWP_NOZORDER(&H4) 不改变窗口听Z轴位置（即忽略hWndInsertAfter参数）SWP_NOREDRAW(&H8) SWP_NOSIZE(&H1) 不改变窗口尺寸（即忽略Cx和Cy参数）SWP_NOMOVE(&H2) 不移动窗口（即忽略X和Y参数）SWP_NOCOPYBITS(&H100) 当窗口移动后，不重画它上面的任何内容SWP_NOACTIVATE(&H10) 窗口移动后不激活窗口，当然，如果窗口在移动前就是激活的则例外 SWP_HIDEWINDOW(&H80) 隐藏窗口，窗口隐藏后既不出现在屏幕上也不出现在任务栏上，但它仍然处于激活状态 SWP_DRAWFRAME(&H20) 移动窗口后重画窗口及其上的所有内容</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        [DllImport("user32.dll", EntryPoint = "SetParent")]
        public static extern IntPtr SetParent(IntPtr hWnd, IntPtr hParentWnd);

        [DllImport("user32.dll", EntryPoint = "SetWindowRgn")]
        public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, int redraw);

        //[DllImport("Gdi32.dll", EntryPoint = "CreateRectRgnIndirect")]
        //public static extern IntPtr CreateRectRgnIndirect(ref Rectangle rect);
        /// <summary>
        /// 区域合成
        /// </summary>
        /// <param name="dest">{合成后的区域}</param>
        /// <param name="src1">{两个原始区域 1}</param>
        /// <param name="src2">{两个原始区域 2}</param>
        /// <param name="mode">合并选项 RGN_AND  = 1;RGN_OR   = 2; RGN_XOR  = 3;RGN_DIFF = 4; RGN_COPY = 5; {复制第一个区域}</param>
        /// <returns>{有四种可能的返回值 ERROR = 0; {错误} NULLREGION = 1; {空区域} SIMPLEREGION = 2; {单矩形区域}COMPLEXREGION = 3; {多矩形区域}}</returns>
        [DllImport("Gdi32.dll", EntryPoint = "CombineRgn")]
        public static extern int CombineRgn(IntPtr dest, IntPtr src1, IntPtr src2, int mode);

        [DllImport("Gdi32.dll", EntryPoint = "CombineRgn")]
        public static extern int DeleteObject(IntPtr obj);

        [DllImport("user32.dll", EntryPoint = "GetCapture")]
        public static extern IntPtr GetCapture();

        [DllImport("user32.dll", EntryPoint = "SetCapture")]
        public static extern IntPtr SetCapture(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        public static extern int ReleaseCapture(IntPtr hwnd);

        public static void SetVideo(IntPtr iPtr, IntPtr pPtr, int width, int height)
        {
            Win32API.SetParent(iPtr, pPtr);
            Win32API.SetWindowPos(iPtr, (IntPtr)0, 0, 0, width, height, 0x0040);
            Win32API.EnableWindow(iPtr, true);
        }

        /// <summary>
        /// 动画显示/隐藏窗体
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="dwTime">动画时长</param>
        /// <param name="dwFlags">动画参数（动画方式 | 隐藏/激活 | 动画方向）</param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        /// <summary>
        /// 播放声音
        /// </summary>
        /// <param name="pszSound"></param>
        /// <param name="hmod"></param>
        /// <param name="fdwSound"></param>
        /// <returns></returns>
        [DllImport("winmm.dll", EntryPoint = "PlaySound")]
        public static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hwnd, out RECT lpRect);
        public struct RECT
        {
            public int Left; //最左坐标
            public int Top; //最上坐标
            public int Right; //最右坐标
            public int Bottom; //最下坐标
        }
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
