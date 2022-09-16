using FieldSoftware.PrinterCE_NetCF;
using iNTrack.iNTrackService;
using Resco.Controls.CommonControls;
using Resco.UIElements;
using Resco.UIElements.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Services.Protocols;
using System.Windows.Forms;

namespace iNTrack
{
    public class frmPrint : Form
    {
        private IContainer components = null;

        private UIElementPanelControl pnlForm;

        private UILabel lblBarcode;

        private UILabel lblItemcode;

        private UILabel lblDesc;

        private UITextBox txtDesc;

        private UILabel lblUOM;

        private UILabel lblProdDate;

        private UITextBox txtPrice;

        private ToolbarControl tbcMenu;

        private ToolbarItem tbiBack;

        private ToolbarItem tbiPrint;

        private UIComboBox cmbUOM;

        private UITextBox txtBarcode;

        private UITextBoxButton btnBarcode;

        private UITextBox txtItemcode;

        private UITextBoxButton btnItemcode;

        private UILabel lblPort;

        private UIComboBox cmbPort;

        private UICheckBox chkExcludePrice;

        private UITextBox txtProdDate;

        private UILabel lblExpDate;

        private UITextBox txtExpDate;

        private bool m_bIsItemValidated;

        private DataTable m_dtItem;

        private AsciiCE m_AsciiCE = null;

        public frmPrint()
        {
            this.InitializeComponent();
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int width = bounds.Width;
            bounds = Screen.PrimaryScreen.Bounds;
            base.Size = new Size(width, bounds.Height);
            this.AutoScroll = false;
        }

        private void cmbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    this.m_AsciiCE = null;
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

