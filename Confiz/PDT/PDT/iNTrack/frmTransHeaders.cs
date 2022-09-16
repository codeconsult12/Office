using iNTrack.iNTrackService;
using Microsoft.VisualBasic;
using Resco.Controls.AdvancedList;
using Resco.Controls.CommonControls;
using Resco.Controls.MessageBox;
using Resco.UIElements;
using Resco.UIElements.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Web.Services.Protocols;
using System.Windows.Forms;

namespace iNTrack
{
    public class frmTransHeaders : Form
    {
        private IContainer components = null;

        private ToolbarControl tbcMenu;

        private ToolbarItem tbiUndo;

        private ToolbarItem tbiDelete;

        private ToolbarItem tbiConfirm;

        private ToolbarItem tbiBack;

        private ToolbarItem tbiNext;

        private ToolbarItem tbiNew;

        private UIElementPanelControl pnlSearch;

        private UITextBox txtFilter;

        private UITextBoxButton btnFilter;

        private UIComboBox cmbSearchBy;

        private UILabel lblSearchBy;

        private AdvancedList lstEntry;

        private RowTemplate tempRow;

        private TextCell celltxtNo;

        private TextCell celltxtStatusText;

        private TextCell celltxtSource;

        private TextCell celltxtSourceName;

        private TextCell celltxtDest;

        private TextCell celltxtDestName;

        private TextCell celltxtStatus;

        private TextCell celltxtCount;

        private TextCell celltxtQuantity;

        private RowTemplate tempRowSelect;

        private TextCell celltxtNoSelect;

        private TextCell celltxtStatusTextSelect;

        private TextCell celltxtSourceSelect;

        private TextCell celltxtSourceNameSelect;

        private TextCell celltxtDestSelect;

        private TextCell celltxtDestNameSelect;

        private TextCell celltxtStatusSelect;

        private TextCell celltxtCountSelect;

        private TextCell celltxtQuantitySelect;

        private TextCell celltxtOrigin;

        private TextCell celltxtOriginSelect;

        public frmTransHeaders()
        {
            this.InitializeComponent();
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int width = bounds.Width;
            bounds = Screen.PrimaryScreen.Bounds;
            base.Size = new Size(width, bounds.Height);
            this.AutoScroll = false;
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.celltxtNo.set_SelectedText(string.Empty);
                this.celltxtNoSelect.set_SelectedText(string.Empty);
                this.celltxtSource.set_SelectedText(string.Empty);
                this.celltxtSourceSelect.set_SelectedText(string.Empty);
                this.celltxtSourceName.set_SelectedText(string.Empty);
                this.celltxtDestSelect.set_SelectedText(string.Empty);
            }
            catch (Exception exception)
            {
                CommonLib.DisplayErrorMessage(exception);
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

        private DataTable DownloadERPHeaders()
        {
            Service service;
            DataTable dataTable;
            string[] str;
            try
            {
                DataTable item = null;
                switch (Property.TransactionType)
                {
                    case Property.TransactionTypeEnum.PO:
                        {
                            service = new Service();
                            try
                            {
                                service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                str = new string[] { "Transaction_Header_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), Property.TransactionType.ToString(), CommonLib.FormatString(this.txtFilter.get_Text()) };
                                item = service.GetData(str).Tables[0];
                            }
                            finally
                            {
                                if (service != null)
                                {
                                    ((IDisposable)service).Dispose();
                                }
                            }
                            break;
                        }
                    case Property.TransactionTypeEnum.PI:
                        {
                            service = new Service();
                            try
                            {
                                service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                str = new string[] { "Transaction_Header_3001", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), Property.TransactionType.ToString(), CommonLib.FormatString(this.txtFilter.get_Text()) };
                                item = service.GetData(str).Tables[0];
                                Property.DocLine = new DataTable();
                                if (item.Rows.Count > 0)
                                {
                                    if ((Property.Setup.Rows[0]["Download Purchase Invoice Line"].ToString() == "Yes" ? true : Property.Setup.Rows[0]["Download Purchase Invoice Line"].ToString() == "1"))
                                    {
                                        str = new string[] { "Transaction_Line_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), CommonLib.FormatString(this.txtFilter.get_Text()) };
                                        Property.DocLine = service.GetData(str).Tables[0];
                                        if ((int)Property.DocLine.Select("[Barcode] = ''").Length > 0)
                                        {
                                            throw new Exception("Barcode detail is missing");
                                        }
                                    }
                                    try
                                    {
                                        SqlCeLib.Transaction(SqlCeLib.TransStatus.Begin);
                                        object[] date = new object[] { "Insert Into [Transaction Header] ([Transaction Type], [Transaction No.], [Source], [Source Name], [Destination], [Destination Name], [Document Date], [Expected Date], [Closing Date], [Reference No.1], [Reference No.2], [Reference No.3], [Reference No.4], [Reference No.5], [Receive], [Remarks], [Status], [Origin], [HHT User ID], [Created On]) Values('", Property.TransactionType.ToString(), "', '", item.Rows[0]["No"].ToString(), "', '", item.Rows[0]["Source"].ToString(), "', '", item.Rows[0]["Source Name"].ToString(), "', '", item.Rows[0]["Destination"].ToString(), "', '", item.Rows[0]["Destination Name"].ToString(), "', '", null, null, null, null, null, null, null, null, null, null };
                                        DateTime dateTime = DateTime.ParseExact(item.Rows[0]["Document Date"].ToString(), "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                                        date[13] = dateTime.Date;
                                        date[14] = "', '";
                                        dateTime = DateTime.ParseExact(item.Rows[0]["Expected Date"].ToString(), "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                                        date[15] = dateTime.Date;
                                        date[16] = "', '";
                                        dateTime = DateTime.ParseExact(item.Rows[0]["Closing Date"].ToString(), "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                                        date[17] = dateTime.Date;
                                        date[18] = "', '', '', '', '', '', 0, '', 'AU', '";
                                        date[19] = item.Rows[0]["Origin"].ToString();
                                        date[20] = "', '";
                                        date[21] = Property.UserCode;
                                        date[22] = "', GetDate())";
                                        SqlCeLib.Execute(string.Concat(date), SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                                        foreach (DataRow row in Property.DocLine.Rows)
                                        {
                                            str = new string[] { "Insert Into [Transaction Line] ([Transaction Type], [Transaction No.], [Line No.], [Itemcode], [Barcode], [Description], [UOM], [Quantity], [Unit Price], [Amount], [Discount Perc.], [Discount Amount]) Values ('", Property.TransactionType.ToString(), "', '", item.Rows[0]["No"].ToString(), "', '", row["Line No."].ToString(), "', '", row["Itemcode"].ToString(), "', '", row["Barcode"].ToString(), "', '", CommonLib.FormatString(row["Description"].ToString()), "', '", row["UOM"].ToString(), "', ", row["Quantity"].ToString(), ", ", row["Unit Price"].ToString(), ", ", row["Amount"].ToString(), ", ", row["Discount Perc."].ToString(), ", ", row["Discount Amount"].ToString(), ")" };
                                            SqlCeLib.Execute(string.Concat(str), SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                                        }
                                        SqlCeLib.Transaction(SqlCeLib.TransStatus.Commit);
                                    }
                                    catch (Exception exception1)
                                    {
                                        Exception exception = exception1;
                                        SqlCeLib.Transaction(SqlCeLib.TransStatus.Rollback);
                                        throw exception;
                                    }
                                }
                            }
                            finally
                            {
                                if (service != null)
                                {
                                    ((IDisposable)service).Dispose();
                                }
                            }
                            break;
                        }
                    case Property.TransactionTypeEnum.PR:
                        {
                            service = new Service();
                            try
                            {
                                service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                str = new string[] { "Transaction_Header_3002", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), Property.TransactionType.ToString(), CommonLib.FormatString(this.txtFilter.get_Text()) };
                                item = service.GetData(str).Tables[0];
                            }
                            finally
                            {
                                if (service != null)
                                {
                                    ((IDisposable)service).Dispose();
                                }
                            }
                            break;
                        }
                    case Property.TransactionTypeEnum.PRS:
                        {
                            service = new Service();
                            try
                            {
                                service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                str = new string[] { "Transaction_Header_3003", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), Property.TransactionType.ToString(), CommonLib.FormatString(this.txtFilter.get_Text()) };
                                item = service.GetData(str).Tables[0];
                            }
                            finally
                            {
                                if (service != null)
                                {
                                    ((IDisposable)service).Dispose();
                                }
                            }
                            break;
                        }
                    case Property.TransactionTypeEnum.SO:
                        {
                            service = new Service();
                            try
                            {
                                service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                str = new string[] { "Transaction_Header_3004", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), Property.TransactionType.ToString(), CommonLib.FormatString(this.txtFilter.get_Text()) };
                                item = service.GetData(str).Tables[0];
                            }
                            finally
                            {
                                if (service != null)
                                {
                                    ((IDisposable)service).Dispose();
                                }
                            }
                            break;
                        }
                    case Property.TransactionTypeEnum.SI:
                        {
                            service = new Service();
                            try
                            {
                                service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                str = new string[] { "Transaction_Header_3005", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), Property.TransactionType.ToString(), CommonLib.FormatString(this.txtFilter.get_Text()) };
                                item = service.GetData(str).Tables[0];
                            }
                            finally
                            {
                                if (service != null)
                                {
                                    ((IDisposable)service).Dispose();
                                }
                            }
                            break;
                        }
                    case Property.TransactionTypeEnum.SR:
                        {
                            service = new Service();
                            try
                            {
                                service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                str = new string[] { "Transaction_Header_3006", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), Property.TransactionType.ToString(), CommonLib.FormatString(this.txtFilter.get_Text()) };
                                item = service.GetData(str).Tables[0];
                            }
                            finally
                            {
                                if (service != null)
                                {
                                    ((IDisposable)service).Dispose();
                                }
                            }
                            break;
                        }
                    case Property.TransactionTypeEnum.SRR:
                        {
                            service = new Service();
                            try
                            {
                                service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                str = new string[] { "Transaction_Header_3007", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), Property.TransactionType.ToString(), CommonLib.FormatString(this.txtFilter.get_Text()) };
                                item = service.GetData(str).Tables[0];
                            }
                            finally
                            {
                                if (service != null)
                                {
                                    ((IDisposable)service).Dispose();
                                }
                            }
                            break;
                        }
                    case Property.TransactionTypeEnum.TRQ:
                        {
                            throw new Exception("Not implemented");
                        }
                    case Property.TransactionTypeEnum.TRO:
                        {
                            service = new Service();
                            try
                            {
                                service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                str = new string[] { "Transaction_Header_3009", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), Property.TransactionType.ToString(), CommonLib.FormatString(this.txtFilter.get_Text()) };
                                item = service.GetData(str).Tables[0];
                            }
                            finally
                            {
                                if (service != null)
                                {
                                    ((IDisposable)service).Dispose();
                                }
                            }
                            break;
                        }
                    case Property.TransactionTypeEnum.TRS:
                        {
                            service = new Service();
                            try
                            {
                                service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                str = new string[] { "Transaction_Header_3010", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), Property.TransactionType.ToString(), CommonLib.FormatString(this.txtFilter.get_Text()) };
                                item = service.GetData(str).Tables[0];
                            }
                            finally
                            {
                                if (service != null)
                                {
                                    ((IDisposable)service).Dispose();
                                }
                            }
                            break;
                        }
                    case Property.TransactionTypeEnum.TRI:
                        {
                            service = new Service();
                            try
                            {
                                service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                str = new string[] { "Transaction_Header_3011", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), Property.TransactionType.ToString(), CommonLib.FormatString(this.txtFilter.get_Text()) };
                                item = service.GetData(str).Tables[0];
                            }
                            finally
                            {
                                if (service != null)
                                {
                                    ((IDisposable)service).Dispose();
                                }
                            }
                            break;
                        }
                }
                dataTable = item;
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
            return dataTable;
        }

