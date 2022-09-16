using iNTrack.iNTrackService;
using Microsoft.VisualBasic;
using Resco.Controls.AdvancedList;
using Resco.Controls.CommonControls;
using Resco.Controls.MessageBox;
using Resco.UIElements;
using Resco.UIElements.Controls;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Resources;
using System.Web.Services.Protocols;
using System.Windows.Forms;

namespace iNTrack
{
    public class frmTransLines : Form
    {
        private frmTransLines.SourceEnum m_SourceEnum;

        private DataTable m_dtData = null;

        private IContainer components = null;

        private ToolbarControl tbcMenu;

        private ToolbarItem tbiBack;

        private ToolbarItem tbiDelete;

        private AdvancedList lstEntry;

        private RowTemplate tempRow;

        private TextCell celltxtItemNo;

        private TextCell celltxtBarcode;

        private TextCell celltxtDesc;

        private TextCell celltxtUOM;

        private TextCell celltxtQuantity;

        private TextCell celltxtLineNo;

        private RowTemplate tempRowSelect;

        private TextCell celltxtItemNoSelect;

        private TextCell celltxtBarcodeSelect;

        private TextCell celltxtDescSelect;

        private TextCell celltxtUOMSelect;

        private TextCell celltxtQuantitySelect;

        private TextCell celltxtLineNoSelect;

        private UIElementPanelControl pnlSearch;

        private UITextBox txtBarcode;

        private UITextBoxButton btnFilter;

        private UILabel lblBarcode;

