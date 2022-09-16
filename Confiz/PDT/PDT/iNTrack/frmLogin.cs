using iNTrack.iNTrackService;
using Resco.Controls.CommonControls;
using Resco.Controls.MessageBox;
using Resco.UIElements;
using Resco.UIElements.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Web.Services.Protocols;
using System.Windows.Forms;

namespace iNTrack
{
    public class frmLogin : Form
    {
        private IContainer components = null;

        private UIElementPanelControl pnlForm;

        private ToolbarControl tbcMenu;

        private ToolbarItem tbiLogin;

        private ToolbarItem tbiExit;

        private UITextBox txtUserCode;

        private UITextBoxButton btnUserID;

        private UILabel lblUserCode;

        private UITextBox txtPassword;

        private UITextBoxButton btnPassword;

        private UILabel lblPassword;

        private UIImage pcbUser;

        private UILabel lblHeader;

        private UIImage pcbLogo;

        private UILabel lblCC2;

        private UILabel lblCC1;

        private UILabel lblDeviceID;

        private UILabel lblVersion;

        public frmLogin()
        {
            this.InitializeComponent();
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int width = bounds.Width;
            bounds = Screen.PrimaryScreen.Bounds;
            base.Size = new Size(width, bounds.Height);
            this.AutoScroll = false;
        }

