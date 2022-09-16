using iNTrack.iNTrackService;
using Microsoft.VisualBasic;
using Resco.Controls.CommonControls;
using Resco.Controls.MessageBox;
using Resco.Controls.OutlookControls;
using Resco.UIElements;
using Resco.UIElements.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Services.Protocols;
using System.Windows.Forms;

namespace iNTrack
{
    public class frmTransLine : Form
    {
        private bool m_bIsItemValidated;

        private bool m_bValidateLine;

        private double m_dWasPrice;

        private double m_dNowPrice;

        private double m_dDiscAmount;

        private DataTable m_dtItem;

        private IContainer components = null;

        private UIElementPanelControl pnlForm;

        private UILabel lblBarcode;

        private UILabel lblQuantity;

        private ToolbarControl tbcMenu;

        private ToolbarItem tbiBack;

        private ToolbarItem tbiUndo;

        private ToolbarItem tbiNext;

        private UILabel lblItemcode;

        private UITextBox txtDesc;

        private UILabel lblDesc;

        private UITextBox txtPrice;

        private UILabel lblSummary;

        private UIButton btnLastScan;

        private UILabel lblUOM;

        private UIButton btnIC;

        private ToolbarItem tbiLine;

        private UITextBox txtAmount;

        private UILabel lblTotAmount;

        private UILabel lblShelf;

        private UIComboBox cmbUOM;

        private UITextBox txtBarcode;

        private UITextBoxButton btnBarcode;

        private UITextBox txtItemcode;

        private UITextBoxButton btnItemcode;

        private UITextBox txtQuantity;

        private UITextBoxButton btnQuantity;

        private UITextBox txtShelfNo;

        private UITextBoxButton btnShelfNo;

        private UIComboBox cmbReason;

        private UITextBox txtShelfPrice;

        private UITextBoxButton btnShelfPrice;

        private UILabel lblReason;

        private UITextBoxButton btnPrice;

        private UITextBoxButton btnAmount;

        private OutlookDateTimePicker dtpProdDate;

        private OutlookDateTimePicker dtpExpDate;

        private UICheckBox chkDate;

        private UICheckBox chkExcludePrice;

        public frmTransLine()
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
                try
                {
                    this.btnLastScan.Focus();
                    DataRow[] dataRowArray = Property.TransLine.Select("Quantity > 0", "[Line No.] Desc");
                    if ((int)dataRowArray.Length == 0)
                    {
                        throw new Exception("No item scanned yet");
                    }
                    frmItem _frmItem = new frmItem(dataRowArray[0]["Itemcode"].ToString(), dataRowArray[0]["Barcode"].ToString(), dataRowArray[0]["Description"].ToString(), dataRowArray[0]["UOM"].ToString(), double.Parse(dataRowArray[0]["Unit Price"].ToString()), double.Parse(dataRowArray[0]["Quantity"].ToString()));
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
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpProdDate.Enabled = this.chkDate.get_Checked();
            this.dtpExpDate.Enabled = this.chkDate.get_Checked();
        }

