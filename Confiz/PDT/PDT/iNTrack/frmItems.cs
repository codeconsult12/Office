using iNTrack.iNTrackService;
using Resco.Controls.CommonControls;
using Resco.Controls.SmartGrid;
using Resco.UIElements;
using Resco.UIElements.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web.Services.Protocols;
using System.Windows.Forms;

namespace iNTrack
{
    public class frmItems : Form
    {
        private string m_sBarcode;

        private frmItems.ParentForm m_ParentForm;

        private DataTable m_dtItem = null;

        private IContainer components = null;

        private ToolbarControl tbcMenu;

        private ToolbarItem tbiBack;

        private ToolbarItem tbiNext;

        private UIElementPanelControl pnlSearch;

        private UITextBox txtSearch;

        private UITextBoxButton btnFilter;

        private UIRadioButton rbtnCode;

        private UIRadioButton rbtnName;

        private UICheckBox chkExact;

        private ToolbarItem tbiSelect;

        private SmartGrid sgItem;

        public string Barcode
        {
            get
            {
                return this.m_sBarcode;
            }
            set
            {
                this.m_sBarcode = value;
            }
        }

        public frmItems(frmItems.ParentForm parentform)
        {
            this.InitializeComponent();
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int width = bounds.Width;
            bounds = Screen.PrimaryScreen.Bounds;
            base.Size = new Size(width, bounds.Height);
            this.AutoScroll = false;
            this.m_ParentForm = parentform;
        }

