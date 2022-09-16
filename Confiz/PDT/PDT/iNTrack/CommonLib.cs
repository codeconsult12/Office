using Resco.Controls.MessageBox;
using Resco.UIElements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace iNTrack
{
    public static class CommonLib
    {
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            DataTable dataTable;
            try
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                DataTable dataTable1 = new DataTable();
                foreach (PropertyDescriptor property in properties)
                {
                    dataTable1.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
                }
                foreach (T datum in data)
                {
                    DataRow dataRow = dataTable1.NewRow();
                    foreach (PropertyDescriptor propertyDescriptor in properties)
                    {
                        DataRow dataRow1 = dataRow;
                        string name = propertyDescriptor.Name;
                        object value = propertyDescriptor.GetValue(datum);
                        if (value == null)
                        {
                            value = DBNull.Value;
                        }
                        dataRow1[name] = value;
                    }
                    dataTable1.Rows.Add(dataRow);
                }
                dataTable = dataTable1;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public static void CreateCustomTitleControl(string Title, Form CurrentForm)
        {
            try
            {
                TitleControl titleControl = new TitleControl(Title)
                {
                    Dock = DockStyle.Top,
                    Location = new Point(0, 0)
                };
                if (!(CurrentForm.AutoScaleDimensions == new SizeF(96f, 96f)))
                {
                    titleControl.Size = new Size(240, 20);
                }
                else
                {
                    titleControl.Size = new Size(240, 10);
                }
                titleControl.TabIndex = 20;
                titleControl.Font = new Font("Tahoma", 8f, FontStyle.Bold);
                titleControl.ForeColor = Color.Black;
                titleControl.BackColor = CurrentForm.BackColor;
                titleControl.Visible = true;
                CurrentForm.Controls.Add(titleControl);
                CurrentForm.Refresh();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static string Decrypt(string Key, string Content)
        {
            string str;
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(Key);
                byte[] numArray = new byte[] { 18, 52, 86, 120, 144, 171, 205, 239 };
                byte[] numArray1 = new byte[Content.Length + 1];
                numArray1 = Convert.FromBase64String(Content);
                MemoryStream memoryStream = new MemoryStream();
                try
                {
                    DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, numArray), CryptoStreamMode.Write);
                    cryptoStream.Write(numArray1, 0, (int)numArray1.Length);
                    cryptoStream.FlushFinalBlock();
                    Encoding uTF8 = Encoding.UTF8;
                    byte[] array = memoryStream.ToArray();
                    long length = memoryStream.Length;
                    str = uTF8.GetString(array, 0, int.Parse(length.ToString()));
                }
                finally
                {
                    if (memoryStream != null)
                    {
                        ((IDisposable)memoryStream).Dispose();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        public static void DisplayErrorMessage(Exception ex)
        {
            Cursor.Current = Cursors.Default;
            InteropLib.PlaySound(string.Concat(Property.ProgramPath, Path.DirectorySeparatorChar, "Error.wav"));
            MessageBoxEx.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        }

        public static void DisplaySuccessMessage(Exception ex)
        {
            Cursor.Current = Cursors.Default;
            InteropLib.PlaySound(string.Concat(Property.ProgramPath, Path.DirectorySeparatorChar, "Success.wav"));
            MessageBoxEx.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        }

        public static string Encrypt(string Key, string Content)
        {
            string base64String;
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(Key);
                byte[] numArray = new byte[] { 18, 52, 86, 120, 144, 171, 205, 239 };
                byte[] bytes1 = Encoding.UTF8.GetBytes(Content);
                MemoryStream memoryStream = new MemoryStream();
                try
                {
                    DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, numArray), CryptoStreamMode.Write);
                    cryptoStream.Write(bytes1, 0, (int)bytes1.Length);
                    cryptoStream.FlushFinalBlock();
                    base64String = Convert.ToBase64String(memoryStream.ToArray());
                }
                finally
                {
                    if (memoryStream != null)
                    {
                        ((IDisposable)memoryStream).Dispose();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return base64String;
        }

        public static string FormatString(string Value)
        {
            string str;
            try
            {
                str = (!string.IsNullOrEmpty(Value) ? Value.Replace("'", "''").Trim() : string.Empty);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        public static byte[] GetDataInByte(string FilePath)
        {
            byte[] numArray;
            try
            {
                if (!File.Exists(FilePath))
                {
                    numArray = null;
                }
                else
                {
                    FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                    try
                    {
                        byte[] numArray1 = new byte[checked((IntPtr)fileStream.Length)];
                        fileStream.Read(numArray1, 0, (int)fileStream.Length);
                        numArray = numArray1;
                    }
                    finally
                    {
                        if (fileStream != null)
                        {
                            ((IDisposable)fileStream).Dispose();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return numArray;
        }

        public static string GetDataInText(string FilePath)
        {
            string empty;
            try
            {
                if (!File.Exists(FilePath))
                {
                    empty = string.Empty;
                }
                else
                {
                    StreamReader streamReader = new StreamReader(FilePath);
                    try
                    {
                        empty = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        if (streamReader != null)
                        {
                            ((IDisposable)streamReader).Dispose();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return empty;
        }

        public static DataTable GetFalshDirectories()
        {
            DataTable dataTable;
            string[] strArrays;
            try
            {
                DataTable dataTable1 = new DataTable();
                dataTable1.Columns.Add("Directory");
                string[] directories = Directory.GetDirectories("\\");
                for (int i = 0; i < (int)directories.Length; i++)
                {
                    string str = directories[i];
                    if (((new DirectoryInfo(str)).Attributes & FileAttributes.Temporary) == FileAttributes.Temporary)
                    {
                        DataRowCollection rows = dataTable1.Rows;
                        strArrays = new string[] { str };
                        rows.Add(strArrays);
                    }
                }
                if (((int)dataTable1.Select("Directory = 'FlashDisk'").Length != 0 ? false : Directory.Exists("FlashDisk")))
                {
                    DataRowCollection dataRowCollection = dataTable1.Rows;
                    strArrays = new string[] { "FlashDisk" };
                    dataRowCollection.Add(strArrays);
                }
                dataTable = dataTable1;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public static void PlayNotification(Exception ex)
        {
            Cursor.Current = Cursors.Default;
            InteropLib.PlaySound(string.Concat(Property.ProgramPath, Path.DirectorySeparatorChar, "Success.wav"));
            MessageBoxEx.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        }

        public static void SetDropDown(string DisplayMember, string ValueMember, object DataSource, UIComboBox ComboBox)
        {
            try
            {
                ComboBox.set_DisplayMember(DisplayMember);
                ComboBox.set_ValueMember(ValueMember);
                ComboBox.set_DataSource(DataSource);
                ComboBox.set_SelectedIndex(-1);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void SetLocalTime(DateTime value)
        {
            try
            {
                InteropLib.SYSTEMTIME sYSTEMTIME = new InteropLib.SYSTEMTIME()
                {
                    Year = (short)value.Year,
                    Month = (short)value.Month,
                    DayOfWeek = (short)value.DayOfWeek,
                    Day = (short)value.Day,
                    Hour = (short)value.Hour,
                    Minute = (short)value.Minute,
                    Second = (short)value.Second,
                    Milliseconds = (short)value.Millisecond
                };
                InteropLib.SetLocalTime(ref sYSTEMTIME);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void SwitchForm(Form NewForm)
        {
            try
            {
                NewForm.Show();
                if (Property.ActiveForm.Tag != Property.PrincipalForm.Tag)
                {
                    Property.ActiveForm.Dispose();
                    Property.ActiveForm.Close();
                }
                else
                {
                    Property.ActiveForm.Hide();
                }
                Property.ActiveForm = NewForm;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public enum ConnStatus
        {
            Open,
            Close
        }

        public enum ExecMode
        {
            Scalar,
            NonQuery,
            Query,
            ResultSet
        }

        public enum TransStatus
        {
            Begin,
            Commit,
            Rollback
        }
    }
}