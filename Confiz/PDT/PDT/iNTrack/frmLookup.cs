using iNTrack.iNTrackService;
using Resco.Controls.AdvancedList;
using Resco.Controls.CommonControls;
using Resco.UIElements;
using Resco.UIElements.Controls;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Web.Services.Protocols;
using System.Windows.Forms;

namespace iNTrack
{
    public class frmLookup : Form
    {
        private IContainer components = null;

        private ToolbarControl tbcMenu;

        private ToolbarItem tbiBack;

        private ToolbarItem tbiNext;

        private UIElementPanelControl pnlSearch;

        private UITextBox txtFilter;

        private UITextBoxButton btnFilter;

        private AdvancedList lstEntry;

        private UIRadioButton rbtnCode;

        private UIRadioButton rbtnName;

        private RowTemplate tempRow;

        private TextCell celltxtCode;

        private TextCell celltxtName;

        private Cell cellSepH;

        private RowTemplate tempRowSelect;

        private TextCell celltxtCodeSelect;

        private TextCell celltxtNameSelect;

        private SeparatorCell cellSepHSelect;

        private Cell cellSepV;

        private Cell cellSepVSelect;

        private frmLookup.SourceEnum m_SourceEnum;

        private string m_sSelectedCode;

        private string m_sSelectedName;

        private DataTable m_dtEntry = null;

        public string SelectedCode
        {
            get
            {
                return this.m_sSelectedCode;
            }
            set
            {
                this.m_sSelectedCode = value;
            }
        }

        public string SelectedName
        {
            get
            {
                return this.m_sSelectedName;
            }
            set
            {
                this.m_sSelectedName = value;
            }
        }

        public frmLookup(frmLookup.SourceEnum Source)
        {
            this.InitializeComponent();
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int width = bounds.Width;
            bounds = Screen.PrimaryScreen.Bounds;
            base.Size = new Size(width, bounds.Height);
            this.AutoScroll = false;
            this.m_SourceEnum = Source;
        }