        public frmTransLines(frmTransLines.SourceEnum Source)
        {
            this.InitializeComponent();
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int width = bounds.Width;
            bounds = Screen.PrimaryScreen.Bounds;
            base.Size = new Size(width, bounds.Height);
            this.AutoScroll = false;
            this.m_dtData = new DataTable();
            this.m_dtData.Columns.Add("Itemcode");
            this.m_dtData.Columns.Add("Barcode");
            this.m_dtData.Columns.Add("Description");
            this.m_dtData.Columns.Add("UOM");
            this.m_dtData.Columns.Add("Quantity", typeof(double));
            this.m_dtData.Columns.Add("Line No.", typeof(int));
            this.m_SourceEnum = Source;
            switch (this.m_SourceEnum)
            {
                case frmTransLines.SourceEnum.DocumentLine:
                    {
                        this.tbiDelete.set_Visible(false);
                        break;
                    }
                case frmTransLines.SourceEnum.TransactionLine:
                    {
                        this.tbiDelete.set_Visible(true);
                        break;
                    }
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

        private void frmTransLines_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    switch (this.m_SourceEnum)
                    {
                        case frmTransLines.SourceEnum.DocumentLine:
                            {
                                this.Text = ":: Document Lines";
                                this.m_dtData.Merge(Property.DocLine, true, MissingSchemaAction.Ignore);
                                break;
                            }
                        case frmTransLines.SourceEnum.TransactionLine:
                            {
                                switch (Property.TransactionType)
                                {
                                    case Property.TransactionTypeEnum.SPC:
                                        {
                                            this.Text = ":: Shelf Price Check Lines";
                                            goto case Property.TransactionTypeEnum.SC;
                                        }
                                    case Property.TransactionTypeEnum.PRQ:
                                        {
                                            this.Text = ":: Purch. Req. Lines";
                                            goto case Property.TransactionTypeEnum.SC;
                                        }
                                    case Property.TransactionTypeEnum.PO:
                                        {
                                            this.Text = ":: Purch. Order Lines";
                                            goto case Property.TransactionTypeEnum.SC;
                                        }
                                    case Property.TransactionTypeEnum.PI:
                                        {
                                            this.Text = ":: Purch. Receipt Note Lines";
                                            goto case Property.TransactionTypeEnum.SC;
                                        }
                                    case Property.TransactionTypeEnum.PR:
                                    case Property.TransactionTypeEnum.PRS:
                                        {
                                            this.Text = ":: Purch. Return Lines";
                                            goto case Property.TransactionTypeEnum.SC;
                                        }
                                    case Property.TransactionTypeEnum.SO:
                                    case Property.TransactionTypeEnum.SI:
                                        {
                                            this.Text = ":: Sales Order Lines";
                                            goto case Property.TransactionTypeEnum.SC;
                                        }
                                    case Property.TransactionTypeEnum.SR:
                                    case Property.TransactionTypeEnum.SRR:
                                        {
                                            this.Text = ":: Sales Return Lines";
                                            goto case Property.TransactionTypeEnum.SC;
                                        }
                                    case Property.TransactionTypeEnum.TRQ:
                                        {
                                            this.Text = ":: Transfer Req. Lines";
                                            goto case Property.TransactionTypeEnum.SC;
                                        }
                                    case Property.TransactionTypeEnum.TRO:
                                    case Property.TransactionTypeEnum.TRS:
                                        {
                                            this.Text = ":: Transfer Out Lines";
                                            goto case Property.TransactionTypeEnum.SC;
                                        }
                                    case Property.TransactionTypeEnum.TRI:
                                        {
                                            this.Text = ":: Transfer In Lines";
                                            goto case Property.TransactionTypeEnum.SC;
                                        }
                                    case Property.TransactionTypeEnum.ADJ:
                                        {
                                            this.Text = ":: Stock Wastage Lines";
                                            goto case Property.TransactionTypeEnum.SC;
                                        }
                                    case Property.TransactionTypeEnum.SHRINK:
                                        {
                                            this.Text = ":: Stock Shrink. Lines";
                                            goto case Property.TransactionTypeEnum.SC;
                                        }
                                    case Property.TransactionTypeEnum.MISC:
                                        {
                                            this.Text = ":: Stock Misc. Lines";
                                            goto case Property.TransactionTypeEnum.SC;
                                        }
                                    case Property.TransactionTypeEnum.SC:
                                        {
                                            this.m_dtData.Merge(Property.TransLine, true, MissingSchemaAction.Ignore);
                                            break;
                                        }
                                    case Property.TransactionTypeEnum.PLC:
                                        {
                                            this.Text = ":: Product Label Count Lines";
                                            goto case Property.TransactionTypeEnum.SC;
                                        }
                                    case Property.TransactionTypeEnum.SLC:
                                        {
                                            this.Text = ":: Shelf Label Count Lines";
                                            goto case Property.TransactionTypeEnum.SC;
                                        }
                                    default:
                                        {
                                            goto case Property.TransactionTypeEnum.SC;
                                        }
                                }
                                break;
                            }
                    }
                    this.lstEntry.get_DataRows().Clear();
                    this.lstEntry.set_DataSource(this.m_dtData.DefaultView);
                    this.tbiDelete.set_Enabled(false);
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmTransLines));
            this.tbcMenu = new ToolbarControl();
            this.tbiBack = new ToolbarItem();
            this.tbiDelete = new ToolbarItem();
            this.lstEntry = new AdvancedList();
            this.tempRow = new RowTemplate();
            this.celltxtItemNo = new TextCell();
            this.celltxtBarcode = new TextCell();
            this.celltxtDesc = new TextCell();
            this.celltxtUOM = new TextCell();
            this.celltxtQuantity = new TextCell();
            this.celltxtLineNo = new TextCell();
            this.tempRowSelect = new RowTemplate();
            this.celltxtItemNoSelect = new TextCell();
            this.celltxtBarcodeSelect = new TextCell();
            this.celltxtDescSelect = new TextCell();
            this.celltxtUOMSelect = new TextCell();
            this.celltxtQuantitySelect = new TextCell();
            this.celltxtLineNoSelect = new TextCell();
            this.pnlSearch = new UIElementPanelControl();
            this.txtBarcode = new UITextBox();
            this.btnFilter = new UITextBoxButton();
            this.lblBarcode = new UILabel();
            this.pnlSearch.SuspendElementLayout();
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
            this.tbcMenu.get_Items().Add(this.tbiDelete);
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
            this.tbiDelete.set_BackColor(Color.Black);
            this.tbiDelete.set_CustomSize(new Size(0, 0));
            this.tbiDelete.set_ImageDefault(imgManager.GetImage("iNTrack.Trash"));
            this.tbiDelete.set_Name("tbiDelete");
            this.tbiDelete.set_ToolbarItemBehavior(2);
            this.lstEntry.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this.lstEntry.set_AutoSelectRow(false);
            this.lstEntry.set_BackColor(Color.FromArgb(213, 231, 255));
            this.lstEntry.BorderStyle = BorderStyle.FixedSingle;
            this.lstEntry.get_DataRows().Clear();
            RowCollection dataRows = this.lstEntry.get_DataRows();
            string[] str = new string[] { componentResourceManager.GetString("lstEntry.DataRows"), componentResourceManager.GetString("lstEntry.DataRows1"), componentResourceManager.GetString("lstEntry.DataRows2"), componentResourceManager.GetString("lstEntry.DataRows3"), componentResourceManager.GetString("lstEntry.DataRows4") };
            dataRows.Add(new Row(0, 0, -1, -1, str));
            this.lstEntry.set_FocusOnClick(true);
            this.lstEntry.Location = new Point(0, 55);
            this.lstEntry.Name = "lstEntry";
            this.lstEntry.set_ScrollbarSmallChange(32);
            this.lstEntry.set_ScrollbarWidth(26);
            this.lstEntry.set_SelectedTemplateIndex(1);
            this.lstEntry.set_ShowScrollbar(false);
            this.lstEntry.Size = new Size(318, 182);
            this.lstEntry.TabIndex = 8;
            this.lstEntry.get_Templates().Add(this.tempRow);
            this.lstEntry.get_Templates().Add(this.tempRowSelect);
            this.lstEntry.set_TouchScrolling(true);
            this.lstEntry.add_CustomizeCell(new CustomizeCellEventHandler(this, frmTransLines.lstEntry_CustomizeCell));
            this.lstEntry.add_RowEntered(new RowEnteredEventHandler(this, frmTransLines.lstEntry_RowEntered));
            this.tempRow.set_BackColor(Color.FromArgb(213, 231, 255));
            this.tempRow.get_CellTemplates().Add(this.celltxtItemNo);
            this.tempRow.get_CellTemplates().Add(this.celltxtBarcode);
            this.tempRow.get_CellTemplates().Add(this.celltxtDesc);
            this.tempRow.get_CellTemplates().Add(this.celltxtUOM);
            this.tempRow.get_CellTemplates().Add(this.celltxtQuantity);
            this.tempRow.get_CellTemplates().Add(this.celltxtLineNo);
            this.tempRow.set_Height(50);
            this.tempRow.set_Name("tempRow");
            this.celltxtItemNo.set_Alignment(2);
            this.celltxtItemNo.get_CellSource().set_ColumnIndex(0);
            this.celltxtItemNo.set_DesignName("celltxtItemNo");
            this.celltxtItemNo.set_Location(new Point(2, 0));
            this.celltxtItemNo.set_Size(new Size(118, 15));
            this.celltxtItemNo.set_TextFont(new Font("Tahoma", 8f, FontStyle.Bold));
            this.celltxtBarcode.set_Alignment(2);
            this.celltxtBarcode.get_CellSource().set_ColumnIndex(1);
            this.celltxtBarcode.set_DesignName("celltxtBarcode");
            this.celltxtBarcode.set_Location(new Point(120, 0));
            this.celltxtBarcode.set_Size(new Size(200, 15));
            this.celltxtBarcode.set_TextFont(new Font("Tahoma", 8f, FontStyle.Bold));
            this.celltxtDesc.get_CellSource().set_ColumnIndex(2);
            this.celltxtDesc.set_DesignName("celltxtDesc");
            this.celltxtDesc.set_Location(new Point(2, 15));
            this.celltxtDesc.set_Size(new Size(318, 15));
            this.celltxtUOM.get_CellSource().set_ColumnIndex(3);
            this.celltxtUOM.set_DesignName("celltxtUOM");
            this.celltxtUOM.set_Location(new Point(2, 30));
            this.celltxtUOM.set_Size(new Size(118, 15));
            this.celltxtQuantity.get_CellSource().set_ColumnIndex(4);
            this.celltxtQuantity.set_DesignName("celltxtQuantity");
            this.celltxtQuantity.set_Location(new Point(120, 30));
            this.celltxtQuantity.set_Size(new Size(200, 15));
            this.celltxtLineNo.get_CellSource().set_ColumnIndex(5);
            this.celltxtLineNo.set_DesignName("celltxtLineNo");
            this.celltxtLineNo.set_Location(new Point(320, 30));
            this.celltxtLineNo.set_Size(new Size(-1, 20));
            this.celltxtLineNo.set_Visible(false);
            this.tempRowSelect.set_BackColor(SystemColors.Info);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtItemNoSelect);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtBarcodeSelect);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtDescSelect);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtUOMSelect);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtQuantitySelect);
            this.tempRowSelect.get_CellTemplates().Add(this.celltxtLineNoSelect);
            this.tempRowSelect.set_Height(50);
            this.tempRowSelect.set_Name("tempRowSelect");
            this.celltxtItemNoSelect.set_Alignment(2);
            this.celltxtItemNoSelect.get_CellSource().set_ColumnIndex(0);
            this.celltxtItemNoSelect.set_DesignName("celltxtItemNoSelect");
            this.celltxtItemNoSelect.set_Location(new Point(2, 0));
            this.celltxtItemNoSelect.set_Size(new Size(118, 15));
            this.celltxtItemNoSelect.set_TextFont(new Font("Tahoma", 8f, FontStyle.Bold));
            this.celltxtBarcodeSelect.set_Alignment(2);
            this.celltxtBarcodeSelect.get_CellSource().set_ColumnIndex(1);
            this.celltxtBarcodeSelect.set_DesignName("celltxtBarcodeSelect");
            this.celltxtBarcodeSelect.set_Location(new Point(120, 0));
            this.celltxtBarcodeSelect.set_Size(new Size(200, 15));
            this.celltxtBarcodeSelect.set_TextFont(new Font("Tahoma", 8f, FontStyle.Bold));
            this.celltxtDescSelect.set_Alignment(2);
            this.celltxtDescSelect.get_CellSource().set_ColumnIndex(2);
            this.celltxtDescSelect.set_DesignName("celltxtDescSelect");
            this.celltxtDescSelect.set_Location(new Point(2, 15));
            this.celltxtDescSelect.set_Size(new Size(318, 15));
            this.celltxtUOMSelect.set_Alignment(2);
            this.celltxtUOMSelect.get_CellSource().set_ColumnIndex(3);
            this.celltxtUOMSelect.set_DesignName("celltxtUOMSelect");
            this.celltxtUOMSelect.set_Location(new Point(2, 30));
            this.celltxtUOMSelect.set_Size(new Size(118, 15));
            this.celltxtQuantitySelect.set_Alignment(2);
            this.celltxtQuantitySelect.get_CellSource().set_ColumnIndex(4);
            this.celltxtQuantitySelect.set_DesignName("celltxtQuantitySelect");
            this.celltxtQuantitySelect.set_Location(new Point(120, 30));
            this.celltxtQuantitySelect.set_Size(new Size(200, 15));
            this.celltxtLineNoSelect.set_Alignment(2);
            this.celltxtLineNoSelect.get_CellSource().set_ColumnIndex(5);
            this.celltxtLineNoSelect.set_DesignName("celltxtLineNoSelect");
            this.celltxtLineNoSelect.set_Location(new Point(320, 30));
            this.celltxtLineNoSelect.set_Size(new Size(-1, 20));
            this.celltxtLineNoSelect.set_Visible(false);
            this.pnlSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this.pnlSearch.BackColor = Color.FromArgb(213, 231, 255);
            this.pnlSearch.get_Children().Add(this.txtBarcode);
            this.pnlSearch.get_Children().Add(this.lblBarcode);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new Size(318, 54);
            this.pnlSearch.TabIndex = 9;
            this.txtBarcode.get_Buttons().Add(this.btnFilter);
            this.txtBarcode.set_Layout(new ElementLayout(3, 0, 5, 22, 5, 0, 308, 26));
            this.txtBarcode.set_Name("txtBarcode");
            this.txtBarcode.set_TabIndex(1);
            this.txtBarcode.add_TextChanged(new EventHandler(this.txtBarcode_TextChanged));
            this.btnFilter.set_Action(1);
            this.btnFilter.set_BackColor(Color.Transparent);
            this.btnFilter.set_BorderThickness(0);
            this.btnFilter.set_HorizontalAlignment(2);
            this.btnFilter.set_Name("btnFilter");
            this.btnFilter.get_PressedBackground().set_BackColor(Color.Transparent);
            this.btnFilter.set_Size(new Size(18, 18));
            this.btnFilter.set_StateIcon(2);
            this.btnFilter.set_VisibleMode(1);
            this.lblBarcode.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblBarcode.set_Layout(new ElementLayout(0, 0, 5, 5, 0, 0, 44, 13));
            this.lblBarcode.set_Name("lblBarcode");
            this.lblBarcode.set_TabIndex(7);
            this.lblBarcode.set_Text("Barcode");
            this.lblBarcode.set_TextAlignment(2);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = Color.FromArgb(213, 231, 255);
            base.ClientSize = new Size(318, 294);
            base.ControlBox = false;
            base.Controls.Add(this.pnlSearch);
            base.Controls.Add(this.lstEntry);
            base.Controls.Add(this.tbcMenu);
            base.MinimizeBox = false;
            base.Name = "frmTransLines";
            this.Text = ":: Transaction Lines";
            base.Load += new EventHandler(this.frmTransLines_Load);
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

        private void lstEntry_RowEntered(object sender, RowEnteredEventArgs e)
        {
            this.tbiDelete.set_Enabled(true);
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
                                base.DialogResult = DialogResult.Cancel;
                                break;
                            }
                        case 1:
                            {
                                if (this.lstEntry.get_ActiveRowIndex() != -1)
                                {
                                    DataRow dataRow = Property.TransLine.Select(string.Format("[Line No.] = {0}", this.lstEntry.get_SelectedRow().get_Item("Line No.").ToString()))[0];
                                    if (MessageBoxEx.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        Cursor.Current = Cursors.WaitCursor;
                                        Service service = new Service();
                                        try
                                        {
                                            service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                            if (Property.TransactionType != Property.TransactionTypeEnum.SC)
                                            {
                                                if (Property.OperationMode != Property.OperationModeEnum.Online)
                                                {
                                                    SqlCeLib.Execute(string.Format("Delete From [HHT Transactions] Where [Transaction Type] = '{0}' And [Transaction No.] = '{1}' And [Line No.] = {2}", Property.TransactionType.ToString(), Property.TransactionNo, dataRow["Line No."]), SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                                                }
                                                else
                                                {
                                                    string[] str = new string[] { "HHT_Transactions_2002", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), Property.TransactionType.ToString(), Property.TransactionNo, Property.UserCode, string.Empty, dataRow["Line No."].ToString() };
                                                    service.SetData(str, new DataSet());
                                                }
                                                dataRow.Delete();
                                                Property.TransLine.AcceptChanges();
                                            }
                                            else
                                            {
                                                double num = Convert.ToDouble(dataRow["Quantity"]);
                                                if (Conversion.Val(Convert.ToString(Property.TransLine.Compute("Sum(Quantity)", string.Format("Barcode = '{0}' And (Quantity = {1} Or Quantity = {2})", dataRow["Barcode"], num, num * -1)))) == 0)
                                                {
                                                    throw new Exception("Line has already been deleted");
                                                }
                                                if (Property.OperationMode == Property.OperationModeEnum.Online)
                                                {
                                                    iNTrackLib.InsertStockCount(dataRow["Bin Code"].ToString(), dataRow["Itemcode"].ToString(), dataRow["Barcode"].ToString(), dataRow["Description"].ToString(), dataRow["UOM"].ToString(), (int)dataRow["Valid Item"], num * -1, 0, 0);
                                                }
                                            }
                                            if (Property.TransLine.Rows.Count != 0)
                                            {
                                                this.m_dtData.Rows.Clear();
                                                this.m_dtData.Merge(Property.TransLine, true, MissingSchemaAction.Ignore);
                                            }
                                            else
                                            {
                                                base.DialogResult = DialogResult.Cancel;
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
                                    break;
                                }
                                else
                                {
                                    return;
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
                this.tbcMenu.set_SelectedIndex(-1);
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.celltxtBarcode.set_SelectedText(this.txtBarcode.get_Text());
                    this.celltxtBarcodeSelect.set_SelectedText(this.txtBarcode.get_Text());
                    if (!string.IsNullOrEmpty(this.txtBarcode.get_Text().Trim()))
                    {
                        ((DataView)this.lstEntry.get_DataSource()).RowFilter = string.Format("[Barcode] Like '*{0}*'", this.txtBarcode.get_Text());
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
            DocumentLine,
            TransactionLine
        }
    }
}