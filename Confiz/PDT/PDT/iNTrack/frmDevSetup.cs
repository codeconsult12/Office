using iNTrack.iNTrackService;
using Resco.Controls.CommonControls;
using Resco.Controls.MessageBox;
using Resco.UIElements;
using Resco.UIElements.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Net;
using System.Web.Services.Protocols;
using System.Windows.Forms;

namespace iNTrack
{
    public class frmDevSetup : Form
    {
        private IContainer components = null;

        private UIElementPanelControl pnlForm;

        private ToolbarControl tbcMenu;

        private ToolbarItem tbiBack;

        private ToolbarItem tbiSave;

        private UILabel lblDeviceName;

        private UILabel lblDeviceID;

        private UIComboBox cmbLocation;

        private UILabel lblLocation;

        private UIComboBox cmbDataPath;

        private UILabel lblDataPath;

        private UITextBox txtDeviceName;

        private UITextBoxButton btnDeviceName;

        private UILabel lblTimeZone;

        private UIComboBox cmbTimeZone;

        private UILabel lblURL;

        private UITextBox txtURL;

        private UITextBoxButton btnURL;

        private UITextBox txtDeviceID;

        private UITextBoxButton btnDeviceID;

        private UIComboBox cmbCompany;

        private UILabel lblCompany;