        private void DownloadiNTrackHeaders()
        {
            try
            {
                DataTable dataTable = new DataTable();
                DataTable dataTable1 = new DataTable();
                Service service = new Service();
                try
                {
                    service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                    string[] str = new string[] { "Transaction_Header_3012", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionType.ToString(), Property.UserCode };
                    dataTable = service.GetData(str).Tables[0];
                }
                finally
                {
                    if (service != null)
                    {
                        ((IDisposable)service).Dispose();
                    }
                }
                switch (Property.TransactionType)
                {
                    case Property.TransactionTypeEnum.SPC:
                    case Property.TransactionTypeEnum.TRQ:
                    case Property.TransactionTypeEnum.TRO:
                    case Property.TransactionTypeEnum.TRS:
                    case Property.TransactionTypeEnum.TRI:
                    case Property.TransactionTypeEnum.ADJ:
                    case Property.TransactionTypeEnum.SHRINK:
                    case Property.TransactionTypeEnum.MISC:
                    case Property.TransactionTypeEnum.PLC:
                    case Property.TransactionTypeEnum.SLC:
                        {
                            dataTable.Columns["InventLocationIdFrom"].ColumnName = "Source";
                            dataTable.Columns["FromLocationName"].ColumnName = "Source Name";
                            dataTable.Columns["InventLocationIdTo"].ColumnName = "Destination";
                            dataTable.Columns["ToLocationName"].ColumnName = "Destination Name";
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.PRQ:
                    case Property.TransactionTypeEnum.PO:
                    case Property.TransactionTypeEnum.PI:
                    case Property.TransactionTypeEnum.SR:
                    case Property.TransactionTypeEnum.SRR:
                        {
                            dataTable.Columns["HHTSourceNo"].ColumnName = "Source";
                            dataTable.Columns["HHTSourceName"].ColumnName = "Source Name";
                            dataTable.Columns["InventLocationIdTo"].ColumnName = "Destination";
                            dataTable.Columns["ToLocationName"].ColumnName = "Destination Name";
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.PR:
                    case Property.TransactionTypeEnum.PRS:
                    case Property.TransactionTypeEnum.SO:
                    case Property.TransactionTypeEnum.SI:
                        {
                            dataTable.Columns["InventLocationIdFrom"].ColumnName = "Source";
                            dataTable.Columns["FromLocationName"].ColumnName = "Source Name";
                            dataTable.Columns["HHTSourceNo"].ColumnName = "Destination";
                            dataTable.Columns["HHTSourceName"].ColumnName = "Destination Name";
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.SC:
                        {
                            if (Property.TransactionType == Property.TransactionTypeEnum.PI)
                            {
                                dataTable1 = (DataTable)SqlCeLib.Execute(string.Format("Select H.[Transaction No.] No, H.Source, H.[Source Name], H.Destination, H.[Destination Name], H.[Document Date], H.[Expected Date], H.[Closing Date], H.[Reference No.1], H.[Reference No.2], H.[Reference No.3], H.[Reference No.4], H.[Reference No.5], H.Status, H.Origin, Count(T.Quantity) [Count], Coalesce(Sum(T.Quantity), 0) Quantity From [Transaction Header] H Left Outer Join [HHT Transactions] T On H.[Transaction Type] = T.[Transaction Type] And H.[Transaction No.] = T.[Transaction No.] Where H.[Transaction Type] = '{0}' Group By H.[Transaction No.], H.Source, H.[Source Name], H.Destination, H.[Destination Name], H.[Document Date], H.[Expected Date], H.[Closing Date], H.[Reference No.1], H.[Reference No.2], H.[Reference No.3], H.[Reference No.4], H.[Reference No.5], H.Status, H.Origin Order By H.[Transaction No.]", Property.TransactionType.ToString()), SqlCeLib.ExecMode.Query, new SqlCeParameter[0]);
                            }
                            DataTable dataTable2 = Property.TransHeader.Clone();
                            dataTable2.Columns["New"].DefaultValue = "0";
                            dataTable2.Merge(dataTable, true, MissingSchemaAction.Ignore);
                            dataTable2.Merge(dataTable1, true, MissingSchemaAction.Ignore);
                            var collection =
                                from ERP in Property.TransHeader.Copy().AsEnumerable()
                                join iNTrack in dataTable2.AsEnumerable() on ERP.Field<string>("No") equals iNTrack.Field<string>("No")
                                select new { No = ERP.Field<string>("No") };
                            foreach (var item in collection)
                            {
                                DataRow dataRow = Property.TransHeader.Select(string.Format("No = '{0}'", item.No))[0];
                                dataTable2.Select(string.Format("No = '{0}'", item.No))[0]["Origin"] = dataRow["Origin"];
                                dataRow.Delete();
                            }
                            Property.TransHeader.Merge(dataTable2, true, MissingSchemaAction.Ignore);
                            this.txtFilter.set_Text(string.Empty);
                            this.lstEntry.get_DataRows().Clear();
                            Property.TransHeader.DefaultView.RowFilter = string.Empty;
                            this.lstEntry.set_DataSource(Property.TransHeader.DefaultView);
                            break;
                        }
                    default:
                        {
                            goto case Property.TransactionTypeEnum.SC;
                        }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void frmTransHeaders_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.SetMenu();
                    this.SetSearchControl();
                    Property.TransHeader = new DataTable();
                    Property.TransHeader.Columns.Add("No");
                    Property.TransHeader.Columns.Add("Status Text").DefaultValue = "Open";
                    Property.TransHeader.Columns.Add("Source");
                    Property.TransHeader.Columns.Add("Source Name");
                    Property.TransHeader.Columns.Add("Destination");
                    Property.TransHeader.Columns.Add("Destination Name");
                    Property.TransHeader.Columns.Add("Status").DefaultValue = "AU";
                    Property.TransHeader.Columns.Add("Count", typeof(double)).DefaultValue = 0;
                    Property.TransHeader.Columns.Add("Quantity", typeof(double)).DefaultValue = 0;
                    Property.TransHeader.Columns.Add("Origin").DefaultValue = string.Empty;
                    Property.TransHeader.Columns.Add("Document Date", typeof(DateTime));
                    Property.TransHeader.Columns.Add("Expected Date", typeof(DateTime));
                    Property.TransHeader.Columns.Add("Closing Date", typeof(DateTime));
                    Property.TransHeader.Columns.Add("Reference No.1").DefaultValue = string.Empty;
                    Property.TransHeader.Columns.Add("Reference No.2").DefaultValue = string.Empty;
                    Property.TransHeader.Columns.Add("Reference No.3").DefaultValue = string.Empty;
                    Property.TransHeader.Columns.Add("Reference No.4").DefaultValue = string.Empty;
                    Property.TransHeader.Columns.Add("Reference No.5").DefaultValue = string.Empty;
                    Property.TransHeader.Columns.Add("New").DefaultValue = "1";
                    this.DownloadiNTrackHeaders();
                    Property.TransHeader.DefaultView.RowFilter = string.Empty;
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

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmTransHeaders));
            this.pnlSearch = new UIElementPanelControl();
            this.txtFilter = new UITextBox();
            this.btnFilter = new UITextBoxButton();
            this.cmbSearchBy = new UIComboBox();
            this.lblSearchBy = new UILabel();
            this.lstEntry = new AdvancedList();
            this.tempRow = new RowTemplate();
            this.celltxtNo = new TextCell();
            this.celltxtStatusText = new TextCell();
            this.celltxtSource = new TextCell();
            this.celltxtSourceName = new TextCell();
            this.celltxtDest = new TextCell();
            this.celltxtDestName = new TextCell();
            this.celltxtStatus = new TextCell();
            this.celltxtCount = new TextCell();
            this.celltxtQuantity = new TextCell();
            this.celltxtOrigin = new TextCell();
            this.tempRowSelect = new RowTemplate();
            this.celltxtNoSelect = new TextCell();
            this.celltxtStatusTextSelect = new TextCell();
            this.celltxtSourceSelect = new TextCell();
            this.celltxtSourceNameSelect = new TextCell();
            this.celltxtDestSelect = new TextCell();
            this.celltxtDestNameSelect = new TextCell();
            this.celltxtStatusSelect = new TextCell();
            this.celltxtCountSelect = new TextCell();
            this.celltxtQuantitySelect = new TextCell();
            this.celltxtOriginSelect = new TextCell();
            this.tbcMenu = new ToolbarControl();
            this.tbiBack = new ToolbarItem();
            this.tbiNew = new ToolbarItem();
            this.tbiConfirm = new ToolbarItem();
            this.tbiUndo = new ToolbarItem();
            this.tbiNext = new ToolbarItem();
            this.tbiDelete = new ToolbarItem();
            this.pnlSearch.SuspendElementLayout();
            base.SuspendLayout();
            this.pnlSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this.pnlSearch.BackColor = Color.FromArgb(213, 231, 255);
            this.pnlSearch.get_Children().Add(this.txtFilter);
            this.pnlSearch.get_Children().Add(this.cmbSearchBy);
            this.pnlSearch.get_Children().Add(this.lblSearchBy);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new Size(318, 67);
            this.pnlSearch.TabIndex = 2;
            this.txtFilter.get_Buttons().Add(this.btnFilter);
            this.txtFilter.set_Layout(new ElementLayout(3, 0, 5, 33, 5, 0, 308, 26));
            this.txtFilter.set_Name("txtFilter");
            this.txtFilter.set_TabIndex(1);
            this.txtFilter.add_KeyPress(new KeyPressEventHandler(this.txtFilter_KeyPress));
            this.txtFilter.add_GotFocus(new EventHandler(this.txtFilter_GotFocus));
            this.txtFilter.add_TextChanged(new EventHandler(this.txtFilter_TextChanged));
            this.txtFilter.add_LostFocus(new EventHandler(this.txtFilter_LostFocus));
            this.btnFilter.set_Action(1);
            this.btnFilter.set_BackColor(Color.Transparent);
            this.btnFilter.set_BorderThickness(0);
            this.btnFilter.set_HorizontalAlignment(2);
            this.btnFilter.set_Name("btnFilter");
            this.btnFilter.get_PressedBackground().set_BackColor(Color.Transparent);
            this.btnFilter.set_Size(new Size(18, 18));
            this.btnFilter.set_StateIcon(2);
            this.btnFilter.set_VisibleMode(1);
            this.cmbSearchBy.set_BackColor(SystemColors.Window);
            this.cmbSearchBy.set_Layout(new ElementLayout(3, 0, 66, 5, 5, 0, 247, 26));
            this.cmbSearchBy.set_Name("cmbSearchBy");
            this.cmbSearchBy.set_TabIndex(2);
            this.cmbSearchBy.add_SelectedIndexChanged(new EventHandler(this.cmbSearchBy_SelectedIndexChanged));
            this.lblSearchBy.set_AutoSize(false);
            this.lblSearchBy.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblSearchBy.set_Layout(new ElementLayout(0, 0, 5, 5, 0, 0, 61, 26));
            this.lblSearchBy.set_Name("lblSearchBy");
            this.lblSearchBy.set_TabIndex(2);
            this.lblSearchBy.set_Text("Search By");
            this.lblSearchBy.set_TextAlignment(2);
            this.lstEntry.set_AutoSelectRow(false);
            this.lstEntry.set_BackColor(Color.FromArgb(213, 231, 255));
            this.lstEntry.BorderStyle = BorderStyle.FixedSingle;
            this.lstEntry.get_DataRows().Clear();
            RowCollection dataRows = this.lstEntry.get_DataRows();
            string[] str = new string[] { componentResourceManager.GetString("lstEntry.DataRows"), componentResourceManager.GetString("lstEntry.DataRows1"), componentResourceManager.GetString("lstEntry.DataRows2"), componentResourceManager.GetString("lstEntry.DataRows3"), componentResourceManager.GetString("lstEntry.DataRows4"), componentResourceManager.GetString("lstEntry.DataRows5"), componentResourceManager.GetString("lstEntry.DataRows6"), componentResourceManager.GetString("lstEntry.DataRows7"), componentResourceManager.GetString("lstEntry.DataRows8"), componentResourceManager.GetString("lstEntry.DataRows9") };
            dataRows.Add(new Row(0, 0, -1, -1, str));
            RowCollection rowCollection = this.lstEntry.get_DataRows();
            str = new string[] { componentResourceManager.GetString("lstEntry.DataRows10"), componentResourceManager.GetString("lstEntry.DataRows11"), componentResourceManager.GetString("lstEntry.DataRows12"), componentResourceManager.GetString("lstEntry.DataRows13"), componentResourceManager.GetString("lstEntry.DataRows14"), componentResourceManager.GetString("lstEntry.DataRows15"), componentResourceManager.GetString("lstEntry.DataRows16"), componentResourceManager.GetString("lstEntry.DataRows17"), componentResourceManager.GetString("lstEntry.DataRows18"), componentResourceManager.GetString("lstEntry.DataRows19") };
            rowCollection.Add(new Row(0, 0, -1, -1, str));
            this.lstEntry.Dock = DockStyle.Bottom;
            this.lstEntry.set_FocusOnClick(true);
            this.lstEntry.Location = new Point(0, 73);
            this.lstEntry.Name = "lstEntry";
            this.lstEntry.set_ScrollbarSmallChange(32);
            this.lstEntry.set_ScrollbarWidth(26);
            this.lstEntry.set_SelectedTemplateIndex(1);
            this.lstEntry.set_ShowScrollbar(false);
            this.lstEntry.Size = new Size(318, 171);
            this.lstEntry.TabIndex = 4;
            this.lstEntry.get_Templates().Add(this.tempRow);
            this.lstEntry.get_Templates().Add(this.tempRowSelect);
            this.lstEntry.set_TouchScrolling(true);
            this.lstEntry.add_CustomizeCell(new CustomizeCellEventHandler(this, frmTransHeaders.lstEntry_CustomizeCell));
            this.lstEntry.DoubleClick += new EventHandler(this.lstEntry_DoubleClick);
            this.lstEntry.add_RowEntered(new RowEnteredEventHandler(this, frmTransHeaders.lstEntry_RowEntered));
            this.tempRow.set_BackColor(Color.FromArgb(213, 231, 255));
            this.tempRow.get_CellTemplates().Add(this.celltxtNo);
            this.tempRow.get_CellTemplates().Add(this.celltxtStatusText);
            this.tempRow.get_CellTemplates().Add(this.celltxtSource);
            this.tempRow.get_CellTemplates().Add(this.celltxtSourceName);
            this.tempRow.get_CellTemplates().Add(this.celltxtDest);
            this.tempRow.get_CellTemplates().Add(this.celltxtDestName);
            this.tempRow.get_CellTemplates().Add(this.celltxtStatus);
            this.tempRow.get_CellTemplates().Add(this.celltxtCount);
            this.tempRow.get_CellTemplates().Add(this.celltxtQuantity);
            this.tempRow.get_CellTemplates().Add(this.celltxtOrigin);
            this.tempRow.set_Height(100);
            this.tempRow.set_Name("tempRow");
            this.celltxtNo.set_Alignment(2);
            this.celltxtNo.get_CellSource().set_ColumnIndex(0);
            this.celltxtNo.set_DesignName("celltxtNo");
            this.celltxtNo.set_Location(new Point(5, 0));
            this.celltxtNo.set_Size(new Size(150, 36));
            this.celltxtNo.set_TextFont(new Font("Tahoma", 10f, FontStyle.Bold));
            this.celltxtStatusText.set_Alignment(2);
            this.celltxtStatusText.get_CellSource().set_ColumnIndex(1);
            this.celltxtStatusText.set_DesignName("celltxtStatusText");
            this.celltxtStatusText.set_Location(new Point(155, 0));
            this.celltxtStatusText.set_Size(new Size(165, 36));
            this.celltxtStatusText.set_TextFont(new Font("Tahoma", 10f, FontStyle.Bold));
            this.celltxtStatusText.set_Visible(false);
            this.celltxtSource.set_Alignment(2);
            this.celltxtSource.get_CellSource().set_ColumnIndex(2);
            this.celltxtSource.set_DesignName("celltxtSource");
            this.celltxtSource.set_ForeColor(Color.DimGray);
            this.celltxtSource.set_Location(new Point(5, 20));
            this.celltxtSource.set_Size(new Size(65, 36));
            this.celltxtSourceName.set_Alignment(2);
            this.celltxtSourceName.get_CellSource().set_ColumnIndex(3);
            this.celltxtSourceName.set_DesignName("celltxtSourceName");
            this.celltxtSourceName.set_ForeColor(Color.DimGray);
            this.celltxtSourceName.set_Location(new Point(70, 20));
            this.celltxtSourceName.set_Size(new Size(250, 36));
            this.celltxtDest.set_Alignment(2);
            this.celltxtDest.get_CellSource().set_ColumnIndex(4);
            this.celltxtDest.set_DesignName("celltxtDest");
            this.celltxtDest.set_ForeColor(Color.DimGray);
            this.celltxtDest.set_Location(new Point(5, 40));
            this.celltxtDest.set_Size(new Size(65, 36));
            this.celltxtDestName.set_Alignment(2);
            this.celltxtDestName.get_CellSource().set_ColumnIndex(5);
            this.celltxtDestName.set_DesignName("celltxtDestName");
            this.celltxtDestName.set_ForeColor(Color.DimGray);
            this.celltxtDestName.set_Location(new Point(70, 40));
            this.celltxtDestName.set_Size(new Size(250, 36));
            this.celltxtStatus.set_Alignment(2);
            this.celltxtStatus.get_CellSource().set_ColumnIndex(6);
            this.celltxtStatus.set_DesignName("celltxtStatus");
            this.celltxtStatus.set_Location(new Point(0, 0));
            this.celltxtStatus.set_Size(new Size(0, 0));
            this.celltxtStatus.set_Visible(false);
            this.celltxtCount.set_Alignment(2);
            this.celltxtCount.get_CellSource().set_ColumnIndex(7);
            this.celltxtCount.set_DesignName("celltxtCount");
            this.celltxtCount.set_ForeColor(Color.DimGray);
            this.celltxtCount.set_Location(new Point(5, 60));
            this.celltxtCount.set_Size(new Size(65, 36));
            this.celltxtQuantity.set_Alignment(2);
            this.celltxtQuantity.get_CellSource().set_ColumnIndex(8);
            this.celltxtQuantity.set_DesignName("celltxtQuantity");
            this.celltxtQuantity.set_ForeColor(Color.DimGray);
            this.celltxtQuantity.set_Location(new Point(70, 60));
            this.celltxtQuantity.set_Size(new Size(250, 36));
            this.celltxtOrigin.set_Alignment(2);
            this.celltxtOrigin.get_CellSource().set_ColumnIndex(9);
            this.celltxtOrigin.set_DesignName("celltxtOrigin");
            this.celltxtOrigin.set_Location(new Point(155, 0));
            this.celltxtOrigin.set_Size(new Size(165, 36));
            this.celltxtOrigin.set_TextFont(new Font("Tahoma", 10f, FontStyle.Bold));
            this.tempRowSelect.set_BackColor(SystemColors.Info);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtNoSelect);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtStatusTextSelect);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtSourceSelect);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtSourceNameSelect);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtDestSelect);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtDestNameSelect);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtStatusSelect);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtCountSelect);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtQuantitySelect);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtOriginSelect);
            this.tempRowSelect.set_Height(100);
            this.tempRowSelect.set_Name("tempRowSelect");
            this.celltxtNoSelect.set_Alignment(2);
            this.celltxtNoSelect.get_CellSource().set_ColumnIndex(0);
            this.celltxtNoSelect.set_DesignName("celltxtNoSelect");
            this.celltxtNoSelect.set_Location(new Point(5, 0));
            this.celltxtNoSelect.set_Size(new Size(150, 36));
            this.celltxtNoSelect.set_TextFont(new Font("Tahoma", 10f, FontStyle.Bold));
            this.celltxtStatusTextSelect.set_Alignment(2);
            this.celltxtStatusTextSelect.get_CellSource().set_ColumnIndex(1);
            this.celltxtStatusTextSelect.set_DesignName("celltxtStatusTextSelect");
            this.celltxtStatusTextSelect.set_Location(new Point(155, 0));
            this.celltxtStatusTextSelect.set_Size(new Size(165, 36));
            this.celltxtStatusTextSelect.set_TextFont(new Font("Tahoma", 10f, FontStyle.Bold));
            this.celltxtStatusTextSelect.set_Visible(false);
            this.celltxtSourceSelect.set_Alignment(2);
            this.celltxtSourceSelect.get_CellSource().set_ColumnIndex(2);
            this.celltxtSourceSelect.set_DesignName("celltxtSourceSelect");
            this.celltxtSourceSelect.set_ForeColor(Color.DimGray);
            this.celltxtSourceSelect.set_Location(new Point(5, 20));
            this.celltxtSourceSelect.set_Size(new Size(65, 36));
            this.celltxtSourceNameSelect.set_Alignment(2);
            this.celltxtSourceNameSelect.get_CellSource().set_ColumnIndex(3);
            this.celltxtSourceNameSelect.set_DesignName("celltxtSourceNameSelect");
            this.celltxtSourceNameSelect.set_ForeColor(Color.DimGray);
            this.celltxtSourceNameSelect.set_Location(new Point(70, 20));
            this.celltxtSourceNameSelect.set_Size(new Size(250, 36));
            this.celltxtDestSelect.set_Alignment(2);
            this.celltxtDestSelect.get_CellSource().set_ColumnIndex(4);
            this.celltxtDestSelect.set_DesignName("celltxtDestSelect");
            this.celltxtDestSelect.set_ForeColor(Color.DimGray);
            this.celltxtDestSelect.set_Location(new Point(5, 40));
            this.celltxtDestSelect.set_Size(new Size(65, 36));
            this.celltxtDestNameSelect.set_Alignment(2);
            this.celltxtDestNameSelect.get_CellSource().set_ColumnIndex(5);
            this.celltxtDestNameSelect.set_DesignName("celltxtDestNameSelect");
            this.celltxtDestNameSelect.set_ForeColor(Color.DimGray);
            this.celltxtDestNameSelect.set_Location(new Point(70, 40));
            this.celltxtDestNameSelect.set_Size(new Size(250, 36));
            this.celltxtStatusSelect.set_Alignment(2);
            this.celltxtStatusSelect.get_CellSource().set_ColumnIndex(6);
            this.celltxtStatusSelect.set_DesignName("celltxtStatusSelect");
            this.celltxtStatusSelect.set_ForeColor(Color.DimGray);
            this.celltxtStatusSelect.set_Location(new Point(0, 0));
            this.celltxtStatusSelect.set_Size(new Size(0, 0));
            this.celltxtStatusSelect.set_Visible(false);
            this.celltxtCountSelect.set_Alignment(2);
            this.celltxtCountSelect.get_CellSource().set_ColumnIndex(7);
            this.celltxtCountSelect.set_DesignName("celltxtCountSelect");
            this.celltxtCountSelect.set_ForeColor(Color.DimGray);
            this.celltxtCountSelect.set_Location(new Point(5, 60));
            this.celltxtCountSelect.set_Size(new Size(65, 36));
            this.celltxtQuantitySelect.set_Alignment(2);
            this.celltxtQuantitySelect.get_CellSource().set_ColumnIndex(8);
            this.celltxtQuantitySelect.set_DesignName("celltxtQuantitySelect");
            this.celltxtQuantitySelect.set_ForeColor(Color.DimGray);
            this.celltxtQuantitySelect.set_Location(new Point(70, 60));
            this.celltxtQuantitySelect.set_Size(new Size(250, 36));
            this.celltxtOriginSelect.set_Alignment(2);
            this.celltxtOriginSelect.get_CellSource().set_ColumnIndex(9);
            this.celltxtOriginSelect.set_DesignName("celltxtOriginSelect");
            this.celltxtOriginSelect.set_Location(new Point(155, 0));
            this.celltxtOriginSelect.set_Size(new Size(165, 36));
            this.celltxtOriginSelect.set_TextFont(new Font("Tahoma", 10f, FontStyle.Bold));
            this.tbcMenu.set_ArrowsTransparency(0);
            this.tbcMenu.BackColor = Color.Black;
            this.tbcMenu.set_BmpArrowNext(imgManager.GetImage("iNTrack.Arrow Right2"));
            this.tbcMenu.set_BmpArrowPrevious(imgManager.GetImage("iNTrack.Arrow Left2"));
            this.tbcMenu.Dock = DockStyle.Bottom;
            this.tbcMenu.set_EnableArrowsTransparency(false);
            this.tbcMenu.get_Items().Add(this.tbiBack);
            this.tbcMenu.get_Items().Add(this.tbiNew);
            this.tbcMenu.get_Items().Add(this.tbiConfirm);
            this.tbcMenu.get_Items().Add(this.tbiUndo);
            this.tbcMenu.get_Items().Add(this.tbiNext);
            this.tbcMenu.get_Items().Add(this.tbiDelete);
            this.tbcMenu.set_ItemsAlignment(4);
            this.tbcMenu.set_ItemSpacing(5);
            this.tbcMenu.Location = new Point(0, 244);
            this.tbcMenu.set_MarginAtBegin(50);
            this.tbcMenu.set_MarginAtEnd(45);
            this.tbcMenu.Name = "tbcMenu";
            this.tbcMenu.Size = new Size(318, 50);
            this.tbcMenu.TabIndex = 3;
            this.tbcMenu.add_SelectionChanged(new EventHandler(this.tbcMenu_SelectionChanged));
            this.tbiBack.set_BackColor(Color.Black);
            this.tbiBack.set_CustomSize(new Size(0, 0));
            this.tbiBack.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Left"));
            this.tbiBack.set_Name("tbiBack");
            this.tbiBack.set_ToolbarItemBehavior(2);
            this.tbiNew.set_BackColor(Color.Black);
            this.tbiNew.set_CustomSize(new Size(0, 0));
            this.tbiNew.set_ImageDefault(imgManager.GetImage("iNTrack.Plus"));
            this.tbiNew.set_Name("tbiNew");
            this.tbiNew.set_ToolbarItemBehavior(2);
            this.tbiConfirm.set_BackColor(Color.Black);
            this.tbiConfirm.set_CustomSize(new Size(0, 0));
            this.tbiConfirm.set_ImageDefault(imgManager.GetImage("iNTrack.Ok"));
            this.tbiConfirm.set_Name("tbiConfirm");
            this.tbiConfirm.set_ToolbarItemBehavior(2);
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
            this.tbiDelete.set_BackColor(Color.Black);
            this.tbiDelete.set_CustomSize(new Size(0, 0));
            this.tbiDelete.set_ImageDefault(imgManager.GetImage("iNTrack.Trash"));
            this.tbiDelete.set_Name("tbiDelete");
            this.tbiDelete.set_ToolbarItemBehavior(2);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = Color.FromArgb(213, 231, 255);
            base.ClientSize = new Size(318, 294);
            base.ControlBox = false;
            base.Controls.Add(this.lstEntry);
            base.Controls.Add(this.pnlSearch);
            base.Controls.Add(this.tbcMenu);
            base.MinimizeBox = false;
            base.Name = "frmTransHeaders";
            this.Text = ":: Transaction Headers";
            base.Load += new EventHandler(this.frmTransHeaders_Load);
            this.pnlSearch.ResumeElementLayout(false);
            base.ResumeLayout(false);
        }

        private void lstEntry_CustomizeCell(object sender, CustomizeCellEventArgs e)
        {
            try
            {
                Cell cell = e.get_Cell();
                Rectangle bounds = e.get_Cell().get_Bounds();
                int x = bounds.X;
                bounds = e.get_Cell().get_Bounds();
                int y = bounds.Y;
                bounds = e.get_Cell().get_Bounds();
                cell.set_Bounds(new Rectangle(x, y, bounds.Width, 1));
                if (e.get_DataRow().get_Index() == this.lstEntry.get_DataRows().Count - 1)
                {
                    e.get_Cell().set_Visible(false);
                }
            }
            catch (Exception exception)
            {
                CommonLib.DisplayErrorMessage(exception);
            }
        }

        private void lstEntry_DoubleClick(object sender, EventArgs e)
        {
            if (this.tbiNext.get_Enabled())
            {
                this.tbcMenu.set_SelectedIndex(4);
            }
        }

        private void lstEntry_RowEntered(object sender, RowEnteredEventArgs e)
        {
            try
            {
                Property.TransactionNo = this.lstEntry.get_SelectedRow().get_Item("No").ToString();
                Property.TranactionOrigin = this.lstEntry.get_SelectedRow().get_Item("Origin").ToString();
                this.tbiDelete.set_Enabled(true);
                this.tbiConfirm.set_Enabled(double.Parse(this.lstEntry.get_SelectedRow().get_Item("Quantity").ToString()) != 0);
                this.tbiUndo.set_Enabled(double.Parse(this.lstEntry.get_SelectedRow().get_Item("Quantity").ToString()) != 0);
                this.tbiNext.set_Enabled(true);
            }
            catch (Exception exception)
            {
                CommonLib.DisplayErrorMessage(exception);
            }
        }

        private void ResetDocumentProperties()
        {
            Property.OperationMode = Property.OperationModeEnum.Online;
            Property.DocumentDate = DateTime.Now.Date;
            Property.ReferenceDate = DateTime.Now.Date;
            Property.TransactionPortCode = string.Empty;
            Property.TransactionPortName = string.Empty;
            Property.HeaderReferenceNo1 = string.Empty;
            Property.HeaderReferenceNo2 = string.Empty;
            Property.Remarks = string.Empty;
            Property.DefaultReasonCode = string.Empty;
            Property.LineReferenceNo1 = string.Empty;
            Property.LineReferenceNo2 = string.Empty;
        }

        private void SetMenu()
        {
            try
            {
                switch (Property.TransactionType)
                {
                    case Property.TransactionTypeEnum.SPC:
                    case Property.TransactionTypeEnum.PRQ:
                    case Property.TransactionTypeEnum.PO:
                    case Property.TransactionTypeEnum.PR:
                    case Property.TransactionTypeEnum.PRS:
                    case Property.TransactionTypeEnum.SO:
                    case Property.TransactionTypeEnum.SI:
                    case Property.TransactionTypeEnum.SR:
                    case Property.TransactionTypeEnum.SRR:
                    case Property.TransactionTypeEnum.TRQ:
                    case Property.TransactionTypeEnum.TRO:
                    case Property.TransactionTypeEnum.TRS:
                    case Property.TransactionTypeEnum.ADJ:
                    case Property.TransactionTypeEnum.SHRINK:
                    case Property.TransactionTypeEnum.MISC:
                    case Property.TransactionTypeEnum.PLC:
                    case Property.TransactionTypeEnum.SLC:
                        {
                            this.tbiNew.set_Enabled(true);
                            this.tbiNew.set_Visible(true);
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.PI:
                        {
                            this.tbiNew.set_Enabled((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionTypeEnum.PO.ToString())).Length > 0);
                            this.tbiNew.set_Visible(this.tbiNew.get_Enabled());
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.TRI:
                        {
                            this.tbiNew.set_Enabled(false);
                            this.tbiNew.set_Visible(false);
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.SC:
                        {
                            this.tbiUndo.set_Enabled(false);
                            this.tbiDelete.set_Enabled(false);
                            this.tbiConfirm.set_Enabled(false);
                            this.tbiNext.set_Enabled(false);
                            break;
                        }
                    default:
                        {
                            goto case Property.TransactionTypeEnum.SC;
                        }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void SetSearchControl()
        {
            string[] strArrays;
            try
            {
                switch (Property.TransactionType)
                {
                    case Property.TransactionTypeEnum.SPC:
                        {
                            this.Text = ":: Shelf Price Checks";
                            UIComboBox uIComboBox = this.cmbSearchBy;
                            strArrays = new string[] { "Count. No." };
                            uIComboBox.set_StringData(strArrays);
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.PRQ:
                        {
                            this.Text = ":: Purch. Requisitions";
                            UIComboBox uIComboBox1 = this.cmbSearchBy;
                            strArrays = new string[] { "Req. No." };
                            uIComboBox1.set_StringData(strArrays);
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.PO:
                        {
                            this.Text = ":: Purch. Orders";
                            UIComboBox uIComboBox2 = this.cmbSearchBy;
                            strArrays = new string[] { "Ordr. No.", "Vendor No." };
                            uIComboBox2.set_StringData(strArrays);
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.PI:
                        {
                            this.Text = ":: Purch. Receipt Notes";
                            UIComboBox uIComboBox3 = this.cmbSearchBy;
                            strArrays = new string[] { "Ordr. No.", "Vendor No." };
                            uIComboBox3.set_StringData(strArrays);
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.PR:
                    case Property.TransactionTypeEnum.PRS:
                        {
                            this.Text = ":: Purch. Returns";
                            UIComboBox uIComboBox4 = this.cmbSearchBy;
                            strArrays = new string[] { "Ret. No.", "Vendor No." };
                            uIComboBox4.set_StringData(strArrays);
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.SO:
                    case Property.TransactionTypeEnum.SI:
                        {
                            this.Text = ":: Sales Orders";
                            UIComboBox uIComboBox5 = this.cmbSearchBy;
                            strArrays = new string[] { "Ordr. No.", "Cust. No." };
                            uIComboBox5.set_StringData(strArrays);
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.SR:
                    case Property.TransactionTypeEnum.SRR:
                        {
                            this.Text = ":: Sales Returns";
                            UIComboBox uIComboBox6 = this.cmbSearchBy;
                            strArrays = new string[] { "Ret. No.", "Cust. No." };
                            uIComboBox6.set_StringData(strArrays);
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.TRQ:
                        {
                            this.Text = ":: Transfer Requests";
                            UIComboBox uIComboBox7 = this.cmbSearchBy;
                            strArrays = new string[] { "Req. No.", "Shpd. frm - code" };
                            uIComboBox7.set_StringData(strArrays);
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.TRO:
                    case Property.TransactionTypeEnum.TRS:
                        {
                            this.Text = ":: Transfer Outs";
                            UIComboBox uIComboBox8 = this.cmbSearchBy;
                            strArrays = new string[] { "Order No.", "Shpd. to - code" };
                            uIComboBox8.set_StringData(strArrays);
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.TRI:
                        {
                            this.Text = ":: Transfer Ins";
                            UIComboBox uIComboBox9 = this.cmbSearchBy;
                            strArrays = new string[] { "Rcpt. No.", "Shpd. from - code", "Ref. No." };
                            uIComboBox9.set_StringData(strArrays);
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.ADJ:
                        {
                            this.Text = ":: Stock Wastages";
                            UIComboBox uIComboBox10 = this.cmbSearchBy;
                            strArrays = new string[] { "Doc. No." };
                            uIComboBox10.set_StringData(strArrays);
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.SHRINK:
                        {
                            this.Text = ":: Stock Shrinkages";
                            UIComboBox uIComboBox11 = this.cmbSearchBy;
                            strArrays = new string[] { "Doc. No." };
                            uIComboBox11.set_StringData(strArrays);
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.MISC:
                        {
                            this.Text = ":: Stock Miscellaneous";
                            UIComboBox uIComboBox12 = this.cmbSearchBy;
                            strArrays = new string[] { "Doc. No." };
                            uIComboBox12.set_StringData(strArrays);
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.SC:
                        {
                            break;
                        }
                    case Property.TransactionTypeEnum.PLC:
                        {
                            this.Text = ":: Product Label Counts";
                            UIComboBox uIComboBox13 = this.cmbSearchBy;
                            strArrays = new string[] { "Count. No." };
                            uIComboBox13.set_StringData(strArrays);
                            goto case Property.TransactionTypeEnum.SC;
                        }
                    case Property.TransactionTypeEnum.SLC:
                        {
                            this.Text = ":: Shelf Label Counts";
                            UIComboBox uIComboBox14 = this.cmbSearchBy;
                            strArrays = new string[] { "Count. No." };
                            uIComboBox14.set_StringData(strArrays);
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
                throw exception;
            }
        }

        private void tbcMenu_SelectionChanged(object sender, EventArgs e)
        {
            DataTable dataTable;
            DataRow str;
            DialogResult dialogResult;
            frmTransHeader _frmTransHeader;
            frmTransLine _frmTransLine;
            DataTable table;
            Service service;
            int count;
            double num;
            string[] strArrays;
            try
            {
                try
                {
                    dataTable = null;
                    switch (this.tbcMenu.get_SelectedIndex())
                    {
                        case 0:
                            {
                                CommonLib.SwitchForm(new frmOptions());
                                break;
                            }
                        case 1:
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                this.lstEntry.set_ActiveRowIndex(-1);
                                this.tbiUndo.set_Enabled(false);
                                this.tbiDelete.set_Enabled(false);
                                this.tbiConfirm.set_Enabled(false);
                                this.tbiNext.set_Enabled(false);
                                Property.IsNewDoc = true;
                                Property.TransactionNo = string.Empty;
                                Property.TransactionStatus = "SM";
                                Property.TranactionOrigin = "iNTrack";
                                this.ResetDocumentProperties();
                                _frmTransHeader = new frmTransHeader();
                                try
                                {
                                    dialogResult = _frmTransHeader.ShowDialog();
                                }
                                finally
                                {
                                    if (_frmTransHeader != null)
                                    {
                                        ((IDisposable)_frmTransHeader).Dispose();
                                    }
                                }
                                if (dialogResult == DialogResult.OK)
                                {
                                    Property.IsPortSelected = !string.IsNullOrEmpty(Property.TransactionPortCode);
                                    _frmTransLine = new frmTransLine();
                                    try
                                    {
                                        _frmTransLine.ShowDialog();
                                    }
                                    finally
                                    {
                                        if (_frmTransLine != null)
                                        {
                                            ((IDisposable)_frmTransLine).Dispose();
                                        }
                                    }
                                    if (!string.IsNullOrEmpty(Property.TransactionNo))
                                    {
                                        this.lstEntry.set_ActiveRowIndex(Property.TransHeader.Rows.Count - 1);
                                        str = Property.TransHeader.Select(string.Format("[No] = '{0}'", Property.TransactionNo))[0];
                                        count = Property.TransLine.Rows.Count;
                                        str["Count"] = count.ToString();
                                        num = Math.Round(Conversion.Val(Convert.ToString(Property.TransLine.Compute("Sum(Quantity)", string.Empty))), 2);
                                        str["Quantity"] = num.ToString();
                                        Property.TransHeader.AcceptChanges();
                                    }
                                }
                                break;
                            }
                        case 2:
                            {
                                if (this.lstEntry.get_ActiveRowIndex() != -1)
                                {
                                    if (MessageBoxEx.Show("Are you sure you want to confirm?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        Application.DoEvents();
                                        Property.TransactionStatus = (this.lstEntry.get_SelectedRow().get_Item("Status").ToString() == "0" || this.lstEntry.get_SelectedRow().get_Item("Status").ToString() == "AU" ? "AU" : "SM");
                                        if (iNTrackLib.CheckItemValidity())
                                        {
                                            iNTrackLib.GetDocumentLines();
                                            iNTrackLib.GetTransactionLines();
                                            if ((Conversion.Val(Convert.ToString(Property.TransLine.Compute("Sum([Quantity])", string.Empty))) == Conversion.Val(Convert.ToString(Property.DocLine.Compute("Sum([Quantity])", string.Empty))) ? false : MessageBoxEx.Show("Document is partially processed. Are you sure you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No))
                                            {
                                                return;
                                            }
                                        }
                                        str = Property.TransHeader.Select(string.Format("No = '{0}'", Property.TransactionNo))[0];
                                        Cursor.Current = Cursors.WaitCursor;
                                        switch (Property.TransactionType)
                                        {
                                            case Property.TransactionTypeEnum.SPC:
                                            case Property.TransactionTypeEnum.PRQ:
                                            case Property.TransactionTypeEnum.ADJ:
                                            case Property.TransactionTypeEnum.SHRINK:
                                            case Property.TransactionTypeEnum.MISC:
                                            case Property.TransactionTypeEnum.PLC:
                                            case Property.TransactionTypeEnum.SLC:
                                                {
                                                    Property.TransactionPortCode = string.Empty;
                                                    Property.TransactionPortName = string.Empty;
                                                    goto case Property.TransactionTypeEnum.SC;
                                                }
                                            case Property.TransactionTypeEnum.PO:
                                            case Property.TransactionTypeEnum.PI:
                                            case Property.TransactionTypeEnum.SR:
                                            case Property.TransactionTypeEnum.SRR:
                                            case Property.TransactionTypeEnum.TRQ:
                                            case Property.TransactionTypeEnum.TRI:
                                                {
                                                    Property.TransactionPortCode = this.lstEntry.get_SelectedRow().get_Item("Source").ToString();
                                                    Property.TransactionPortName = this.lstEntry.get_SelectedRow().get_Item("Source Name").ToString();
                                                    goto case Property.TransactionTypeEnum.SC;
                                                }
                                            case Property.TransactionTypeEnum.PR:
                                            case Property.TransactionTypeEnum.PRS:
                                            case Property.TransactionTypeEnum.SO:
                                            case Property.TransactionTypeEnum.SI:
                                            case Property.TransactionTypeEnum.TRO:
                                            case Property.TransactionTypeEnum.TRS:
                                                {
                                                    Property.TransactionPortCode = this.lstEntry.get_SelectedRow().get_Item("Destination").ToString();
                                                    Property.TransactionPortName = this.lstEntry.get_SelectedRow().get_Item("Destination Name").ToString();
                                                    goto case Property.TransactionTypeEnum.SC;
                                                }
                                            case Property.TransactionTypeEnum.SC:
                                                {
                                                    Property.IsPortSelected = !string.IsNullOrEmpty(Property.TransactionPortCode);
                                                    Property.TransactionStatus = (this.lstEntry.get_SelectedRow().get_Item("Status").ToString() == "0" || this.lstEntry.get_SelectedRow().get_Item("Status").ToString() == "AU" ? "AU" : "SM");
                                                    if (Property.TransactionType != Property.TransactionTypeEnum.PI)
                                                    {
                                                        Property.OperationMode = Property.OperationModeEnum.Online;
                                                    }
                                                    else if (!(Property.TransactionStatus == "AU"))
                                                    {
                                                        Property.OperationMode = Property.OperationModeEnum.Online;
                                                    }
                                                    else
                                                    {
                                                        Property.OperationMode = Property.OperationModeEnum.Offline;
                                                    }
                                                    if (!Property.IsPortSelected)
                                                    {
                                                        if ((Property.TransactionType == Property.TransactionTypeEnum.PO || Property.TransactionType == Property.TransactionTypeEnum.PR ? true : Property.TransactionType == Property.TransactionTypeEnum.PRS))
                                                        {
                                                            iNTrackLib.GetTransactionLines();
                                                            if (Property.TransactionType != Property.TransactionTypeEnum.PO)
                                                            {
                                                                Property.TransLine.Columns["InventLocationIdFrom"].ColumnName = "Source";
                                                                Property.TransLine.Columns["FromLocationName"].ColumnName = "Source Name";
                                                                Property.TransLine.Columns["HHTSourceNo"].ColumnName = "Destination";
                                                                Property.TransLine.Columns["SourceName"].ColumnName = "Destination Name";
                                                                dataTable = Property.TransLine.Copy();
                                                                dataTable.Columns["Destination"].ColumnName = "Port";
                                                                dataTable.Columns["Destination Name"].ColumnName = "Port Name";
                                                            }
                                                            else
                                                            {
                                                                Property.TransLine.Columns["HHTSourceNo"].ColumnName = "Source";
                                                                Property.TransLine.Columns["SourceName"].ColumnName = "Source Name";
                                                                Property.TransLine.Columns["InventLocationIdTo"].ColumnName = "Destination";
                                                                Property.TransLine.Columns["ToLocationName"].ColumnName = "Destination Name";
                                                                dataTable = Property.TransLine.Copy();
                                                                dataTable.Columns["Source"].ColumnName = "Port";
                                                                dataTable.Columns["Source Name"].ColumnName = "Port Name";
                                                            }
                                                            DataView defaultView = dataTable.DefaultView;
                                                            strArrays = new string[] { "Port", "Port Name" };
                                                            table = defaultView.ToTable(true, strArrays);
                                                            if (table.Rows.Count > 0)
                                                            {
                                                                goto Label4;
                                                            }
                                                        }
                                                    }
                                                    service = new Service();
                                                    try
                                                    {
                                                        service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                                        if (Property.OperationMode != Property.OperationModeEnum.Online)
                                                        {
                                                            DataSet dataSet = new DataSet();
                                                            dataTable = (DataTable)SqlCeLib.Execute(string.Format("Select * From [Transaction Header] Where [Transaction Type] = '{0}' And [Transaction No.] = '{1}'", Property.TransactionType, Property.TransactionNo), SqlCeLib.ExecMode.Query, new SqlCeParameter[0]);
                                                            dataSet.Tables.Add(dataTable.Copy());
                                                            dataTable = (DataTable)SqlCeLib.Execute(string.Format("Select * From [HHT Transactions] Where [Transaction Type] = '{0}' And [Transaction No.] = '{1}'", Property.TransactionType, Property.TransactionNo), SqlCeLib.ExecMode.Query, new SqlCeParameter[0]);
                                                            dataSet.Tables.Add(dataTable.Copy());
                                                            strArrays = new string[] { "Transaction_Header_1001", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationName"].ToString(), Property.Configuration.Tables[0].Rows[0]["DeviceID"].ToString() };
                                                            service.SetData(strArrays, dataSet);
                                                            SqlCeLib.Execute(string.Format("Delete From [Transaction Header] Where [Transaction Type] = '{0}' And [Transaction No.] = '{1}'", Property.TransactionType, Property.TransactionNo), SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                                                            SqlCeLib.Execute(string.Format("Delete From [Transaction Line] Where [Transaction Type] = '{0}' And [Transaction No.] = '{1}'", Property.TransactionType, Property.TransactionNo), SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                                                            SqlCeLib.Execute(string.Format("Delete From [HHT Transactions] Where [Transaction Type] = '{0}' And [Transaction No.] = '{1}'", Property.TransactionType, Property.TransactionNo), SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                                                        }
                                                        else
                                                        {
                                                            strArrays = new string[] { "Transaction_Header_4001", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionType.ToString(), Property.TransactionNo, Property.UserCode };
                                                            service.SetData(strArrays, new DataSet());
                                                        }
                                                    }
                                                    finally
                                                    {
                                                        if (service != null)
                                                        {
                                                            ((IDisposable)service).Dispose();
                                                        }
                                                    }
                                                    Property.TransHeader.Select(string.Format("No = '{0}'", Property.TransactionNo))[0].Delete();
                                                Label3:
                                                    Property.TransHeader.AcceptChanges();
                                                    this.tbiUndo.set_Enabled(false);
                                                    this.tbiDelete.set_Enabled(false);
                                                    this.tbiConfirm.set_Enabled(false);
                                                    this.tbiNext.set_Enabled(false);
                                                    break;
                                                }
                                            default:
                                                {
                                                    goto case Property.TransactionTypeEnum.SC;
                                                }
                                        }
                                    }
                                    break;
                                }
                                else
                                {
                                    return;
                                }
                            }
                        case 3:
                            {
                                if (this.lstEntry.get_ActiveRowIndex() != -1)
                                {
                                    if (MessageBoxEx.Show("Are you sure you want to undo complete transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        Application.DoEvents();
                                        Cursor.Current = Cursors.WaitCursor;
                                        str = Property.TransHeader.Select(string.Format("[No] = '{0}'", Property.TransactionNo))[0];
                                        service = new Service();
                                        try
                                        {
                                            service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                            strArrays = new string[] { "HHT_Transactions_2000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionType.ToString(), Property.TransactionNo, Property.UserCode };
                                            service.SetData(strArrays, new DataSet());
                                        }
                                        finally
                                        {
                                            if (service != null)
                                            {
                                                ((IDisposable)service).Dispose();
                                            }
                                        }
                                        str["Count"] = "0";
                                        str["Quantity"] = "0";
                                        Property.TransHeader.AcceptChanges();
                                    }
                                    break;
                                }
                                else
                                {
                                    return;
                                }
                            }
                        case 4:
                            {
                                if (this.lstEntry.get_ActiveRowIndex() != -1)
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    Property.TransactionStatus = (this.lstEntry.get_SelectedRow().get_Item("Status").ToString() == "0" || this.lstEntry.get_SelectedRow().get_Item("Status").ToString() == "AU" ? "AU" : "SM");
                                    this.ResetDocumentProperties();
                                    str = Property.TransHeader.Select(string.Format("[No] = '{0}'", Property.TransactionNo))[0];
                                    Property.IsNewDoc = str["New"].ToString() == "1";
                                    Property.DocumentDate = (DateTime)str["Document Date"];
                                    Property.ReferenceDate = (DateTime)str["Expected Date"];
                                    Property.HeaderReferenceNo1 = str["Reference No.1"].ToString();
                                    Property.HeaderReferenceNo2 = str["Reference No.2"].ToString();
                                    switch (Property.TransactionType)
                                    {
                                        case Property.TransactionTypeEnum.SPC:
                                        case Property.TransactionTypeEnum.PRQ:
                                        case Property.TransactionTypeEnum.ADJ:
                                        case Property.TransactionTypeEnum.SHRINK:
                                        case Property.TransactionTypeEnum.MISC:
                                        case Property.TransactionTypeEnum.PLC:
                                        case Property.TransactionTypeEnum.SLC:
                                            {
                                                Property.TransactionPortCode = string.Empty;
                                                Property.TransactionPortName = string.Empty;
                                                goto case Property.TransactionTypeEnum.SC;
                                            }
                                        case Property.TransactionTypeEnum.PO:
                                        case Property.TransactionTypeEnum.PI:
                                        case Property.TransactionTypeEnum.SR:
                                        case Property.TransactionTypeEnum.SRR:
                                        case Property.TransactionTypeEnum.TRQ:
                                        case Property.TransactionTypeEnum.TRI:
                                            {
                                                Property.TransactionPortCode = this.lstEntry.get_SelectedRow().get_Item("Source").ToString();
                                                Property.TransactionPortName = this.lstEntry.get_SelectedRow().get_Item("Source Name").ToString();
                                                goto case Property.TransactionTypeEnum.SC;
                                            }
                                        case Property.TransactionTypeEnum.PR:
                                        case Property.TransactionTypeEnum.PRS:
                                        case Property.TransactionTypeEnum.SO:
                                        case Property.TransactionTypeEnum.SI:
                                        case Property.TransactionTypeEnum.TRO:
                                        case Property.TransactionTypeEnum.TRS:
                                            {
                                                Property.TransactionPortCode = this.lstEntry.get_SelectedRow().get_Item("Destination").ToString();
                                                Property.TransactionPortName = this.lstEntry.get_SelectedRow().get_Item("Destination Name").ToString();
                                                goto case Property.TransactionTypeEnum.SC;
                                            }
                                        case Property.TransactionTypeEnum.SC:
                                            {
                                                _frmTransHeader = new frmTransHeader();
                                                try
                                                {
                                                    dialogResult = _frmTransHeader.ShowDialog();
                                                }
                                                finally
                                                {
                                                    if (_frmTransHeader != null)
                                                    {
                                                        ((IDisposable)_frmTransHeader).Dispose();
                                                    }
                                                }
                                                if (dialogResult == DialogResult.OK)
                                                {
                                                    if (Property.TransactionType == Property.TransactionTypeEnum.PI)
                                                    {
                                                        if (Property.TransactionStatus == "AU")
                                                        {
                                                            Property.OperationMode = Property.OperationModeEnum.Offline;
                                                        }
                                                    }
                                                    Property.IsPortSelected = !string.IsNullOrEmpty(Property.TransactionPortCode);
                                                    _frmTransLine = new frmTransLine();
                                                    try
                                                    {
                                                        _frmTransLine.ShowDialog();
                                                    }
                                                    finally
                                                    {
                                                        if (_frmTransLine != null)
                                                        {
                                                            ((IDisposable)_frmTransLine).Dispose();
                                                        }
                                                    }
                                                    count = Property.TransLine.Rows.Count;
                                                    str["Count"] = count.ToString();
                                                    num = Math.Round(Conversion.Val(Convert.ToString(Property.TransLine.Compute("Sum(Quantity)", string.Empty))), 2);
                                                    str["Quantity"] = num.ToString();
                                                    Property.TransHeader.AcceptChanges();
                                                }
                                                break;
                                            }
                                        default:
                                            {
                                                goto case Property.TransactionTypeEnum.SC;
                                            }
                                    }
                                }
                                else
                                {
                                    return;
                                }
                                break;
                            }
                        case 5:
                            {
                                if (this.lstEntry.get_ActiveRowIndex() != -1)
                                {
                                    if (MessageBoxEx.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        Application.DoEvents();
                                        Cursor.Current = Cursors.WaitCursor;
                                        Property.TransactionStatus = (this.lstEntry.get_SelectedRow().get_Item("Status").ToString() == "0" || this.lstEntry.get_SelectedRow().get_Item("Status").ToString() == "AU" ? "AU" : "SM");
                                        if (Property.TransactionType != Property.TransactionTypeEnum.PI)
                                        {
                                            Property.OperationMode = Property.OperationModeEnum.Online;
                                        }
                                        else if (!(Property.TransactionStatus == "AU"))
                                        {
                                            Property.OperationMode = Property.OperationModeEnum.Online;
                                        }
                                        else
                                        {
                                            Property.OperationMode = Property.OperationModeEnum.Offline;
                                        }
                                        if (Property.OperationMode != Property.OperationModeEnum.Online)
                                        {
                                            SqlCeLib.Execute(string.Format("Delete From [Transaction Header] Where [Transaction Type] = '{0}' And [Transaction No.] = '{1}'", Property.TransactionType, Property.TransactionNo), SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                                            SqlCeLib.Execute(string.Format("Delete From [Transaction Line] Where [Transaction Type] = '{0}' And [Transaction No.] = '{1}'", Property.TransactionType, Property.TransactionNo), SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                                            SqlCeLib.Execute(string.Format("Delete From [HHT Transactions] Where [Transaction Type] = '{0}' And [Transaction No.] = '{1}'", Property.TransactionType, Property.TransactionNo), SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                                        }
                                        else
                                        {
                                            service = new Service();
                                            try
                                            {
                                                service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                                strArrays = new string[] { "Transaction_Header_2000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionType.ToString(), Property.TransactionNo, Property.UserCode };
                                                service.SetData(strArrays, new DataSet());
                                            }
                                            finally
                                            {
                                                if (service != null)
                                                {
                                                    ((IDisposable)service).Dispose();
                                                }
                                            }
                                        }
                                        Property.TransHeader.Select(string.Format("No = '{0}'", Property.TransactionNo))[0].Delete();
                                        Property.TransHeader.AcceptChanges();
                                        this.tbiUndo.set_Enabled(false);
                                        this.tbiDelete.set_Enabled(false);
                                        this.tbiConfirm.set_Enabled(false);
                                        this.tbiNext.set_Enabled(false);
                                    }
                                    break;
                                }
                                else
                                {
                                    return;
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
                return;
            }
            finally
            {
                this.tbcMenu.set_SelectedIndex(-1);
                Cursor.Current = Cursors.Default;
            }
            return;
        Label4:
            string transactionNo = Property.TransactionNo;
            foreach (DataRow row in table.Rows)
            {
                Property.IsNewDoc = true;
                Property.TransactionNo = string.Empty;
                Property.TranactionOrigin = "iNTrack";
                Property.TransactionPortCode = row["Port"].ToString();
                Property.TransactionPortName = row["Port Name"].ToString();
                Property.IsPortSelected = true;
                Property.TransLine.Clear();
                DataRow[] dataRowArray = dataTable.Select(string.Format("Port = '{0}'", row["Port"]), "[Line No.] Asc");
                for (int i = 0; i < (int)dataRowArray.Length; i++)
                {
                    DataRow dataRow = dataRowArray[i];
                    iNTrackLib.InsertTrans(dataRow["Itemcode"].ToString(), dataRow["Barcode"].ToString(), dataRow["Description"].ToString(), dataRow["UOM"].ToString(), dataRow["Reason Code"].ToString(), double.Parse(dataRow["Quantity"].ToString()), double.Parse(dataRow["Unit Price"].ToString()), 0, double.Parse(dataRow["Amount"].ToString()), false, dataRow["Production Date"].ToString(), dataRow["Expiry Date"].ToString(), true);
                }
                if (Property.OperationMode == Property.OperationModeEnum.Online)
                {
                    service = new Service();
                    try
                    {
                        service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                        strArrays = new string[] { "Transaction_Header_4001", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionType.ToString(), Property.TransactionNo, Property.UserCode };
                        service.SetData(strArrays, new DataSet());
                    }
                    finally
                    {
                        if (service != null)
                        {
                            ((IDisposable)service).Dispose();
                        }
                    }
                }
                Property.TransHeader.Select(string.Format("No = '{0}'", Property.TransactionNo))[0].Delete();
            }
            Property.TransactionNo = transactionNo;
            if (Property.OperationMode == Property.OperationModeEnum.Online)
            {
                service = new Service();
                try
                {
                    service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                    strArrays = new string[] { "Transaction_Header_2000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionType.ToString(), Property.TransactionNo, Property.UserCode };
                    service.SetData(strArrays, new DataSet());
                }
                finally
                {
                    if (service != null)
                    {
                        ((IDisposable)service).Dispose();
                    }
                }
            }
            Property.TransHeader.Select(string.Format("No = '{0}'", Property.TransactionNo))[0].Delete();
            goto Label3;
        }

        private void txtFilter_GotFocus(object sender, EventArgs e)
        {
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                try
                {
                    if (e.KeyChar == '\r')
                    {
                        if (this.cmbSearchBy.get_SelectedIndex() == 0)
                        {
                            Property.TransactionTypeEnum transactionType = Property.TransactionType;
                            if (transactionType != Property.TransactionTypeEnum.PI)
                            {
                                switch (transactionType)
                                {
                                    case Property.TransactionTypeEnum.SI:
                                    case Property.TransactionTypeEnum.SRR:
                                    case Property.TransactionTypeEnum.TRS:
                                    case Property.TransactionTypeEnum.TRI:
                                    {
                                        break;
                                    }
                                    default:
                                    {
                                        goto Label0;
                                    }
                                }
                            }
                            if ((int)Property.TransHeader.Select(string.Format("[No] = '{0}'", this.txtFilter.get_Text())).Length == 0)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                DataTable dataTable = this.DownloadERPHeaders();
                                if (dataTable.Rows.Count == 0)
                                {
                                    throw new Exception("Document not found");
                                }
                                Property.TransHeader.Clear();
                                Property.TransHeader.Merge(dataTable, true, MissingSchemaAction.Ignore);
                                this.DownloadiNTrackHeaders();
                                this.txtFilter.set_Text(dataTable.Rows[0]["No"].ToString());
                            }
                        Label0:
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

        private void txtFilter_LostFocus(object sender, EventArgs e)
        {
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string str = null;
                    switch (this.cmbSearchBy.get_SelectedIndex())
                    {
                        case 0:
                            {
                                str = "No";
                                break;
                            }
                        case 1:
                            {
                                switch (Property.TransactionType)
                                {
                                    case Property.TransactionTypeEnum.PO:
                                        {
                                            str = "Source";
                                            break;
                                        }
                                    case Property.TransactionTypeEnum.PI:
                                        {
                                            str = "Source";
                                            break;
                                        }
                                    case Property.TransactionTypeEnum.PR:
                                        {
                                            str = "Destination";
                                            break;
                                        }
                                    case Property.TransactionTypeEnum.PRS:
                                        {
                                            str = "Destination";
                                            break;
                                        }
                                    case Property.TransactionTypeEnum.SO:
                                        {
                                            str = "Destination";
                                            break;
                                        }
                                    case Property.TransactionTypeEnum.SI:
                                        {
                                            str = "Destination";
                                            break;
                                        }
                                    case Property.TransactionTypeEnum.SR:
                                    case Property.TransactionTypeEnum.SRR:
                                        {
                                            str = "Source";
                                            break;
                                        }
                                    case Property.TransactionTypeEnum.TRQ:
                                    case Property.TransactionTypeEnum.TRI:
                                        {
                                            str = "Source";
                                            break;
                                        }
                                    case Property.TransactionTypeEnum.TRO:
                                    case Property.TransactionTypeEnum.TRS:
                                        {
                                            str = "Destination";
                                            break;
                                        }
                                }
                                break;
                            }
                        case 2:
                            {
                                if (Property.TransactionType == Property.TransactionTypeEnum.TRI)
                                {
                                    str = "Reference No.1";
                                }
                                break;
                            }
                    }
                    if (!string.IsNullOrEmpty(this.txtFilter.get_Text().Trim()))
                    {
                        ((DataView)this.lstEntry.get_DataSource()).RowFilter = string.Format("[{0}] Like '*{1}*'", str, this.txtFilter.get_Text());
                    }
                    else
                    {
                        ((DataView)this.lstEntry.get_DataSource()).RowFilter = string.Empty;
                    }
                    string str1 = str;
                    if (str1 != null)
                    {
                        if (str1 == "No")
                        {
                            this.celltxtNo.set_SelectedText(this.txtFilter.get_Text());
                            this.celltxtNoSelect.set_SelectedText(this.txtFilter.get_Text());
                        }
                        else if (str1 == "Source")
                        {
                            this.celltxtSource.set_SelectedText(this.txtFilter.get_Text());
                            this.celltxtSourceSelect.set_SelectedText(this.txtFilter.get_Text());
                        }
                        else if (str1 == "Destination")
                        {
                            this.celltxtSourceName.set_SelectedText(this.txtFilter.get_Text());
                            this.celltxtDestSelect.set_SelectedText(this.txtFilter.get_Text());
                        }
                        else if (str1 == "Reference No.1")
                        {
                            DataRow[] dataRowArray = Property.TransHeader.Select(string.Format("[Reference No.1] = '{0}'", this.txtFilter.get_Text()));
                            if ((int)dataRowArray.Length > 0)
                            {
                                this.celltxtNo.set_SelectedText(dataRowArray[0]["No"].ToString());
                                this.celltxtNoSelect.set_SelectedText(dataRowArray[0]["No"].ToString());
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