        private void AddSmartGridColumn(string DataMember, string HeaderText, string Name, int Width, Resco.Controls.SmartGrid.Alignment Alignment, Resco.Controls.SmartGrid.SmartGrid SmartGrid)
        {
            try
            {
                Column column = new Column();
                column.set_Alignment(Alignment);
                column.set_DataMember(DataMember);
                column.set_HeaderText(HeaderText);
                column.set_Name(Name);
                column.set_Width(Width);
                SmartGrid.get_Columns().Add(column);
            }
            catch (Exception exception)
            {
                throw exception;
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

        private void frmItems_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.SetItemList();
                    this.tbiSelect.set_Visible(this.m_ParentForm != frmItems.ParentForm.Home);
                    this.tbiSelect.set_Enabled(false);
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
            this.pnlSearch = new UIElementPanelControl();
            this.txtSearch = new UITextBox();
            this.btnFilter = new UITextBoxButton();
            this.rbtnCode = new UIRadioButton();
            this.rbtnName = new UIRadioButton();
            this.chkExact = new UICheckBox();
            this.sgItem = new SmartGrid();
            this.tbcMenu = new ToolbarControl();
            this.tbiBack = new ToolbarItem();
            this.tbiSelect = new ToolbarItem();
            this.tbiNext = new ToolbarItem();
            this.pnlSearch.SuspendElementLayout();
            base.SuspendLayout();
            this.pnlSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this.pnlSearch.BackColor = Color.FromArgb(213, 231, 255);
            this.pnlSearch.get_Children().Add(this.txtSearch);
            this.pnlSearch.get_Children().Add(this.rbtnCode);
            this.pnlSearch.get_Children().Add(this.rbtnName);
            this.pnlSearch.get_Children().Add(this.chkExact);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new Size(318, 64);
            this.pnlSearch.TabIndex = 6;
            this.txtSearch.get_Buttons().Add(this.btnFilter);
            this.txtSearch.set_Layout(new ElementLayout(3, 0, 4, 34, 6, 0, 308, 26));
            this.txtSearch.set_Name("txtSearch");
            this.txtSearch.set_TabIndex(4);
            this.txtSearch.add_KeyPress(new KeyPressEventHandler(this.txtSearch_KeyPress));
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
            this.rbtnCode.set_TabIndex(1);
            this.rbtnCode.set_Text("Code");
            this.rbtnName.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.rbtnName.set_Layout(new ElementLayout(0, 0, 68, 5, 0, 0, 60, 28));
            this.rbtnName.set_Name("rbtnName");
            this.rbtnName.set_TabIndex(2);
            this.rbtnName.set_Text("Name");
            this.chkExact.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.chkExact.set_Layout(new ElementLayout(0, 0, 135, 5, 0, 0, 59, 29));
            this.chkExact.set_Name("chkExact");
            this.chkExact.set_TabIndex(3);
            this.chkExact.set_Text("Exact");
            this.sgItem.set_AlternatingBackColor(Color.FromArgb(213, 231, 255));
            this.sgItem.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this.sgItem.set_BackgroundColor(Color.FromArgb(213, 231, 255));
            this.sgItem.set_BorderStyle(BorderStyle.Fixed3D);
            this.sgItem.set_ColumnHeaderHeight(40);
            this.sgItem.set_HeaderBackColor(Color.RoyalBlue);
            this.sgItem.set_HeaderFont(new Font("Tahoma", 9f, FontStyle.Bold));
            this.sgItem.set_HeaderForeColor(Color.White);
            this.sgItem.set_HeaderVistaStyle(true);
            this.sgItem.Location = new Point(3, 67);
            this.sgItem.Name = "sgItem";
            this.sgItem.set_RowHeight(20);
            this.sgItem.set_ScrollBars(ScrollBars.None);
            this.sgItem.Size = new Size(312, 171);
            this.sgItem.TabIndex = 5;
            this.sgItem.set_TouchScrolling(true);
            this.sgItem.add_SelectionChanged(new EventHandler(this.sgItem_SelectionChanged));
            this.tbcMenu.set_ArrowsTransparency(0);
            this.tbcMenu.BackColor = Color.Black;
            this.tbcMenu.set_BmpArrowNext(imgManager.GetImage("iNTrack.Arrow Right2"));
            this.tbcMenu.set_BmpArrowPrevious(imgManager.GetImage("iNTrack.Arrow Left2"));
            this.tbcMenu.Dock = DockStyle.Bottom;
            this.tbcMenu.set_EnableArrowsTransparency(false);
            this.tbcMenu.get_Items().Add(this.tbiBack);
            this.tbcMenu.get_Items().Add(this.tbiSelect);
            this.tbcMenu.get_Items().Add(this.tbiNext);
            this.tbcMenu.set_ItemsAlignment(4);
            this.tbcMenu.set_ItemSpacing(6);
            this.tbcMenu.Location = new Point(0, 244);
            this.tbcMenu.set_MarginAtBegin(40);
            this.tbcMenu.set_MarginAtEnd(40);
            this.tbcMenu.Name = "tbcMenu";
            this.tbcMenu.Size = new Size(318, 50);
            this.tbcMenu.TabIndex = 5;
            this.tbcMenu.add_SelectionChanged(new EventHandler(this.tbcMenu_SelectionChanged));
            this.tbiBack.set_BackColor(Color.Black);
            this.tbiBack.set_CustomSize(new Size(0, 0));
            this.tbiBack.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Left"));
            this.tbiBack.set_Name("tbiBack");
            this.tbiBack.set_ToolbarItemBehavior(2);
            this.tbiSelect.set_BackColor(Color.Black);
            this.tbiSelect.set_CustomSize(new Size(0, 0));
            this.tbiSelect.set_ImageDefault(imgManager.GetImage("iNTrack.Ok"));
            this.tbiSelect.set_Name("tbiSelect");
            this.tbiSelect.set_ToolbarItemBehavior(2);
            this.tbiNext.set_BackColor(Color.Black);
            this.tbiNext.set_CustomSize(new Size(0, 0));
            this.tbiNext.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Right"));
            this.tbiNext.set_Name("tbiNext");
            this.tbiNext.set_ToolbarItemBehavior(2);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = Color.FromArgb(213, 231, 255);
            base.ClientSize = new Size(318, 294);
            base.ControlBox = false;
            base.Controls.Add(this.sgItem);
            base.Controls.Add(this.pnlSearch);
            base.Controls.Add(this.tbcMenu);
            base.MinimizeBox = false;
            base.Name = "frmItems";
            this.Text = ":: Item Card";
            base.Load += new EventHandler(this.frmItems_Load);
            this.pnlSearch.ResumeElementLayout(false);
            base.ResumeLayout(false);
        }

        private void SetItemList()
        {
            try
            {
                this.AddSmartGridColumn("Itemcode", "Itemcode", "colItemcode", 100, 0, this.sgItem);
                this.AddSmartGridColumn("Description", "Desc", "colDescription", 120, 0, this.sgItem);
                this.AddSmartGridColumn("Barcode", "Barcode", "colBarcode", 100, 0, this.sgItem);
                this.AddSmartGridColumn("UOM", "UOM", "colUOM", 100, 0, this.sgItem);
                this.AddSmartGridColumn("Vendor Code", "Vendor Code", "colVendorCode", 100, 0, this.sgItem);
                this.AddSmartGridColumn("Vendor Name", "Vendor Name", "colVendorName", 100, 0, this.sgItem);
                this.AddSmartGridColumn("Sales Price", "Sales Price", "colSalesPrice", 0, 0, this.sgItem);
                if ((Property.ShowCostPrice ? true : Property.Module == Property.ModuleEnum.Purchase))
                {
                    this.AddSmartGridColumn("Unit Price", "Cost Price", "colCostPrice", 116, 0, this.sgItem);
                }
                this.m_dtItem = new DataTable();
                this.m_dtItem.Columns.Add("Itemcode");
                this.m_dtItem.Columns.Add("Description");
                this.m_dtItem.Columns.Add("Barcode");
                this.m_dtItem.Columns.Add("UOM");
                this.m_dtItem.Columns.Add("Vendor Code");
                this.m_dtItem.Columns.Add("Vendor Name");
                this.m_dtItem.Columns.Add("Sales Price", typeof(double));
                this.m_dtItem.Columns.Add("Unit Price", typeof(double));
                this.sgItem.set_DataSource(this.m_dtItem);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void sgItem_SelectionChanged(object sender, EventArgs e)
        {
            this.tbiSelect.set_Enabled(this.sgItem.get_SelectedCell().RowIndex > -1);
            this.tbiNext.set_Enabled(this.sgItem.get_SelectedCell().RowIndex > -1);
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
                                switch (this.m_ParentForm)
                                {
                                    case frmItems.ParentForm.Adjustment:
                                    case frmItems.ParentForm.StockCount:
                                    case frmItems.ParentForm.Transaction:
                                        {
                                            base.DialogResult = DialogResult.Cancel;
                                            break;
                                        }
                                    case frmItems.ParentForm.Home:
                                        {
                                            CommonLib.SwitchForm(new frmHome());
                                            break;
                                        }
                                }
                                break;
                            }
                        case 1:
                            {
                                this.Barcode = ((DataRowView)this.sgItem.get_Rows().get_Item(this.sgItem.get_SelectedCell().RowIndex).get_Data()).Row["Barcode"].ToString();
                                base.DialogResult = DialogResult.OK;
                                break;
                            }
                        case 2:
                            {
                                DataRowView data = (DataRowView)this.sgItem.get_Rows().get_Item(this.sgItem.get_SelectedCell().RowIndex).get_Data();
                                frmItem _frmItem = new frmItem(data.Row["Itemcode"].ToString(), data.Row["Barcode"].ToString(), data.Row["Description"].ToString(), data.Row["UOM"].ToString(), (double)data.Row["Sales Price"], 0);
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
            }
        }

        private void txtSearch_GotFocus(object sender, EventArgs e)
        {
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataTable item;
            string[] str;
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (e.KeyChar == '\r')
                    {
                        if (!string.IsNullOrEmpty(this.txtSearch.get_Text().Trim()))
                        {
                            Service service = new Service();
                            try
                            {
                                service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                if (!this.rbtnCode.get_Checked())
                                {
                                    Service service1 = service;
                                    str = new string[] { "HHT_Barcodes_3002", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), string.Empty, null };
                                    str[4] = (this.chkExact.get_Checked() ? CommonLib.FormatString(this.txtSearch.get_Text()) : string.Concat("%", CommonLib.FormatString(this.txtSearch.get_Text()), "%"));
                                    item = service1.GetData(str).Tables[0];
                                }
                                else
                                {
                                    Service service2 = service;
                                    str = new string[] { "HHT_Barcodes_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), string.Empty, null, null };
                                    str[4] = (this.chkExact.get_Checked() ? CommonLib.FormatString(this.txtSearch.get_Text()) : string.Concat("%", CommonLib.FormatString(this.txtSearch.get_Text()), "%"));
                                    str[5] = string.Empty;
                                    item = service2.GetData(str).Tables[0];
                                }
                            }
                            finally
                            {
                                if (service != null)
                                {
                                    ((IDisposable)service).Dispose();
                                }
                            }
                            this.m_dtItem.Rows.Clear();
                            this.m_dtItem.Merge(item, true, MissingSchemaAction.Ignore);
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

        private void txtSearch_LostFocus(object sender, EventArgs e)
        {
        }

        public enum ParentForm
        {
            Adjustment,
            Home,
            StockCount,
            Transaction
        }
    }
}