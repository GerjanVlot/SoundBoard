using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AudioDashboard.Common
{
    public class Keyboard : IDisposable
    {

        private static Keyboard _instance;

        public static Keyboard Instance => _instance ?? (_instance = new Keyboard());

        public event EventHandler<KeyEventArgs> KeyPress; 

        // Structure contain information about low-level keyboard input event 
        [StructLayout(LayoutKind.Sequential)]
        private struct KbDllHookStruct
        {
            public readonly Keys key;
            public readonly int scanCode;
            public readonly int flags;
            public readonly int time;
            public readonly IntPtr extra;
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string name);

        private static IntPtr _ptrHook;
        private static LowLevelKeyboardProc _callback;

        private Keyboard()
        {
            _callback = new LowLevelKeyboardProc(CaptureKey);
            ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
            _ptrHook = SetWindowsHookEx(13, _callback, GetModuleHandle(objCurrentModule.ModuleName), 0);
        }

        private IntPtr CaptureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            if (nCode >= 0)
            {
                var objKeyInfo = (KbDllHookStruct)Marshal.PtrToStructure(lp, typeof(KbDllHookStruct));

                KeyPress?.Invoke(this, new KeyEventArgs(objKeyInfo.key));
            }

            return CallNextHookEx(_ptrHook, nCode, wp, lp);
        }
        
        public void Dispose()
        {
            UnhookWindowsHookEx(_ptrHook);
        }
    }
}