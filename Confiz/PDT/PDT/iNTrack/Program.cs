namespace iNTrack
{
    using System;
    using System.Collections;
    using System.Data;
    using System.IO;
    using System.Windows.Forms;

    internal static class Program
    {
        private static bool CheckForLicense()
        {
            try
            {
                if (!File.Exists(Property.DataPath + Path.DirectorySeparatorChar + "iNTrack.lic"))
                {
                    throw new Exception("Product not activated");
                }
                string content = null;
                StreamReader objA = new StreamReader(Property.DataPath + Path.DirectorySeparatorChar + "iNTrack.lic");
                try
                {
                    content = objA.ReadToEnd();
                }
                finally
                {
                    if (!ReferenceEquals(objA, null))
                    {
                        objA.Dispose();
                    }
                }
                string str2 = CommonLib.Decrypt("apnttnpa", content);
                string deviceID = InteropLib.GetDeviceID();
                if (string.IsNullOrEmpty(deviceID))
                {
                    deviceID = InteropLib.GetDeviceID("AP&T-iNTrack");
                }
                if (str2.Substring(str2.IndexOf('|') + 1) != deviceID)
                {
                    throw new Exception("Invalid license");
                }
                return true;
            }
            catch (Exception exception1)
            {
                CommonLib.DisplayErrorMessage(exception1);
                return false;
            }
        }

        [MTAThread]
        private static void Main()
        {
            try
            {
                if (InteropLib.IsProgramRunning("iNTrack"))
                {
                    throw new Exception("Another instance running");
                }
                ReadAppConfig();
                if (!Property.IsDeviceConfigured)
                {
                    frmDevSetup mainForm = new frmDevSetup();
                    Property.PrincipalForm = mainForm;
                    Property.ActiveForm = mainForm;
                    Application.Run(mainForm);
                }
                else if (CheckForLicense())
                {
                    frmLogin mainForm = new frmLogin();
                    Property.PrincipalForm = mainForm;
                    Property.ActiveForm = mainForm;
                    Application.Run(mainForm);
                }
                else
                {
                    frmLicense mainForm = new frmLicense();
                    Property.PrincipalForm = mainForm;
                    Property.ActiveForm = mainForm;
                    Application.Run(mainForm);
                }
            }
            catch (Exception exception1)
            {
                CommonLib.DisplayErrorMessage(exception1);
            }
        }

        private static void ReadAppConfig()
        {
            try
            {
                string path = Property.ProgramPath + Path.DirectorySeparatorChar + "Config.xml";
                IEnumerator enumerator = CommonLib.GetFalshDirectories().Rows.GetEnumerator();
                try
                {
                    while (true)
                    {
                        bool flag = enumerator.MoveNext();
                        if (flag)
                        {
                            DataRow current = (DataRow) enumerator.Current;
                            if (!File.Exists(current["Directory"].ToString() + Path.DirectorySeparatorChar + "Data.sdf"))
                            {
                                continue;
                            }
                            Property.IsDeviceConfigured = true;
                            Property.DataPath = current["Directory"].ToString();
                            if (File.Exists(current["Directory"].ToString() + Path.DirectorySeparatorChar + "Config.xml"))
                            {
                                flag = !File.Exists(path);
                                if (!flag)
                                {
                                    File.Delete(path);
                                }
                                File.Copy(current["Directory"].ToString() + Path.DirectorySeparatorChar + "Config.xml", path);
                            }
                            path = current["Directory"].ToString() + Path.DirectorySeparatorChar + "Config.xml";
                        }
                        break;
                    }
                }
                finally
                {
                    IDisposable objA = enumerator as IDisposable;
                    if (!ReferenceEquals(objA, null))
                    {
                        objA.Dispose();
                    }
                }
                if (!File.Exists(path))
                {
                    throw new Exception("Config file not found");
                }
                Property.Configuration.ReadXml(path);
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
        }
    }
}