        private void cmbReason_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                try
                {
                    if ((e.KeyChar != '\r' ? false : this.cmbReason.get_SelectedIndex() > -1))
                    {
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

        private void cmbReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (Property.TransactionType == Property.TransactionTypeEnum.SPC)
                    {
                        switch (this.cmbReason.get_SelectedIndex())
                        {
                            case 0:
                            case 1:
                                {
                                    this.txtShelfPrice.set_Text(this.txtPrice.get_Text());
                                    this.txtShelfPrice.set_Enabled(false);
                                    break;
                                }
                            case 2:
                                {
                                    this.txtShelfPrice.set_Enabled(true);
                                    this.txtShelfPrice.set_Text(string.Empty);
                                    break;
                                }
                            case 3:
                                {
                                    this.txtShelfPrice.set_Text("0");
                                    this.txtShelfPrice.set_Enabled(false);
                                    break;
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

        private void cmbUOM_Click(object sender, UIMouseEventArgs e)
        {
            try
            {
                try
                {
                    if ((!this.m_bIsItemValidated || (int)this.cmbUOM.get_StringData().Length != 1 ? false : !this.m_bValidateLine))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        Service service = new Service();
                        try
                        {
                            service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                            Service service1 = service;
                            string[] str = new string[] { "HHT_Barcodes_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), null, null };
                            str[3] = (Property.Module != Property.ModuleEnum.Purchase || !Property.IsPortSelected ? string.Empty : Property.TransactionPortCode);
                            str[4] = CommonLib.FormatString(this.txtItemcode.get_Text());
                            this.m_dtItem = service1.GetData(str).Tables[0];
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

        private void dtpExpDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtpExpDate.get_Value().Date > this.dtpProdDate.get_Value().Date)
            {
                this.dtpExpDate.set_Value(this.dtpProdDate.get_Value().Date);
            }
        }

        private void frmTransLine_Load(object sender, EventArgs e)
        {
            DataTable item;
            bool flag;
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Property.TransactionTypeEnum transactionType = Property.TransactionType;
                    switch (transactionType)
                    {
                        case Property.TransactionTypeEnum.SPC:
                            {
                                this.Text = ":: Shelf Price Check Line";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.PRQ:
                            {
                                this.Text = ":: Purch. Req. Line";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.PO:
                            {
                                this.Text = ":: Purch. Order Line";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.PI:
                            {
                                this.Text = ":: Purch. Receipt Note Line";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.PR:
                        case Property.TransactionTypeEnum.PRS:
                            {
                                this.Text = ":: Purch. Return Line";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.SO:
                        case Property.TransactionTypeEnum.SI:
                            {
                                this.Text = ":: Sales Order Line";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.SR:
                        case Property.TransactionTypeEnum.SRR:
                            {
                                this.Text = ":: Sales Return Line";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.TRQ:
                            {
                                this.Text = ":: Transfer Req. Line";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.TRO:
                        case Property.TransactionTypeEnum.TRS:
                            {
                                this.Text = ":: Transfer Out Line";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.TRI:
                            {
                                this.Text = ":: Transfer In Line";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.ADJ:
                            {
                                this.Text = ":: Stock Wastage Line";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.SHRINK:
                            {
                                this.Text = ":: Stock Shrink. Line";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.MISC:
                            {
                                this.Text = ":: Stock Misc. Line";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.SC:
                            {
                                this.m_bValidateLine = iNTrackLib.CheckItemValidity();
                                ToolbarItem toolbarItem = this.tbiLine;
                                if ((Property.TransactionType != Property.TransactionTypeEnum.PI || !(Property.Setup.Rows[0]["Show Purchase Invoice Line"].ToString() == "Yes") && !(Property.Setup.Rows[0]["Show Purchase Invoice Line"].ToString() == "1") || !(Property.TransactionStatus == "AU")) && (Property.TransactionType != Property.TransactionTypeEnum.PRS || !(Property.Setup.Rows[0]["Show Purchase Return Line"].ToString() == "Yes") && !(Property.Setup.Rows[0]["Show Purchase Return Line"].ToString() == "1") || !(Property.TransactionStatus == "AU")) && (Property.TransactionType != Property.TransactionTypeEnum.SI || !(Property.Setup.Rows[0]["Show Sales Invoice Line"].ToString() == "Yes") && !(Property.Setup.Rows[0]["Show Sales Invoice Line"].ToString() == "1") || !(Property.TransactionStatus == "AU")) && (Property.TransactionType != Property.TransactionTypeEnum.SRR || !(Property.Setup.Rows[0]["Show Sales Return Line"].ToString() == "Yes") && !(Property.Setup.Rows[0]["Show Sales Return Line"].ToString() == "1") || !(Property.TransactionStatus == "AU")) && (Property.TransactionType != Property.TransactionTypeEnum.TRS || !(Property.Setup.Rows[0]["Show Transfer Shipment Line"].ToString() == "Yes") && !(Property.Setup.Rows[0]["Show Transfer Shipment Line"].ToString() == "1") || !(Property.TransactionStatus == "AU")))
                                {
                                    flag = (Property.TransactionType != Property.TransactionTypeEnum.TRI || !(Property.Setup.Rows[0]["Show Transfer Receipt Line"].ToString() == "Yes") && !(Property.Setup.Rows[0]["Show Transfer Receipt Line"].ToString() == "1") ? false : Property.TransactionStatus == "AU");
                                }
                                else
                                {
                                    flag = true;
                                }
                                toolbarItem.set_Enabled(flag);
                                if (!Property.ShowPrice)
                                {
                                    this.lblUOM.set_Text("UOM");
                                    this.txtPrice.set_Visible(false);
                                }
                                if (!Property.ShowAmount)
                                {
                                    this.lblQuantity.set_Text("Quantity");
                                    this.txtAmount.set_Visible(false);
                                    this.lblTotAmount.set_Visible(false);
                                }
                                this.lblReason.set_Visible(false);
                                this.cmbReason.set_Visible(false);
                                this.lblShelf.set_Visible(false);
                                this.txtShelfNo.set_Visible(false);
                                this.txtShelfPrice.set_Visible(false);
                                this.dtpProdDate.set_Visible(false);
                                this.dtpExpDate.set_Visible(false);
                                this.chkDate.set_Visible(false);
                                this.chkExcludePrice.set_Visible(false);
                                transactionType = Property.TransactionType;
                                if (transactionType == Property.TransactionTypeEnum.SPC)
                                {
                                    this.lblReason.set_Visible(true);
                                    this.cmbReason.set_Visible(true);
                                    this.lblShelf.set_Visible(true);
                                    this.txtShelfNo.set_Visible(true);
                                    this.txtShelfPrice.set_Visible(true);
                                    DataTable dataTable = new DataTable();
                                    dataTable.Columns.Add("Code");
                                    dataTable.Columns.Add("Description");
                                    DataRowCollection rows = dataTable.Rows;
                                    object[] objArray = new object[] { "GD", "Good" };
                                    rows.Add(objArray);
                                    DataRowCollection dataRowCollection = dataTable.Rows;
                                    objArray = new object[] { "BD", "Bad" };
                                    dataRowCollection.Add(objArray);
                                    DataRowCollection rows1 = dataTable.Rows;
                                    objArray = new object[] { "ER", "Erroneous" };
                                    rows1.Add(objArray);
                                    DataRowCollection dataRowCollection1 = dataTable.Rows;
                                    objArray = new object[] { "MS", "Missing" };
                                    dataRowCollection1.Add(objArray);
                                    CommonLib.SetDropDown("Description", "Code", dataTable, this.cmbReason);
                                }
                                else
                                {
                                    switch (transactionType)
                                    {
                                        case Property.TransactionTypeEnum.PR:
                                        case Property.TransactionTypeEnum.PRS:
                                            {
                                            Label1:
                                                if (Property.TransactionStatus == "SM")
                                                {
                                                    this.lblReason.set_Visible(true);
                                                    this.cmbReason.set_Visible(true);
                                                    string empty = string.Empty;
                                                    transactionType = Property.TransactionType;
                                                    switch (transactionType)
                                                    {
                                                        case Property.TransactionTypeEnum.PR:
                                                        case Property.TransactionTypeEnum.PRS:
                                                            {
                                                                empty = "RETURN";
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                switch (transactionType)
                                                                {
                                                                    case Property.TransactionTypeEnum.ADJ:
                                                                        {
                                                                            empty = "WASTE";
                                                                            break;
                                                                        }
                                                                    case Property.TransactionTypeEnum.SHRINK:
                                                                        {
                                                                            empty = "SHRINK";
                                                                            break;
                                                                        }
                                                                    case Property.TransactionTypeEnum.MISC:
                                                                        {
                                                                            empty = "MISC";
                                                                            break;
                                                                        }
                                                                }
                                                                break;
                                                            }
                                                    }
                                                    Service service = new Service();
                                                    try
                                                    {
                                                        service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                                        string[] str = new string[] { "Reason_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), "%" };
                                                        item = service.GetData(str).Tables[0];
                                                        DataRow[] dataRowArray = item.Copy().Select(string.Format("[Type] <> '{0}'", empty));
                                                        for (int i = 0; i < (int)dataRowArray.Length; i++)
                                                        {
                                                            DataRow dataRow = dataRowArray[i];
                                                            item.Select(string.Format("Code = '{0}'", dataRow["Code"]))[0].Delete();
                                                        }
                                                        item.Columns["Name"].ColumnName = "Description";
                                                    }
                                                    finally
                                                    {
                                                        if (service != null)
                                                        {
                                                            ((IDisposable)service).Dispose();
                                                        }
                                                    }
                                                    CommonLib.SetDropDown("Description", "Code", item.DefaultView.ToTable(), this.cmbReason);
                                                }
                                                break;
                                            }
                                        default:
                                            {
                                                switch (transactionType)
                                                {
                                                    case Property.TransactionTypeEnum.ADJ:
                                                    case Property.TransactionTypeEnum.SHRINK:
                                                    case Property.TransactionTypeEnum.MISC:
                                                        {
                                                            goto Label1;
                                                        }
                                                    case Property.TransactionTypeEnum.PLC:
                                                        {
                                                            this.lblReason.set_Visible(true);
                                                            this.lblReason.set_Text("Prod.");
                                                            this.lblShelf.set_Visible(true);
                                                            this.lblShelf.set_Text("Exp.");
                                                            this.dtpProdDate.set_Visible(true);
                                                            this.dtpExpDate.set_Visible(true);
                                                            this.chkDate.set_Visible(true);
                                                            this.chkExcludePrice.set_Visible(true);
                                                            break;
                                                        }
                                                }
                                                break;
                                            }
                                    }
                                }
                                this.GetTransDetail(true);
                                break;
                            }
                        case Property.TransactionTypeEnum.PLC:
                            {
                                this.Text = ":: Product Label Count Line";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.SLC:
                            {
                                this.Text = ":: Shelf Label Count Line";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        default:
                            {
                                goto case Property.TransactionTypeEnum.SC;
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

        private void GetItemDetail(string Itemcode)
        {
            DataTable item;
            DataRow[] dataRowArray;
            Service service;
            string[] str;
            bool flag;
            bool flag1;
            try
            {
                string empty = string.Empty;
                DataRow dataRow = null;
                if (Itemcode.Length == 0)
                {
                    empty = (this.txtBarcode.get_Text().Length != 14 || !(this.txtBarcode.get_Text().Substring(0, 3) == "990") ? this.txtBarcode.get_Text() : string.Format("{0}00000", this.txtBarcode.get_Text().Substring(0, 9)));
                    if (!this.m_bValidateLine)
                    {
                        service = new Service();
                        try
                        {
                            service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                            Service service1 = service;
                            str = new string[] { "HHT_Barcodes_3001", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), null, null };
                            str[3] = (Property.Module != Property.ModuleEnum.Purchase || !Property.IsPortSelected ? string.Empty : Property.TransactionPortCode);
                            str[4] = CommonLib.FormatString(empty);
                            item = service1.GetData(str).Tables[0];
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
                        dataRowArray = Property.DocLine.Select(string.Format("[Barcode] = '{0}'", empty), string.Empty);
                        if ((int)dataRowArray.Length > 0)
                        {
                            dataRow = dataRowArray[0];
                        }
                    }
                }
                else if (!this.m_bValidateLine)
                {
                    service = new Service();
                    try
                    {
                        service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                        Service service2 = service;
                        str = new string[] { "HHT_Barcodes_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), null, null };
                        str[3] = (Property.Module != Property.ModuleEnum.Purchase || !Property.IsPortSelected ? string.Empty : Property.TransactionPortCode);
                        str[4] = CommonLib.FormatString(Itemcode);
                        item = service2.GetData(str).Tables[0];
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
                    dataRowArray = Property.DocLine.Select(string.Format("[Itemcode] = '{0}'", Itemcode), string.Empty);
                    if ((int)dataRowArray.Length > 0)
                    {
                        dataRow = dataRowArray[0];
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
                if (!this.m_bValidateLine)
                {
                    if (Property.Module == Property.ModuleEnum.Purchase)
                    {
                        if (!Property.IsPortSelected)
                        {
                            if (string.IsNullOrEmpty(dataRow["Vendor Code"].ToString()))
                            {
                                throw new Exception("Vendor detail is missing");
                            }
                            Property.TransactionPortCode = dataRow["Vendor Code"].ToString();
                            Property.TransactionPortName = dataRow["Vendor Name"].ToString();
                        }
                        else if (dataRow["Vendor Code"].ToString() != Property.TransactionPortCode)
                        {
                            throw new Exception("Itemcode is not part of selected vendor");
                        }
                    }
                    switch (Property.Module)
                    {
                        case Property.ModuleEnum.Purchase:
                            {
                                if (iNTrackLib.IsItemBlocked(dataRow["PURCHSTOPPED"].ToString()))
                                {
                                    throw new Exception("Item has been blocked");
                                }
                                break;
                            }
                        case Property.ModuleEnum.Sales:
                            {
                                if (iNTrackLib.IsItemBlocked(dataRow["SALESTOPPED"].ToString()))
                                {
                                    throw new Exception("Item has been blocked");
                                }
                                break;
                            }
                        case Property.ModuleEnum.Store:
                            {
                                if (iNTrackLib.IsItemBlocked(dataRow["INVENTSTOPPED"].ToString()))
                                {
                                    throw new Exception("Item has been blocked");
                                }
                                break;
                            }
                    }
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
                    if (Conversion.Val(this.txtPrice.get_Text()) > 0)
                    {
                        UITextBox uITextBox = this.txtQuantity;
                        double num = double.Parse(string.Concat(this.txtBarcode.get_Text().Substring(9, 3), ".", this.txtBarcode.get_Text().Substring(12, 2))) / double.Parse(this.txtPrice.get_Text());
                        uITextBox.set_Text(num.ToString("F"));
                        UITextBox uITextBox1 = this.txtAmount;
                        num = Conversion.Val(this.txtQuantity.get_Text()) * Conversion.Val(this.txtPrice.get_Text());
                        uITextBox1.set_Text(num.ToString("F"));
                    }
                    this.txtBarcode.remove_TextChanged(new EventHandler(this.txtBarcode_TextChanged));
                    this.txtBarcode.set_Text(empty);
                    this.txtBarcode.add_TextChanged(new EventHandler(this.txtBarcode_TextChanged));
                }
                UITextBox uITextBox2 = this.txtPrice;
                if (Property.TransactionType == Property.TransactionTypeEnum.PI || Property.TransactionType == Property.TransactionTypeEnum.PR)
                {
                    flag = false;
                }
                else
                {
                    flag = (Property.TransactionType != Property.TransactionTypeEnum.PRS ? true : !(Property.TransactionStatus == "SM"));
                }
                uITextBox2.set_ReadOnly(flag);
                if (this.txtPrice.get_ReadOnly())
                {
                    this.btnPrice.set_VisibleMode(0);
                }
                UITextBox uITextBox3 = this.txtAmount;
                if (Property.TransactionType == Property.TransactionTypeEnum.PO)
                {
                    flag1 = false;
                }
                else
                {
                    flag1 = (Property.TransactionType != Property.TransactionTypeEnum.PI ? true : !(Property.TransactionStatus == "SM"));
                }
                uITextBox3.set_ReadOnly(flag1);
                if (this.txtAmount.get_ReadOnly())
                {
                    this.btnAmount.set_VisibleMode(0);
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

        private void GetTransDetail(bool RefreshData)
        {
            try
            {
                if (RefreshData)
                {
                    Property.DocLine = new DataTable();
                    Service service = new Service();
                    try
                    {
                        service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                        if (this.m_bValidateLine)
                        {
                            iNTrackLib.GetDocumentLines();
                            if ((int)Property.DocLine.Select("[Barcode] = ''").Length > 0)
                            {
                                MessageBoxEx.Show("Barcode detail is missing", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            }
                        }
                        iNTrackLib.GetTransactionLines();
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
                this.cmbReason.set_SelectedValue(Property.DefaultReasonCode);
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
            this.dtpProdDate = new OutlookDateTimePicker();
            this.tbcMenu = new ToolbarControl();
            this.tbiBack = new ToolbarItem();
            this.tbiLine = new ToolbarItem();
            this.tbiUndo = new ToolbarItem();
            this.tbiNext = new ToolbarItem();
            this.pnlForm = new UIElementPanelControl();
            this.cmbReason = new UIComboBox();
            this.txtShelfNo = new UITextBox();
            this.btnShelfNo = new UITextBoxButton();
            this.lblShelf = new UILabel();
            this.lblBarcode = new UILabel();
            this.lblQuantity = new UILabel();
            this.lblItemcode = new UILabel();
            this.txtDesc = new UITextBox();
            this.lblDesc = new UILabel();
            this.txtPrice = new UITextBox();
            this.btnPrice = new UITextBoxButton();
            this.lblSummary = new UILabel();
            this.btnLastScan = new UIButton();
            this.lblUOM = new UILabel();
            this.btnIC = new UIButton();
            this.txtAmount = new UITextBox();
            this.btnAmount = new UITextBoxButton();
            this.lblTotAmount = new UILabel();
            this.cmbUOM = new UIComboBox();
            this.txtBarcode = new UITextBox();
            this.btnBarcode = new UITextBoxButton();
            this.txtItemcode = new UITextBox();
            this.btnItemcode = new UITextBoxButton();
            this.txtQuantity = new UITextBox();
            this.btnQuantity = new UITextBoxButton();
            this.txtShelfPrice = new UITextBox();
            this.btnShelfPrice = new UITextBoxButton();
            this.lblReason = new UILabel();
            this.chkDate = new UICheckBox();
            this.dtpExpDate = new OutlookDateTimePicker();
            this.chkExcludePrice = new UICheckBox();
            this.pnlForm.SuspendElementLayout();
            base.SuspendLayout();
            this.dtpProdDate.BackColor = SystemColors.Window;
            this.dtpProdDate.BorderStyle = BorderStyle.FixedSingle;
            this.dtpProdDate.set_CustomFormat("dd/MM/yyyy");
            this.dtpProdDate.Font = new Font("Tahoma", 9f, FontStyle.Regular);
            this.dtpProdDate.set_Format(8);
            this.dtpProdDate.Location = new Point(69, 147);
            this.dtpProdDate.set_MaxDate(new DateTime(9999, 12, 31, 23, 59, 59, 999));
            this.dtpProdDate.set_MinDate(new DateTime((long)0));
            this.dtpProdDate.Name = "dtpProdDate";
            this.dtpProdDate.Size = new Size(120, 26);
            this.dtpProdDate.TabIndex = 2;
            this.tbcMenu.set_ArrowsTransparency(0);
            this.tbcMenu.BackColor = Color.Black;
            this.tbcMenu.set_BmpArrowNext(imgManager.GetImage("iNTrack.Arrow Right2"));
            this.tbcMenu.set_BmpArrowPrevious(imgManager.GetImage("iNTrack.Arrow Left2"));
            this.tbcMenu.Dock = DockStyle.Bottom;
            this.tbcMenu.set_EnableArrowsTransparency(false);
            this.tbcMenu.get_Items().Add(this.tbiBack);
            this.tbcMenu.get_Items().Add(this.tbiLine);
            this.tbcMenu.get_Items().Add(this.tbiUndo);
            this.tbcMenu.get_Items().Add(this.tbiNext);
            this.tbcMenu.set_ItemsAlignment(4);
            this.tbcMenu.set_ItemSpacing(5);
            this.tbcMenu.Location = new Point(0, 243);
            this.tbcMenu.set_MarginAtBegin(50);
            this.tbcMenu.set_MarginAtEnd(45);
            this.tbcMenu.Name = "tbcMenu";
            this.tbcMenu.Size = new Size(318, 51);
            this.tbcMenu.TabIndex = 0;
            this.tbcMenu.add_SelectionChanged(new EventHandler(this.tbcMenu_SelectionChanged));
            this.tbiBack.set_BackColor(Color.Black);
            this.tbiBack.set_CustomSize(new Size(0, 0));
            this.tbiBack.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Left"));
            this.tbiBack.set_Name("tbiBack");
            this.tbiBack.set_ToolbarItemBehavior(2);
            this.tbiLine.set_BackColor(Color.Black);
            this.tbiLine.set_CustomSize(new Size(0, 0));
            this.tbiLine.set_ImageDefault(imgManager.GetImage("iNTrack.Document"));
            this.tbiLine.set_Name("tbiLine");
            this.tbiLine.set_ToolbarItemBehavior(2);
            this.tbiUndo.set_BackColor(Color.Black);
            this.tbiUndo.set_CustomSize(new Size(0, 0));
            this.tbiUndo.set_ImageDefault(imgManager.GetImage("iNTrack.Back"));
            this.tbiUndo.set_Name("tbiUndo");
            this.tbiUndo.set_ToolbarItemBehavior(2);
            this.tbiUndo.set_Visible(false);
            this.tbiNext.set_BackColor(Color.Black);
            this.tbiNext.set_CustomSize(new Size(0, 0));
            this.tbiNext.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Right"));
            this.tbiNext.set_Name("tbiNext");
            this.tbiNext.set_ToolbarItemBehavior(2);
            this.pnlForm.set_BackgroundImage(imgManager.GetImage("iNTrack.BGP"));
            this.pnlForm.set_BackgroundImageLayout(6);
            this.pnlForm.get_Children().Add(this.cmbReason);
            this.pnlForm.get_Children().Add(this.txtShelfNo);
            this.pnlForm.get_Children().Add(this.lblShelf);
            this.pnlForm.get_Children().Add(this.lblBarcode);
            this.pnlForm.get_Children().Add(this.lblQuantity);
            this.pnlForm.get_Children().Add(this.lblItemcode);
            this.pnlForm.get_Children().Add(this.txtDesc);
            this.pnlForm.get_Children().Add(this.lblDesc);
            this.pnlForm.get_Children().Add(this.txtPrice);
            this.pnlForm.get_Children().Add(this.lblSummary);
            this.pnlForm.get_Children().Add(this.btnLastScan);
            this.pnlForm.get_Children().Add(this.lblUOM);
            this.pnlForm.get_Children().Add(this.btnIC);
            this.pnlForm.get_Children().Add(this.txtAmount);
            this.pnlForm.get_Children().Add(this.lblTotAmount);
            this.pnlForm.get_Children().Add(this.cmbUOM);
            this.pnlForm.get_Children().Add(this.txtBarcode);
            this.pnlForm.get_Children().Add(this.txtItemcode);
            this.pnlForm.get_Children().Add(this.txtQuantity);
            this.pnlForm.get_Children().Add(this.txtShelfPrice);
            this.pnlForm.get_Children().Add(this.lblReason);
            this.pnlForm.get_Children().Add(this.chkDate);
            this.pnlForm.get_Children().Add(this.chkExcludePrice);
            this.pnlForm.Dock = DockStyle.Fill;
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new Size(318, 294);
            this.pnlForm.TabIndex = 1;
            this.cmbReason.set_BackColor(SystemColors.Window);
            this.cmbReason.set_Layout(new ElementLayout(0, 0, 70, 147, 83, 0, 165, 26));
            this.cmbReason.set_Name("cmbReason");
            this.cmbReason.set_TabIndex(10);
            this.cmbReason.set_Tag("");
            this.cmbReason.add_KeyPress(new KeyPressEventHandler(this.cmbReason_KeyPress));
            this.cmbReason.add_SelectedIndexChanged(new EventHandler(this.cmbReason_SelectedIndexChanged));
            this.txtShelfNo.get_Buttons().Add(this.btnShelfNo);
            this.txtShelfNo.set_Layout(new ElementLayout(0, 0, 70, 174, 0, 0, 82, 26));
            this.txtShelfNo.set_Name("txtShelfNo");
            this.txtShelfNo.set_TabIndex(11);
            this.txtShelfNo.add_KeyPress(new KeyPressEventHandler(this.txtShelfNo_KeyPress));
            this.btnShelfNo.set_Action(1);
            this.btnShelfNo.set_BackColor(Color.Transparent);
            this.btnShelfNo.set_BorderThickness(0);
            this.btnShelfNo.set_HorizontalAlignment(2);
            this.btnShelfNo.set_Name("btnShelfNo");
            this.btnShelfNo.get_PressedBackground().set_BackColor(Color.Transparent);
            this.btnShelfNo.set_Size(new Size(18, 18));
            this.btnShelfNo.set_StateIcon(2);
            this.btnShelfNo.set_VisibleMode(1);
            this.lblShelf.set_AutoSize(false);
            this.lblShelf.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblShelf.set_Layout(new ElementLayout(0, 0, 5, 174, 0, 0, 67, 26));
            this.lblShelf.set_Name("lblShelf");
            this.lblShelf.set_TabIndex(7);
            this.lblShelf.set_Text("Shelf");
            this.lblShelf.set_TextAlignment(2);
            this.lblBarcode.set_AutoSize(false);
            this.lblBarcode.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblBarcode.set_Layout(new ElementLayout(0, 0, 5, 2, 0, 0, 60, 26));
            this.lblBarcode.set_Name("lblBarcode");
            this.lblBarcode.set_TabIndex(7);
            this.lblBarcode.set_Text("Barcode");
            this.lblBarcode.set_TextAlignment(2);
            this.lblQuantity.set_AutoSize(false);
            this.lblQuantity.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblQuantity.set_Layout(new ElementLayout(0, 0, 5, 120, 0, 0, 60, 26));
            this.lblQuantity.set_Name("lblQuantity");
            this.lblQuantity.set_TabIndex(8);
            this.lblQuantity.set_Text("Qty/Amt");
            this.lblQuantity.set_TextAlignment(2);
            this.lblItemcode.set_AutoSize(false);
            this.lblItemcode.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblItemcode.set_Layout(new ElementLayout(0, 0, 5, 30, 0, 0, 60, 26));
            this.lblItemcode.set_Name("lblItemcode");
            this.lblItemcode.set_TabIndex(7);
            this.lblItemcode.set_Text("Itemcode");
            this.lblItemcode.set_TextAlignment(2);
            this.txtDesc.set_Layout(new ElementLayout(3, 0, 70, 56, 3, 0, 245, 36));
            this.txtDesc.set_Multiline(true);
            this.txtDesc.set_Name("txtDesc");
            this.txtDesc.set_ReadOnly(true);
            this.txtDesc.set_TabIndex(5);
            this.lblDesc.set_AutoSize(false);
            this.lblDesc.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblDesc.set_Layout(new ElementLayout(0, 0, 5, 56, 0, 0, 60, 36));
            this.lblDesc.set_Name("lblDesc");
            this.lblDesc.set_TabIndex(6);
            this.lblDesc.set_Text("Desc");
            this.lblDesc.set_TextAlignment(2);
            this.txtPrice.get_Buttons().Add(this.btnPrice);
            this.txtPrice.set_Layout(new ElementLayout(0, 0, 153, 93, 0, 0, 82, 26));
            this.txtPrice.set_Name("txtPrice");
            this.txtPrice.set_ReadOnly(true);
            this.txtPrice.set_TabIndex(7);
            this.txtPrice.add_KeyPress(new KeyPressEventHandler(this.txtPrice_KeyPress));
            this.txtPrice.add_TextChanged(new EventHandler(this.txtQuantity_TextChanged));
            this.txtPrice.add_LostFocus(new EventHandler(this.txtPrice_LostFocus));
            this.btnPrice.set_Action(1);
            this.btnPrice.set_BackColor(Color.Transparent);
            this.btnPrice.set_BorderThickness(0);
            this.btnPrice.set_HorizontalAlignment(2);
            this.btnPrice.set_Name("btnPrice");
            this.btnPrice.get_PressedBackground().set_BackColor(Color.Transparent);
            this.btnPrice.set_Size(new Size(18, 18));
            this.btnPrice.set_StateIcon(2);
            this.btnPrice.set_VisibleMode(1);
            this.lblSummary.set_Font(new Font("Tahoma", 8f, FontStyle.Bold | FontStyle.Underline));
            this.lblSummary.set_ForeColor(Color.Black);
            this.lblSummary.set_Layout(new ElementLayout(0, 0, 5, 225, 0, 0, 162, 13));
            this.lblSummary.set_Name("lblSummary");
            this.lblSummary.set_TabIndex(13);
            this.lblSummary.set_Text("Count/Qty/Inv: 100/100/100");
            this.lblSummary.set_TextAlignment(2);
            this.btnLastScan.set_BackColor(SystemColors.Desktop);
            this.btnLastScan.set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
            this.btnLastScan.set_ForeColor(Color.White);
            this.btnLastScan.set_Layout(new ElementLayout(0, 0, 153, 201, 0, 0, 82, 23));
            this.btnLastScan.set_Name("btnLastScan");
            this.btnLastScan.set_TabIndex(13);
            this.btnLastScan.set_Text("Last Scan?");
            this.btnLastScan.add_Click(new UIMouseEventHandler(this, frmTransLine.btnLastScan_Click));
            this.lblUOM.set_AutoSize(false);
            this.lblUOM.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblUOM.set_Layout(new ElementLayout(0, 0, 5, 94, 0, 0, 71, 26));
            this.lblUOM.set_Name("lblUOM");
            this.lblUOM.set_TabIndex(6);
            this.lblUOM.set_Text("UOM/Price");
            this.lblUOM.set_TextAlignment(2);
            this.btnIC.set_BackColor(SystemColors.Desktop);
            this.btnIC.set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
            this.btnIC.set_ForeColor(Color.White);
            this.btnIC.set_Layout(new ElementLayout(2, 0, 0, 29, 3, 0, 34, 26));
            this.btnIC.set_Name("btnIC");
            this.btnIC.set_TabIndex(4);
            this.btnIC.set_Text("...");
            this.btnIC.add_Click(new UIMouseEventHandler(this, frmTransLine.btnIC_Click));
            this.txtAmount.get_Buttons().Add(this.btnAmount);
            this.txtAmount.set_Layout(new ElementLayout(0, 0, 153, 120, 0, 0, 82, 26));
            this.txtAmount.set_Name("txtAmount");
            this.txtAmount.set_ReadOnly(true);
            this.txtAmount.set_TabIndex(9);
            this.txtAmount.add_KeyPress(new KeyPressEventHandler(this.txtPrice_KeyPress));
            this.txtAmount.add_LostFocus(new EventHandler(this.txtAmount_LostFocus));
            this.btnAmount.set_Action(1);
            this.btnAmount.set_BackColor(Color.Transparent);
            this.btnAmount.set_BorderThickness(0);
            this.btnAmount.set_HorizontalAlignment(2);
            this.btnAmount.set_Name("btnAmount");
            this.btnAmount.get_PressedBackground().set_BackColor(Color.Transparent);
            this.btnAmount.set_Size(new Size(18, 18));
            this.btnAmount.set_StateIcon(2);
            this.btnAmount.set_VisibleMode(1);
            this.lblTotAmount.set_Font(new Font("Tahoma", 8f, FontStyle.Bold | FontStyle.Underline));
            this.lblTotAmount.set_ForeColor(Color.Black);
            this.lblTotAmount.set_Layout(new ElementLayout(0, 0, 5, 205, 0, 0, 107, 13));
            this.lblTotAmount.set_Name("lblTotAmount");
            this.lblTotAmount.set_TabIndex(12);
            this.lblTotAmount.set_Text("Total Amount: 1000");
            this.lblTotAmount.set_TextAlignment(2);
            this.cmbUOM.set_BackColor(SystemColors.Window);
            this.cmbUOM.set_DropDownWidth(100);
            this.cmbUOM.set_Layout(new ElementLayout(0, 0, 70, 93, 0, 0, 82, 26));
            this.cmbUOM.set_Name("cmbUOM");
            this.cmbUOM.set_TabIndex(6);
            this.cmbUOM.add_SelectedIndexChanged(new EventHandler(this.cmbUOM_SelectedIndexChanged));
            this.cmbUOM.add_Click(new UIMouseEventHandler(this, frmTransLine.cmbUOM_Click));
            this.txtBarcode.get_Buttons().Add(this.btnBarcode);
            this.txtBarcode.set_Layout(new ElementLayout(3, 0, 70, 2, 3, 0, 245, 26));
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
            this.txtItemcode.set_Layout(new ElementLayout(3, 0, 70, 29, 39, 0, 209, 26));
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
            this.txtQuantity.get_Buttons().Add(this.btnQuantity);
            this.txtQuantity.set_Layout(new ElementLayout(0, 0, 70, 120, 166, 0, 82, 26));
            this.txtQuantity.set_Name("txtQuantity");
            this.txtQuantity.set_TabIndex(8);
            this.txtQuantity.add_KeyPress(new KeyPressEventHandler(this.txtQuantity_KeyPress));
            this.txtQuantity.add_TextChanged(new EventHandler(this.txtQuantity_TextChanged));
            this.btnQuantity.set_Action(1);
            this.btnQuantity.set_BackColor(Color.Transparent);
            this.btnQuantity.set_BorderThickness(0);
            this.btnQuantity.set_HorizontalAlignment(2);
            this.btnQuantity.set_Name("btnQuantity");
            this.btnQuantity.get_PressedBackground().set_BackColor(Color.Transparent);
            this.btnQuantity.set_Size(new Size(18, 18));
            this.btnQuantity.set_StateIcon(2);
            this.btnQuantity.set_VisibleMode(1);
            this.txtShelfPrice.get_Buttons().Add(this.btnShelfPrice);
            this.txtShelfPrice.set_Layout(new ElementLayout(0, 0, 153, 174, 0, 0, 82, 26));
            this.txtShelfPrice.set_Name("txtShelfPrice");
            this.txtShelfPrice.set_TabIndex(12);
            this.txtShelfPrice.add_KeyPress(new KeyPressEventHandler(this.txtPrice_KeyPress));
            this.btnShelfPrice.set_Action(1);
            this.btnShelfPrice.set_BackColor(Color.Transparent);
            this.btnShelfPrice.set_BorderThickness(0);
            this.btnShelfPrice.set_HorizontalAlignment(2);
            this.btnShelfPrice.set_Name("btnShelfPrice");
            this.btnShelfPrice.get_PressedBackground().set_BackColor(Color.Transparent);
            this.btnShelfPrice.set_Size(new Size(18, 18));
            this.btnShelfPrice.set_StateIcon(2);
            this.btnShelfPrice.set_VisibleMode(1);
            this.lblReason.set_AutoSize(false);
            this.lblReason.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblReason.set_Layout(new ElementLayout(0, 0, 5, 147, 0, 0, 60, 26));
            this.lblReason.set_Name("lblReason");
            this.lblReason.set_TabIndex(5);
            this.lblReason.set_Text("Reason");
            this.lblReason.set_TextAlignment(2);
            this.chkDate.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.chkDate.set_Layout(new ElementLayout(0, 0, 192, 146, 0, 0, 29, 29));
            this.chkDate.set_Name("chkDate");
            this.chkDate.set_TabIndex(14);
            this.chkDate.add_CheckedChanged(new EventHandler(this.chkDate_CheckedChanged));
            this.dtpExpDate.BackColor = SystemColors.Window;
            this.dtpExpDate.BorderStyle = BorderStyle.FixedSingle;
            this.dtpExpDate.set_CustomFormat("dd/MM/yyyy");
            this.dtpExpDate.Font = new Font("Tahoma", 9f, FontStyle.Regular);
            this.dtpExpDate.set_Format(8);
            this.dtpExpDate.Location = new Point(69, 174);
            this.dtpExpDate.set_MaxDate(new DateTime(9999, 12, 31, 23, 59, 59, 999));
            this.dtpExpDate.set_MinDate(new DateTime((long)0));
            this.dtpExpDate.Name = "dtpExpDate";
            this.dtpExpDate.Size = new Size(120, 26);
            this.dtpExpDate.TabIndex = 3;
            this.dtpExpDate.add_ValueChanged(new EventHandler(this.dtpExpDate_ValueChanged));
            this.chkExcludePrice.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.chkExcludePrice.set_Layout(new ElementLayout(0, 0, 153, 118, 0, 0, 76, 29));
            this.chkExcludePrice.set_Name("chkExcludePrice");
            this.chkExcludePrice.set_TabIndex(14);
            this.chkExcludePrice.set_Text("Ex. Price");
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(318, 294);
            base.ControlBox = false;
            base.Controls.Add(this.dtpExpDate);
            base.Controls.Add(this.dtpProdDate);
            base.Controls.Add(this.tbcMenu);
            base.Controls.Add(this.pnlForm);
            base.MinimizeBox = false;
            base.Name = "frmTransLine";
            this.Text = ":: Transaction Line";
            base.Load += new EventHandler(this.frmTransLine_Load);
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
                this.txtAmount.set_Text(string.Empty);
                this.txtShelfNo.set_Text(string.Empty);
                this.txtShelfPrice.set_Text(string.Empty);
                this.txtPrice.set_ReadOnly(true);
                this.txtAmount.set_ReadOnly(true);
                this.chkDate.set_Checked(false);
                this.chkExcludePrice.set_Checked(false);
                this.dtpProdDate.Enabled = false;
                this.dtpExpDate.Enabled = false;
                this.dtpProdDate.set_Value(DateTime.Now.Date);
                this.dtpExpDate.set_Value(DateTime.Now.Date);
                this.m_dWasPrice = 0;
                this.m_dNowPrice = 0;
                this.m_dDiscAmount = 0;
                this.m_bIsItemValidated = false;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void Save()
        {
            DateTime date;
            string str;
            string empty;
            try
            {
                if (string.IsNullOrEmpty(this.txtBarcode.get_Text().Trim()))
                {
                    this.txtBarcode.SelectAll();
                    this.txtBarcode.Focus();
                    throw new Exception("Invalid barcode");
                }
                double num = Conversion.Val(this.txtQuantity.get_Text());
                if ((num == 0 ? true : num > 9999))
                {
                    this.txtQuantity.SelectAll();
                    this.txtQuantity.Focus();
                    throw new Exception("Invalid quantity");
                }
                if ((!this.cmbReason.get_Visible() ? false : this.cmbReason.get_SelectedIndex() == -1))
                {
                    this.cmbReason.Focus();
                    throw new Exception("Invalid reason");
                }
                if ((!this.txtShelfNo.get_Visible() ? false : string.IsNullOrEmpty(this.txtShelfNo.get_Text().Trim())))
                {
                    this.txtShelfNo.SelectAll();
                    this.txtShelfNo.Focus();
                    throw new Exception("Invalid shelf no.");
                }
                if ((!this.txtShelfPrice.get_Visible() || !this.txtShelfPrice.get_Enabled() ? false : Conversion.Val(this.txtShelfPrice.get_Text()) == 0))
                {
                    this.txtShelfPrice.SelectAll();
                    this.txtShelfPrice.Focus();
                    throw new Exception("Invalid shelf price");
                }
                if ((Property.Module != Property.ModuleEnum.Purchase ? false : Conversion.Val(this.txtPrice.get_Text()) == 0))
                {
                    this.txtBarcode.SelectAll();
                    this.txtBarcode.Focus();
                    throw new Exception("Invalid price");
                }
                if (this.m_bValidateLine)
                {
                    double num1 = Conversion.Val(Convert.ToString(Property.DocLine.Compute("Sum(Quantity)", string.Format("Barcode = '{0}'", this.txtBarcode.get_Text()))));
                    if (Conversion.Val(Convert.ToString(Property.TransLine.Compute("Sum(Quantity)", string.Format("Barcode = '{0}'", this.txtBarcode.get_Text())))) + num > num1)
                    {
                        this.txtQuantity.SelectAll();
                        this.txtQuantity.Focus();
                        throw new Exception("Excess quantity not allowed");
                    }
                }
                string text = this.txtItemcode.get_Text();
                string text1 = this.txtBarcode.get_Text();
                string str1 = this.txtDesc.get_Text();
                string text2 = this.cmbUOM.get_Text();
                string str2 = Convert.ToString(this.cmbReason.get_SelectedValue());
                double num2 = num;
                double mDNowPrice = this.m_dNowPrice;
                double mDDiscAmount = this.m_dDiscAmount;
                double num3 = double.Parse(this.txtAmount.get_Text());
                bool flag = this.m_dNowPrice != this.m_dWasPrice;
                if (this.chkDate.get_Checked())
                {
                    date = this.dtpProdDate.get_Value().Date;
                    str = date.ToString("dd/MM/yyyy");
                }
                else
                {
                    str = string.Empty;
                }
                if (this.chkDate.get_Checked())
                {
                    date = this.dtpExpDate.get_Value().Date;
                    empty = date.ToString("dd/MM/yyyy");
                }
                else
                {
                    empty = string.Empty;
                }
                iNTrackLib.InsertTrans(text, text1, str1, text2, str2, num2, mDNowPrice, mDDiscAmount, num3, flag, str, empty, this.chkExcludePrice.get_Checked());
                this.GetTransDetail(false);
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
                UILabel uILabel1 = this.lblTotAmount;
                num = Math.Round(Conversion.Val(Convert.ToString(Property.TransLine.Compute("Sum(Amount)", string.Empty))), 2);
                uILabel1.set_Text(string.Format("Total Amount: {0}", num.ToString()));
                this.tbiUndo.set_Enabled(str != "0");
                this.tbiNext.set_Enabled(Property.TransLine.Rows.Count > 0);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void SetItemDetail(DataRow datarow)
        {
            DataRow[] dataRowArray;
            try
            {
                double num = 0;
                double num1 = 0;
                double num2 = 0;
                this.txtDesc.set_Text(datarow["Description"].ToString());
                if (!this.m_bValidateLine)
                {
                    num = (Property.Module != Property.ModuleEnum.Purchase ? double.Parse(datarow["Sales Price"].ToString()) : double.Parse(datarow["Unit Price"].ToString()));
                }
                else
                {
                    dataRowArray = Property.DocLine.Select(string.Format("[Barcode] = '{0}'", datarow["Barcode"]));
                    num1 = double.Parse(dataRowArray[0]["Discount Perc."].ToString());
                    num2 = double.Parse(dataRowArray[0]["Discount Amount"].ToString());
                    num = double.Parse(dataRowArray[0]["Unit Price"].ToString());
                }
                switch (Property.TransactionType)
                {
                    case Property.TransactionTypeEnum.PI:
                    case Property.TransactionTypeEnum.PR:
                    case Property.TransactionTypeEnum.PRS:
                        {
                            dataRowArray = Property.TransLine.Select(string.Format("[Barcode] = '{0}'", datarow["Barcode"]), "[Line No.] Desc");
                            if ((int)dataRowArray.Length > 0)
                            {
                                num = double.Parse(dataRowArray[0]["Unit Price"].ToString());
                            }
                            break;
                        }
                }
                this.txtPrice.set_Text(num.ToString("F"));
                this.m_dWasPrice = num;
                this.m_dNowPrice = num;
                if (num1 > 0)
                {
                    this.m_dDiscAmount = num1 * this.m_dWasPrice / 100;
                }
                else if (num2 <= 0)
                {
                    this.m_dDiscAmount = 0;
                }
                else
                {
                    this.m_dDiscAmount = (num2 > num ? num : num2);
                }
                if (!string.IsNullOrEmpty(this.txtQuantity.get_Text()))
                {
                    double num3 = Conversion.Val(this.txtQuantity.get_Text());
                    UITextBox uITextBox = this.txtAmount;
                    double mDWasPrice = num3 * this.m_dWasPrice - num3 * this.m_dDiscAmount;
                    uITextBox.set_Text(mDWasPrice.ToString("F"));
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void tbcMenu_SelectionChanged(object sender, EventArgs e)
        {
            frmTransLines frmTransLine;
            try
            {
                try
                {
                    switch (this.tbcMenu.get_SelectedIndex())
                    {
                        case 0:
                            {
                                base.DialogResult = DialogResult.Cancel;
                                break;
                            }
                        case 1:
                            {
                                frmTransLine = new frmTransLines(frmTransLines.SourceEnum.DocumentLine);
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
                        case 2:
                            {
                                if (MessageBoxEx.Show("Are you sure you want to undo the transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    Application.DoEvents();
                                    Cursor.Current = Cursors.WaitCursor;
                                    Service service = new Service();
                                    try
                                    {
                                        service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                        string[] str = new string[] { "HHT_Transactions_2001", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionType.ToString(), Property.TransactionNo, Property.UserCode, string.Empty };
                                        service.SetData(str, new DataSet());
                                    }
                                    finally
                                    {
                                        if (service != null)
                                        {
                                            ((IDisposable)service).Dispose();
                                        }
                                    }
                                    Property.TransLine.Clear();
                                    Property.TransLine.AcceptChanges();
                                    this.SetControls();
                                }
                                break;
                            }
                        case 3:
                            {
                                frmTransLine = new frmTransLines(frmTransLines.SourceEnum.TransactionLine);
                                try
                                {
                                    frmTransLine.ShowDialog();
                                    this.SetControls();
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

        private void txtAmount_LostFocus(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (!this.txtAmount.get_ReadOnly())
                    {
                        if (string.IsNullOrEmpty(this.txtAmount.get_Text()))
                        {
                            if (!string.IsNullOrEmpty(this.txtQuantity.get_Text()))
                            {
                                this.txtAmount.set_Text("0.00");
                            }
                        }
                        else if (string.IsNullOrEmpty(this.txtQuantity.get_Text()))
                        {
                            this.txtAmount.set_Text(string.Empty);
                        }
                        else if (Conversion.Val(this.txtAmount.get_Text()) != 0)
                        {
                            double num = Conversion.Val(this.txtQuantity.get_Text());
                            UITextBox uITextBox = this.txtAmount;
                            double mDNowPrice = num * this.m_dNowPrice - num * this.m_dDiscAmount;
                            uITextBox.set_Text(mDNowPrice.ToString("F"));
                        }
                        else
                        {
                            this.txtAmount.set_Text("0.00");
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
            finally
            {
                Cursor.Current = Cursors.Default;
            }
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
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool length;
            try
            {
                try
                {
                    UITextBox uITextBox = (UITextBox)sender;
                    int keyChar = e.KeyChar;
                    if (keyChar == 13)
                    {
                        if (!string.IsNullOrEmpty(uITextBox.get_Text()))
                        {
                            this.txtQuantity.SelectAll();
                            this.txtQuantity.Focus();
                        }
                    }
                    else if (keyChar != 46)
                    {
                        KeyPressEventArgs keyPressEventArg = e;
                        if (keyChar == 8)
                        {
                            length = false;
                        }
                        else if (!Enumerable.Range(48, 10).Contains<int>(keyChar))
                        {
                            length = true;
                        }
                        else if (!uITextBox.get_Text().Contains<char>('.'))
                        {
                            length = false;
                        }
                        else
                        {
                            string text = uITextBox.get_Text();
                            char[] chrArray = new char[] { '.' };
                            length = text.Split(chrArray)[1].Length >= 3;
                        }
                        keyPressEventArg.Handled = length;
                    }
                    else
                    {
                        e.Handled = (this.txtItemcode.get_Text().Length != 4 ? true : uITextBox.get_Text().Contains<char>('.'));
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

        private void txtPrice_LostFocus(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (!this.txtPrice.get_ReadOnly())
                    {
                        this.m_dNowPrice = Conversion.Val(this.txtPrice.get_Text());
                        if (this.m_dNowPrice != 0)
                        {
                            switch (Property.TransactionType)
                            {
                                case Property.TransactionTypeEnum.PI:
                                    {
                                        if (this.m_dNowPrice > this.m_dWasPrice)
                                        {
                                            this.m_dNowPrice = this.m_dWasPrice;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            this.m_dNowPrice = this.m_dWasPrice;
                        }
                        this.txtPrice.set_Text(this.m_dNowPrice.ToString("F"));
                        if (this.m_dNowPrice != this.m_dWasPrice)
                        {
                            this.m_dDiscAmount = (this.m_dDiscAmount > this.m_dNowPrice ? this.m_dNowPrice : this.m_dDiscAmount);
                        }
                        if (Conversion.Val(this.txtAmount.get_Text()) > 0)
                        {
                            double num = Conversion.Val(this.txtQuantity.get_Text());
                            UITextBox uITextBox = this.txtAmount;
                            double mDNowPrice = num * this.m_dNowPrice - num * this.m_dDiscAmount;
                            uITextBox.set_Text(mDNowPrice.ToString("F"));
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

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool length;
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
                        KeyPressEventArgs keyPressEventArg = e;
                        if (keyChar == 8)
                        {
                            length = false;
                        }
                        else if (!Enumerable.Range(48, 10).Contains<int>(keyChar))
                        {
                            length = true;
                        }
                        else if (!this.txtQuantity.get_Text().Contains<char>('.'))
                        {
                            length = false;
                        }
                        else
                        {
                            string text = this.txtQuantity.get_Text();
                            char[] chrArray = new char[] { '.' };
                            length = text.Split(chrArray)[1].Length >= 3;
                        }
                        keyPressEventArg.Handled = length;
                    }
                    else
                    {
                        e.Handled = this.txtQuantity.get_Text().Contains<char>('.');
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

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (!string.IsNullOrEmpty(this.txtQuantity.get_Text()))
                    {
                        double num = Conversion.Val(this.txtQuantity.get_Text());
                        UITextBox uITextBox = this.txtAmount;
                        double mDNowPrice = num * this.m_dNowPrice - num * this.m_dDiscAmount;
                        uITextBox.set_Text(mDNowPrice.ToString("F"));
                    }
                    else
                    {
                        this.txtAmount.set_Text(string.Empty);
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

        private void txtShelfNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                try
                {
                    if (e.KeyChar == '\r')
                    {
                        if (!string.IsNullOrEmpty(this.txtShelfNo.get_Text().Trim()))
                        {
                            if (!this.txtShelfPrice.get_Visible())
                            {
                                this.txtQuantity.SelectAll();
                                this.txtQuantity.Focus();
                            }
                            else
                            {
                                this.txtShelfPrice.SelectAll();
                                this.txtShelfPrice.Focus();
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
    }
}