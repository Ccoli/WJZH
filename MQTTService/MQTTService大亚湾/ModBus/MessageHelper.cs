using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace ActiveMQAlarmListener
{
    //进程间通过窗口发送消息，主要是像3D客户端发送消息，比如执行某个脚本
   public class MessageHelper
    {
        const int WM_COPYDATA = 0x004A;
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
        //Win32 API函数  
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

        //保存查找到的OSG句柄
        private static IntPtr OsgWindowHwnd = IntPtr.Zero;

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, uint hwndChildAfter, string lpszClass, string classname);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int EnumChildWindows(IntPtr hWndParent, CallBack lpfn, int lParam);

        public delegate bool CallBack(IntPtr hwnd, int lParam);

        /// <summary>
        /// 查找窗体的句柄，包括之窗口
        /// </summary>
        /// <param name="hwnd">父窗体句柄</param>
        /// <param name="classname">窗口类名</param>
        /// <param name="bChild">设定是否在子窗体中查找</param>
        /// <returns>没找到返回IntPtr.Zero</returns>
        public static IntPtr FindWindowEx(IntPtr hwnd, string classname, bool bChild = true)
        {
            IntPtr iResult = IntPtr.Zero;
            // 首先在父窗体上查找控件
            iResult = MessageHelper.FindWindowEx(hwnd, 0, classname, null);
            // 如果找到直接返回控件句柄
            if (iResult != IntPtr.Zero) return iResult;

            // 如果设定了不在子窗体中查找
            if (!bChild) return iResult;
            int count = 0;
            // 枚举子窗体，查找控件句柄
            int i = MessageHelper.EnumChildWindows(
            hwnd,
            (h, l) =>
            {
                count++;
                IntPtr f1 = MessageHelper.FindWindowEx(h, 0, classname, null);
                if (f1 == IntPtr.Zero)
                {
                    //再往下找一次
                    int i2 = MessageHelper.EnumChildWindows(
                    h,
                    (h2, l2) =>
                    {
                        count++;
                        IntPtr f2 = MessageHelper.FindWindowEx(h2, 0, classname, null);
                        if (f2 == IntPtr.Zero)
                            return true;
                        else
                        {
                            iResult = f2;
                            return false;
                        }
                    },
                    0);
                    if (iResult == IntPtr.Zero)
                        return true;
                    else
                        return false;
                }
                else
                {
                    iResult = f1;
                    return false;
                }
            },
            0);
            // 返回查找结果
            return iResult;
        }
        /// <summary>
        /// 查找OSG窗口句柄
        /// </summary>
        /// <returns></returns>
        public static int FindOsgWindowHwnd()
        {
            //若之前已经找到了直接返回
            if (OsgWindowHwnd != IntPtr.Zero)
            {
                //窗口句柄是否还有效，无效则再次查找
                int b = IsWindow(OsgWindowHwnd);
                if(b==1)
                    OsgWindowHwnd.ToInt32();
            }
            //先试下找父亲，再试下找OSG窗口
            OsgWindowHwnd = FindWindow("OSG_PARENT_WINDOW", null);
            if (OsgWindowHwnd == IntPtr.Zero)
            {
                OsgWindowHwnd = FindWindowEx(IntPtr.Zero, "OSGWINDOW");
            }
            return OsgWindowHwnd.ToInt32();
        }

       //发送消息，执行某段脚本代码
       public static bool SendMessageTo3D(string script)
        {
            script = string.Format("<TubyFunction>{0}", script);
            int hwnd = FindOsgWindowHwnd();
            if (hwnd != 0)
            {
                byte[] sarr = System.Text.Encoding.Default.GetBytes(script);
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)Convert.ToInt16("1");//可以是任意值  
                cds.cbData = len + 1;//指定lpData内存区域的字节数  
                cds.lpData =script;//发送给目标窗口所在进程的数据  
                SendMessage(hwnd, WM_COPYDATA, 0, ref cds);
                return true;
            }
            return false;
        }
        //判断3D客户端是否还存在
       public static bool IsExistTuby3D()
       {
           int hwnd = FindOsgWindowHwnd();
           return hwnd != 0;
       }

       //按照日期记录报警日志
        public static void WriteLog(string text)
        {
            StreamWriter file = null;
            try
            {
                string dir = "log";
                if (Directory.Exists(dir) == false)
                {
                    Directory.CreateDirectory(dir);
                }
                file = new StreamWriter(string.Format("log\\alram{0}.log", DateTime.Now.ToString("yyyyMMdd")), true);
                file.AutoFlush = true;
                file.WriteLine(string.Format("\n{0} :{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), text));
                file.Close();
                file.Dispose();
            }
            catch (Exception ex)
            {
                file = null;
            }
        }
    }
}
