using iNTrack.iNTrackService;
using Microsoft.VisualBasic;
using Resco.Controls.CommonControls;
using Resco.Controls.MessageBox;
using Resco.UIElements;
using Resco.UIElements.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Services.Protocols;
using System.Windows.Forms;

namespace iNTrack
{
    public class frmStockCount : Form
    {
        private IContainer components = null;

        private UIElementPanelControl pnlForm;

        private UILabel lblBarcode;

        private UITextBox txtBarcode;

        private UILabel uiLabel2;

        private UITextBox txtQuantity;

        private ToolbarControl tbcMenu;

        private UIComboBox cmbBin;

        private UILabel lblBin;

        private ToolbarItem tbiBack;

        private ToolbarItem tbiUndo;

        private ToolbarItem tbiConfirm;

        private ToolbarItem tbiNext;

        private UILabel lblItemcode;

        private UITextBox txtItemcode;

        private UIButton btnIC;

        private UITextBox txtDesc;

        private UILabel lblDesc;

        private UILabel lblUOM;

        private UITextBox txtPrice;

        private UIButton btnLastScan;

        private UILabel lblSummary;

        private UIComboBox cmbUOM;

        private DataTable m_dtBin = null;

        private bool m_bIsItemValidated;

        private DataTable m_dtItem;

        public frmStockCount()
        {
            this.InitializeComponent();
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int width = bounds.Width;
            bounds = Screen.PrimaryScreen.Bounds;
            base.Size = new Size(width, bounds.Height);
            this.AutoScroll = false;
        }