        protected override void Dispose(bool disposing)
        {
            if ((!disposing ? false : this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmLookup_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    switch (this.m_SourceEnum)
                    {
                        case frmLookup.SourceEnum.Vendor:
                            {
                                this.Text = "Select Vendor";
                                break;
                            }
                        case frmLookup.SourceEnum.Customer:
                            {
                                this.Text = "Select Customer";
                                break;
                            }
                        case frmLookup.SourceEnum.Location:
                            {
                                this.Text = "Select Location";
                                break;
                            }
                        case frmLookup.SourceEnum.InvoiceNo:
                            {
                                this.Text = "Select Venor Invoice No.";
                                this.rbtnCode.set_Text("Inv. No.");
                                this.rbtnName.set_Visible(false);
                                this.cellSepV.set_Visible(false);
                                this.cellSepVSelect.set_Visible(false);
                                this.celltxtName.set_Visible(false);
                                this.celltxtNameSelect.set_Visible(false);
                                break;
                            }
                        case frmLookup.SourceEnum.Reason:
                            {
                                this.Text = "Select Reason";
                                break;
                            }
                    }
                    this.SetEntryList();
                    this.tbiNext.set_Enabled(false);
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmLookup));
            this.tbcMenu = new ToolbarControl();
            this.tbiBack = new ToolbarItem();
            this.tbiNext = new ToolbarItem();
            this.pnlSearch = new UIElementPanelControl();
            this.txtFilter = new UITextBox();
            this.btnFilter = new UITextBoxButton();
            this.rbtnCode = new UIRadioButton();
            this.rbtnName = new UIRadioButton();
            this.lstEntry = new AdvancedList();
            this.tempRow = new RowTemplate();
            this.celltxtCode = new TextCell();
            this.celltxtName = new TextCell();
            this.cellSepH = new Cell();
            this.cellSepV = new Cell();
            this.tempRowSelect = new RowTemplate();
            this.celltxtCodeSelect = new TextCell();
            this.celltxtNameSelect = new TextCell();
            this.cellSepHSelect = new SeparatorCell();
            this.cellSepVSelect = new Cell();
            this.pnlSearch.SuspendElementLayout();
            base.SuspendLayout();
            this.tbcMenu.set_ArrowsTransparency(0);
            this.tbcMenu.BackColor = Color.Black;
            this.tbcMenu.set_BmpArrowNext(imgManager.GetImage("iNTrack.Arrow Right2"));
            this.tbcMenu.set_BmpArrowPrevious(imgManager.GetImage("iNTrack.Arrow Left2"));
            this.tbcMenu.Dock = DockStyle.Bottom;
            this.tbcMenu.set_EnableArrowsTransparency(false);
            this.tbcMenu.get_Items().Add(this.tbiBack);
            this.tbcMenu.get_Items().Add(this.tbiNext);
            this.tbcMenu.set_ItemsAlignment(4);
            this.tbcMenu.set_ItemSpacing(5);
            this.tbcMenu.Location = new Point(0, 244);
            this.tbcMenu.set_MarginAtBegin(40);
            this.tbcMenu.set_MarginAtEnd(40);
            this.tbcMenu.Name = "tbcMenu";
            this.tbcMenu.Size = new Size(318, 50);
            this.tbcMenu.TabIndex = 4;
            this.tbcMenu.add_SelectionChanged(new EventHandler(this.tbcMenu_SelectionChanged));
            this.tbiBack.set_BackColor(Color.Black);
            this.tbiBack.set_CustomSize(new Size(0, 0));
            this.tbiBack.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Left"));
            this.tbiBack.set_Name("tbiBack");
            this.tbiBack.set_ToolbarItemBehavior(2);
            this.tbiNext.set_BackColor(Color.Black);
            this.tbiNext.set_CustomSize(new Size(0, 0));
            this.tbiNext.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Right"));
            this.tbiNext.set_Name("tbiNext");
            this.tbiNext.set_ToolbarItemBehavior(2);
            this.pnlSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this.pnlSearch.BackColor = Color.FromArgb(213, 231, 255);
            this.pnlSearch.get_Children().Add(this.txtFilter);
            this.pnlSearch.get_Children().Add(this.rbtnCode);
            this.pnlSearch.get_Children().Add(this.rbtnName);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new Size(318, 64);
            this.txtFilter.get_Buttons().Add(this.btnFilter);
            this.txtFilter.set_Layout(new ElementLayout(3, 0, 5, 35, 5, 0, 308, 26));
            this.txtFilter.set_Name("txtFilter");
            this.txtFilter.set_TabIndex(2);
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
            this.rbtnCode.set_Checked(true);
            this.rbtnCode.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.rbtnCode.set_Layout(new ElementLayout(0, 0, 5, 5, 0, 0, 55, 28));
            this.rbtnCode.set_Name("rbtnCode");
            this.rbtnCode.set_Text("Code");
            this.rbtnCode.add_CheckedChanged(new EventHandler(this.rbtnCode_CheckedChanged));
            this.rbtnName.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.rbtnName.set_Layout(new ElementLayout(0, 0, 68, 5, 0, 0, 60, 28));
            this.rbtnName.set_Name("rbtnName");
            this.rbtnName.set_TabIndex(1);
            this.rbtnName.set_Text("Name");
            this.lstEntry.set_AutoSelectRow(false);
            this.lstEntry.set_BackColor(Color.FromArgb(213, 231, 255));
            this.lstEntry.BorderStyle = BorderStyle.FixedSingle;
            this.lstEntry.get_DataRows().Clear();
            RowCollection dataRows = this.lstEntry.get_DataRows();
            string[] str = new string[] { componentResourceManager.GetString("lstEntry.DataRows"), componentResourceManager.GetString("lstEntry.DataRows1") };
            dataRows.Add(new Row(0, 0, -1, -1, str));
            this.lstEntry.Dock = DockStyle.Bottom;
            this.lstEntry.set_FocusOnClick(true);
            this.lstEntry.set_GridLines(false);
            this.lstEntry.Location = new Point(0, 66);
            this.lstEntry.Name = "lstEntry";
            this.lstEntry.set_ScrollbarSmallChange(32);
            this.lstEntry.set_ScrollbarWidth(26);
            this.lstEntry.set_SelectedTemplateIndex(1);
            this.lstEntry.set_ShowScrollbar(false);
            this.lstEntry.Size = new Size(318, 178);
            this.lstEntry.TabIndex = 3;
            this.lstEntry.get_Templates().Add(this.tempRow);
            this.lstEntry.get_Templates().Add(this.tempRowSelect);
            this.lstEntry.set_TouchScrolling(true);
            this.lstEntry.DoubleClick += new EventHandler(this.lstEntry_DoubleClick);
            this.lstEntry.add_RowEntered(new RowEnteredEventHandler(this, frmLookup.lstEntry_RowEntered));
            this.tempRow.set_BackColor(Color.FromArgb(213, 231, 255));
            this.tempRow.get_CellTemplates().Add(this.celltxtCode);
            this.tempRow.get_CellTemplates().Add(this.celltxtName);
            this.tempRow.get_CellTemplates().Add(this.cellSepH);
            this.tempRow.get_CellTemplates().Add(this.cellSepV);
            this.tempRow.set_Height(30);
            this.tempRow.set_Name("tempRow");
            this.celltxtCode.set_Alignment(2);
            this.celltxtCode.get_CellSource().set_ColumnIndex(0);
            this.celltxtCode.set_DesignName("celltxtCode");
            this.celltxtCode.set_Location(new Point(5, 0));
            this.celltxtCode.set_Size(new Size(75, 30));
            this.celltxtCode.set_TextFont(new Font("Tahoma", 9f, FontStyle.Bold));
            this.celltxtName.set_Alignment(2);
            this.celltxtName.get_CellSource().set_ColumnIndex(1);
            this.celltxtName.set_DesignName("celltxtName");
            this.celltxtName.set_Location(new Point(75, 0));
            this.celltxtName.set_Size(new Size(360, 30));
            this.celltxtName.set_TextFont(new Font("Tahoma", 9f, FontStyle.Bold));
            this.cellSepH.set_BackColor(SystemColors.Highlight);
            this.cellSepH.set_CustomizeCell(true);
            this.cellSepH.set_DesignName("cellSepH");
            this.cellSepH.set_Location(new Point(0, 29));
            this.cellSepH.set_Size(new Size(-1, 1));
            this.cellSepV.set_BackColor(SystemColors.Highlight);
            this.cellSepV.set_CustomizeCell(true);
            this.cellSepV.set_DesignName("cellSepV");
            this.cellSepV.set_Location(new Point(74, 0));
            this.cellSepV.set_Size(new Size(1, 30));
            this.tempRowSelect.set_BackColor(SystemColors.Info);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtCodeSelect);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtNameSelect);
            this.tempRowSelect.get_CellTemplates().Add(this.cellSepHSelect);
            this.tempRowSelect.get_CellTemplates().Add(this.cellSepVSelect);
            this.tempRowSelect.set_Height(30);
            this.tempRowSelect.set_Name("tempRowSelect");
            this.celltxtCodeSelect.set_Alignment(2);
            this.celltxtCodeSelect.get_CellSource().set_ColumnIndex(0);
            this.celltxtCodeSelect.set_DesignName("celltxtCodeSelect");
            this.celltxtCodeSelect.set_Location(new Point(5, 0));
            this.celltxtCodeSelect.set_Size(new Size(75, 30));
            this.celltxtCodeSelect.set_TextFont(new Font("Tahoma", 9f, FontStyle.Bold));
            this.celltxtNameSelect.set_Alignment(2);
            this.celltxtNameSelect.get_CellSource().set_ColumnIndex(1);
            this.celltxtNameSelect.set_DesignName("celltxtNameSelect");
            this.celltxtNameSelect.set_Location(new Point(75, 0));
            this.celltxtNameSelect.set_Size(new Size(360, 30));
            this.celltxtNameSelect.set_TextFont(new Font("Tahoma", 9f, FontStyle.Bold));
            this.cellSepHSelect.set_BackColor(SystemColors.Highlight);
            this.cellSepHSelect.set_CustomizeCell(true);
            this.cellSepHSelect.set_DesignName("cellSepHSelect");
            this.cellSepHSelect.set_Location(new Point(0, 29));
            this.cellSepHSelect.set_Size(new Size(-1, 1));
            this.cellSepVSelect.set_BackColor(SystemColors.Highlight);
            this.cellSepVSelect.set_CustomizeCell(true);
            this.cellSepVSelect.set_DesignName("cellSepVSelect");
            this.cellSepVSelect.set_Location(new Point(74, 0));
            this.cellSepVSelect.set_Size(new Size(1, 30));
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
            base.Name = "frmLookup";
            this.Text = "`";
            base.Load += new EventHandler(this.frmLookup_Load);
            this.pnlSearch.ResumeElementLayout(false);
            base.ResumeLayout(false);
        }

        private void lstEntry_DoubleClick(object sender, EventArgs e)
        {
            this.tbcMenu.set_SelectedIndex(1);
        }

        private void lstEntry_RowEntered(object sender, RowEnteredEventArgs e)
        {
            this.tbiNext.set_Enabled(true);
        }

        private void rbtnCode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.celltxtCode.set_SelectedText(string.Empty);
                this.celltxtCodeSelect.set_SelectedText(string.Empty);
                this.celltxtName.set_SelectedText(string.Empty);
                this.celltxtNameSelect.set_SelectedText(string.Empty);
            }
            catch (Exception exception)
            {
                CommonLib.DisplayErrorMessage(exception);
            }
        }

        private void SetEntryList()
        {
            Service service;
            string[] str;
            try
            {
                this.m_dtEntry = new DataTable();
                this.m_dtEntry.Columns.Add("Code");
                this.m_dtEntry.Columns.Add("Name").DefaultValue = string.Empty;
                DataTable dataTable = new DataTable();
                if (this.m_SourceEnum != frmLookup.SourceEnum.InvoiceNo)
                {
                    service = new Service();
                    try
                    {
                        service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                        switch (this.m_SourceEnum)
                        {
                            case frmLookup.SourceEnum.Vendor:
                                {
                                    str = new string[] { "Vendor_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), "%" };
                                    dataTable = service.GetData(str).Tables[0];
                                    goto case frmLookup.SourceEnum.InvoiceNo;
                                }
                            case frmLookup.SourceEnum.Customer:
                                {
                                    str = new string[] { "Customer_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), "%" };
                                    dataTable = service.GetData(str).Tables[0];
                                    goto case frmLookup.SourceEnum.InvoiceNo;
                                }
                            case frmLookup.SourceEnum.Location:
                                {
                                    str = new string[] { "Location_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), "%" };
                                    dataTable = service.GetData(str).Tables[0];
                                    DataRow[] dataRowArray = dataTable.Select(string.Format("Code = '{0}'", Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString()));
                                    if ((int)dataRowArray.Length == 1)
                                    {
                                        dataRowArray[0].Delete();
                                    }
                                    goto case frmLookup.SourceEnum.InvoiceNo;
                                }
                            case frmLookup.SourceEnum.InvoiceNo:
                                {
                                    break;
                                }
                            case frmLookup.SourceEnum.Reason:
                                {
                                    string empty = string.Empty;
                                    Property.TransactionTypeEnum transactionType = Property.TransactionType;
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
                                    str = new string[] { "Reason_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), "%" };
                                    dataTable = service.GetData(str).Tables[0];
                                    DataRow[] dataRowArray1 = dataTable.Copy().Select(string.Format("[Type] <> '{0}'", empty));
                                    for (int i = 0; i < (int)dataRowArray1.Length; i++)
                                    {
                                        DataRow dataRow = dataRowArray1[i];
                                        dataTable.Select(string.Format("Code = '{0}'", dataRow["Code"]))[0].Delete();
                                    }
                                    goto case frmLookup.SourceEnum.InvoiceNo;
                                }
                            default:
                                {
                                    goto case frmLookup.SourceEnum.InvoiceNo;
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
                }
                else
                {
                    service = new Service();
                    try
                    {
                        service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                        str = new string[] { "HHT_Transactions_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionType.ToString(), Property.TransactionNo, Property.UserCode };
                        dataTable = service.GetData(str).Tables[0];
                        dataTable.Columns["Reference No.2"].ColumnName = "Code";
                        DataView defaultView = dataTable.DefaultView;
                        str = new string[] { "Code" };
                        dataTable = defaultView.ToTable(true, str);
                    }
                    finally
                    {
                        if (service != null)
                        {
                            ((IDisposable)service).Dispose();
                        }
                    }
                }
                this.m_dtEntry.Merge(dataTable, true, MissingSchemaAction.Ignore);
                this.lstEntry.get_DataRows().Clear();
                this.lstEntry.set_DataSource(this.m_dtEntry.DefaultView);
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
                    Cursor.Current = Cursors.WaitCursor;
                    switch (this.tbcMenu.get_SelectedIndex())
                    {
                        case 0:
                            {
                                base.DialogResult = DialogResult.Cancel;
                                break;
                            }
                        case 1:
                            {
                                this.m_sSelectedCode = this.lstEntry.get_SelectedRow().get_Item("Code").ToString();
                                this.m_sSelectedName = this.lstEntry.get_SelectedRow().get_Item("Name").ToString();
                                base.DialogResult = DialogResult.OK;
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

        private void txtFilter_GotFocus(object sender, EventArgs e)
        {
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
                    if (!this.rbtnCode.get_Checked())
                    {
                        this.celltxtName.set_SelectedText(this.txtFilter.get_Text());
                        this.celltxtNameSelect.set_SelectedText(this.txtFilter.get_Text());
                    }
                    else
                    {
                        this.celltxtCode.set_SelectedText(this.txtFilter.get_Text());
                        this.celltxtCodeSelect.set_SelectedText(this.txtFilter.get_Text());
                    }
                    if (!string.IsNullOrEmpty(this.txtFilter.get_Text().Trim()))
                    {
                        ((DataView)this.lstEntry.get_DataSource()).RowFilter = string.Format("{0} Like '*{1}*'", (this.rbtnCode.get_Checked() ? "Code" : "Name"), this.txtFilter.get_Text());
                    }
                    else
                    {
                        ((DataView)this.lstEntry.get_DataSource()).RowFilter = string.Empty;
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

        public enum SourceEnum
        {
            None,
            Vendor,
            Customer,
            Location,
            InvoiceNo,
            Reason
        }
    }
}