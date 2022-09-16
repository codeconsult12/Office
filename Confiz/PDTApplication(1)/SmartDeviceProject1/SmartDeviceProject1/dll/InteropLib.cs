using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace iNTrack
{
    public static class InteropLib
    {
        public const long ERROR_ALREADY_EXISTS = 183L;

        private const string CRLF = "\r\n";

        private const int POWER_NAME = 1;

        private const int ERROR_NOT_SUPPORTED = 50;

        private const int ERROR_INSUFFICIENT_BUFFER = 122;

        private const int WH_KEYBOARD_LL = 20;

        private static int FILE_DEVICE_HAL;

        private static int FILE_ANY_ACCESS;

        private static int METHOD_BUFFERED;

        private static int IOCTL_HAL_GET_DEVICEID;

        private static uint SPI_GETPLATFORMTYPE;

        public static InteropLib.HookEventHandler delegHookEventHandler;

        static InteropLib()
        {
            InteropLib.FILE_DEVICE_HAL = 257;
            InteropLib.FILE_ANY_ACCESS = 0;
            InteropLib.METHOD_BUFFERED = 0;
            InteropLib.IOCTL_HAL_GET_DEVICEID = InteropLib.FILE_DEVICE_HAL << 16 | InteropLib.FILE_ANY_ACCESS << 14 | 84 | InteropLib.METHOD_BUFFERED;
            InteropLib.SPI_GETPLATFORMTYPE = 257;
        }

        [DllImport("coredll.dll", CharSet = CharSet.Unicode)]
        private static extern int AllKeys(bool bEnable);

        [DllImport("coredll.dll", CharSet = CharSet.Unicode,  SetLastError = true)]
        private static extern int CallNextHookEx(InteropLib.HookProc hhk, int nCode, IntPtr wParam, IntPtr lParam);

        private static InteropLib.Platform CheckWinCEPlatform()
        {
            InteropLib.Platform platform = InteropLib.Platform.WindowsCE;
            StringBuilder stringBuilder = new StringBuilder(200);
            InteropLib.SystemParametersInfo(InteropLib.SPI_GETPLATFORMTYPE, 200, stringBuilder, 0);
            string str = stringBuilder.ToString();
            if (str != null)
            {
                if (str == "PocketPC")
                {
                    platform = InteropLib.Platform.PocketPC;
                }
                else if (str == "SmartPhone")
                {
                    platform = InteropLib.Platform.Smartphone;
                }
            }
            return platform;
        }

        [DllImport("coredll.dll" , SetLastError = true)]
        private static extern IntPtr CreateMutex(IntPtr MutexAttributes, bool InitialOwner, string Name);

        private static int CTL_CODE(int DeviceType, int Function, int Method, int Access)
        {
            int deviceType = DeviceType << 16 | Access << 14 | Function << 2 | Method;
            return deviceType;
        }

        [DllImport("coredll.dll" , SetLastError = true)]
        private static extern IntPtr DestroyWindow(IntPtr WindowHandle);

        [DllImport("coredll.dll" , SetLastError = true)]
        private static extern IntPtr FindWindow(IntPtr ClassName, string WindowName);

        public static int GetBackupBatteryLifePercent()
        {
            int backupBatteryLifePercent;
            try
            {
                InteropLib.SYSTEM_POWER_STATUS_EX2 sYSTEMPOWERSTATUSEX2 = new InteropLib.SYSTEM_POWER_STATUS_EX2();
                if (InteropLib.GetSystemPowerStatusEx2(sYSTEMPOWERSTATUSEX2, (uint)Marshal.SizeOf(sYSTEMPOWERSTATUSEX2), false) != Marshal.SizeOf(sYSTEMPOWERSTATUSEX2))
                {
                    backupBatteryLifePercent = 0;
                }
                else
                {
                    backupBatteryLifePercent = sYSTEMPOWERSTATUSEX2.BackupBatteryLifePercent;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return backupBatteryLifePercent;
        }

        public static string GetDeviceID(string AppName)
        {
            string str;
            try
            {
                byte[] appName = new byte[AppName.Length];
                for (int i = 0; i < AppName.Length; i++)
                {
                    appName[i] = (byte)AppName[i];
                }
                byte[] numArray = new byte[20];
                uint num = 20;
                InteropLib.GetDeviceUniqueID(appName, (int)appName.Length, 1, numArray, out num);
                string str1 = "";
                for (int j = 0; j < (int)numArray.Length; j++)
                {
                    str1 = ((j == 4 || j == 6 || j == 8 ? false : j != 10) ? string.Format("{0}{1}", str1, numArray[j].ToString("x2")) : string.Format("{0}-{1}", str1, numArray[j].ToString("x2")));
                }
                str = str1;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        public static string GetDeviceID()
        {
            string str;
            byte[] numArray = new byte[256];
            int length = (int)numArray.Length;
            int num = 0;
            if (InteropLib.KernelIoControl(InteropLib.CTL_CODE(InteropLib.FILE_DEVICE_HAL, 21, InteropLib.METHOD_BUFFERED, InteropLib.FILE_ANY_ACCESS), IntPtr.Zero, 0, numArray, length, ref num))
            {
                int num1 = BitConverter.ToInt32(numArray, 4);
                int num2 = BitConverter.ToInt32(numArray, 12);
                int num3 = BitConverter.ToInt32(numArray, 16);
                StringBuilder stringBuilder = new StringBuilder();
                object[] objArray = new object[] { BitConverter.ToInt32(numArray, num1), BitConverter.ToInt16(numArray, num1 + 4), BitConverter.ToInt16(numArray, num1 + 6), BitConverter.ToInt16(numArray, num1 + 8) };
                stringBuilder.Append(string.Format("{0:X8}-{1:X4}-{2:X4}-{3:X4}-", objArray));
                for (int i = num2; i < num2 + num3; i++)
                {
                    stringBuilder.Append(string.Format("{0:X2}", numArray[i]));
                }
                str = stringBuilder.ToString();
            }
            else
            {
                str = null;
            }
            return str;
        }

        [DllImport("coredll.dll" )]
        private static extern int GetDeviceUniqueID([In][Out] byte[] appdata, int cbApplictionData, int dwDeviceIDVersion, [In][Out] byte[] deviceIDOuput, out uint pcbDeviceIDOutput);

        [DllImport("coredll.dll" )]
        private static extern IntPtr GetForegroundWindow();

        public static int GetMainBatteryLifePercent()
        {
            int batteryLifePercent;
            try
            {
                InteropLib.SYSTEM_POWER_STATUS_EX sYSTEMPOWERSTATUSEX = new InteropLib.SYSTEM_POWER_STATUS_EX();
                if (InteropLib.GetSystemPowerStatusEx(sYSTEMPOWERSTATUSEX, false) != 1)
                {
                    batteryLifePercent = 0;
                }
                else
                {
                    batteryLifePercent = sYSTEMPOWERSTATUSEX.BatteryLifePercent;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return batteryLifePercent;
        }

        public static string GetMemoryStatus()
        {
            string str;
            try
            {
                InteropLib.MEMORYSTATUS mEMORYSTATU = new InteropLib.MEMORYSTATUS()
                {
                    dwLength = Marshal.SizeOf(mEMORYSTATU)
                };
                InteropLib.GlobalMemoryStatus(ref mEMORYSTATU);
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Memory Load = ");
                stringBuilder.Append(string.Concat(mEMORYSTATU.dwMemoryLoad.ToString(), "%"));
                stringBuilder.Append("\r\n");
                stringBuilder.Append("Total RAM = ");
                stringBuilder.Append(mEMORYSTATU.dwTotalPhys.ToString("#,##0"));
                stringBuilder.Append("\r\n");
                stringBuilder.Append("Avail RAM = ");
                stringBuilder.Append(mEMORYSTATU.dwAvailPhys.ToString("#,##0"));
                stringBuilder.Append("\r\n");
                stringBuilder.Append("Total Page = ");
                stringBuilder.Append(mEMORYSTATU.dwTotalPageFile.ToString("#,##0"));
                stringBuilder.Append("\r\n");
                stringBuilder.Append("Avail Page = ");
                stringBuilder.Append(mEMORYSTATU.dwAvailPageFile.ToString("#,##0"));
                stringBuilder.Append("\r\n");
                stringBuilder.Append("Total Virt = ");
                stringBuilder.Append(mEMORYSTATU.dwTotalVirtual.ToString("#,##0"));
                stringBuilder.Append("\r\n");
                stringBuilder.Append("Avail Virt = ");
                stringBuilder.Append(mEMORYSTATU.dwAvailVirtual.ToString("#,##0"));
                str = stringBuilder.ToString();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        [DllImport("coredll.dll", CharSet = CharSet.Unicode , SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string MODS);

        public static InteropLib.Platform GetPlatform()
        {
            InteropLib.Platform platform = InteropLib.Platform.Unknown;
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32S:
                    {
                        platform = InteropLib.Platform.Win32S;
                        break;
                    }
                case PlatformID.Win32Windows:
                    {
                        platform = InteropLib.Platform.Win32Windows;
                        break;
                    }
                case PlatformID.Win32NT:
                    {
                        platform = InteropLib.Platform.Win32NT;
                        break;
                    }
                case PlatformID.WinCE:
                    {
                        platform = InteropLib.CheckWinCEPlatform();
                        break;
                    }
            }
            return platform;
        }

        public static int GetShortestTimeoutInterval()
        {
            int num;
            int num1;
            try
            {
                int num2 = 1000;
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("\\SYSTEM\\CurrentControlSet\\Control\\Power");
                object value = registryKey.GetValue("BattPowerOff");
                object obj = registryKey.GetValue("ExtPowerOff");
                object value1 = registryKey.GetValue("ScreenPowerOff");
                if (value is int)
                {
                    num = (int)value;
                    if (num > 0)
                    {
                        num2 = Math.Min(num2, num);
                    }
                }
                if (obj is int)
                {
                    num = (int)obj;
                    if (num > 0)
                    {
                        num2 = Math.Min(num2, num);
                    }
                }
                if (value1 is int)
                {
                    num = (int)value1;
                    if (num > 0)
                    {
                        num2 = Math.Min(num2, num);
                    }
                }
                num1 = num2 * 9 / 10;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num1;
        }

        [DllImport("coredll" )]
        private static extern uint GetSystemPowerStatusEx(InteropLib.SYSTEM_POWER_STATUS_EX lpSystemPowerStatus, bool fUpdate);

        [DllImport("coredll" )]
        private static extern uint GetSystemPowerStatusEx2(InteropLib.SYSTEM_POWER_STATUS_EX2 lpSystemPowerStatus, uint dwLen, bool fUpdate);

        [DllImport("coredll.dll" )]
        private static extern void GlobalMemoryStatus(ref InteropLib.MEMORYSTATUS lpBuffer);

        public static bool IsProgramRunning(string Name)
        {
            bool lastWin32Error;
            try
            {
                InteropLib.CreateMutex(IntPtr.Zero, true, Name);
                lastWin32Error = (long)Marshal.GetLastWin32Error() == (long)183;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return lastWin32Error;
        }

        [DllImport("coredll.dll" )]
        private static extern bool KernelIoControl(int IoControlCode, IntPtr InputBuffer, int InputBufferSize, byte[] OutputBuffer, int OutputBufferSize, ref int BytesReturned);

        [DllImport("coredll.dll" )]
        private static extern int lineClose(IntPtr hLine);

        [DllImport("coredll.dll" , SetLastError = true)]
        private static extern InteropLib.LineErrReturn lineInitializeEx(out IntPtr hLineApp, IntPtr hAppHandle, IntPtr lCallBack, string FriendlyAppName, out uint NumDevices, ref uint APIVersion, ref InteropLib.LINEINITIALIZEEXPARAMS lineExInitParams);

        [DllImport("coredll.dll" )]
        private static extern int lineNegotiateAPIVersion(IntPtr lphLineApp, int dwDeviceID, int dwAPILowVersion, int dwAPIHighVersion, out int lpdwAPIVersion, out InteropLib.LINEEXTENSIONID lpExtensionID);

        [DllImport("coredll.dll" )]
        private static extern int lineOpen(IntPtr hLineApp, int dwDeviceID, out IntPtr hLine, int dwAPIVersion, int dwExtVersion, int dwCallbackInstance, int dwPrivileges, int dwMediaModes, IntPtr lpCallParams);

        [DllImport("cellcore.dll" )]
        private static extern int lineRegister(IntPtr hLine, int dwRegisterMode, string lpszOperator, int dwOperatorFormat);

        [DllImport("cellcore.dll" )]
        private static extern int lineSetEquipmentState(IntPtr hLine, int dwState);

        [DllImport("coredll.dll" )]
        private static extern int lineShutdown(IntPtr hLine);

        [DllImport("coredll" , SetLastError = true)]
        public static extern int PlaySound(string szSound, IntPtr hModule, int flags);

        public static void PlaySound(string FileName)
        {
            try
            {
                InteropLib.PlaySound(FileName, IntPtr.Zero, 131072);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static unsafe void RecordVoice(string FileName)
        {
            char* chrPointer;
            try
            {
                char[] chrArray = new char[200];
                InteropLib.VOICERECORDER vOICERECORDER = new InteropLib.VOICERECORDER();
                IntPtr intPtr = new IntPtr();
                IntPtr foregroundWindow = InteropLib.GetForegroundWindow();
                Buffer.BlockCopy(FileName.ToCharArray(), 0, chrArray, 0, 2 * FileName.Length);
                try
                {
                    char[] chrArray1 = chrArray;
                    char[] chrArray2 = chrArray1;
                    if (chrArray1 == null || (int)chrArray2.Length == 0)
                    {
                        chrPointer = null;
                    }
                    else
                    {
                        chrPointer = &chrArray2[0];
                    }
                    vOICERECORDER.hwndParent = foregroundWindow;
                    vOICERECORDER.dwStyle = InteropLib.WindowStyle.VRS_MODAL | InteropLib.WindowStyle.VRS_NO_MOVE | InteropLib.WindowStyle.VRS_RECORD_MODE;
                    vOICERECORDER.cb = Marshal.SizeOf(vOICERECORDER);
                    vOICERECORDER.xPos = -1;
                    vOICERECORDER.yPos = -1;
                    vOICERECORDER.lpszRecordFileName = chrPointer;
                }
                finally
                {
                    chrPointer = null;
                }
                intPtr = InteropLib.VoiceRecorder_Create(ref vOICERECORDER);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [DllImport("coredll.dll" , SetLastError = true)]
        private static extern int SetDevicePower(string pvDevice, int dwDeviceFlags, InteropLib.DevicePowerState DeviceState);

        [DllImport("coredll.dll" , SetLastError = true)]
        public static extern bool SetLocalTime(ref InteropLib.SYSTEMTIME Time);

        [DllImport("CoreDLL" )]
        public static extern int SetSystemPowerState(string stateName, InteropLib.PowerState powerState, InteropLib.DevicePowerFlags flags);

        [DllImport("coredll.dll" , SetLastError = true)]
        private static extern bool SetSystemTime(ref InteropLib.SYSTEMTIME Time);

        [DllImport("coredll.dll", CharSet = CharSet.Unicode , SetLastError = true)]
        private static extern int SetWindowsHookEx(int type, InteropLib.HookProc hookProc, IntPtr hInstance, int m);

        public static void SoftResetDevice()
        {
            byte[] numArray = new byte[256];
            int length = (int)numArray.Length;
            int num = 0;
            int num1 = InteropLib.CTL_CODE(InteropLib.FILE_DEVICE_HAL, 15, InteropLib.METHOD_BUFFERED, InteropLib.FILE_ANY_ACCESS);
            InteropLib.KernelIoControl(num1, IntPtr.Zero, 0, numArray, length, ref num);
        }

        [DllImport("coredll" )]
        public static extern int SystemIdleTimerReset();

        [DllImport("coredll.dll" )]
        private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, StringBuilder pvParam, uint fWinIni);

        public static void TogglePhone(int Status)
        {
            uint num;
            int num1;
            InteropLib.LINEEXTENSIONID lINEEXTENSIONID;
            try
            {
                uint num2 = 131072;
                IntPtr zero = IntPtr.Zero;
                IntPtr intPtr = IntPtr.Zero;
                InteropLib.LINEINITIALIZEEXPARAMS lINEINITIALIZEEXPARAM = new InteropLib.LINEINITIALIZEEXPARAMS()
                {
                    hEvent = IntPtr.Zero,
                    dwTotalSize = Marshal.SizeOf(lINEINITIALIZEEXPARAM),
                    dwNeededSize = lINEINITIALIZEEXPARAM.dwTotalSize,
                    dwUsedSize = lINEINITIALIZEEXPARAM.dwTotalSize
                };
                lINEINITIALIZEEXPARAM.hEvent = IntPtr.Zero;
                lINEINITIALIZEEXPARAM.dwOptions = 2;
                InteropLib.lineInitializeEx(out intPtr, IntPtr.Zero, IntPtr.Zero, "deltaProfile", out num, ref num2, ref lINEINITIALIZEEXPARAM);
                InteropLib.lineNegotiateAPIVersion(intPtr, 0, 65540, 131072, out num1, out lINEEXTENSIONID);
                InteropLib.lineOpen(intPtr, 0, out zero, num1, 0, 0, 4, 16, IntPtr.Zero);
                if (Status != 0)
                {
                    InteropLib.lineSetEquipmentState(zero, 5);
                    InteropLib.lineRegister(zero, 1, null, 0);
                }
                else
                {
                    InteropLib.lineSetEquipmentState(zero, 4);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void ToggleWifi(int Status)
        {
            try
            {
                string empty = string.Empty;
                string str = "{98C5250D-C29A-4985-AE5F-AFE5367E5006}";
                string[] valueNames = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\Power\\State", false).GetValueNames();
                int num = 0;
                while (num < (int)valueNames.Length)
                {
                    string str1 = valueNames[num];
                    if (!str1.Contains(str))
                    {
                        num++;
                    }
                    else
                    {
                        empty = str1;
                        break;
                    }
                }
                if (Status != 0)
                {
                    InteropLib.SetDevicePower(empty, 1, InteropLib.DevicePowerState.D0);
                }
                else
                {
                    InteropLib.SetDevicePower(empty, 1, InteropLib.DevicePowerState.D4);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [DllImport("coredll.dll", CharSet = CharSet.Unicode,  SetLastError = true)]
        private static extern int UnhookWindowsHookEx(int idHook);

        [DllImport("voicectl.dll" )]
        private static extern unsafe IntPtr VoiceRecorder_Create(InteropLib.VOICERECORDER* voicerec);

        public enum DevicePowerFlags
        {
            None = 0,
            POWER_NAME = 1,
            POWER_FORCE = 4096,
            POWER_DUMPDW = 8192
        }

        private enum DevicePowerState
        {
            Unspecified = -1,
            D0 = 0,
            D1 = 1,
            D2 = 2,
            D3 = 3,
            D4 = 4
        }

        public class HookEventArgs : EventArgs
        {
            public int Code;

            public IntPtr wParam;

            public IntPtr lParam;

            public HookEventArgs()
            {
            }
        }

        public delegate void HookEventHandler(InteropLib.HookEventArgs e, InteropLib.KeyBoardInfo keyBoardInfo);

        private delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);

        public class KeyBoardInfo
        {
            public int vkCode;

            public int scanCode;

            public int flags;

            public int time;

            public KeyBoardInfo()
            {
            }
        }

        private enum LINEEQUIPSTATE
        {
            LINEEQUIPSTATE_MINIMUM = 1,
            LINEEQUIPSTATE_RXONLY = 2,
            LINEEQUIPSTATE_TXONLY = 3,
            LINEEQUIPSTATE_NOTXRX = 4,
            LINEEQUIPSTATE_FULL = 5
        }

        private enum LineErrReturn : uint
        {
            LINE_OK = 0,
            LINEERR_INIFILECORRUPT = 2147483662,
            LINEERR_INVALAPPNAME = 2147483669,
            LINEERR_INVALPARAM = 2147483698,
            LINEERR_INVALPOINTER = 2147483701,
            LINEERR_NOMEM = 2147483716,
            LINEERR_OPERATIONFAILED = 2147483720,
            LINEERR_REINIT = 2147483730
        }

        private struct LINEEXTENSIONID
        {
            public IntPtr dwExtensionID0;

            public IntPtr dwExtensionID1;

            public IntPtr dwExtensionID2;

            public IntPtr dwExtensionID3;
        }

        private enum LINEINITIALIZEEXOPTION
        {
            LINEINITIALIZEEXOPTION_USEHIDDENWINDOW = 1,
            LINEINITIALIZEEXOPTION_USEEVENT = 2,
            LINEINITIALIZEEXOPTION_USECOMPLETIONPORT = 3
        }

        private struct LINEINITIALIZEEXPARAMS
        {
            public int dwTotalSize;

            public int dwNeededSize;

            public int dwUsedSize;

            public int dwOptions;

            public IntPtr hEvent;

            public int dwCompletionKey;
        }

        private enum LINEOPFORMAT
        {
            LINEOPFORMAT_NONE = 0,
            LINEOPFORMAT_ALPHASHORT = 1,
            LINEOPFORMAT_ALPHALONG = 2,
            LINEOPFORMAT_NUMERIC = 4
        }

        private enum LINEREGMODE
        {
            LINEREGMODE_AUTOMATIC = 1,
            LINEREGMODE_MANUAL = 2,
            LINEREGMODE_MANAUTO = 3
        }

        public struct MEMORYSTATUS
        {
            public int dwLength;

            public int dwMemoryLoad;

            public int dwTotalPhys;

            public int dwAvailPhys;

            public int dwTotalPageFile;

            public int dwAvailPageFile;

            public int dwTotalVirtual;

            public int dwAvailVirtual;
        }

        public enum Platform
        {
            PocketPC,
            WindowsCE,
            Smartphone,
            Win32NT,
            Win32S,
            Win32Windows,
            Unknown
        }

        public enum PowerState
        {
            POWER_STATE_ON = 65536,
            POWER_STATE_OFF = 131072,
            POWER_STATE_CRITICAL = 262144,
            POWER_STATE_BOOT = 524288,
            POWER_STATE_IDLE = 1048576,
            POWER_STATE_SUSPEND = 2097152,
            POWER_STATE_UNATTENDED = 4194304,
            POWER_STATE_RESET = 8388608,
            POWER_STATE_USERIDLE = 16777216,
            POWER_STATE_PASSWORD = 268435456
        }

        public enum SoundFlags
        {
            SND_SYNC = 0,
            SND_ASYNC = 1,
            SND_NODEFAULT = 2,
            SND_MEMORY = 4,
            SND_LOOP = 8,
            SND_NOSTOP = 16,
            SND_PURGE = 64,
            SND_NOWAIT = 8192,
            SND_ALIAS = 65536,
            SND_FILENAME = 131072,
            SND_RESOURCE = 262148,
            SND_ALIAS_ID = 1114112
        }

        public class SYSTEM_POWER_STATUS_EX
        {
            public byte ACLineStatus;

            public byte BatteryFlag;

            public byte BatteryLifePercent;

            public byte Reserved1;

            public uint BatteryLifeTime;

            public uint BatteryFullLifeTime;

            public byte Reserved2;

            public byte BackupBatteryFlag;

            public byte BackupBatteryLifePercent;

            public byte Reserved3;

            public uint BackupBatteryLifeTime;

            public uint BackupBatteryFullLifeTime;

            public SYSTEM_POWER_STATUS_EX()
            {
            }
        }

        public class SYSTEM_POWER_STATUS_EX2
        {
            public byte ACLineStatus;

            public byte BatteryFlag;

            public byte BatteryLifePercent;

            public byte Reserved1;

            public uint BatteryLifeTime;

            public uint BatteryFullLifeTime;

            public byte Reserved2;

            public byte BackupBatteryFlag;

            public byte BackupBatteryLifePercent;

            public byte Reserved3;

            public uint BackupBatteryLifeTime;

            public uint BackupBatteryFullLifeTime;

            public uint BatteryVoltage;

            public uint BatteryCurrent;

            public uint BatteryAverageCurrent;

            public uint BatteryAverageInterval;

            public uint BatterymAHourConsumed;

            public uint BatteryTemperature;

            public uint BackupBatteryVoltage;

            public byte BatteryChemistry;

            public SYSTEM_POWER_STATUS_EX2()
            {
            }
        }

        public struct SYSTEMTIME
        {
            public short Year;

            public short Month;

            public short DayOfWeek;

            public short Day;

            public short Hour;

            public short Minute;

            public short Second;

            public short Milliseconds;
        }

        private struct VOICERECORDER
        {
            public int cb;

            public InteropLib.WindowStyle dwStyle;

            public int xPos;

            public int yPos;

            public IntPtr hwndParent;

            public int id;

            public unsafe char* lpszRecordFileName;
        }

        private enum WindowStyle : uint
        {
            VRS_NO_OKCANCEL = 1,
            VRS_NO_NOTIFY = 2,
            VRS_MODAL = 4,
            VRS_NO_OK = 8,
            VRS_NO_RECORD = 16,
            VRS_PLAY_MODE = 32,
            VRS_NO_MOVE = 64,
            VRS_RECORD_MODE = 128,
            VRS_STOP_DISMISS = 256
        }
    }
}