        private void btnIC_Click(object sender, UIMouseEventArgs e)
        {
            try
            {
                try
                {
                    frmItems frmItem = new frmItems(frmItems.ParentForm.Transaction);
                    try
                    {
                        if (frmItem.ShowDialog() == DialogResult.OK)
                        {
                            this.txtBarcode.set_Text(frmItem.Barcode);
                            this.GetItemDetail(string.Empty);
                            this.txtQuantity.SelectAll();
                            this.txtQuantity.Focus();
                        }
                    }
                    finally
                    {
                        if (frmItem != null)
                        {
                            ((IDisposable)frmItem).Dispose();
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

        private void btnLastScan_Click(object sender, UIMouseEventArgs e)
        {
            try
            {
                DataRow[] dataRowArray = Property.TransLine.Select("Quantity > 0", "[Line No.] Desc");
                if ((int)dataRowArray.Length == 0)
                {
                    throw new Exception("No item scanned yet");
                }
                frmItem _frmItem = new frmItem(dataRowArray[0]["Itemcode"].ToString(), dataRowArray[0]["Barcode"].ToString(), dataRowArray[0]["Description"].ToString(), dataRowArray[0]["UOM"].ToString(), (double)dataRowArray[0]["Unit Price"], (double)dataRowArray[0]["Quantity"]);
                try
                {
                    _frmItem.ShowDialog();
                }
                finally
                {
                    if (_frmItem != null)
                    {
                        ((IDisposable)_frmItem).Dispose();
                    }
                }
            }
            catch (Exception exception)
            {
                CommonLib.DisplayErrorMessage(exception);
            }
        }

        private void cmbBin_Validating(object sender, CancelEventArgs e)
        {
            bool flag;
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (this.cmbBin.get_SelectedIndex() == -1)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = (Property.TransLine.Rows.Count == 0 ? false : !(Property.TransLine.Rows[0]["Bin Code"].ToString() != this.cmbBin.get_Text()));
                    }
                    if (!flag)
                    {
                        Property.TransactionNo = this.cmbBin.get_SelectedValue().ToString();
                        this.GetStockCountDetail(true);
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
                        this.txtQuantity.SelectAll();
                        this.txtQuantity.Focus();
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

        private void frmStockCount_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.tbiUndo.set_Visible(false);
                    this.GetStockCountBin();
                    Property.TransactionNo = string.Empty;
                    this.GetStockCountDetail(true);
                    this.cmbBin.Focus();
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
                if (dataRow != null)
                {
                    if (iNTrackLib.IsItemBlocked(dataRow["Blocked"].ToString()))
                    {
                        throw new Exception("Item has been blocked");
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
                    if ((string.IsNullOrEmpty(empty) ? false : empty != this.txtBarcode.get_Text()))
                    {
                        this.txtBarcode.remove_TextChanged(new EventHandler(this.txtBarcode_TextChanged));
                        this.txtBarcode.set_Text(empty);
                        this.txtBarcode.add_TextChanged(new EventHandler(this.txtBarcode_TextChanged));
                    }
                }
                else if ((this.txtItemcode.get_Text().Length != 0 ? true : Property.Setup.Rows[0]["Check Item Validity - Stock"].ToString() == "1"))
                {
                    if (this.txtBarcode.get_Text().Length == 0)
                    {
                        throw new Exception("Invalid itemcode");
                    }
                    throw new Exception("Invalid barcode");
                }
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

        private void GetStockCountBin()
        {
            try
            {
                Service service = new Service();
                try
                {
                    service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                    string[] str = new string[] { "HHT_Stock_Count_Bin_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString() };
                    this.m_dtBin = service.GetData(str).Tables[0];
                }
                finally
                {
                    if (service != null)
                    {
                        ((IDisposable)service).Dispose();
                    }
                }
                CommonLib.SetDropDown("Bin Code", "Count No", this.m_dtBin, this.cmbBin);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void GetStockCountDetail(bool RefreshData)
        {
            try
            {
                if (RefreshData)
                {
                    Service service = new Service();
                    try
                    {
                        service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                        string[] str = new string[] { "HHT_Stock_Count_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionNo, this.cmbBin.get_Text(), Property.UserCode };
                        Property.TransLine = service.GetData(str).Tables[0];
                    }
                    finally
                    {
                        if (service != null)
                        {
                            ((IDisposable)service).Dispose();
                        }
                    }
                }
                bool mBIsItemValidated = this.m_bIsItemValidated;
                this.txtBarcode.set_Text(string.Empty);
                this.txtItemcode.set_Text(string.Empty);
                if (!mBIsItemValidated)
                {
                    this.ResetControls();
                }
                this.SetControls();
                this.txtBarcode.Focus();
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
            this.tbiUndo = new ToolbarItem();
            this.tbiConfirm = new ToolbarItem();
            this.tbiNext = new ToolbarItem();
            this.pnlForm = new UIElementPanelControl();
            this.lblBarcode = new UILabel();
            this.txtBarcode = new UITextBox();
            this.uiLabel2 = new UILabel();
            this.txtQuantity = new UITextBox();
            this.cmbBin = new UIComboBox();
            this.lblBin = new UILabel();
            this.lblItemcode = new UILabel();
            this.txtItemcode = new UITextBox();
            this.btnIC = new UIButton();
            this.txtDesc = new UITextBox();
            this.lblDesc = new UILabel();
            this.lblUOM = new UILabel();
            this.txtPrice = new UITextBox();
            this.btnLastScan = new UIButton();
            this.lblSummary = new UILabel();
            this.cmbUOM = new UIComboBox();
            this.pnlForm.SuspendElementLayout();
            base.SuspendLayout();
            this.tbcMenu.set_ArrowsTransparency(0);
            this.tbcMenu.BackColor = Color.Black;
            this.tbcMenu.set_BmpArrowNext(imgManager.GetImage("iNTrack.Arrow Right2"));
            this.tbcMenu.set_BmpArrowPrevious(imgManager.GetImage("iNTrack.Arrow Left2"));
            this.tbcMenu.Dock = DockStyle.Bottom;
            this.tbcMenu.set_EnableArrowsTransparency(false);
            this.tbcMenu.get_Items().Add(this.tbiBack);
            this.tbcMenu.get_Items().Add(this.tbiUndo);
            this.tbcMenu.get_Items().Add(this.tbiConfirm);
            this.tbcMenu.get_Items().Add(this.tbiNext);
            this.tbcMenu.set_ItemsAlignment(4);
            this.tbcMenu.set_ItemSpacing(5);
            this.tbcMenu.Location = new Point(0, 244);
            this.tbcMenu.set_MarginAtBegin(50);
            this.tbcMenu.set_MarginAtEnd(45);
            this.tbcMenu.Name = "tbcMenu";
            this.tbcMenu.Size = new Size(318, 50);
            this.tbcMenu.TabIndex = 1;
            this.tbcMenu.add_SelectionChanged(new EventHandler(this.tbcMenu_SelectionChanged));
            this.tbiBack.set_BackColor(Color.Black);
            this.tbiBack.set_CustomSize(new Size(0, 0));
            this.tbiBack.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Left"));
            this.tbiBack.set_Name("tbiBack");
            this.tbiBack.set_ToolbarItemBehavior(2);
            this.tbiUndo.set_BackColor(Color.Black);
            this.tbiUndo.set_CustomSize(new Size(0, 0));
            this.tbiUndo.set_ImageDefault(imgManager.GetImage("iNTrack.Back"));
            this.tbiUndo.set_Name("tbiUndo");
            this.tbiUndo.set_ToolbarItemBehavior(2);
            this.tbiConfirm.set_BackColor(Color.Black);
            this.tbiConfirm.set_CustomSize(new Size(0, 0));
            this.tbiConfirm.set_ImageDefault(imgManager.GetImage("iNTrack.Ok"));
            this.tbiConfirm.set_Name("tbiConfirm");
            this.tbiConfirm.set_ToolbarItemBehavior(2);
            this.tbiNext.set_BackColor(Color.Black);
            this.tbiNext.set_CustomSize(new Size(0, 0));
            this.tbiNext.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Right"));
            this.tbiNext.set_Name("tbiNext");
            this.tbiNext.set_ToolbarItemBehavior(2);
            this.pnlForm.set_BackgroundImage(imgManager.GetImage("iNTrack.BGP"));
            this.pnlForm.set_BackgroundImageLayout(6);
            this.pnlForm.get_Children().Add(this.lblBarcode);
            this.pnlForm.get_Children().Add(this.txtBarcode);
            this.pnlForm.get_Children().Add(this.uiLabel2);
            this.pnlForm.get_Children().Add(this.txtQuantity);
            this.pnlForm.get_Children().Add(this.cmbBin);
            this.pnlForm.get_Children().Add(this.lblBin);
            this.pnlForm.get_Children().Add(this.lblItemcode);
            this.pnlForm.get_Children().Add(this.txtItemcode);
            this.pnlForm.get_Children().Add(this.btnIC);
            this.pnlForm.get_Children().Add(this.txtDesc);
            this.pnlForm.get_Children().Add(this.lblDesc);
            this.pnlForm.get_Children().Add(this.lblUOM);
            this.pnlForm.get_Children().Add(this.txtPrice);
            this.pnlForm.get_Children().Add(this.btnLastScan);
            this.pnlForm.get_Children().Add(this.lblSummary);
            this.pnlForm.get_Children().Add(this.cmbUOM);
            this.pnlForm.Dock = DockStyle.Fill;
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new Size(318, 294);
            this.pnlForm.TabIndex = 2;
            this.lblBarcode.set_AutoSize(false);
            this.lblBarcode.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblBarcode.set_Layout(new ElementLayout(0, 0, 5, 32, 0, 0, 60, 26));
            this.lblBarcode.set_Name("lblBarcode");
            this.lblBarcode.set_TabIndex(7);
            this.lblBarcode.set_Text("Barcode");
            this.lblBarcode.set_TextAlignment(2);
            this.txtBarcode.set_Layout(new ElementLayout(3, 0, 70, 32, 3, 0, 245, 26));
            this.txtBarcode.set_Name("txtBarcode");
            this.txtBarcode.set_TabIndex(1);
            this.txtBarcode.add_KeyPress(new KeyPressEventHandler(this.txtBarcode_KeyPress));
            this.uiLabel2.set_AutoSize(false);
            this.uiLabel2.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.uiLabel2.set_Layout(new ElementLayout(0, 0, 5, 150, 0, 0, 60, 26));
            this.uiLabel2.set_Name("uiLabel2");
            this.uiLabel2.set_TabIndex(8);
            this.uiLabel2.set_Text("Quantity");
            this.uiLabel2.set_TextAlignment(2);
            this.txtQuantity.set_Layout(new ElementLayout(0, 0, 70, 150, 0, 0, 82, 26));
            this.txtQuantity.set_Name("txtQuantity");
            this.txtQuantity.set_TabIndex(7);
            this.txtQuantity.add_KeyPress(new KeyPressEventHandler(this.txtQuantity_KeyPress));
            this.cmbBin.set_BackColor(SystemColors.Window);
            this.cmbBin.set_Layout(new ElementLayout(3, 0, 70, 5, 3, 0, 245, 26));
            this.cmbBin.set_Name("cmbBin");
            this.cmbBin.set_TabIndex(9);
            this.cmbBin.set_Tag("");
            this.cmbBin.add_Validating(new CancelEventHandler(this.cmbBin_Validating));
            this.lblBin.set_AutoSize(false);
            this.lblBin.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblBin.set_Layout(new ElementLayout(0, 0, 5, 5, 0, 0, 60, 26));
            this.lblBin.set_Name("lblBin");
            this.lblBin.set_TabIndex(5);
            this.lblBin.set_Text("Bin");
            this.lblBin.set_TextAlignment(2);
            this.lblItemcode.set_AutoSize(false);
            this.lblItemcode.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblItemcode.set_Layout(new ElementLayout(0, 0, 5, 60, 0, 0, 60, 26));
            this.lblItemcode.set_Name("lblItemcode");
            this.lblItemcode.set_TabIndex(7);
            this.lblItemcode.set_Text("Itemcode");
            this.lblItemcode.set_TextAlignment(2);
            this.txtItemcode.set_Layout(new ElementLayout(3, 0, 70, 59, 39, 0, 209, 26));
            this.txtItemcode.set_Name("txtItemcode");
            this.txtItemcode.set_TabIndex(2);
            this.txtItemcode.add_KeyPress(new KeyPressEventHandler(this.txtItemcode_KeyPress));
            this.txtItemcode.add_TextChanged(new EventHandler(this.txtItemcode_TextChanged));
            this.btnIC.set_BackColor(SystemColors.Desktop);
            this.btnIC.set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
            this.btnIC.set_ForeColor(Color.White);
            this.btnIC.set_Layout(new ElementLayout(2, 0, 0, 59, 4, 0, 33, 26));
            this.btnIC.set_Name("btnIC");
            this.btnIC.set_TabIndex(3);
            this.btnIC.set_Text("...");
            this.btnIC.add_Click(new UIMouseEventHandler(this, frmStockCount.btnIC_Click));
            this.txtDesc.set_Layout(new ElementLayout(3, 0, 70, 86, 3, 0, 245, 36));
            this.txtDesc.set_Multiline(true);
            this.txtDesc.set_Name("txtDesc");
            this.txtDesc.set_ReadOnly(true);
            this.txtDesc.set_TabIndex(4);
            this.lblDesc.set_AutoSize(false);
            this.lblDesc.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblDesc.set_Layout(new ElementLayout(0, 0, 5, 86, 0, 0, 60, 36));
            this.lblDesc.set_Name("lblDesc");
            this.lblDesc.set_TabIndex(6);
            this.lblDesc.set_Text("Desc");
            this.lblDesc.set_TextAlignment(2);
            this.lblUOM.set_AutoSize(false);
            this.lblUOM.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblUOM.set_Layout(new ElementLayout(0, 0, 5, 124, 0, 0, 71, 26));
            this.lblUOM.set_Name("lblUOM");
            this.lblUOM.set_TabIndex(6);
            this.lblUOM.set_Text("UOM/Price");
            this.lblUOM.set_TextAlignment(2);
            this.txtPrice.set_Layout(new ElementLayout(0, 0, 153, 123, 0, 0, 82, 26));
            this.txtPrice.set_Name("txtPrice");
            this.txtPrice.set_ReadOnly(true);
            this.txtPrice.set_TabIndex(6);
            this.btnLastScan.set_BackColor(SystemColors.Desktop);
            this.btnLastScan.set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
            this.btnLastScan.set_ForeColor(Color.White);
            this.btnLastScan.set_Layout(new ElementLayout(0, 0, 70, 181, 0, 0, 82, 30));
            this.btnLastScan.set_Name("btnLastScan");
            this.btnLastScan.set_TabIndex(8);
            this.btnLastScan.set_Text("Last Scan?");
            this.btnLastScan.add_Click(new UIMouseEventHandler(this, frmStockCount.btnLastScan_Click));
            this.lblSummary.set_Font(new Font("Tahoma", 9f, FontStyle.Bold | FontStyle.Underline));
            this.lblSummary.set_ForeColor(Color.Black);
            this.lblSummary.set_Layout(new ElementLayout(0, 0, 7, 226, 0, 0, 156, 15));
            this.lblSummary.set_Name("lblSummary");
            this.lblSummary.set_TabIndex(13);
            this.lblSummary.set_Text("Count/Quantity: 100/100");
            this.lblSummary.set_TextAlignment(2);
            this.cmbUOM.set_BackColor(SystemColors.Window);
            this.cmbUOM.set_DropDownWidth(100);
            this.cmbUOM.set_Layout(new ElementLayout(0, 0, 70, 123, 0, 0, 82, 26));
            this.cmbUOM.set_Name("cmbUOM");
            this.cmbUOM.set_TabIndex(5);
            this.cmbUOM.add_SelectedIndexChanged(new EventHandler(this.cmbUOM_SelectedIndexChanged));
            this.cmbUOM.add_Click(new UIMouseEventHandler(this, frmStockCount.cmbUOM_Click));
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(318, 294);
            base.ControlBox = false;
            base.Controls.Add(this.tbcMenu);
            base.Controls.Add(this.pnlForm);
            base.MinimizeBox = false;
            base.Name = "frmStockCount";
            this.Text = ":: Stock Count";
            base.Load += new EventHandler(this.frmStockCount_Load);
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
                this.txtQuantity.set_Text(string.Empty);
                this.m_bIsItemValidated = false;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void Save()
        {
            try
            {
                double num = Conversion.Val(this.txtQuantity.get_Text());
                if ((num == 0 ? true : num > 9999))
                {
                    this.txtQuantity.SelectAll();
                    this.txtQuantity.Focus();
                    throw new Exception("Invalid quantity");
                }
                if (this.txtItemcode.get_Text().Length == 0)
                {
                    if (Property.Setup.Rows[0]["Prompt on Invalid Barcode-SC"].ToString() == "1")
                    {
                        if ((int)Property.TransLine.Select(string.Format("Barcode = '{0}'", CommonLib.FormatString(this.txtBarcode.get_Text()))).Length == 0)
                        {
                            Cursor.Current = Cursors.Default;
                            if (MessageBoxEx.Show("Barcode is invalid. Are you sure you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.No)
                            {
                                Application.DoEvents();
                                Cursor.Current = Cursors.WaitCursor;
                            }
                            else
                            {
                                this.txtBarcode.SelectAll();
                                this.txtBarcode.Focus();
                                return;
                            }
                        }
                    }
                }
                iNTrackLib.InsertStockCount(this.cmbBin.get_Text(), this.txtItemcode.get_Text(), this.txtBarcode.get_Text(), this.txtDesc.get_Text(), this.cmbUOM.get_Text(), 1, num, Conversion.Val(this.txtPrice.get_Text()), 0);
                this.GetStockCountDetail(false);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void SetControls()
        {
            try
            {
                double num = Math.Round(Conversion.Val(Convert.ToString(Property.TransLine.Compute("Sum(Quantity)", string.Empty))), 2);
                string str = num.ToString();
                UILabel uILabel = this.lblSummary;
                int count = Property.TransLine.Rows.Count;
                uILabel.set_Text(string.Format("Count/Qty: {0}/{1}", count.ToString(), str));
                this.tbiUndo.set_Enabled(str != "0");
                this.tbiConfirm.set_Enabled(str != "0");
                this.tbiNext.set_Enabled(Property.TransLine.Rows.Count > 0);
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
            try
            {
                try
                {
                    switch (this.tbcMenu.get_SelectedIndex())
                    {
                        case 0:
                            {
                                CommonLib.SwitchForm(new frmOptions());
                                break;
                            }
                        case 1:
                            {
                                if (MessageBoxEx.Show("Are you sure you want to undo complete stock count?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    Application.DoEvents();
                                    Cursor.Current = Cursors.WaitCursor;
                                }
                                break;
                            }
                        case 2:
                            {
                                if (MessageBoxEx.Show("Are you sure you want to confirm?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    Application.DoEvents();
                                    Cursor.Current = Cursors.WaitCursor;
                                    Service service = new Service();
                                    try
                                    {
                                        service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                        string[] str = new string[] { "HHT_Stock_Count_Bin_4000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionNo, this.cmbBin.get_Text() };
                                        service.SetData(str, new DataSet());
                                    }
                                    finally
                                    {
                                        if (service != null)
                                        {
                                            ((IDisposable)service).Dispose();
                                        }
                                    }
                                    this.m_dtBin.Select(string.Format("[Count No] = '{0}' And [Bin Code] = '{1}'", Property.TransactionNo, this.cmbBin.get_Text()))[0].Delete();
                                    this.m_dtBin.AcceptChanges();
                                    CommonLib.SetDropDown("Bin Code", "Count No", this.m_dtBin, this.cmbBin);
                                    Property.TransactionNo = string.Empty;
                                    this.GetStockCountDetail(true);
                                }
                                break;
                            }
                        case 3:
                            {
                                frmTransLines frmTransLine = new frmTransLines(frmTransLines.SourceEnum.TransactionLine);
                                try
                                {
                                    frmTransLine.ShowDialog();
                                }
                                finally
                                {
                                    if (frmTransLine != null)
                                    {
                                        ((IDisposable)frmTransLine).Dispose();
                                    }
                                }
                                break;
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
                    if (this.cmbBin.get_SelectedIndex() == -1)
                    {
                        e.Handled = true;
                        this.cmbBin.Focus();
                        throw new Exception("Invalid storage area");
                    }
                    if (e.KeyChar == '\r')
                    {
                        this.txtBarcode.set_Text(this.txtBarcode.get_Text().Trim().ToUpper());
                        if (!string.IsNullOrEmpty(this.txtBarcode.get_Text()))
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            this.GetItemDetail(string.Empty);
                            this.txtQuantity.SelectAll();
                            this.txtQuantity.Focus();
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
                if (this.txtItemcode.get_Text().Trim().Length != 0)
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

        private void txtItemcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                try
                {
                    if (this.cmbBin.get_SelectedIndex() == -1)
                    {
                        e.Handled = true;
                        this.cmbBin.Focus();
                        throw new Exception("Invalid storage area");
                    }
                    if (e.KeyChar == '\r')
                    {
                        this.txtItemcode.set_Text(this.txtItemcode.get_Text().Trim().ToUpper());
                        if (!string.IsNullOrEmpty(this.txtItemcode.get_Text()))
                        {
                            if (this.txtItemcode.get_Text().Length != 4)
                            {
                                throw new Exception("Itemcode entry is limited to weighable items");
                            }
                            Cursor.Current = Cursors.WaitCursor;
                            this.GetItemDetail(this.txtItemcode.get_Text());
                            this.txtQuantity.SelectAll();
                            this.txtQuantity.Focus();
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
                if (this.txtBarcode.get_Text().Trim().Length != 0)
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

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                try
                {
                    int keyChar = e.KeyChar;
                    if (keyChar == 13)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        this.Save();
                    }
                    else if (keyChar != 46)
                    {
                        e.Handled = (keyChar == 8 ? false : !Enumerable.Range(48, 10).Contains<int>(keyChar));
                    }
                    else
                    {
                        e.Handled = ((UITextBox)sender).get_Text().Contains<char>('.');
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