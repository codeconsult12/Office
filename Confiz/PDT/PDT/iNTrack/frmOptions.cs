using Microsoft.WindowsCE.Forms;
using Resco.Controls.AdvancedList;
using Resco.Controls.CommonControls;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace iNTrack
{
    public class frmOptions : Form
    {
        private IContainer components = null;

        private AdvancedList lstEntry;

        private RowTemplate tempRow;

        private TextCell cellOption;

        private TextCell cellCaption;

        private Cell cellSep;

        private TextCell cellType;

        private ToolbarControl tbcMenu;

        private ToolbarItem tbiBack;

        private ToolbarItem tbiNext;

        private InputPanel inputPanel1;

        public frmOptions()
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

        private void frmOptions_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.SetModuleOptions();
                    this.SetGranules();
                    this.tbiNext.set_Enabled(false);
                    Property.TransactionType = Property.TransactionTypeEnum.None;
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
            this.lstEntry = new AdvancedList();
            this.tempRow = new RowTemplate();
            this.cellOption = new TextCell();
            this.cellCaption = new TextCell();
            this.cellType = new TextCell();
            this.cellSep = new Cell();
            this.tbcMenu = new ToolbarControl();
            this.tbiBack = new ToolbarItem();
            this.tbiNext = new ToolbarItem();
            this.inputPanel1 = new InputPanel();
            base.SuspendLayout();
            this.lstEntry.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this.lstEntry.set_BackColor(Color.FromArgb(213, 231, 255));
            this.lstEntry.get_DataRows().Clear();
            this.lstEntry.set_GridLines(false);
            this.lstEntry.Location = new Point(0, 0);
            this.lstEntry.Name = "lstEntry";
            this.lstEntry.set_ScrollbarSmallChange(32);
            this.lstEntry.set_ScrollbarWidth(26);
            this.lstEntry.set_ShowScrollbar(false);
            this.lstEntry.Size = new Size(318, 243);
            this.lstEntry.TabIndex = 0;
            this.lstEntry.get_Templates().Add(this.tempRow);
            this.lstEntry.set_TouchScrolling(true);
            this.lstEntry.add_CustomizeCell(new CustomizeCellEventHandler(this, frmOptions.lstEntry_CustomizeCell));
            this.lstEntry.add_CellClick(new CellEventHandler(this, frmOptions.lstEntry_CellClick));
            this.lstEntry.add_RowEntered(new RowEnteredEventHandler(this, frmOptions.lstEntry_RowEntered));
            this.tempRow.set_BackColor(Color.FromArgb(213, 231, 255));
            this.tempRow.get_CellTemplates().Add(this.cellOption);
            this.tempRow.get_CellTemplates().Add(this.cellCaption);
            this.tempRow.get_CellTemplates().Add(this.cellType);
            this.tempRow.get_CellTemplates().Add(this.cellSep);
            this.tempRow.set_Height(72);
            this.tempRow.set_Name("tempRow");
            this.cellOption.set_Alignment(2);
            this.cellOption.get_CellSource().set_ColumnIndex(0);
            this.cellOption.set_DesignName("cellOption");
            this.cellOption.set_Location(new Point(5, 0));
            this.cellOption.set_Size(new Size(360, 36));
            this.cellOption.set_TextFont(new Font("Tahoma", 10f, FontStyle.Bold));
            this.cellCaption.get_CellSource().set_ColumnIndex(1);
            this.cellCaption.set_DesignName("cellCaption");
            this.cellCaption.set_ForeColor(Color.DimGray);
            this.cellCaption.set_Location(new Point(5, 36));
            this.cellCaption.set_Size(new Size(360, 38));
            this.cellType.get_CellSource().set_ColumnIndex(2);
            this.cellType.set_DesignName("cellType");
            this.cellType.set_ForeColor(Color.DimGray);
            this.cellType.set_Location(new Point(0, 72));
            this.cellType.set_Size(new Size(-1, 1));
            this.cellType.set_Visible(false);
            this.cellSep.set_BackColor(Color.FromArgb(141, 186, 251));
            this.cellSep.set_CustomizeCell(true);
            this.cellSep.set_DesignName("cellSep");
            this.cellSep.set_Location(new Point(0, 71));
            this.cellSep.set_Size(new Size(-1, 1));
            this.tbcMenu.set_ArrowsTransparency(0);
            this.tbcMenu.BackColor = Color.Black;
            this.tbcMenu.set_BmpArrowNext(imgManager.GetImage("iNTrack.Arrow Right2"));
            this.tbcMenu.set_BmpArrowPrevious(imgManager.GetImage("iNTrack.Arrow Left2"));
            this.tbcMenu.BorderStyle = BorderStyle.FixedSingle;
            this.tbcMenu.Dock = DockStyle.Bottom;
            this.tbcMenu.set_EnableArrowsTransparency(false);
            this.tbcMenu.ForeColor = Color.Black;
            this.tbcMenu.get_Items().Add(this.tbiBack);
            this.tbcMenu.get_Items().Add(this.tbiNext);
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
            this.tbiNext.set_BackColor(Color.Black);
            this.tbiNext.set_CustomSize(new Size(0, 0));
            this.tbiNext.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Right"));
            this.tbiNext.set_Name("tbiNext");
            this.tbiNext.set_ToolbarItemBehavior(2);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(318, 294);
            base.ControlBox = false;
            base.Controls.Add(this.tbcMenu);
            base.Controls.Add(this.lstEntry);
            base.Name = "frmOptions";
            this.Text = ":: Options";
            base.Load += new EventHandler(this.frmOptions_Load);
            base.ResumeLayout(false);
        }

        private void lstEntry_CellClick(object sender, CellEventArgs e)
        {
            try
            {
                this.tbcMenu.set_SelectedIndex(1);
            }
            catch (Exception exception)
            {
                CommonLib.DisplayErrorMessage(exception);
            }
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
            try
            {
                this.tbiNext.set_Enabled(true);
            }
            catch (Exception exception)
            {
                CommonLib.DisplayErrorMessage(exception);
            }
        }

        private void SetGranules()
        {
            try
            {
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void SetModuleOptions()
        {
            string[] strArrays;
            try
            {
                this.lstEntry.get_DataRows().Clear();
                switch (Property.Module)
                {
                    case Property.ModuleEnum.Count:
                        {
                            this.Text = ":: Count Options";
                            RowCollection dataRows = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Stock Count", "Perform stock count", "SC" };
                            dataRows.Add(new Row(0, 0, -1, -1, "Stock Count", strArrays));
                            RowCollection rowCollection = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Shelf Price Check", "Perform shelf price check", "SPC" };
                            rowCollection.Add(new Row(0, 0, -1, -1, "Shelf Price Check", strArrays));
                            RowCollection dataRows1 = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Product Label Count", "Count product label to print", "PLC" };
                            dataRows1.Add(new Row(0, 0, -1, -1, "Product Label Count", strArrays));
                            RowCollection rowCollection1 = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Shelf Label Count", "Count shelf label to print", "SLC" };
                            rowCollection1.Add(new Row(0, 0, -1, -1, "Shelf Label Count", strArrays));
                            break;
                        }
                    case Property.ModuleEnum.Print:
                        {
                            this.Text = ":: Print Options";
                            RowCollection dataRows2 = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Product Label Print", "Print product label", "PLP" };
                            dataRows2.Add(new Row(0, 0, -1, -1, "Product Label Print", strArrays));
                            RowCollection rowCollection2 = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Shelf Label Print", "Print shelf label", "SLP" };
                            rowCollection2.Add(new Row(0, 0, -1, -1, "Shelf Label Print", strArrays));
                            break;
                        }
                    case Property.ModuleEnum.Purchase:
                        {
                            this.Text = ":: Purchase Options";
                            RowCollection dataRows3 = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Purchase Requisition", "Create purchase requisition", "PRQ" };
                            dataRows3.Add(new Row(0, 0, -1, -1, "Purchase Requisition", strArrays));
                            RowCollection rowCollection3 = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Purchase Order", "Create purchase order", "PO" };
                            rowCollection3.Add(new Row(0, 0, -1, -1, "Purchase Order", strArrays));
                            RowCollection dataRows4 = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Purchase Receipt Note", "Create purchase receipt note", "PI" };
                            dataRows4.Add(new Row(0, 0, -1, -1, "Purchase Receipt Note", strArrays));
                            RowCollection rowCollection4 = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Purchase Return", "Create purchase return", "PRS" };
                            rowCollection4.Add(new Row(0, 0, -1, -1, "Purchase Return Shipment", strArrays));
                            break;
                        }
                    case Property.ModuleEnum.Sales:
                        {
                            this.Text = ":: Sales Options";
                            RowCollection dataRows5 = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Sales Order", "Create sales order", "SI" };
                            dataRows5.Add(new Row(0, 0, -1, -1, "Sales Order Shipment", strArrays));
                            RowCollection rowCollection5 = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Sales Return", "Create sales return", "SR" };
                            rowCollection5.Add(new Row(0, 0, -1, -1, "Sales Return", strArrays));
                            break;
                        }
                    case Property.ModuleEnum.Store:
                        {
                            this.Text = ":: Store Options";
                            RowCollection dataRows6 = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Transfer Request", "Create transfer request", "TRQ" };
                            dataRows6.Add(new Row(0, 0, -1, -1, "Transfer Request", strArrays));
                            RowCollection rowCollection6 = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Transfer Out", "Create transfer out", "TRS" };
                            rowCollection6.Add(new Row(0, 0, -1, -1, "Transfer Out Shipment", strArrays));
                            RowCollection dataRows7 = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Transfer In", "Create transfer in", "TRI" };
                            dataRows7.Add(new Row(0, 0, -1, -1, "Transfer In", strArrays));
                            RowCollection rowCollection7 = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Stock Wastage", "Create stock wastage", "ADJ" };
                            rowCollection7.Add(new Row(0, 0, -1, -1, "Stock Wastage", strArrays));
                            RowCollection dataRows8 = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Stock Shrinkage", "Create stock shrinkage", "SHRINK" };
                            dataRows8.Add(new Row(0, 0, -1, -1, "Stock Shrinkage", strArrays));
                            RowCollection rowCollection8 = this.lstEntry.get_DataRows();
                            strArrays = new string[] { "Stock Miscellaneous", "Create stock miscellaneous", "MISC" };
                            rowCollection8.Add(new Row(0, 0, -1, -1, "Stock Miscellaneous", strArrays));
                            break;
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
            DataRow[] dataRowArray;
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    switch (this.tbcMenu.get_SelectedIndex())
                    {
                        case 0:
                            {
                                CommonLib.SwitchForm(new frmHome());
                                break;
                            }
                        case 1:
                            {
                                if (this.lstEntry.get_ActiveRowIndex() != -1)
                                {
                                    Property.ShowPrice = true;
                                    Property.ShowAmount = true;
                                    Property.BackdatedDocumentAllowed = false;
                                    Property.ShowInventory = false;
                                    Property.NegativeStockAllowed = true;
                                    string str = this.lstEntry.get_SelectedRow().get_Tag().ToString();
                                    if (str != null)
                                    {
                                        switch (str)
                                        {
                                            case "Stock Count":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.SC;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    CommonLib.SwitchForm(new frmStockCount());
                                                    break;
                                                }
                                            case "Shelf Price Check":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.SPC;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    Property.ShowAmount = false;
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Product Label Count":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.PLC;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    Property.ShowAmount = false;
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Shelf Label Count":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.SLC;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    Property.ShowAmount = false;
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Product Label Print":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.PLP;
                                                    CommonLib.SwitchForm(new frmPrint());
                                                    break;
                                                }
                                            case "Shelf Label Print":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.SLP;
                                                    CommonLib.SwitchForm(new frmPrint());
                                                    break;
                                                }
                                            case "Purchase Requisition":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.PRQ;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    if (Property.BackdatedDocumentAllowedForUser)
                                                    {
                                                        Property.BackdatedDocumentAllowed = (dataRowArray[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Backdated Document Allowed"].ToString() == "1");
                                                    }
                                                    if (Property.ShowInventoryForUser)
                                                    {
                                                        Property.ShowInventory = (dataRowArray[0]["Show Inventory"].ToString() == "Yes" ? true : dataRowArray[0]["Show Inventory"].ToString() == "1");
                                                    }
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Purchase Order":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.PO;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    if (Property.BackdatedDocumentAllowedForUser)
                                                    {
                                                        Property.BackdatedDocumentAllowed = (dataRowArray[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Backdated Document Allowed"].ToString() == "1");
                                                    }
                                                    if (Property.ShowInventoryForUser)
                                                    {
                                                        Property.ShowInventory = (dataRowArray[0]["Show Inventory"].ToString() == "Yes" ? true : dataRowArray[0]["Show Inventory"].ToString() == "1");
                                                    }
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Purchase Receipt Note":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.PI;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    if (Property.BackdatedDocumentAllowedForUser)
                                                    {
                                                        Property.BackdatedDocumentAllowed = (dataRowArray[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Backdated Document Allowed"].ToString() == "1");
                                                    }
                                                    if (Property.ShowInventoryForUser)
                                                    {
                                                        Property.ShowInventory = (dataRowArray[0]["Show Inventory"].ToString() == "Yes" ? true : dataRowArray[0]["Show Inventory"].ToString() == "1");
                                                    }
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Purchase Return":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.PR;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    if (Property.BackdatedDocumentAllowedForUser)
                                                    {
                                                        Property.BackdatedDocumentAllowed = (dataRowArray[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Backdated Document Allowed"].ToString() == "1");
                                                    }
                                                    if (Property.ShowInventoryForUser)
                                                    {
                                                        Property.ShowInventory = (dataRowArray[0]["Show Inventory"].ToString() == "Yes" ? true : dataRowArray[0]["Show Inventory"].ToString() == "1");
                                                    }
                                                    Property.NegativeStockAllowed = (dataRowArray[0]["Negative Stock Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Negative Stock Allowed"].ToString() == "1");
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Purchase Return Shipment":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.PRS;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    if (Property.BackdatedDocumentAllowedForUser)
                                                    {
                                                        Property.BackdatedDocumentAllowed = (dataRowArray[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Backdated Document Allowed"].ToString() == "1");
                                                    }
                                                    if (Property.ShowInventoryForUser)
                                                    {
                                                        Property.ShowInventory = (dataRowArray[0]["Show Inventory"].ToString() == "Yes" ? true : dataRowArray[0]["Show Inventory"].ToString() == "1");
                                                    }
                                                    Property.NegativeStockAllowed = (dataRowArray[0]["Negative Stock Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Negative Stock Allowed"].ToString() == "1");
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Sales Order":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.SO;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    if (Property.BackdatedDocumentAllowedForUser)
                                                    {
                                                        Property.BackdatedDocumentAllowed = (dataRowArray[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Backdated Document Allowed"].ToString() == "1");
                                                    }
                                                    if (Property.ShowInventoryForUser)
                                                    {
                                                        Property.ShowInventory = (dataRowArray[0]["Show Inventory"].ToString() == "Yes" ? true : dataRowArray[0]["Show Inventory"].ToString() == "1");
                                                    }
                                                    Property.NegativeStockAllowed = (dataRowArray[0]["Negative Stock Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Negative Stock Allowed"].ToString() == "1");
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Sales Order Shipment":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.SI;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    if (Property.BackdatedDocumentAllowedForUser)
                                                    {
                                                        Property.BackdatedDocumentAllowed = (dataRowArray[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Backdated Document Allowed"].ToString() == "1");
                                                    }
                                                    if (Property.ShowInventoryForUser)
                                                    {
                                                        Property.ShowInventory = (dataRowArray[0]["Show Inventory"].ToString() == "Yes" ? true : dataRowArray[0]["Show Inventory"].ToString() == "1");
                                                    }
                                                    Property.NegativeStockAllowed = (dataRowArray[0]["Negative Stock Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Negative Stock Allowed"].ToString() == "1");
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Sales Return":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.SR;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    if (Property.BackdatedDocumentAllowedForUser)
                                                    {
                                                        Property.BackdatedDocumentAllowed = (dataRowArray[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Backdated Document Allowed"].ToString() == "1");
                                                    }
                                                    if (Property.ShowInventoryForUser)
                                                    {
                                                        Property.ShowInventory = (dataRowArray[0]["Show Inventory"].ToString() == "Yes" ? true : dataRowArray[0]["Show Inventory"].ToString() == "1");
                                                    }
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Sales Return Receipt":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.SRR;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    if (Property.BackdatedDocumentAllowedForUser)
                                                    {
                                                        Property.BackdatedDocumentAllowed = (dataRowArray[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Backdated Document Allowed"].ToString() == "1");
                                                    }
                                                    if (Property.ShowInventoryForUser)
                                                    {
                                                        Property.ShowInventory = (dataRowArray[0]["Show Inventory"].ToString() == "Yes" ? true : dataRowArray[0]["Show Inventory"].ToString() == "1");
                                                    }
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Transfer Request":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.TRQ;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    Property.ShowPrice = false;
                                                    Property.ShowAmount = false;
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    if (Property.BackdatedDocumentAllowedForUser)
                                                    {
                                                        Property.BackdatedDocumentAllowed = (dataRowArray[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Backdated Document Allowed"].ToString() == "1");
                                                    }
                                                    if (Property.ShowInventoryForUser)
                                                    {
                                                        Property.ShowInventory = (dataRowArray[0]["Show Inventory"].ToString() == "Yes" ? true : dataRowArray[0]["Show Inventory"].ToString() == "1");
                                                    }
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Transfer Out":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.TRO;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    Property.ShowPrice = false;
                                                    Property.ShowAmount = false;
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    if (Property.BackdatedDocumentAllowedForUser)
                                                    {
                                                        Property.BackdatedDocumentAllowed = (dataRowArray[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Backdated Document Allowed"].ToString() == "1");
                                                    }
                                                    if (Property.ShowInventoryForUser)
                                                    {
                                                        Property.ShowInventory = (dataRowArray[0]["Show Inventory"].ToString() == "Yes" ? true : dataRowArray[0]["Show Inventory"].ToString() == "1");
                                                    }
                                                    Property.NegativeStockAllowed = (dataRowArray[0]["Negative Stock Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Negative Stock Allowed"].ToString() == "1");
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Transfer Out Shipment":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.TRS;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    Property.ShowPrice = false;
                                                    Property.ShowAmount = false;
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    if (Property.BackdatedDocumentAllowedForUser)
                                                    {
                                                        Property.BackdatedDocumentAllowed = (dataRowArray[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Backdated Document Allowed"].ToString() == "1");
                                                    }
                                                    if (Property.ShowInventoryForUser)
                                                    {
                                                        Property.ShowInventory = (dataRowArray[0]["Show Inventory"].ToString() == "Yes" ? true : dataRowArray[0]["Show Inventory"].ToString() == "1");
                                                    }
                                                    Property.NegativeStockAllowed = (dataRowArray[0]["Negative Stock Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Negative Stock Allowed"].ToString() == "1");
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Transfer In":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.TRI;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    Property.ShowPrice = false;
                                                    Property.ShowAmount = false;
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    if (Property.BackdatedDocumentAllowedForUser)
                                                    {
                                                        Property.BackdatedDocumentAllowed = (dataRowArray[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Backdated Document Allowed"].ToString() == "1");
                                                    }
                                                    if (Property.ShowInventoryForUser)
                                                    {
                                                        Property.ShowInventory = (dataRowArray[0]["Show Inventory"].ToString() == "Yes" ? true : dataRowArray[0]["Show Inventory"].ToString() == "1");
                                                    }
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Stock Wastage":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.ADJ;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    if (Property.BackdatedDocumentAllowedForUser)
                                                    {
                                                        Property.BackdatedDocumentAllowed = (dataRowArray[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Backdated Document Allowed"].ToString() == "1");
                                                    }
                                                    if (Property.ShowInventoryForUser)
                                                    {
                                                        Property.ShowInventory = (dataRowArray[0]["Show Inventory"].ToString() == "Yes" ? true : dataRowArray[0]["Show Inventory"].ToString() == "1");
                                                    }
                                                    Property.NegativeStockAllowed = (dataRowArray[0]["Negative Stock Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Negative Stock Allowed"].ToString() == "1");
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Stock Shrinkage":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.SHRINK;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    if (Property.BackdatedDocumentAllowedForUser)
                                                    {
                                                        Property.BackdatedDocumentAllowed = (dataRowArray[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Backdated Document Allowed"].ToString() == "1");
                                                    }
                                                    if (Property.ShowInventoryForUser)
                                                    {
                                                        Property.ShowInventory = (dataRowArray[0]["Show Inventory"].ToString() == "Yes" ? true : dataRowArray[0]["Show Inventory"].ToString() == "1");
                                                    }
                                                    Property.NegativeStockAllowed = (dataRowArray[0]["Negative Stock Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Negative Stock Allowed"].ToString() == "1");
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
                                                }
                                            case "Stock Miscellaneous":
                                                {
                                                    Property.TransactionType = Property.TransactionTypeEnum.MISC;
                                                    if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString())).Length == 0)
                                                    {
                                                        throw new Exception("User access has been denied");
                                                    }
                                                    dataRowArray = Property.DocumentSetup.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionType.ToString()));
                                                    if ((int)dataRowArray.Length == 0)
                                                    {
                                                        throw new Exception("Document setup has been missing for current location and selected transaction type");
                                                    }
                                                    if (Property.BackdatedDocumentAllowedForUser)
                                                    {
                                                        Property.BackdatedDocumentAllowed = (dataRowArray[0]["Backdated Document Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Backdated Document Allowed"].ToString() == "1");
                                                    }
                                                    if (Property.ShowInventoryForUser)
                                                    {
                                                        Property.ShowInventory = (dataRowArray[0]["Show Inventory"].ToString() == "Yes" ? true : dataRowArray[0]["Show Inventory"].ToString() == "1");
                                                    }
                                                    Property.NegativeStockAllowed = (dataRowArray[0]["Negative Stock Allowed"].ToString() == "Yes" ? true : dataRowArray[0]["Negative Stock Allowed"].ToString() == "1");
                                                    CommonLib.SwitchForm(new frmTransHeaders());
                                                    break;
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
    }
}