        private void cmbUOM_Click(object sender, UIMouseEventArgs e)
        {
            try
            {
                try
                {
                    if ((!this.m_bIsItemValidated ? false : (int)this.cmbUOM.get_StringData().Length == 1))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        Service service = new Service();
                        try
                        {
                            service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                            string[] str = new string[] { "HHT_Barcodes_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), string.Empty, CommonLib.FormatString(this.txtItemcode.get_Text()) };
                            this.m_dtItem = service.GetData(str).Tables[0];
                            if (this.m_dtItem.Rows.Count > 1)
                            {
                                this.cmbUOM.set_StringData((
                                    from r in this.m_dtItem.AsEnumerable()
                                    select r.Field<string>("UOM")).ToArray<string>());
                            }
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

        private void cmbUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.cmbUOM.get_SelectedIndex() > -1)
                    {
                        this.txtBarcode.remove_TextChanged(new EventHandler(this.txtBarcode_TextChanged));
                        this.txtItemcode.remove_TextChanged(new EventHandler(this.txtItemcode_TextChanged));
                        DataRow dataRow = this.m_dtItem.Select(string.Format("[UOM] = '{0}'", this.cmbUOM.get_Text()))[0];
                        this.txtBarcode.set_Text((string)dataRow["Barcode"]);
                        this.txtItemcode.set_Text((string)dataRow["Itemcode"]);
                        this.SetItemDetail(dataRow);
                        this.txtBarcode.add_TextChanged(new EventHandler(this.txtBarcode_TextChanged));
                        this.txtItemcode.add_TextChanged(new EventHandler(this.txtItemcode_TextChanged));
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

        private void frmPrint_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (Property.TransactionType != Property.TransactionTypeEnum.PLP)
                    {
                        this.Text = "Print Shelf Label";
                        this.chkExcludePrice.set_Visible(false);
                        this.lblProdDate.set_Visible(false);
                        this.txtProdDate.set_Visible(false);
                        this.lblExpDate.set_Visible(false);
                        this.txtExpDate.set_Visible(false);
                    }
                    else
                    {
                        this.Text = "Print Product Label";
                    }
                    this.cmbPort.set_SelectedIndex(4);
                    this.tbiPrint.set_Enabled(false);
                    this.txtBarcode.Focus();
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

        private void GetItemDetail(string Itemcode)
        {
            DataTable item;
            Service service;
            string[] str;
            try
            {
                string empty = string.Empty;
                DataRow dataRow = null;
                if (Itemcode.Length == 0)
                {
                    empty = (this.txtBarcode.get_Text().Length != 14 || !(this.txtBarcode.get_Text().Substring(0, 3) == "990") ? this.txtBarcode.get_Text() : string.Format("{0}00000", this.txtBarcode.get_Text().Substring(0, 9)));
                    service = new Service();
                    try
                    {
                        service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                        str = new string[] { "HHT_Barcodes_3001", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), string.Empty, CommonLib.FormatString(empty) };
                        item = service.GetData(str).Tables[0];
                        if (item.Rows.Count > 0)
                        {
                            dataRow = item.Rows[0];
                        }
                    }
                    finally
                    {
                        if (service != null)
                        {
                            ((IDisposable)service).Dispose();
                        }
                    }
                }
                else
                {
                    service = new Service();
                    try
                    {
                        service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                        str = new string[] { "HHT_Barcodes_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), string.Empty, CommonLib.FormatString(Itemcode) };
                        item = service.GetData(str).Tables[0];
                        if (item.Rows.Count > 0)
                        {
                            dataRow = item.Rows[0];
                        }
                    }
                    finally
                    {
                        if (service != null)
                        {
                            ((IDisposable)service).Dispose();
                        }
                    }
                }
                if (dataRow == null)
                {
                    if (this.txtBarcode.get_Text().Length == 0)
                    {
                        throw new Exception("Invalid itemcode");
                    }
                    throw new Exception("Invalid barcode");
                }
                if (this.txtBarcode.get_Text().Length == 0)
                {
                    this.txtBarcode.remove_TextChanged(new EventHandler(this.txtBarcode_TextChanged));
                    this.txtBarcode.set_Text((string)dataRow["Barcode"]);
                    this.txtBarcode.add_TextChanged(new EventHandler(this.txtBarcode_TextChanged));
                }
                else
                {
                    this.txtItemcode.remove_TextChanged(new EventHandler(this.txtItemcode_TextChanged));
                    this.txtItemcode.set_Text((string)dataRow["Itemcode"]);
                    this.txtItemcode.add_TextChanged(new EventHandler(this.txtItemcode_TextChanged));
                }
                this.cmbUOM.remove_SelectedIndexChanged(new EventHandler(this.cmbUOM_SelectedIndexChanged));
                UIComboBox uIComboBox = this.cmbUOM;
                str = new string[] { (string)dataRow["UOM"] };
                uIComboBox.set_StringData(str);
                this.cmbUOM.add_SelectedIndexChanged(new EventHandler(this.cmbUOM_SelectedIndexChanged));
                this.SetItemDetail(dataRow);
                this.tbiPrint.set_Enabled(true);
                this.m_bIsItemValidated = true;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                if (this.txtBarcode.get_Text().Length == 0)
                {
                    this.txtItemcode.SelectAll();
                    this.txtItemcode.Focus();
                }
                else
                {
                    this.txtBarcode.SelectAll();
                    this.txtBarcode.Focus();
                }
                throw exception;
            }
        }

        private void InitializeComponent()
        {
            this.tbcMenu = new ToolbarControl();
            this.tbiBack = new ToolbarItem();
            this.tbiPrint = new ToolbarItem();
            this.pnlForm = new UIElementPanelControl();
            this.lblProdDate = new UILabel();
            this.lblBarcode = new UILabel();
            this.lblItemcode = new UILabel();
            this.lblDesc = new UILabel();
            this.txtDesc = new UITextBox();
            this.lblUOM = new UILabel();
            this.txtPrice = new UITextBox();
            this.cmbUOM = new UIComboBox();
            this.txtBarcode = new UITextBox();
            this.btnBarcode = new UITextBoxButton();
            this.txtItemcode = new UITextBox();
            this.btnItemcode = new UITextBoxButton();
            this.lblPort = new UILabel();
            this.cmbPort = new UIComboBox();
            this.chkExcludePrice = new UICheckBox();
            this.txtProdDate = new UITextBox();
            this.lblExpDate = new UILabel();
            this.txtExpDate = new UITextBox();
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
            this.tbcMenu.get_Items().Add(this.tbiPrint);
            this.tbcMenu.set_ItemsAlignment(4);
            this.tbcMenu.set_ItemSpacing(5);
            this.tbcMenu.Location = new Point(0, 244);
            this.tbcMenu.Name = "tbcMenu";
            this.tbcMenu.Size = new Size(238, 50);
            this.tbcMenu.set_StretchBackgroundImage(true);
            this.tbcMenu.TabIndex = 0;
            this.tbcMenu.add_SelectionChanged(new EventHandler(this.tbcMenu_SelectionChanged));
            this.tbiBack.set_BackColor(Color.Black);
            this.tbiBack.set_CustomSize(new Size(0, 0));
            this.tbiBack.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Left"));
            this.tbiBack.set_Name("tbiBack");
            this.tbiBack.set_ToolbarItemBehavior(2);
            this.tbiPrint.set_BackColor(Color.Black);
            this.tbiPrint.set_CustomSize(new Size(0, 0));
            this.tbiPrint.set_ImageDefault(imgManager.GetImage("iNTrack.Print"));
            this.tbiPrint.set_Name("tbiPrint");
            this.tbiPrint.set_ToolbarItemBehavior(2);
            this.pnlForm.set_BackgroundImage(imgManager.GetImage("iNTrack.BGP"));
            this.pnlForm.set_BackgroundImageLayout(6);
            this.pnlForm.get_Children().Add(this.lblProdDate);
            this.pnlForm.get_Children().Add(this.lblBarcode);
            this.pnlForm.get_Children().Add(this.lblItemcode);
            this.pnlForm.get_Children().Add(this.lblDesc);
            this.pnlForm.get_Children().Add(this.txtDesc);
            this.pnlForm.get_Children().Add(this.lblUOM);
            this.pnlForm.get_Children().Add(this.txtPrice);
            this.pnlForm.get_Children().Add(this.cmbUOM);
            this.pnlForm.get_Children().Add(this.txtBarcode);
            this.pnlForm.get_Children().Add(this.txtItemcode);
            this.pnlForm.get_Children().Add(this.lblPort);
            this.pnlForm.get_Children().Add(this.cmbPort);
            this.pnlForm.get_Children().Add(this.chkExcludePrice);
            this.pnlForm.get_Children().Add(this.txtProdDate);
            this.pnlForm.get_Children().Add(this.lblExpDate);
            this.pnlForm.get_Children().Add(this.txtExpDate);
            this.pnlForm.Dock = DockStyle.Fill;
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new Size(238, 294);
            this.pnlForm.TabIndex = 7;
            this.lblProdDate.set_AutoSize(false);
            this.lblProdDate.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblProdDate.set_Layout(new ElementLayout(0, 0, 5, 149, 0, 0, 65, 26));
            this.lblProdDate.set_Name("lblProdDate");
            this.lblProdDate.set_TabIndex(14);
            this.lblProdDate.set_Text("Prod. Date");
            this.lblProdDate.set_TextAlignment(2);
            this.lblBarcode.set_AutoSize(false);
            this.lblBarcode.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblBarcode.set_Layout(new ElementLayout(0, 0, 5, 32, 0, 0, 65, 26));
            this.lblBarcode.set_Name("lblBarcode");
            this.lblBarcode.set_TabIndex(8);
            this.lblBarcode.set_Text("Barcode");
            this.lblBarcode.set_TextAlignment(2);
            this.lblItemcode.set_AutoSize(false);
            this.lblItemcode.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblItemcode.set_Layout(new ElementLayout(0, 0, 5, 59, 0, 0, 65, 26));
            this.lblItemcode.set_Name("lblItemcode");
            this.lblItemcode.set_TabIndex(9);
            this.lblItemcode.set_Text("Itemcode");
            this.lblItemcode.set_TextAlignment(2);
            this.lblDesc.set_AutoSize(false);
            this.lblDesc.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblDesc.set_Layout(new ElementLayout(0, 0, 5, 86, 0, 0, 60, 36));
            this.lblDesc.set_Name("lblDesc");
            this.lblDesc.set_TabIndex(10);
            this.lblDesc.set_Text("Desc");
            this.lblDesc.set_TextAlignment(2);
            this.txtDesc.set_Layout(new ElementLayout(3, 0, 70, 86, 3, 0, 165, 36));
            this.txtDesc.set_Multiline(true);
            this.txtDesc.set_Name("txtDesc");
            this.txtDesc.set_ReadOnly(true);
            this.txtDesc.set_TabIndex(4);
            this.lblUOM.set_AutoSize(false);
            this.lblUOM.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblUOM.set_Layout(new ElementLayout(0, 0, 5, 123, 0, 0, 65, 26));
            this.lblUOM.set_Name("lblUOM");
            this.lblUOM.set_TabIndex(12);
            this.lblUOM.set_Text("UOM/Price");
            this.lblUOM.set_TextAlignment(2);
            this.txtPrice.set_Layout(new ElementLayout(0, 0, 153, 123, 0, 0, 82, 26));
            this.txtPrice.set_Name("txtPrice");
            this.txtPrice.set_ReadOnly(true);
            this.txtPrice.set_TabIndex(6);
            this.cmbUOM.set_BackColor(SystemColors.Window);
            this.cmbUOM.set_DropDownWidth(100);
            this.cmbUOM.set_Layout(new ElementLayout(0, 0, 70, 123, 0, 0, 82, 26));
            this.cmbUOM.set_Name("cmbUOM");
            this.cmbUOM.set_TabIndex(5);
            this.cmbUOM.add_SelectedIndexChanged(new EventHandler(this.cmbUOM_SelectedIndexChanged));
            this.cmbUOM.add_Click(new UIMouseEventHandler(this, frmPrint.cmbUOM_Click));
            this.txtBarcode.get_Buttons().Add(this.btnBarcode);
            this.txtBarcode.set_Layout(new ElementLayout(3, 0, 70, 32, 3, 0, 165, 26));
            this.txtBarcode.set_Name("txtBarcode");
            this.txtBarcode.set_TabIndex(2);
            this.txtBarcode.add_KeyPress(new KeyPressEventHandler(this.txtBarcode_KeyPress));
            this.txtBarcode.add_TextChanged(new EventHandler(this.txtBarcode_TextChanged));
            this.btnBarcode.set_Action(1);
            this.btnBarcode.set_BackColor(Color.Transparent);
            this.btnBarcode.set_BorderThickness(0);
            this.btnBarcode.set_HorizontalAlignment(2);
            this.btnBarcode.set_Name("btnBarcode");
            this.btnBarcode.get_PressedBackground().set_BackColor(Color.Transparent);
            this.btnBarcode.set_Size(new Size(18, 18));
            this.btnBarcode.set_StateIcon(2);
            this.btnBarcode.set_VisibleMode(1);
            this.txtItemcode.get_Buttons().Add(this.btnItemcode);
            this.txtItemcode.set_Layout(new ElementLayout(3, 0, 70, 59, 3, 0, 165, 26));
            this.txtItemcode.set_Name("txtItemcode");
            this.txtItemcode.set_TabIndex(3);
            this.txtItemcode.add_KeyPress(new KeyPressEventHandler(this.txtItemcode_KeyPress));
            this.txtItemcode.add_TextChanged(new EventHandler(this.txtItemcode_TextChanged));
            this.btnItemcode.set_Action(1);
            this.btnItemcode.set_BackColor(Color.Transparent);
            this.btnItemcode.set_BorderThickness(0);
            this.btnItemcode.set_HorizontalAlignment(2);
            this.btnItemcode.set_Name("btnItemcode");
            this.btnItemcode.get_PressedBackground().set_BackColor(Color.Transparent);
            this.btnItemcode.set_Size(new Size(18, 18));
            this.btnItemcode.set_StateIcon(2);
            this.btnItemcode.set_VisibleMode(1);
            this.lblPort.set_AutoSize(false);
            this.lblPort.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblPort.set_Layout(new ElementLayout(0, 0, 5, 5, 0, 0, 65, 26));
            this.lblPort.set_Name("lblPort");
            this.lblPort.set_TabIndex(12);
            this.lblPort.set_Text("COM Port");
            this.lblPort.set_TextAlignment(2);
            this.cmbPort.set_BackColor(SystemColors.Window);
            this.cmbPort.set_DropDownWidth(100);
            this.cmbPort.set_Layout(new ElementLayout(0, 0, 70, 5, 0, 0, 82, 26));
            this.cmbPort.set_Name("cmbPort");
            UIComboBox uIComboBox = this.cmbPort;
            string[] strArrays = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            uIComboBox.set_StringData(strArrays);
            this.cmbPort.set_TabIndex(1);
            this.cmbPort.set_Text("1");
            this.cmbPort.add_SelectedIndexChanged(new EventHandler(this.cmbPort_SelectedIndexChanged));
            this.chkExcludePrice.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.chkExcludePrice.set_Layout(new ElementLayout(0, 0, 155, 150, 0, 0, 81, 29));
            this.chkExcludePrice.set_Name("chkExcludePrice");
            this.chkExcludePrice.set_TabIndex(8);
            this.chkExcludePrice.set_Text("Exc. Price");
            this.txtProdDate.set_Layout(new ElementLayout(0, 0, 70, 150, 0, 0, 82, 26));
            this.txtProdDate.set_Name("txtProdDate");
            this.txtProdDate.set_TabIndex(7);
            this.txtProdDate.add_KeyPress(new KeyPressEventHandler(this.txtProdDate_KeyPress));
            this.lblExpDate.set_AutoSize(false);
            this.lblExpDate.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblExpDate.set_Layout(new ElementLayout(0, 0, 5, 176, 0, 0, 65, 26));
            this.lblExpDate.set_Name("lblExpDate");
            this.lblExpDate.set_TabIndex(14);
            this.lblExpDate.set_Text("Exp. Date");
            this.lblExpDate.set_TextAlignment(2);
            this.txtExpDate.set_Layout(new ElementLayout(0, 0, 70, 177, 0, 0, 82, 26));
            this.txtExpDate.set_Name("txtExpDate");
            this.txtExpDate.set_TabIndex(9);
            this.txtExpDate.add_KeyPress(new KeyPressEventHandler(this.txtExpDate_KeyPress));
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(238, 294);
            base.ControlBox = false;
            base.Controls.Add(this.tbcMenu);
            base.Controls.Add(this.pnlForm);
            base.MinimizeBox = false;
            base.Name = "frmPrint";
            base.Tag = "Print Label";
            this.Text = ":: Print Label";
            base.Load += new EventHandler(this.frmPrint_Load);
            this.pnlForm.ResumeElementLayout(false);
            base.ResumeLayout(false);
        }

        private void ResetControls()
        {
            try
            {
                this.txtDesc.set_Text(string.Empty);
                this.cmbUOM.set_DataSource(null);
                this.cmbUOM.set_Text(string.Empty);
                this.txtPrice.set_Text(string.Empty);
                this.chkExcludePrice.set_Checked(false);
                this.txtProdDate.set_Text(string.Empty);
                this.txtExpDate.set_Text(string.Empty);
                this.tbiPrint.set_Enabled(false);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void SetItemDetail(DataRow datarow)
        {
            try
            {
                this.txtDesc.set_Text(datarow["Description"].ToString());
                UITextBox uITextBox = this.txtPrice;
                double num = double.Parse(datarow["Sales Price"].ToString());
                uITextBox.set_Text(num.ToString("F"));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void tbcMenu_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dateTime;
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    switch (this.tbcMenu.get_SelectedIndex())
                    {
                        case 0:
                            {
                                CommonLib.SwitchForm(new frmOptions());
                                break;
                            }
                        case 1:
                            {
                                string dataInText = CommonLib.GetDataInText(string.Concat(Property.ProgramPath, Path.DirectorySeparatorChar, (Property.TransactionType == Property.TransactionTypeEnum.PLP ? "Product.prn" : "Shelf.prn")));
                                dataInText = dataInText.Replace("{company}", (Property.TransactionType == Property.TransactionTypeEnum.PLP ? "AFCOOP" : "ARMED FORCES COOP SOCIETY"));
                                dataInText = dataInText.Replace("{itemcode}", this.txtItemcode.get_Text());
                                if (this.txtDesc.get_Text().Length <= 20)
                                {
                                    dataInText = dataInText.Replace("{desc1}", this.txtDesc.get_Text());
                                    dataInText = dataInText.Replace("{desc2}", string.Empty);
                                }
                                else
                                {
                                    dataInText = dataInText.Replace("{desc1}", this.txtDesc.get_Text().Substring(0, 20));
                                    dataInText = (this.txtDesc.get_Text().Length <= 40 ? dataInText.Replace("{desc2}", this.txtDesc.get_Text().Substring(20)) : dataInText.Replace("{desc2}", this.txtDesc.get_Text().Substring(20, 20)));
                                }
                                dataInText = dataInText.Replace("{barcode}", this.txtBarcode.get_Text());
                                if (!this.chkExcludePrice.get_Checked())
                                {
                                    dataInText = dataInText.Replace("{currency}", "AED");
                                    double num = double.Parse(this.txtPrice.get_Text());
                                    dataInText = dataInText.Replace("{price}", num.ToString("F"));
                                }
                                else
                                {
                                    dataInText = dataInText.Replace("{currency}", string.Empty);
                                    dataInText = dataInText.Replace("{price}", string.Empty);
                                }
                                string empty = string.Empty;
                                if (!string.IsNullOrEmpty(this.txtProdDate.get_Text().Trim()))
                                {
                                    try
                                    {
                                        dateTime = DateTime.ParseExact(this.txtProdDate.get_Text(), "ddMMyy", CultureInfo.InvariantCulture);
                                        empty = string.Format("P {0}", dateTime.ToString("dd/MM/yy", CultureInfo.InvariantCulture));
                                    }
                                    catch (Exception exception)
                                    {
                                        this.txtProdDate.SelectAll();
                                        this.txtProdDate.Focus();
                                        throw new Exception("Production date must be in ddMMyy format");
                                    }
                                }
                                dataInText = dataInText.Replace("{pDate}", empty);
                                string str = string.Empty;
                                if (!string.IsNullOrEmpty(this.txtExpDate.get_Text().Trim()))
                                {
                                    try
                                    {
                                        dateTime = DateTime.ParseExact(this.txtExpDate.get_Text(), "ddMMyy", CultureInfo.InvariantCulture);
                                        str = string.Format("E {0}", dateTime.ToString("dd/MM/yy", CultureInfo.InvariantCulture));
                                    }
                                    catch (Exception exception1)
                                    {
                                        this.txtExpDate.SelectAll();
                                        this.txtExpDate.Focus();
                                        throw new Exception("Expiry date must be in ddMMyy format");
                                    }
                                }
                                dataInText = dataInText.Replace("{eDate}", str);
                                if (this.m_AsciiCE == null)
                                {
                                    AsciiCE.ASCIIPORT aSCIIPORT = AsciiCE.ASCIIPORT.COM1;
                                    string text = this.cmbPort.get_Text();
                                    if (text != null)
                                    {
                                        switch (text)
                                        {
                                            case "1":
                                                {
                                                    aSCIIPORT = AsciiCE.ASCIIPORT.COM1;
                                                    break;
                                                }
                                            case "2":
                                                {
                                                    aSCIIPORT = AsciiCE.ASCIIPORT.COM2;
                                                    break;
                                                }
                                            case "3":
                                                {
                                                    aSCIIPORT = AsciiCE.ASCIIPORT.COM3;
                                                    break;
                                                }
                                            case "4":
                                                {
                                                    aSCIIPORT = AsciiCE.ASCIIPORT.COM4;
                                                    break;
                                                }
                                            case "5":
                                                {
                                                    aSCIIPORT = AsciiCE.ASCIIPORT.COM5;
                                                    break;
                                                }
                                            case "6":
                                                {
                                                    aSCIIPORT = AsciiCE.ASCIIPORT.COM6;
                                                    break;
                                                }
                                            case "7":
                                                {
                                                    aSCIIPORT = AsciiCE.ASCIIPORT.COM7;
                                                    break;
                                                }
                                            case "8":
                                                {
                                                    aSCIIPORT = AsciiCE.ASCIIPORT.COM8;
                                                    break;
                                                }
                                            case "9":
                                                {
                                                    aSCIIPORT = AsciiCE.ASCIIPORT.COM9;
                                                    break;
                                                }
                                        }
                                    }
                                    this.m_AsciiCE = new AsciiCE("523Y3M158K");
                                    this.m_AsciiCE.SelectPort(aSCIIPORT);
                                    this.m_AsciiCE.PrDialogBox = PrinterCE_Base.DIALOGBOX_ACTION.DISABLE;
                                }
                                this.m_AsciiCE.Text(dataInText);
                                break;
                            }
                        case 2:
                            {
                                this.ResetControls();
                                this.txtBarcode.set_Text(string.Empty);
                                this.txtBarcode.Focus();
                                break;
                            }
                    }
                }
                catch (Exception exception2)
                {
                    CommonLib.DisplayErrorMessage(exception2);
                }
            }
            finally
            {
                this.tbcMenu.set_SelectedIndex(-1);
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                try
                {
                    if (e.KeyChar == '\r')
                    {
                        this.txtBarcode.set_Text(this.txtBarcode.get_Text().Trim().ToUpper());
                        if (!string.IsNullOrEmpty(this.txtBarcode.get_Text()))
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            this.GetItemDetail(string.Empty);
                            this.txtProdDate.SelectAll();
                            this.txtProdDate.Focus();
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

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.m_bIsItemValidated)
                {
                    this.ResetControls();
                }
                if (this.txtItemcode.get_Text().Length != 0)
                {
                    this.txtItemcode.remove_TextChanged(new EventHandler(this.txtItemcode_TextChanged));
                    this.txtItemcode.set_Text(string.Empty);
                    this.txtItemcode.add_TextChanged(new EventHandler(this.txtItemcode_TextChanged));
                }
            }
            catch (Exception exception)
            {
                CommonLib.DisplayErrorMessage(exception);
            }
        }

        private void txtExpDate_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtItemcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                try
                {
                    if (e.KeyChar == '\r')
                    {
                        this.txtItemcode.set_Text(this.txtItemcode.get_Text().Trim().ToUpper());
                        if (!string.IsNullOrEmpty(this.txtItemcode.get_Text()))
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            this.GetItemDetail(this.txtItemcode.get_Text());
                            this.txtProdDate.SelectAll();
                            this.txtProdDate.Focus();
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

        private void txtItemcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.m_bIsItemValidated)
                {
                    this.ResetControls();
                }
                if (this.txtBarcode.get_Text().Length != 0)
                {
                    this.txtBarcode.remove_TextChanged(new EventHandler(this.txtBarcode_TextChanged));
                    this.txtBarcode.set_Text(string.Empty);
                    this.txtBarcode.add_TextChanged(new EventHandler(this.txtBarcode_TextChanged));
                }
            }
            catch (Exception exception)
            {
                CommonLib.DisplayErrorMessage(exception);
            }
        }

        private void txtProdDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                try
                {
                    if (e.KeyChar == '\r')
                    {
                        this.txtExpDate.SelectAll();
                        this.txtExpDate.Focus();
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