        public frmDevSetup()
        {
            this.InitializeComponent();
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int width = bounds.Width;
            bounds = Screen.PrimaryScreen.Bounds;
            base.Size = new Size(width, bounds.Height);
            this.AutoScroll = false;
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (this.cmbCompany.get_SelectedIndex() > -1)
                    {
                        Service service = new Service();
                        try
                        {
                            service.Url = this.txtURL.get_Text().Trim();
                            string[] str = new string[] { "Location_3000", this.cmbCompany.get_SelectedValue().ToString(), "%" };
                            CommonLib.SetDropDown("Name", "Code", service.GetData(str).Tables[0], this.cmbLocation);
                            this.cmbLocation.set_SelectedValue(Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString());
                            this.cmbLocation.Focus();
                        }
                        finally
                        {
                            if (service != null)
                            {
                                ((IDisposable)service).Dispose();
                            }
                        }
                    }
                }
                catch (WebException webException)
                {
                    CommonLib.DisplayErrorMessage(new Exception("Server not found"));
                }
                catch (Exception exception)
                {
                    CommonLib.DisplayErrorMessage(exception);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void cmbDataPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.cmbDataPath.get_SelectedIndex() > -1)
                    {
                        this.cmbTimeZone.Focus();
                    }
                }
                catch (Exception exception)
                {
                    CommonLib.DisplayErrorMessage(exception);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void cmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.cmbLocation.get_SelectedIndex() > -1)
                    {
                        this.txtDeviceID.Focus();
                    }
                }
                catch (Exception exception)
                {
                    CommonLib.DisplayErrorMessage(exception);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if ((!disposing ? false : this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmDevSetup_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.txtURL.set_Text(Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString());
                    this.txtDeviceID.set_Text(Property.Configuration.Tables[0].Rows[0]["DeviceID"].ToString());
                    this.txtDeviceName.set_Text(Property.Configuration.Tables[0].Rows[0]["DeviceName"].ToString());
                    CommonLib.SetDropDown("Directory", "Directory", CommonLib.GetFalshDirectories(), this.cmbDataPath);
                    this.cmbDataPath.set_SelectedValue(Property.DataPath);
                    CommonLib.SetDropDown("DisplayName", "StandardName", OpenNETCFLib.GetTimeZoneInfo(), this.cmbTimeZone);
                    this.cmbTimeZone.set_SelectedValue(Property.Configuration.Tables[0].Rows[0]["TimeZoneName"].ToString());
                    if (Property.IsDeviceConfigured)
                    {
                        this.GetCompanyList();
                    }
                    this.txtURL.SelectAll();
                    this.txtURL.Focus();
                }
                catch (WebException webException)
                {
                    CommonLib.DisplayErrorMessage(new Exception("Server not found"));
                }
                catch (Exception exception)
                {
                    CommonLib.DisplayErrorMessage(exception);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void GetCompanyList()
        {
            try
            {
                Service service = new Service();
                try
                {
                    service.Url = this.txtURL.get_Text().Trim();
                    string[] strArrays = new string[] { "Company_3000" };
                    DataTable item = service.GetData(strArrays).Tables[0];
                    strArrays = new string[] { "Company_3000" };
                    CommonLib.SetDropDown("Name", "Code", service.GetData(strArrays).Tables[0], this.cmbCompany);
                    this.cmbCompany.set_SelectedValue(Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString());
                }
                finally
                {
                    if (service != null)
                    {
                        ((IDisposable)service).Dispose();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void InitializeComponent()
        {
            this.tbcMenu = new ToolbarControl();
            this.tbiBack = new ToolbarItem();
            this.tbiSave = new ToolbarItem();
            this.pnlForm = new UIElementPanelControl();
            this.lblDeviceName = new UILabel();
            this.lblDeviceID = new UILabel();
            this.txtDeviceID = new UITextBox();
            this.btnDeviceID = new UITextBoxButton();
            this.cmbLocation = new UIComboBox();
            this.lblLocation = new UILabel();
            this.cmbDataPath = new UIComboBox();
            this.lblDataPath = new UILabel();
            this.txtDeviceName = new UITextBox();
            this.btnDeviceName = new UITextBoxButton();
            this.lblTimeZone = new UILabel();
            this.cmbTimeZone = new UIComboBox();
            this.lblURL = new UILabel();
            this.txtURL = new UITextBox();
            this.btnURL = new UITextBoxButton();
            this.cmbCompany = new UIComboBox();
            this.lblCompany = new UILabel();
            this.pnlForm.SuspendElementLayout();
            base.SuspendLayout();
            this.tbcMenu.set_ArrowsTransparency(0);
            this.tbcMenu.BackColor = Color.Black;
            this.tbcMenu.set_BmpArrowNext(imgManager.GetImage("iNTrack.Arrow Right2"));
            this.tbcMenu.set_BmpArrowPrevious(imgManager.GetImage("iNTrack.Arrow Left2"));
            this.tbcMenu.BorderStyle = BorderStyle.FixedSingle;
            this.tbcMenu.Dock = DockStyle.Bottom;
            this.tbcMenu.set_EnableArrowsTransparency(false);
            this.tbcMenu.ForeColor = Color.Black;
            this.tbcMenu.get_Items().Add(this.tbiBack);
            this.tbcMenu.get_Items().Add(this.tbiSave);
            this.tbcMenu.set_ItemsAlignment(4);
            this.tbcMenu.set_ItemSpacing(5);
            this.tbcMenu.Location = new Point(0, 244);
            this.tbcMenu.Name = "tbcMenu";
            this.tbcMenu.Size = new Size(318, 50);
            this.tbcMenu.set_StretchBackgroundImage(true);
            this.tbcMenu.TabIndex = 7;
            this.tbcMenu.add_SelectionChanged(new EventHandler(this.tbcMenu_SelectionChanged));
            this.tbiBack.set_BackColor(Color.Black);
            this.tbiBack.set_CustomSize(new Size(0, 0));
            this.tbiBack.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Left"));
            this.tbiBack.set_Name("tbiBack");
            this.tbiBack.set_ToolbarItemBehavior(2);
            this.tbiSave.set_BackColor(Color.Black);
            this.tbiSave.set_CustomSize(new Size(0, 0));
            this.tbiSave.set_ImageDefault(imgManager.GetImage("iNTrack.Save"));
            this.tbiSave.set_Name("tbiSave");
            this.tbiSave.set_ToolbarItemBehavior(2);
            this.pnlForm.set_BackgroundImage(imgManager.GetImage("iNTrack.BGP"));
            this.pnlForm.set_BackgroundImageLayout(6);
            this.pnlForm.get_Children().Add(this.lblDeviceName);
            this.pnlForm.get_Children().Add(this.lblDeviceID);
            this.pnlForm.get_Children().Add(this.txtDeviceID);
            this.pnlForm.get_Children().Add(this.cmbLocation);
            this.pnlForm.get_Children().Add(this.lblLocation);
            this.pnlForm.get_Children().Add(this.cmbDataPath);
            this.pnlForm.get_Children().Add(this.lblDataPath);
            this.pnlForm.get_Children().Add(this.txtDeviceName);
            this.pnlForm.get_Children().Add(this.lblTimeZone);
            this.pnlForm.get_Children().Add(this.cmbTimeZone);
            this.pnlForm.get_Children().Add(this.lblURL);
            this.pnlForm.get_Children().Add(this.txtURL);
            this.pnlForm.get_Children().Add(this.cmbCompany);
            this.pnlForm.get_Children().Add(this.lblCompany);
            this.pnlForm.Dock = DockStyle.Fill;
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new Size(318, 294);
            this.pnlForm.TabIndex = 8;
            this.lblDeviceName.set_AutoSize(false);
            this.lblDeviceName.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblDeviceName.set_Layout(new ElementLayout(0, 0, 5, 113, 0, 0, 82, 26));
            this.lblDeviceName.set_Name("lblDeviceName");
            this.lblDeviceName.set_TabIndex(3);
            this.lblDeviceName.set_Text("Device Name");
            this.lblDeviceName.set_TextAlignment(2);
            this.lblDeviceID.set_AutoSize(false);
            this.lblDeviceID.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblDeviceID.set_Layout(new ElementLayout(0, 0, 5, 86, 0, 0, 82, 26));
            this.lblDeviceID.set_Name("lblDeviceID");
            this.lblDeviceID.set_TabIndex(3);
            this.lblDeviceID.set_Text("Device ID");
            this.lblDeviceID.set_TextAlignment(2);
            this.txtDeviceID.get_Buttons().Add(this.btnDeviceID);
            this.txtDeviceID.set_Layout(new ElementLayout(HAlignment.Right, 0, 87, 86, 5, 0, 226, 26));
            this.txtDeviceID.set_MaxLength(4);
            this.txtDeviceID.set_Name("txtDeviceID");
            this.txtDeviceID.set_TabIndex(4);
            this.txtDeviceID.set_Tag("Device ID");
            this.txtDeviceID.add_KeyPress(new KeyPressEventHandler(this.txtDeviceID_KeyPress));
            this.btnDeviceID.set_Action(1);
            this.btnDeviceID.set_BackColor(Color.Transparent);
            this.btnDeviceID.set_BorderThickness(0);
            this.btnDeviceID.set_HorizontalAlignment(2);
            this.btnDeviceID.set_Name("btnDeviceID");
            this.btnDeviceID.get_PressedBackground().set_BackColor(Color.Transparent);
            this.btnDeviceID.set_Size(new Size(18, 18));
            this.btnDeviceID.set_StateIcon(2);
            this.btnDeviceID.set_VisibleMode(1);
            this.cmbLocation.set_BackColor(SystemColors.Window);
            this.cmbLocation.set_DropDownWidth(200);
            this.cmbLocation.set_Layout(new ElementLayout(3, 0, 87, 59, 5, 0, 226, 26));
            this.cmbLocation.set_Name("cmbLocation");
            this.cmbLocation.set_TabIndex(3);
            this.cmbLocation.add_SelectedIndexChanged(new EventHandler(this.cmbLocation_SelectedIndexChanged));
            this.lblLocation.set_AutoSize(false);
            this.lblLocation.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblLocation.set_Layout(new ElementLayout(0, 0, 5, 59, 0, 0, 82, 26));
            this.lblLocation.set_Name("lblLocation");
            this.lblLocation.set_TabIndex(4);
            this.lblLocation.set_Text("Location");
            this.lblLocation.set_TextAlignment(2);
            this.cmbDataPath.set_BackColor(SystemColors.Window);
            this.cmbDataPath.set_DropDownWidth(200);
            this.cmbDataPath.set_Layout(new ElementLayout(3, 0, 87, 140, 5, 0, 226, 26));
            this.cmbDataPath.set_Name("cmbDataPath");
            this.cmbDataPath.set_TabIndex(6);
            this.cmbDataPath.add_SelectedIndexChanged(new EventHandler(this.cmbDataPath_SelectedIndexChanged));
            this.lblDataPath.set_AutoSize(false);
            this.lblDataPath.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblDataPath.set_Layout(new ElementLayout(0, 0, 5, 140, 0, 0, 82, 26));
            this.lblDataPath.set_Name("lblDataPath");
            this.lblDataPath.set_TabIndex(5);
            this.lblDataPath.set_Text("Data Path");
            this.lblDataPath.set_TextAlignment(2);
            this.txtDeviceName.get_Buttons().Add(this.btnDeviceName);
            this.txtDeviceName.set_Layout(new ElementLayout(3, 0, 87, 113, 5, 0, 226, 26));
            this.txtDeviceName.set_Name("txtDeviceName");
            this.txtDeviceName.set_TabIndex(5);
            this.txtDeviceName.set_Tag("Device Name");
            this.txtDeviceName.add_KeyUp(new KeyEventHandler(this.txtDeviceName_KeyUp));
            this.btnDeviceName.set_Action(1);
            this.btnDeviceName.set_BackColor(Color.Transparent);
            this.btnDeviceName.set_BorderThickness(0);
            this.btnDeviceName.set_HorizontalAlignment(2);
            this.btnDeviceName.set_Name("btnDeviceName");
            this.btnDeviceName.get_PressedBackground().set_BackColor(Color.Transparent);
            this.btnDeviceName.set_Size(new Size(18, 18));
            this.btnDeviceName.set_StateIcon(2);
            this.btnDeviceName.set_VisibleMode(1);
            this.lblTimeZone.set_AutoSize(false);
            this.lblTimeZone.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblTimeZone.set_Layout(new ElementLayout(0, 0, 5, 167, 0, 0, 82, 26));
            this.lblTimeZone.set_Name("lblTimeZone");
            this.lblTimeZone.set_TabIndex(5);
            this.lblTimeZone.set_Text("Time Zone");
            this.lblTimeZone.set_TextAlignment(2);
            this.cmbTimeZone.set_BackColor(SystemColors.Window);
            this.cmbTimeZone.set_DropDownWidth(230);
            this.cmbTimeZone.set_Layout(new ElementLayout(3, 0, 87, 167, 5, 0, 226, 26));
            this.cmbTimeZone.set_Name("cmbTimeZone");
            this.cmbTimeZone.set_TabIndex(7);
            this.lblURL.set_AutoSize(false);
            this.lblURL.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblURL.set_Layout(new ElementLayout(0, 0, 5, 5, 0, 0, 75, 26));
            this.lblURL.set_Name("lblURL");
            this.lblURL.set_TabIndex(4);
            this.lblURL.set_Text("Service URL");
            this.lblURL.set_TextAlignment(2);
            this.txtURL.get_Buttons().Add(this.btnURL);
            this.txtURL.set_Layout(new ElementLayout(3, 0, 87, 5, 5, 0, 226, 26));
            this.txtURL.set_Name("txtURL");
            this.txtURL.set_TabIndex(8);
            this.txtURL.set_Tag("");
            this.txtURL.add_KeyUp(new KeyEventHandler(this.txtURL_KeyUp));
            this.btnURL.set_Action(1);
            this.btnURL.set_BackColor(Color.Transparent);
            this.btnURL.set_BorderThickness(0);
            this.btnURL.set_HorizontalAlignment(2);
            this.btnURL.set_Name("btnURL");
            this.btnURL.get_PressedBackground().set_BackColor(Color.Transparent);
            this.btnURL.set_Size(new Size(18, 18));
            this.btnURL.set_StateIcon(2);
            this.btnURL.set_VisibleMode(1);
            this.cmbCompany.set_BackColor(SystemColors.Window);
            this.cmbCompany.set_Layout(new ElementLayout(3, 0, 87, 32, 5, 0, 226, 26));
            this.cmbCompany.set_Name("cmbCompany");
            this.cmbCompany.set_TabIndex(2);
            this.cmbCompany.set_Tag("");
            this.cmbCompany.add_SelectedIndexChanged(new EventHandler(this.cmbCompany_SelectedIndexChanged));
            this.lblCompany.set_AutoSize(false);
            this.lblCompany.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblCompany.set_Layout(new ElementLayout(0, 0, 5, 32, 0, 0, 75, 26));
            this.lblCompany.set_Name("lblCompany");
            this.lblCompany.set_TabIndex(5);
            this.lblCompany.set_Text("Company");
            this.lblCompany.set_TextAlignment(2);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(318, 294);
            base.ControlBox = false;
            base.Controls.Add(this.tbcMenu);
            base.Controls.Add(this.pnlForm);
            base.MinimizeBox = false;
            base.Name = "frmDevSetup";
            base.Tag = "Device Setup";
            this.Text = ":: Device Setup";
            base.Load += new EventHandler(this.frmDevSetup_Load);
            this.pnlForm.ResumeElementLayout(false);
            base.ResumeLayout(false);
        }

        private void tbcMenu_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (this.tbcMenu.get_SelectedIndex() == 0)
                    {
                        if (!Property.IsDeviceConfigured)
                        {
                            base.Close();
                        }
                        else
                        {
                            CommonLib.SwitchForm(new frmHome());
                        }
                    }
                    else if (this.tbcMenu.get_SelectedIndex() == 1)
                    {
                        if (string.IsNullOrEmpty(this.txtURL.get_Text().Trim()))
                        {
                            this.txtURL.SelectAll();
                            this.txtURL.Focus();
                            throw new Exception("Invalid url");
                        }
                        if (string.IsNullOrEmpty(Convert.ToString(this.cmbCompany.get_SelectedValue())))
                        {
                            this.cmbCompany.Focus();
                            throw new Exception("Invalid company");
                        }
                        if (string.IsNullOrEmpty(Convert.ToString(this.cmbLocation.get_SelectedValue())))
                        {
                            this.cmbLocation.Focus();
                            throw new Exception("Invalid location");
                        }
                        if (string.IsNullOrEmpty(this.txtDeviceID.get_Text().Trim()))
                        {
                            this.txtDeviceID.SelectAll();
                            this.txtDeviceID.Focus();
                            throw new Exception("Invalid device id");
                        }
                        if (!Directory.Exists(this.cmbDataPath.get_Text()))
                        {
                            this.cmbDataPath.Focus();
                            throw new Exception("Invalid data path");
                        }
                        if (string.IsNullOrEmpty(Convert.ToString(this.cmbTimeZone.get_SelectedValue())))
                        {
                            this.cmbTimeZone.Focus();
                            throw new Exception("Invalid time zone");
                        }
                        Service service = new Service();
                        try
                        {
                            service.Url = this.txtURL.get_Text().Trim();
                            try
                            {
                                service.GetServerTime();
                            }
                            catch (Exception exception)
                            {
                                this.txtURL.SelectAll();
                                this.txtURL.Focus();
                                throw new Exception("Error connecting server. Please reconfirm the url before saving");
                            }
                            string[] str = new string[] { "HHT_Setup_3000", this.cmbCompany.get_SelectedValue().ToString() };
                            Property.Setup = service.GetData(str).Tables[0];
                            if (Property.Setup.Rows.Count == 0)
                            {
                                throw new Exception("Setup is missing. Please contact your administrator.");
                            }
                            service.Url = Property.Setup.Rows[0]["iNTrack Web Service URL"].ToString();
                            string deviceID = InteropLib.GetDeviceID();
                            if (string.IsNullOrEmpty(deviceID))
                            {
                                deviceID = InteropLib.GetDeviceID("AP&T-iNTrack");
                            }
                            str = new string[] { "HHT_Register_3000", this.cmbCompany.get_SelectedValue().ToString(), CommonLib.FormatString(this.txtDeviceID.get_Text()) };
                            DataTable item = service.GetData(str).Tables[0];
                            if ((item.Rows.Count <= 0 ? false : (string)item.Rows[0]["MAC Address"] != deviceID))
                            {
                                throw new Exception("Same device id has already been registered");
                            }
                            str = new string[] { "HHT_Register_3001", this.cmbCompany.get_SelectedValue().ToString(), CommonLib.FormatString(deviceID) };
                            item = service.GetData(str).Tables[0];
                            Service service1 = service;
                            str = new string[] { (item.Rows.Count == 0 ? "HHT_Register_1000" : "HHT_Register_4000"), this.cmbCompany.get_SelectedValue().ToString(), CommonLib.FormatString(deviceID), CommonLib.FormatString(this.txtDeviceID.get_Text()), CommonLib.FormatString(this.cmbLocation.get_SelectedValue().ToString()) };
                            service1.SetData(str, new DataSet());
                        }
                        finally
                        {
                            if (service != null)
                            {
                                ((IDisposable)service).Dispose();
                            }
                        }
                        bool flag = (!Property.IsDeviceConfigured ? false : Property.DataPath != this.cmbDataPath.get_Text());
                        Property.Configuration.Tables[0].Rows[0]["SwitchURL"] = this.txtURL.get_Text().Trim();
                        Property.Configuration.Tables[0].Rows[0]["CompanyID"] = this.cmbCompany.get_SelectedValue().ToString();
                        Property.Configuration.Tables[0].Rows[0]["CompanyName"] = this.cmbCompany.get_Text().Trim();
                        Property.Configuration.Tables[0].Rows[0]["LocationID"] = this.cmbLocation.get_SelectedValue().ToString();
                        Property.Configuration.Tables[0].Rows[0]["LocationName"] = this.cmbLocation.get_Text().Trim();
                        Property.Configuration.Tables[0].Rows[0]["IsWHLocation"] = "0";
                        Property.Configuration.Tables[0].Rows[0]["DeviceID"] = this.txtDeviceID.get_Text().Trim();
                        Property.Configuration.Tables[0].Rows[0]["DeviceName"] = this.txtDeviceName.get_Text().Trim();
                        Property.Configuration.Tables[0].Rows[0]["TimeZoneName"] = this.cmbTimeZone.get_SelectedValue().ToString();
                        if (Property.IsDeviceConfigured)
                        {
                            File.Delete(string.Concat(Property.DataPath, Path.DirectorySeparatorChar, "Config.xml"));
                        }
                        Property.Configuration.WriteXml(string.Concat(this.cmbDataPath.get_Text(), Path.DirectorySeparatorChar, "Config.xml"));
                        if (File.Exists(string.Concat(Property.ProgramPath, Path.DirectorySeparatorChar, "Config.xml")))
                        {
                            File.Delete(string.Concat(Property.ProgramPath, Path.DirectorySeparatorChar, "Config.xml"));
                        }
                        File.Copy(string.Concat(this.cmbDataPath.get_Text(), Path.DirectorySeparatorChar, "Config.xml"), string.Concat(Property.ProgramPath, Path.DirectorySeparatorChar, "Config.xml"));
                        string dataPath = Property.DataPath;
                        Property.DataPath = this.cmbDataPath.get_Text();
                        OpenNETCFLib.SetTimeZoneInformation(this.cmbTimeZone.get_SelectedValue().ToString());
                        if (!Property.IsDeviceConfigured)
                        {
                            iNTrackLib.CreateDB();
                            Property.IsDeviceConfigured = true;
                            base.Close();
                        }
                        else
                        {
                            if (flag)
                            {
                                File.Move(string.Concat(dataPath, Path.DirectorySeparatorChar, "Data.sdf"), string.Concat(Property.DataPath, Path.DirectorySeparatorChar, "Data.sdf"));
                                SqlCeLib.sqlCeConn.ConnectionString = string.Format("Data Source={0};Password=a1pntbs1365*;Max Database Size=1000;", string.Concat(Property.DataPath, Path.DirectorySeparatorChar, "Data.sdf"));
                            }
                            Cursor.Current = Cursors.Default;
                            MessageBoxEx.Show("Settings saved", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
                catch (WebException webException)
                {
                    CommonLib.DisplayErrorMessage(new Exception("Server not found"));
                }
                catch (Exception exception1)
                {
                    CommonLib.DisplayErrorMessage(exception1);
                }
            }
            finally
            {
                this.tbcMenu.set_SelectedIndex(-1);
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtDeviceID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                try
                {
                    if (!char.IsLetterOrDigit(e.KeyChar))
                    {
                        int keyChar = e.KeyChar;
                        if (keyChar == 8)
                        {
                            e.Handled = false;
                        }
                        else if (keyChar != 13)
                        {
                            e.Handled = true;
                        }
                        else if (!string.IsNullOrEmpty(this.txtDeviceID.get_Text().Trim()))
                        {
                            this.txtDeviceName.SelectAll();
                            this.txtDeviceName.Focus();
                        }
                    }
                }
                catch (Exception exception)
                {
                    CommonLib.DisplayErrorMessage(exception);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtDeviceName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (!string.IsNullOrEmpty(this.txtDeviceName.get_Text().Trim()))
                        {
                            this.cmbDataPath.Focus();
                        }
                    }
                }
                catch (Exception exception)
                {
                    CommonLib.DisplayErrorMessage(exception);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtURL_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if ((e.KeyCode != Keys.Enter ? false : !string.IsNullOrEmpty(this.txtURL.get_Text().Trim())))
                    {
                        this.GetCompanyList();
                        this.cmbCompany.Focus();
                    }
                }
                catch (WebException webException)
                {
                    CommonLib.DisplayErrorMessage(new Exception("Server not found"));
                }
                catch (Exception exception)
                {
                    CommonLib.DisplayErrorMessage(exception);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}