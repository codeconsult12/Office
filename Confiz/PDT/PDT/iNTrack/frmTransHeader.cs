using iNTrack.iNTrackService;
using Resco.Controls.CommonControls;
using Resco.Controls.OutlookControls;
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
    public class frmTransHeader : Form
    {
        private IContainer components = null;

        private UIElementPanelControl pnlForm;

        private ToolbarControl tbcMenu;

        private ToolbarItem tbiBack;

        private ToolbarItem tbiNext;

        private UILabel lblTransPortCode;

        private UITextBox txtTransPortCode;

        private UIButton btnTransPort;

        private UILabel lblTransPortName;

        private UILabel lblDocDate;

        private UILabel lblRef2;

        private UILabel lblRef1;

        private UITextBox txtRef1;

        private UITextBox txtRemarks;

        private UITextBoxButton btnRemarks;

        private UILabel lblRemarks;

        private UIButton btnRef1;

        private UITextBox txtTransPortName;

        private OutlookDateTimePicker dtpRefDate;

        private OutlookDateTimePicker dtpDocDate;

        private UITextBox txtRef3;

        private UIButton btnRef2;

        private UILabel lblRef3;

        private UIButton btnRef3;

        private UITextBox txtRef2;

        public frmTransHeader()
        {
            this.InitializeComponent();
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int width = bounds.Width;
            bounds = Screen.PrimaryScreen.Bounds;
            base.Size = new Size(width, bounds.Height);
            this.AutoScroll = false;
        }

        private void btnRef1_Click(object sender, UIMouseEventArgs e)
        {
            frmLookup _frmLookup;
            try
            {
                try
                {
                    string str = ((UIButton)sender).get_Tag().ToString();
                    if (str != null)
                    {
                        if (str != "Ref1")
                        {
                            if (str != "Ref2")
                            {
                                if (str == "Ref3")
                                {
                                    _frmLookup = new frmLookup(frmLookup.SourceEnum.Reason);
                                    try
                                    {
                                        if (_frmLookup.ShowDialog() == DialogResult.OK)
                                        {
                                            switch (Property.TransactionType)
                                            {
                                                case Property.TransactionTypeEnum.PR:
                                                case Property.TransactionTypeEnum.PRS:
                                                    {
                                                        this.txtRef3.set_Text(_frmLookup.SelectedName);
                                                        Property.DefaultReasonCode = _frmLookup.SelectedCode;
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                    finally
                                    {
                                        if (_frmLookup != null)
                                        {
                                            ((IDisposable)_frmLookup).Dispose();
                                        }
                                    }
                                }
                            }
                        }
                        else if (Property.TransactionType == Property.TransactionTypeEnum.PI)
                        {
                            _frmLookup = new frmLookup(frmLookup.SourceEnum.InvoiceNo);
                            try
                            {
                                if (_frmLookup.ShowDialog() == DialogResult.OK)
                                {
                                    this.txtRef1.set_Text(_frmLookup.SelectedCode);
                                }
                            }
                            finally
                            {
                                if (_frmLookup != null)
                                {
                                    ((IDisposable)_frmLookup).Dispose();
                                }
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

        private void btnTransPort_Click(object sender, UIMouseEventArgs e)
        {
            try
            {
                frmLookup.SourceEnum sourceEnum = frmLookup.SourceEnum.None;
                switch (Property.TransactionType)
                {
                    case Property.TransactionTypeEnum.PO:
                    case Property.TransactionTypeEnum.PI:
                    case Property.TransactionTypeEnum.PR:
                    case Property.TransactionTypeEnum.PRS:
                        {
                            sourceEnum = frmLookup.SourceEnum.Vendor;
                            goto case Property.TransactionTypeEnum.TRI;
                        }
                    case Property.TransactionTypeEnum.SO:
                    case Property.TransactionTypeEnum.SI:
                    case Property.TransactionTypeEnum.SR:
                    case Property.TransactionTypeEnum.SRR:
                        {
                            sourceEnum = frmLookup.SourceEnum.Customer;
                            goto case Property.TransactionTypeEnum.TRI;
                        }
                    case Property.TransactionTypeEnum.TRQ:
                    case Property.TransactionTypeEnum.TRO:
                    case Property.TransactionTypeEnum.TRS:
                        {
                            sourceEnum = frmLookup.SourceEnum.Location;
                            goto case Property.TransactionTypeEnum.TRI;
                        }
                    case Property.TransactionTypeEnum.TRI:
                        {
                            if (sourceEnum != frmLookup.SourceEnum.None)
                            {
                                frmLookup _frmLookup = new frmLookup(sourceEnum);
                                try
                                {
                                    if (_frmLookup.ShowDialog() == DialogResult.OK)
                                    {
                                        switch (Property.TransactionType)
                                        {
                                            case Property.TransactionTypeEnum.ADJ:
                                            case Property.TransactionTypeEnum.SHRINK:
                                            case Property.TransactionTypeEnum.MISC:
                                                {
                                                    this.txtTransPortCode.set_Text(_frmLookup.SelectedCode);
                                                    this.txtTransPortName.set_Text(_frmLookup.SelectedName);
                                                    Property.DefaultReasonCode = _frmLookup.SelectedCode;
                                                    break;
                                                }
                                            default:
                                                {
                                                    Property.TransactionPortCode = _frmLookup.SelectedCode;
                                                    Property.TransactionPortName = _frmLookup.SelectedName;
                                                    this.txtTransPortCode.set_Text(Property.TransactionPortCode);
                                                    this.txtTransPortName.set_Text(Property.TransactionPortName);
                                                    break;
                                                }
                                        }
                                    }
                                }
                                finally
                                {
                                    if (_frmLookup != null)
                                    {
                                        ((IDisposable)_frmLookup).Dispose();
                                    }
                                }
                            }
                            break;
                        }
                    case Property.TransactionTypeEnum.ADJ:
                    case Property.TransactionTypeEnum.SHRINK:
                    case Property.TransactionTypeEnum.MISC:
                        {
                            sourceEnum = frmLookup.SourceEnum.Reason;
                            goto case Property.TransactionTypeEnum.TRI;
                        }
                    default:
                        {
                            goto case Property.TransactionTypeEnum.TRI;
                        }
                }
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

        private void dtpDocDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtpDocDate.get_Value().Date > DateTime.Now.Date)
            {
                this.dtpDocDate.set_Value(DateTime.Now.Date);
            }
        }

        private void dtpRefDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtpRefDate.get_Value().Date > DateTime.Now.Date)
            {
                this.dtpRefDate.set_Value(this.dtpDocDate.get_Value().Date);
            }
        }

        private void frmTransHeader_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    switch (Property.TransactionType)
                    {
                        case Property.TransactionTypeEnum.SPC:
                            {
                                this.Text = ":: Shelf Price Check";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.PRQ:
                            {
                                this.Text = ":: Purch. Requisition";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.PO:
                            {
                                this.Text = ":: Purch. Order";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.PI:
                            {
                                this.Text = ":: Purch. Receipt Note";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.PR:
                        case Property.TransactionTypeEnum.PRS:
                            {
                                this.Text = ":: Purch. Return";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.SO:
                        case Property.TransactionTypeEnum.SI:
                            {
                                this.Text = ":: Sales Order";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.SR:
                        case Property.TransactionTypeEnum.SRR:
                            {
                                this.Text = ":: Sales Return";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.TRQ:
                            {
                                this.Text = ":: Transfer Request";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.TRO:
                        case Property.TransactionTypeEnum.TRS:
                            {
                                this.Text = ":: Transfer Out";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.TRI:
                            {
                                this.Text = ":: Transfer In";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.ADJ:
                            {
                                this.Text = ":: Stock Wastage";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.SHRINK:
                            {
                                this.Text = ":: Stock Shrinkage";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.MISC:
                            {
                                this.Text = ":: Stock Miscellaneous";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.SC:
                            {
                                switch (Property.TransactionType)
                                {
                                    case Property.TransactionTypeEnum.PO:
                                    case Property.TransactionTypeEnum.PI:
                                    case Property.TransactionTypeEnum.PR:
                                    case Property.TransactionTypeEnum.PRS:
                                        {
                                            this.lblTransPortCode.set_Text("Vend. Code");
                                            this.lblTransPortName.set_Text("Vend. Name");
                                            break;
                                        }
                                    case Property.TransactionTypeEnum.SO:
                                    case Property.TransactionTypeEnum.SI:
                                    case Property.TransactionTypeEnum.SR:
                                    case Property.TransactionTypeEnum.SRR:
                                        {
                                            this.lblTransPortCode.set_Text("Cust. Code");
                                            this.lblTransPortName.set_Text("Cust. Name");
                                            break;
                                        }
                                    case Property.TransactionTypeEnum.TRQ:
                                    case Property.TransactionTypeEnum.TRO:
                                    case Property.TransactionTypeEnum.TRS:
                                    case Property.TransactionTypeEnum.TRI:
                                        {
                                            this.lblTransPortCode.set_Text("Locn. Code");
                                            this.lblTransPortName.set_Text("Locn. Name");
                                            break;
                                        }
                                    case Property.TransactionTypeEnum.ADJ:
                                    case Property.TransactionTypeEnum.SHRINK:
                                    case Property.TransactionTypeEnum.MISC:
                                        {
                                            this.lblTransPortCode.set_Text("Resn. Code");
                                            this.lblTransPortName.set_Text("Resn. Name");
                                            break;
                                        }
                                    default:
                                        {
                                            this.lblTransPortCode.set_Visible(false);
                                            this.txtTransPortCode.set_Visible(false);
                                            this.lblTransPortName.set_Visible(false);
                                            this.txtTransPortName.set_Visible(false);
                                            this.btnTransPort.set_Visible(false);
                                            break;
                                        }
                                }
                                switch (Property.TransactionType)
                                {
                                    case Property.TransactionTypeEnum.ADJ:
                                    case Property.TransactionTypeEnum.SHRINK:
                                    case Property.TransactionTypeEnum.MISC:
                                        {
                                            this.txtTransPortCode.set_ReadOnly(false);
                                            this.btnTransPort.set_Enabled(true);
                                            break;
                                        }
                                    default:
                                        {
                                            this.txtTransPortCode.set_ReadOnly(!string.IsNullOrEmpty(Property.TransactionNo));
                                            this.btnTransPort.set_Enabled(string.IsNullOrEmpty(Property.TransactionNo));
                                            break;
                                        }
                                }
                                this.lblRef1.set_Visible(false);
                                this.txtRef1.set_Visible(false);
                                this.btnRef1.set_Visible(false);
                                this.lblRef2.set_Visible(false);
                                this.txtRef2.set_Visible(false);
                                this.dtpRefDate.set_Visible(false);
                                this.btnRef2.set_Visible(false);
                                this.lblRef3.set_Visible(false);
                                this.txtRef3.set_Visible(false);
                                this.btnRef3.set_Visible(false);
                                switch (Property.TransactionType)
                                {
                                    case Property.TransactionTypeEnum.PI:
                                        {
                                            this.lblRef1.set_Visible(true);
                                            this.txtRef1.set_Visible(true);
                                            this.btnRef1.set_Visible(true);
                                            this.lblRef1.set_Text("Inv. No.");
                                            this.lblRef2.set_Visible(true);
                                            this.dtpRefDate.set_Visible(true);
                                            this.lblRef2.set_Text("Inv. Date");
                                            goto case Property.TransactionTypeEnum.TRI;
                                        }
                                    case Property.TransactionTypeEnum.PR:
                                    case Property.TransactionTypeEnum.PRS:
                                        {
                                            this.lblRef1.set_Visible(true);
                                            this.txtRef1.set_Visible(true);
                                            this.lblRef1.set_Text("RMA No.");
                                            this.lblRef2.set_Visible(true);
                                            this.dtpRefDate.set_Visible(true);
                                            this.lblRef2.set_Text("Ship. Date");
                                            this.lblRef3.set_Visible(true);
                                            this.txtRef3.set_Visible(true);
                                            this.btnRef3.set_Visible(true);
                                            this.txtRef3.set_Enabled(false);
                                            this.lblRef3.set_Text("Reason");
                                            if ((Property.TransactionType != Property.TransactionTypeEnum.PRS ? false : Property.TransactionStatus == "AU"))
                                            {
                                                this.txtRef1.set_Enabled(false);
                                                this.dtpRefDate.Enabled = false;
                                                this.lblRef3.set_Visible(false);
                                                this.txtRef3.set_Visible(false);
                                                this.btnRef3.set_Visible(false);
                                            }
                                            goto case Property.TransactionTypeEnum.TRI;
                                        }
                                    case Property.TransactionTypeEnum.SO:
                                    case Property.TransactionTypeEnum.SI:
                                    case Property.TransactionTypeEnum.SR:
                                    case Property.TransactionTypeEnum.SRR:
                                    case Property.TransactionTypeEnum.TRQ:
                                    case Property.TransactionTypeEnum.TRI:
                                        {
                                            this.dtpDocDate.set_Value(Property.DocumentDate);
                                            this.txtRemarks.set_Text(Property.Remarks);
                                            this.txtTransPortCode.set_Text(Property.TransactionPortCode);
                                            this.txtTransPortName.set_Text(Property.TransactionPortName);
                                            this.txtRef1.set_Text(Property.HeaderReferenceNo1);
                                            this.dtpRefDate.set_Value(Property.ReferenceDate);
                                            this.txtRef2.set_Text(Property.HeaderReferenceNo2);
                                            this.dtpDocDate.Enabled = (!Property.BackdatedDocumentAllowed ? false : Property.TransactionStatus == "SM");
                                            break;
                                        }
                                    case Property.TransactionTypeEnum.TRO:
                                    case Property.TransactionTypeEnum.TRS:
                                        {
                                            this.lblRef1.set_Visible(true);
                                            this.txtRef1.set_Visible(true);
                                            this.lblRef1.set_Text("Driver ID");
                                            this.lblRef2.set_Visible(true);
                                            this.txtRef2.set_Visible(true);
                                            this.lblRef2.set_Text("Driver Name");
                                            if ((Property.TransactionType != Property.TransactionTypeEnum.TRS ? false : Property.TransactionStatus == "AU"))
                                            {
                                                this.txtRef1.set_Enabled(false);
                                                this.txtRef2.set_Enabled(false);
                                            }
                                            goto case Property.TransactionTypeEnum.TRI;
                                        }
                                    case Property.TransactionTypeEnum.ADJ:
                                    case Property.TransactionTypeEnum.SHRINK:
                                    case Property.TransactionTypeEnum.MISC:
                                        {
                                            this.lblRef1.set_Visible(true);
                                            this.txtRef1.set_Visible(true);
                                            this.lblRef1.set_Text("RMA No.");
                                            goto case Property.TransactionTypeEnum.TRI;
                                        }
                                    default:
                                        {
                                            goto case Property.TransactionTypeEnum.TRI;
                                        }
                                }
                                break;
                            }
                        case Property.TransactionTypeEnum.PLC:
                            {
                                this.Text = ":: Product Label Count";
                                goto case Property.TransactionTypeEnum.SC;
                            }
                        case Property.TransactionTypeEnum.SLC:
                            {
                                this.Text = ":: Shelf Label Count";
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

        private void InitializeComponent()
        {
            this.dtpRefDate = new OutlookDateTimePicker();
            this.dtpDocDate = new OutlookDateTimePicker();
            this.tbcMenu = new ToolbarControl();
            this.tbiBack = new ToolbarItem();
            this.tbiNext = new ToolbarItem();
            this.pnlForm = new UIElementPanelControl();
            this.lblTransPortCode = new UILabel();
            this.txtTransPortCode = new UITextBox();
            this.btnTransPort = new UIButton();
            this.lblTransPortName = new UILabel();
            this.lblDocDate = new UILabel();
            this.lblRef2 = new UILabel();
            this.lblRef1 = new UILabel();
            this.txtRef1 = new UITextBox();
            this.txtRemarks = new UITextBox();
            this.btnRemarks = new UITextBoxButton();
            this.lblRemarks = new UILabel();
            this.btnRef1 = new UIButton();
            this.txtTransPortName = new UITextBox();
            this.txtRef3 = new UITextBox();
            this.btnRef2 = new UIButton();
            this.lblRef3 = new UILabel();
            this.btnRef3 = new UIButton();
            this.txtRef2 = new UITextBox();
            this.pnlForm.SuspendElementLayout();
            base.SuspendLayout();
            this.dtpRefDate.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this.dtpRefDate.BackColor = SystemColors.Window;
            this.dtpRefDate.BorderStyle = BorderStyle.FixedSingle;
            this.dtpRefDate.set_CustomFormat("dd/MM/yyyy");
            this.dtpRefDate.Font = new Font("Tahoma", 9f, FontStyle.Regular);
            this.dtpRefDate.set_Format(8);
            this.dtpRefDate.Location = new Point(82, 145);
            this.dtpRefDate.set_MaxDate(new DateTime(9999, 12, 31, 23, 59, 59, 999));
            this.dtpRefDate.set_MinDate(new DateTime((long)0));
            this.dtpRefDate.Name = "dtpRefDate";
            this.dtpRefDate.Size = new Size(198, 26);
            this.dtpRefDate.TabIndex = 7;
            this.dtpRefDate.add_ValueChanged(new EventHandler(this.dtpRefDate_ValueChanged));
            this.dtpDocDate.BackColor = SystemColors.Window;
            this.dtpDocDate.BorderStyle = BorderStyle.FixedSingle;
            this.dtpDocDate.set_CustomFormat("dd/MM/yyyy");
            this.dtpDocDate.Font = new Font("Tahoma", 9f, FontStyle.Regular);
            this.dtpDocDate.set_Format(8);
            this.dtpDocDate.Location = new Point(82, 3);
            this.dtpDocDate.set_MaxDate(new DateTime(9999, 12, 31, 23, 59, 59, 999));
            this.dtpDocDate.set_MinDate(new DateTime((long)0));
            this.dtpDocDate.Name = "dtpDocDate";
            this.dtpDocDate.Size = new Size(120, 23);
            this.dtpDocDate.TabIndex = 1;
            this.dtpDocDate.add_ValueChanged(new EventHandler(this.dtpDocDate_ValueChanged));
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
            this.tbcMenu.TabIndex = 8;
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
            this.pnlForm.set_BackgroundImage(imgManager.GetImage("iNTrack.BGP"));
            this.pnlForm.set_BackgroundImageLayout(6);
            this.pnlForm.get_Children().Add(this.lblTransPortCode);
            this.pnlForm.get_Children().Add(this.txtTransPortCode);
            this.pnlForm.get_Children().Add(this.btnTransPort);
            this.pnlForm.get_Children().Add(this.lblTransPortName);
            this.pnlForm.get_Children().Add(this.lblDocDate);
            this.pnlForm.get_Children().Add(this.lblRef2);
            this.pnlForm.get_Children().Add(this.lblRef1);
            this.pnlForm.get_Children().Add(this.txtRef1);
            this.pnlForm.get_Children().Add(this.txtRemarks);
            this.pnlForm.get_Children().Add(this.lblRemarks);
            this.pnlForm.get_Children().Add(this.btnRef1);
            this.pnlForm.get_Children().Add(this.txtTransPortName);
            this.pnlForm.get_Children().Add(this.txtRef3);
            this.pnlForm.get_Children().Add(this.btnRef2);
            this.pnlForm.get_Children().Add(this.lblRef3);
            this.pnlForm.get_Children().Add(this.btnRef3);
            this.pnlForm.get_Children().Add(this.txtRef2);
            this.pnlForm.Dock = DockStyle.Fill;
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new Size(318, 294);
            this.pnlForm.TabIndex = 9;
            this.lblTransPortCode.set_AutoSize(false);
            this.lblTransPortCode.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblTransPortCode.set_Layout(new ElementLayout(0, 0, 5, 54, 0, 0, 73, 26));
            this.lblTransPortCode.set_Name("lblTransPortCode");
            this.lblTransPortCode.set_TabIndex(7);
            this.lblTransPortCode.set_Text("Port Code");
            this.lblTransPortCode.set_TextAlignment(2);
            this.txtTransPortCode.set_Layout(new ElementLayout(3, 0, 82, 54, 38, 0, 198, 26));
            this.txtTransPortCode.set_Name("txtTransPortCode");
            this.txtTransPortCode.set_TabIndex(3);
            this.txtTransPortCode.add_KeyPress(new KeyPressEventHandler(this.txtTransPortCode_KeyPress));
            this.txtTransPortCode.add_TextChanged(new EventHandler(this.txtTransPortCode_TextChanged));
            this.txtTransPortCode.add_Validating(new CancelEventHandler(this.txtTransPortCode_Validating));
            this.btnTransPort.set_BackColor(SystemColors.Desktop);
            this.btnTransPort.set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
            this.btnTransPort.set_ForeColor(Color.White);
            this.btnTransPort.set_Layout(new ElementLayout(2, 0, 0, 54, 4, 0, 33, 26));
            this.btnTransPort.set_Name("btnTransPort");
            this.btnTransPort.set_TabIndex(4);
            this.btnTransPort.set_Text("...");
            this.btnTransPort.add_Click(new UIMouseEventHandler(this, frmTransHeader.btnTransPort_Click));
            this.lblTransPortName.set_AutoSize(false);
            this.lblTransPortName.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblTransPortName.set_Layout(new ElementLayout(0, 0, 5, 81, 0, 0, 73, 26));
            this.lblTransPortName.set_Name("lblTransPortName");
            this.lblTransPortName.set_TabIndex(6);
            this.lblTransPortName.set_Text("Port Name");
            this.lblTransPortName.set_TextAlignment(2);
            this.lblDocDate.set_AutoSize(false);
            this.lblDocDate.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblDocDate.set_Layout(new ElementLayout(0, 0, 5, 5, 0, 0, 60, 20));
            this.lblDocDate.set_Name("lblDocDate");
            this.lblDocDate.set_TabIndex(7);
            this.lblDocDate.set_Text("Doc. Date");
            this.lblDocDate.set_TextAlignment(2);
            this.lblRef2.set_AutoSize(false);
            this.lblRef2.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblRef2.set_Layout(new ElementLayout(0, 0, 5, 145, 0, 0, 67, 26));
            this.lblRef2.set_Name("lblRef2");
            this.lblRef2.set_TabIndex(7);
            this.lblRef2.set_Text("Ref. 2");
            this.lblRef2.set_TextAlignment(2);
            this.lblRef1.set_AutoSize(false);
            this.lblRef1.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblRef1.set_Layout(new ElementLayout(0, 0, 5, 119, 0, 0, 73, 26));
            this.lblRef1.set_Name("lblRef1");
            this.lblRef1.set_TabIndex(7);
            this.lblRef1.set_Text("Ref. 1");
            this.lblRef1.set_TextAlignment(2);
            this.txtRef1.set_CharacterCasing(1);
            this.txtRef1.set_Layout(new ElementLayout(3, 0, 82, 118, 38, 0, 198, 26));
            this.txtRef1.set_Name("txtRef1");
            this.txtRef1.set_TabIndex(6);
            this.txtRef1.set_Tag("Ref1");
            this.txtRef1.add_KeyPress(new KeyPressEventHandler(this.txtRef1_KeyPress));
            this.txtRemarks.get_Buttons().Add(this.btnRemarks);
            this.txtRemarks.set_Layout(new ElementLayout(3, 0, 82, 27, 4, 0, 232, 26));
            this.txtRemarks.set_Multiline(true);
            this.txtRemarks.set_Name("txtRemarks");
            this.txtRemarks.set_TabIndex(2);
            this.btnRemarks.set_Action(1);
            this.btnRemarks.set_BackColor(Color.Transparent);
            this.btnRemarks.set_BorderThickness(0);
            this.btnRemarks.set_HorizontalAlignment(2);
            this.btnRemarks.set_Name("btnRemarks");
            this.btnRemarks.get_PressedBackground().set_BackColor(Color.Transparent);
            this.btnRemarks.set_Size(new Size(18, 18));
            this.btnRemarks.set_StateIcon(2);
            this.btnRemarks.set_VisibleMode(1);
            this.lblRemarks.set_AutoSize(false);
            this.lblRemarks.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblRemarks.set_Layout(new ElementLayout(0, 0, 5, 27, 0, 0, 58, 26));
            this.lblRemarks.set_Name("lblRemarks");
            this.lblRemarks.set_TabIndex(7);
            this.lblRemarks.set_Text("Remarks");
            this.lblRemarks.set_TextAlignment(2);
            this.btnRef1.set_AutoCheck(true);
            this.btnRef1.set_BackColor(SystemColors.Desktop);
            this.btnRef1.set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
            this.btnRef1.set_ForeColor(Color.White);
            this.btnRef1.set_Layout(new ElementLayout(2, 0, 0, 118, 4, 0, 33, 26));
            this.btnRef1.set_Name("btnRef1");
            this.btnRef1.set_TabIndex(7);
            this.btnRef1.set_Tag("Ref1");
            this.btnRef1.set_Text("...");
            this.btnRef1.add_Click(new UIMouseEventHandler(this, frmTransHeader.btnRef1_Click));
            this.txtTransPortName.set_Font(new Font("Tahoma", 8f, FontStyle.Regular));
            this.txtTransPortName.set_Layout(new ElementLayout(3, 0, 82, 81, 4, 0, 232, 36));
            this.txtTransPortName.set_Multiline(true);
            this.txtTransPortName.set_Name("txtTransPortName");
            this.txtTransPortName.set_ReadOnly(true);
            this.txtTransPortName.set_TabIndex(5);
            this.txtRef3.set_CharacterCasing(1);
            this.txtRef3.set_Layout(new ElementLayout(3, 0, 82, 172, 38, 0, 198, 26));
            this.txtRef3.set_Name("txtRef3");
            this.txtRef3.set_TabIndex(6);
            this.txtRef3.set_Tag("Ref3");
            this.btnRef2.set_AutoCheck(true);
            this.btnRef2.set_BackColor(SystemColors.Desktop);
            this.btnRef2.set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
            this.btnRef2.set_ForeColor(Color.White);
            this.btnRef2.set_Layout(new ElementLayout(2, 0, 0, 145, 4, 0, 33, 26));
            this.btnRef2.set_Name("btnRef2");
            this.btnRef2.set_TabIndex(7);
            this.btnRef2.set_Tag("Ref2");
            this.btnRef2.set_Text("...");
            this.btnRef2.add_Click(new UIMouseEventHandler(this, frmTransHeader.btnRef1_Click));
            this.lblRef3.set_AutoSize(false);
            this.lblRef3.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblRef3.set_Layout(new ElementLayout(0, 0, 5, 171, 0, 0, 67, 26));
            this.lblRef3.set_Name("lblRef3");
            this.lblRef3.set_TabIndex(7);
            this.lblRef3.set_Text("Ref. 3");
            this.lblRef3.set_TextAlignment(2);
            this.btnRef3.set_AutoCheck(true);
            this.btnRef3.set_BackColor(SystemColors.Desktop);
            this.btnRef3.set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
            this.btnRef3.set_ForeColor(Color.White);
            this.btnRef3.set_Layout(new ElementLayout(2, 0, 0, 172, 4, 0, 33, 26));
            this.btnRef3.set_Name("btnRef3");
            this.btnRef3.set_TabIndex(7);
            this.btnRef3.set_Tag("Ref3");
            this.btnRef3.set_Text("...");
            this.btnRef3.add_Click(new UIMouseEventHandler(this, frmTransHeader.btnRef1_Click));
            this.txtRef2.set_CharacterCasing(1);
            this.txtRef2.set_Layout(new ElementLayout(3, 0, 82, 145, 38, 0, 198, 26));
            this.txtRef2.set_Name("txtRef2");
            this.txtRef2.set_TabIndex(6);
            this.txtRef2.set_Tag("Ref2");
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(318, 294);
            base.ControlBox = false;
            base.Controls.Add(this.dtpDocDate);
            base.Controls.Add(this.dtpRefDate);
            base.Controls.Add(this.tbcMenu);
            base.Controls.Add(this.pnlForm);
            base.MinimizeBox = false;
            base.Name = "frmTransHeader";
            this.Text = ":: Transaction Header";
            base.Load += new EventHandler(this.frmTransHeader_Load);
            this.pnlForm.ResumeElementLayout(false);
            base.ResumeLayout(false);
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
                                if ((!string.IsNullOrEmpty(Property.TransactionNo) || !this.txtTransPortName.get_Visible() ? false : string.IsNullOrEmpty(this.txtTransPortName.get_Text().Trim())))
                                {
                                    this.txtTransPortCode.SelectAll();
                                    this.txtTransPortCode.Focus();
                                    throw new Exception(string.Format("Invalid {0}", this.lblTransPortCode.get_Text().ToLower()));
                                }
                                switch (Property.TransactionType)
                                {
                                    case Property.TransactionTypeEnum.PI:
                                        {
                                            if (string.IsNullOrEmpty(this.txtRef1.get_Text().Trim()))
                                            {
                                                this.txtRef1.SelectAll();
                                                this.txtRef1.Focus();
                                                throw new Exception("Invalid vendor invoice no.");
                                            }
                                            Property.HeaderReferenceNo1 = this.txtRef1.get_Text();
                                            Property.LineReferenceNo2 = this.txtRef1.get_Text();
                                            goto case Property.TransactionTypeEnum.TRI;
                                        }
                                    case Property.TransactionTypeEnum.PR:
                                    case Property.TransactionTypeEnum.PRS:
                                        {
                                            if (string.IsNullOrEmpty(this.txtRef1.get_Text().Trim()))
                                            {
                                                this.txtRef1.SelectAll();
                                                this.txtRef1.Focus();
                                                throw new Exception("Invalid rma no.");
                                            }
                                            if ((!this.txtRef3.get_Visible() ? false : string.IsNullOrEmpty(this.txtRef3.get_Text().Trim())))
                                            {
                                                this.txtRef3.SelectAll();
                                                this.txtRef3.Focus();
                                                throw new Exception("Invalid reason");
                                            }
                                            Property.HeaderReferenceNo1 = this.txtRef1.get_Text();
                                            goto case Property.TransactionTypeEnum.TRI;
                                        }
                                    case Property.TransactionTypeEnum.SO:
                                    case Property.TransactionTypeEnum.SI:
                                    case Property.TransactionTypeEnum.SR:
                                    case Property.TransactionTypeEnum.SRR:
                                    case Property.TransactionTypeEnum.TRQ:
                                    case Property.TransactionTypeEnum.TRI:
                                        {
                                            DateTime value = this.dtpDocDate.get_Value();
                                            Property.DocumentDate = value.Date;
                                            value = this.dtpRefDate.get_Value();
                                            Property.ReferenceDate = value.Date;
                                            Property.Remarks = this.txtRemarks.get_Text();
                                            base.DialogResult = DialogResult.OK;
                                            break;
                                        }
                                    case Property.TransactionTypeEnum.TRO:
                                    case Property.TransactionTypeEnum.TRS:
                                        {
                                            if ((!this.txtRef1.get_Enabled() ? false : string.IsNullOrEmpty(this.txtRef1.get_Text().Trim())))
                                            {
                                                this.txtRef1.SelectAll();
                                                this.txtRef1.Focus();
                                                throw new Exception("Invalid driver id");
                                            }
                                            if ((!this.txtRef2.get_Enabled() ? false : string.IsNullOrEmpty(this.txtRef2.get_Text().Trim())))
                                            {
                                                this.txtRef2.SelectAll();
                                                this.txtRef2.Focus();
                                                throw new Exception("Invalid driver name");
                                            }
                                            Property.HeaderReferenceNo1 = this.txtRef1.get_Text();
                                            Property.HeaderReferenceNo2 = this.txtRef2.get_Text();
                                            goto case Property.TransactionTypeEnum.TRI;
                                        }
                                    case Property.TransactionTypeEnum.ADJ:
                                    case Property.TransactionTypeEnum.SHRINK:
                                    case Property.TransactionTypeEnum.MISC:
                                        {
                                            if (string.IsNullOrEmpty(this.txtRef1.get_Text().Trim()))
                                            {
                                                this.txtRef1.SelectAll();
                                                this.txtRef1.Focus();
                                                throw new Exception("Invalid rma no.");
                                            }
                                            Property.HeaderReferenceNo1 = this.txtRef1.get_Text();
                                            goto case Property.TransactionTypeEnum.TRI;
                                        }
                                    default:
                                        {
                                            goto case Property.TransactionTypeEnum.TRI;
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

        private void txtRef1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTransPortCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != '\r' ? false : !string.IsNullOrEmpty(this.txtTransPortCode.get_Text().Trim())))
            {
                e.Handled = true;
                base.Focus();
            }
        }

        private void txtTransPortCode_TextChanged(object sender, EventArgs e)
        {
            this.txtTransPortName.set_Text(string.Empty);
        }

        private void txtTransPortCode_Validating(object sender, CancelEventArgs e)
        {
            DataTable item;
            Service service;
            string str;
            string[] strArrays;
            if ((string.IsNullOrEmpty(this.txtTransPortCode.get_Text().Trim()) ? false : string.IsNullOrEmpty(this.txtTransPortName.get_Text())))
            {
                try
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        this.txtTransPortCode.set_Text(this.txtTransPortCode.get_Text().Trim().ToUpper());
                        switch (Property.TransactionType)
                        {
                            case Property.TransactionTypeEnum.PO:
                            case Property.TransactionTypeEnum.PI:
                            case Property.TransactionTypeEnum.PR:
                            case Property.TransactionTypeEnum.PRS:
                                {
                                    service = new Service();
                                    try
                                    {
                                        service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                        strArrays = new string[] { "Vendor_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), CommonLib.FormatString(this.txtTransPortCode.get_Text().Trim()) };
                                        item = service.GetData(strArrays).Tables[0];
                                        if (item.Rows.Count > 0)
                                        {
                                            this.txtTransPortName.set_Text(item.Rows[0]["Name"].ToString());
                                        }
                                    }
                                    finally
                                    {
                                        if (service != null)
                                        {
                                            ((IDisposable)service).Dispose();
                                        }
                                    }
                                    goto case Property.TransactionTypeEnum.TRI;
                                }
                            case Property.TransactionTypeEnum.SO:
                            case Property.TransactionTypeEnum.SR:
                                {
                                    service = new Service();
                                    try
                                    {
                                        service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                        strArrays = new string[] { "Customer_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), CommonLib.FormatString(this.txtTransPortCode.get_Text().Trim()) };
                                        item = service.GetData(strArrays).Tables[0];
                                        if (item.Rows.Count > 0)
                                        {
                                            this.txtTransPortName.set_Text(item.Rows[0]["Name"].ToString());
                                        }
                                    }
                                    finally
                                    {
                                        if (service != null)
                                        {
                                            ((IDisposable)service).Dispose();
                                        }
                                    }
                                    goto case Property.TransactionTypeEnum.TRI;
                                }
                            case Property.TransactionTypeEnum.SI:
                            case Property.TransactionTypeEnum.SRR:
                            case Property.TransactionTypeEnum.TRS:
                            case Property.TransactionTypeEnum.TRI:
                                {
                                    if (!string.IsNullOrEmpty(this.txtTransPortName.get_Text().Trim()))
                                    {
                                        switch (Property.TransactionType)
                                        {
                                            case Property.TransactionTypeEnum.PO:
                                            case Property.TransactionTypeEnum.PI:
                                            case Property.TransactionTypeEnum.PR:
                                            case Property.TransactionTypeEnum.PRS:
                                            case Property.TransactionTypeEnum.SO:
                                            case Property.TransactionTypeEnum.SR:
                                            case Property.TransactionTypeEnum.TRQ:
                                            case Property.TransactionTypeEnum.TRO:
                                                {
                                                    Property.TransactionPortCode = this.txtTransPortCode.get_Text();
                                                    Property.TransactionPortName = this.txtTransPortName.get_Text();
                                                    goto case Property.TransactionTypeEnum.TRI;
                                                }
                                            case Property.TransactionTypeEnum.SI:
                                            case Property.TransactionTypeEnum.SRR:
                                            case Property.TransactionTypeEnum.TRS:
                                            case Property.TransactionTypeEnum.TRI:
                                                {
                                                    break;
                                                }
                                            case Property.TransactionTypeEnum.ADJ:
                                            case Property.TransactionTypeEnum.SHRINK:
                                            case Property.TransactionTypeEnum.MISC:
                                                {
                                                    Property.DefaultReasonCode = this.txtTransPortCode.get_Text();
                                                    goto case Property.TransactionTypeEnum.TRI;
                                                }
                                            default:
                                                {
                                                    goto case Property.TransactionTypeEnum.TRI;
                                                }
                                        }
                                    }
                                    else
                                    {
                                        e.Cancel = true;
                                    }
                                    break;
                                }
                            case Property.TransactionTypeEnum.TRQ:
                            case Property.TransactionTypeEnum.TRO:
                                {
                                    if (this.txtTransPortCode.get_Text().Trim() != Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString())
                                    {
                                        service = new Service();
                                        try
                                        {
                                            service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                            strArrays = new string[] { "Location_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), CommonLib.FormatString(this.txtTransPortCode.get_Text().Trim()) };
                                            item = service.GetData(strArrays).Tables[0];
                                            if (item.Rows.Count > 0)
                                            {
                                                this.txtTransPortName.set_Text(item.Rows[0]["Name"].ToString());
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
                                    goto case Property.TransactionTypeEnum.TRI;
                                }
                            case Property.TransactionTypeEnum.ADJ:
                            case Property.TransactionTypeEnum.SHRINK:
                            case Property.TransactionTypeEnum.MISC:
                                {
                                    if (Property.TransactionType != Property.TransactionTypeEnum.ADJ)
                                    {
                                        str = (Property.TransactionType != Property.TransactionTypeEnum.SHRINK ? "MISC" : "SHRINK");
                                    }
                                    else
                                    {
                                        str = "WASTE";
                                    }
                                    service = new Service();
                                    try
                                    {
                                        service.Url = Property.Configuration.Tables[0].Rows[0]["SwitchURL"].ToString();
                                        strArrays = new string[] { "Reason_3000", Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), CommonLib.FormatString(this.txtTransPortCode.get_Text().Trim()) };
                                        DataRow[] dataRowArray = service.GetData(strArrays).Tables[0].Select(string.Format("[Type] = '{0}'", str));
                                        if ((int)dataRowArray.Length > 0)
                                        {
                                            this.txtTransPortName.set_Text(dataRowArray[0]["Name"].ToString());
                                        }
                                    }
                                    finally
                                    {
                                        if (service != null)
                                        {
                                            ((IDisposable)service).Dispose();
                                        }
                                    }
                                    goto case Property.TransactionTypeEnum.TRI;
                                }
                            default:
                                {
                                    goto case Property.TransactionTypeEnum.TRI;
                                }
                        }
                    }
                    catch (Exception exception1)
                    {
                        Exception exception = exception1;
                        e.Cancel = true;
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
}