        protected override void Dispose(bool disposing)
        {
            if ((!disposing ? false : this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    OpenNETCFLib.SetTimeZoneInformation(Property.Configuration.Tables[0].Rows[0]["TimeZoneName"].ToString());
                    SqlCeLib.ConnectionString = string.Format("Data Source={0};Password=a1pntbs1365*;Max Database Size=1000;", string.Concat(Property.DataPath, Path.DirectorySeparatorChar, "Data.sdf"));
                    this.lblVersion.set_Text(string.Format("v{0}", Property.ApplicationVersion));
                    this.lblDeviceID.set_Text(string.Format("Device ID {0}", Property.Configuration.Tables[0].Rows[0]["DeviceID"].ToString()));
                    this.txtUserCode.Focus();
                }
                catch (Exception exception)
                {
                    CommonLib.DisplayErrorMessage(exception);
                    base.Close();
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void InitializeComponent()
        {
            this.tbcMenu = new ToolbarControl();
            this.tbiLogin = new ToolbarItem();
            this.tbiExit = new ToolbarItem();
            this.pnlForm = new UIElementPanelControl();
            this.txtUserCode = new UITextBox();
            this.btnUserID = new UITextBoxButton();
            this.lblUserCode = new UILabel();
            this.txtPassword = new UITextBox();
            this.btnPassword = new UITextBoxButton();
            this.lblPassword = new UILabel();
            this.pcbUser = new UIImage();
            this.lblHeader = new UILabel();
            this.pcbLogo = new UIImage();
            this.lblCC2 = new UILabel();
            this.lblCC1 = new UILabel();
            this.lblDeviceID = new UILabel();
            this.lblVersion = new UILabel();
            this.pnlForm.SuspendElementLayout();
            base.SuspendLayout();
            this.tbcMenu.set_ArrowsTransparency(0);
            this.tbcMenu.BackColor = Color.Black;
            this.tbcMenu.BorderStyle = BorderStyle.FixedSingle;
            this.tbcMenu.Dock = DockStyle.Bottom;
            this.tbcMenu.set_EnableArrowsTransparency(false);
            this.tbcMenu.get_Items().Add(this.tbiLogin);
            this.tbcMenu.get_Items().Add(this.tbiExit);
            this.tbcMenu.set_ItemsAlignment(4);
            this.tbcMenu.set_ItemSpacing(5);
            this.tbcMenu.Location = new Point(0, 244);
            this.tbcMenu.Name = "tbcMenu";
            this.tbcMenu.Size = new Size(318, 50);
            this.tbcMenu.TabIndex = 2;
            this.tbcMenu.add_SelectionChanged(new EventHandler(this.tbcMenu_SelectionChanged));
            this.tbiLogin.set_BackColor(Color.Black);
            this.tbiLogin.set_CustomSize(new Size(0, 0));
            this.tbiLogin.set_ImageDefault(imgManager.GetImage("iNTrack.Go In"));
            this.tbiLogin.set_Name("tbiLogin");
            this.tbiLogin.set_ToolbarItemBehavior(2);
            this.tbiExit.set_BackColor(Color.Black);
            this.tbiExit.set_CustomSize(new Size(0, 0));
            this.tbiExit.set_ImageDefault(imgManager.GetImage("iNTrack.Standby"));
            this.tbiExit.set_Name("tbiExit");
            this.tbiExit.set_ToolbarItemBehavior(2);
            this.pnlForm.set_BackgroundImage(imgManager.GetImage("iNTrack.BGP"));
            this.pnlForm.set_BackgroundImageLayout(6);
            this.pnlForm.get_Children().Add(this.txtUserCode);
            this.pnlForm.get_Children().Add(this.lblUserCode);
            this.pnlForm.get_Children().Add(this.txtPassword);
            this.pnlForm.get_Children().Add(this.lblPassword);
            this.pnlForm.get_Children().Add(this.pcbUser);
            this.pnlForm.get_Children().Add(this.lblHeader);
            this.pnlForm.get_Children().Add(this.pcbLogo);
            this.pnlForm.get_Children().Add(this.lblCC2);
            this.pnlForm.get_Children().Add(this.lblCC1);
            this.pnlForm.get_Children().Add(this.lblDeviceID);
            this.pnlForm.get_Children().Add(this.lblVersion);
            this.pnlForm.Dock = DockStyle.Fill;
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.set_Padding(new Thickness(3));
            this.pnlForm.Size = new Size(318, 294);
            this.txtUserCode.get_Buttons().Add(this.btnUserID);
            this.txtUserCode.set_Layout(new ElementLayout(3, 0, 89, 133, 15, 0, 208, 26));
            this.txtUserCode.set_Name("txtUserCode");
            this.txtUserCode.add_KeyUp(new KeyEventHandler(this.txtUserCode_KeyUp));
            this.btnUserID.set_Action(1);
            this.btnUserID.set_BackColor(Color.Transparent);
            this.btnUserID.set_BorderThickness(0);
            this.btnUserID.set_HorizontalAlignment(2);
            this.btnUserID.set_Name("btnUserID");
            this.btnUserID.get_PressedBackground().set_BackColor(Color.Transparent);
            this.btnUserID.set_Size(new Size(18, 18));
            this.btnUserID.set_StateIcon(2);
            this.btnUserID.set_VisibleMode(1);
            this.lblUserCode.set_AutoSize(false);
            this.lblUserCode.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblUserCode.set_Layout(new ElementLayout(0, 0, 18, 133, 0, 0, 73, 26));
            this.lblUserCode.set_Name("lblUserCode");
            this.lblUserCode.set_TabIndex(2);
            this.lblUserCode.set_Text("User Code");
            this.lblUserCode.set_TextAlignment(2);
            this.txtPassword.get_Buttons().Add(this.btnPassword);
            this.txtPassword.set_Layout(new ElementLayout(3, 0, 89, 160, 15, 0, 208, 26));
            this.txtPassword.set_Name("txtPassword");
            this.txtPassword.set_PasswordChar('*');
            this.txtPassword.set_TabIndex(1);
            this.txtPassword.add_KeyUp(new KeyEventHandler(this.txtPassword_KeyUp));
            this.btnPassword.set_Action(1);
            this.btnPassword.set_BackColor(Color.Transparent);
            this.btnPassword.set_BorderThickness(0);
            this.btnPassword.set_HorizontalAlignment(2);
            this.btnPassword.set_Name("btnPassword");
            this.btnPassword.get_PressedBackground().set_BackColor(Color.Transparent);
            this.btnPassword.set_Size(new Size(18, 18));
            this.btnPassword.set_StateIcon(2);
            this.btnPassword.set_VisibleMode(1);
            this.lblPassword.set_AutoSize(false);
            this.lblPassword.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblPassword.set_Layout(new ElementLayout(0, 0, 18, 160, 0, 0, 73, 26));
            this.lblPassword.set_Name("lblPassword");
            this.lblPassword.set_TabIndex(4);
            this.lblPassword.set_Text("Password");
            this.lblPassword.set_TextAlignment(2);
            this.pcbUser.set_BorderThickness(1);
            this.pcbUser.set_Image(imgManager.GetImage("iNTrack.Customer"));
            this.pcbUser.set_Layout(new ElementLayout(1, 0, 124, 29, 0, 0, 125, 100));
            this.pcbUser.set_Name("pcbUser");
            this.pcbUser.set_TabIndex(5);
            this.lblHeader.set_Font(new Font("Tahoma", 14f, FontStyle.Bold));
            this.lblHeader.set_Layout(new ElementLayout(1, 0, 117, 3, 0, 0, 83, 23));
            this.lblHeader.set_Name("lblHeader");
            this.lblHeader.set_TabIndex(4);
            this.lblHeader.set_Text("  iNTrack");
            this.lblHeader.set_TextAlignment(0);
            this.pcbLogo.set_DefaultImage(imgManager.GetImage("iNTrack.AP&T Logo"));
            this.pcbLogo.set_ImageSizeMode(1);
            this.pcbLogo.set_Layout(new ElementLayout(0, 0, 21, 188, 0, 0, 50, 50));
            this.pcbLogo.set_Name("pcbLogo");
            this.pcbLogo.set_TabIndex(5);
            this.lblCC2.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblCC2.set_Layout(new ElementLayout(0, 0, 92, 225, 0, 0, 133, 13));
            this.lblCC2.set_Name("lblCC2");
            this.lblCC2.set_TabIndex(6);
            this.lblCC2.set_Text("AP&T Business Solutions");
            this.lblCC1.set_Font(new Font("Tahoma", 8f, FontStyle.Regular));
            this.lblCC1.set_Layout(new ElementLayout(0, 0, 91, 208, 0, 0, 56, 13));
            this.lblCC1.set_Name("lblCC1");
            this.lblCC1.set_TabIndex(7);
            this.lblCC1.set_Text("Powered By");
            this.lblDeviceID.set_Font(new Font("Tahoma", 8f, FontStyle.Regular));
            this.lblDeviceID.set_Layout(new ElementLayout(0, 0, 91, 189, 0, 0, 66, 13));
            this.lblDeviceID.set_Name("lblDeviceID");
            this.lblDeviceID.set_TabIndex(7);
            this.lblDeviceID.set_Text("Device ID {0}");
            this.lblVersion.set_Font(new Font("Tahoma", 8f, FontStyle.Regular));
            this.lblVersion.set_Layout(new ElementLayout(2, 0, 0, 189, 17, 0, 30, 13));
            this.lblVersion.set_Name("lblVersion");
            this.lblVersion.set_TabIndex(7);
            this.lblVersion.set_Text("v1.0.3");
            this.lblVersion.set_TextAlignment(9);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(318, 294);
            base.ControlBox = false;
            base.Controls.Add(this.tbcMenu);
            base.Controls.Add(this.pnlForm);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmLogin";
            base.Tag = "User Login";
            this.Text = ":: User Login";
            base.Load += new EventHandler(this.frmLogin_Load);
            this.pnlForm.ResumeElementLayout(false);
            base.ResumeLayout(false);
        }

        private void tbcMenu_SelectionChanged(object sender, EventArgs e)
        {
            DataTable item;
            string[] str;
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (this.tbcMenu.get_SelectedIndex() == 0)
                    {
                        if (string.IsNullOrEmpty(this.txtUserCode.get_Text().Trim()))
                        {
                            this.txtUserCode.Focus();
                            throw new Exception("Invalid user id");
                        }
                        Service service = new Service();
                        try
                        {
                            service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                            str = new string[] { "HHT_User_Setup_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), CommonLib.FormatString(this.txtUserCode.get_Text()) };
                            item = service.GetData(str).Tables[0];
                        }
                        finally
                        {
                            if (service != null)
                            {
                                ((IDisposable)service).Dispose();
                            }
                        }
                        if (item.Rows.Count == 0)
                        {
                            this.txtUserCode.SelectAll();
                            this.txtUserCode.Focus();
                            throw new Exception("User does not exist");
                        }
                        if (item.Rows[0]["Password"].ToString() != this.txtPassword.get_Text())
                        {
                            this.txtPassword.SelectAll();
                            this.txtPassword.Focus();
                            throw new Exception("Invalid password");
                        }
                        service = new Service();
                        try
                        {
                            service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                            str = new string[] { "HHT_Setup_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString() };
                            Property.Setup = service.GetData(str).Tables[0];
                            if (Property.ApplicationVersion != (string)Property.Setup.Rows[0]["Version No."])
                            {
                                Cursor.Current = Cursors.Default;
                                if (MessageBoxEx.Show("iNTrack has to be updated to continue. Do you want to update now?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                                {
                                    return;
                                }
                                else
                                {
                                    Process.Start(string.Format("{0}\\Update.exe", Property.ProgramPath), null);
                                    base.Close();
                                }
                            }
                            str = new string[] { "HHT_Document_Setup_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), string.Empty };
                            Property.DocumentSetup = service.GetData(str).Tables[0];
                            str = new string[] { "HHT_User_Permission_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), this.txtUserCode.get_Text(), string.Empty };
                            Property.UserPermission = service.GetData(str).Tables[0];
                        }
                        finally
                        {
                            if (service != null)
                            {
                                ((IDisposable)service).Dispose();
                            }
                        }
                        iNTrackLib.CreateAXClient(Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Setup.Rows[0]["AIF URL"].ToString(), Property.Setup.Rows[0]["AIF User Domain"].ToString(), Property.Setup.Rows[0]["AIF User Name"].ToString(), Property.Setup.Rows[0]["AIF User Password"].ToString());
                        Property.UserCode = this.txtUserCode.get_Text();
                        Property.UserName = item.Rows[0]["HHT User Name"].ToString();
                        Property.BackdatedDocumentAllowedForUser = (item.Rows[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : item.Rows[0]["Backdated Document Allowed"].ToString() == "1");
                        Property.ShowInventoryForUser = (item.Rows[0]["Show Inventory"].ToString() == "Yes" ? true : item.Rows[0]["Show Inventory"].ToString() == "1");
                        Property.ShowCostPrice = (item.Rows[0]["Show Cost Price"].ToString() == "Yes" ? true : item.Rows[0]["Show Cost Price"].ToString() == "1");
                        this.txtUserCode.set_Text(string.Empty);
                        this.txtPassword.set_Text(string.Empty);
                        this.txtUserCode.Focus();
                        CommonLib.SwitchForm(new frmHome());
                    }
                    else if (this.tbcMenu.get_SelectedIndex() == 1)
                    {
                        base.Close();
                    }
                }
                catch (Exception exception)
                {
                    CommonLib.DisplayErrorMessage(exception);
                }
            }
            finally
            {
                this.tbcMenu.set_SelectedIndex(-1);
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        this.tbcMenu.set_SelectedIndex(0);
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

        private void txtUserCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    if ((e.KeyCode != Keys.Enter ? false : !string.IsNullOrEmpty(this.txtUserCode.get_Text().Trim())))
                    {
                        this.txtPassword.SelectAll();
                        this.txtPassword.Focus();
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
    }
}