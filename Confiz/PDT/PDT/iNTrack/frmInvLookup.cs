using iNTrack.AXiNTrackService;
using Resco.Controls.CommonControls;
using Resco.UIElements;
using Resco.UIElements.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace iNTrack
{
    public class frmInvLookup : Form
    {
        private IContainer components = null;

        private UIElementPanelControl pnlForm;

        private UILabel lblItemcode;

        private UITextBox txtItemcode;

        private UILabel lblDesc;

        private UITextBox txtDesc;

        private UILabel lblUOM;

        private UITextBox txtUOM;

        private ToolbarControl tbcMenu;

        private ToolbarItem tbiBack;

        private UITextBox txtStock;

        private UILabel lblSalesHist;

        private UITextBox txtSales30;

        private UILabel lblSales30;

        private UITextBox txtSales60;

        private UILabel lblSales60;

        private string m_sBarcode;

        public frmInvLookup(string Itemcode, string Barcode, string Description, string UOM)
        {
            this.InitializeComponent();
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int width = bounds.Width;
            bounds = Screen.PrimaryScreen.Bounds;
            base.Size = new Size(width, bounds.Height);
            this.AutoScroll = false;
            this.m_sBarcode = Barcode;
            this.txtItemcode.set_Text(Itemcode);
            this.txtDesc.set_Text(Description);
            this.txtUOM.set_Text(UOM);
        }

        protected override void Dispose(bool disposing)
        {
            if ((!disposing ? false : this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmInvLookup_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ApntAxHHTOnHandQtyServiceContract[] onHandQtyItemSold = Property.AXClient.getOnHandQtyItemSold(Property.Configuration.Tables[0].Rows[0]["CompanyID"].ToString(), this.txtItemcode.get_Text(), Property.Configuration.Tables[0].Rows[0]["LocationID"].ToString(), string.Empty);
                    if ((int)onHandQtyItemSold.Length <= 0)
                    {
                        this.txtStock.set_Text("0");
                        this.txtSales30.set_Text("0");
                        this.txtSales60.set_Text("0");
                    }
                    else
                    {
                        UITextBox uITextBox = this.txtStock;
                        decimal inventQty = onHandQtyItemSold[0].InventQty;
                        uITextBox.set_Text(inventQty.ToString());
                        UITextBox uITextBox1 = this.txtSales30;
                        inventQty = onHandQtyItemSold[0].TotalItemsSold30Days;
                        uITextBox1.set_Text(inventQty.ToString());
                        UITextBox uITextBox2 = this.txtSales60;
                        inventQty = onHandQtyItemSold[0].TotalItemsSold60Days;
                        uITextBox2.set_Text(inventQty.ToString());
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
            this.pnlForm = new UIElementPanelControl();
            this.lblSalesHist = new UILabel();
            this.lblItemcode = new UILabel();
            this.txtItemcode = new UITextBox();
            this.lblDesc = new UILabel();
            this.txtDesc = new UITextBox();
            this.lblUOM = new UILabel();
            this.txtUOM = new UITextBox();
            this.txtStock = new UITextBox();
            this.txtSales30 = new UITextBox();
            this.lblSales30 = new UILabel();
            this.txtSales60 = new UITextBox();
            this.lblSales60 = new UILabel();
            this.tbcMenu = new ToolbarControl();
            this.tbiBack = new ToolbarItem();
            this.pnlForm.SuspendElementLayout();
            base.SuspendLayout();
            this.pnlForm.BackColor = Color.FromArgb(213, 231, 255);
            this.pnlForm.set_BackgroundImageLayout(6);
            this.pnlForm.get_Children().Add(this.lblSalesHist);
            this.pnlForm.get_Children().Add(this.lblItemcode);
            this.pnlForm.get_Children().Add(this.txtItemcode);
            this.pnlForm.get_Children().Add(this.lblDesc);
            this.pnlForm.get_Children().Add(this.txtDesc);
            this.pnlForm.get_Children().Add(this.lblUOM);
            this.pnlForm.get_Children().Add(this.txtUOM);
            this.pnlForm.get_Children().Add(this.txtStock);
            this.pnlForm.get_Children().Add(this.txtSales30);
            this.pnlForm.get_Children().Add(this.lblSales30);
            this.pnlForm.get_Children().Add(this.txtSales60);
            this.pnlForm.get_Children().Add(this.lblSales60);
            this.pnlForm.Dock = DockStyle.Fill;
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new Size(318, 294);
            this.pnlForm.TabIndex = 4;
            this.lblSalesHist.set_AutoSize(false);
            this.lblSalesHist.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblSalesHist.set_Layout(new ElementLayout(0, 0, 4, 95, 0, 0, 60, 26));
            this.lblSalesHist.set_Name("lblSalesHist");
            this.lblSalesHist.set_TabIndex(12);
            this.lblSalesHist.set_Text("Sales Hist.");
            this.lblSalesHist.set_TextAlignment(2);
            this.lblItemcode.set_AutoSize(false);
            this.lblItemcode.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblItemcode.set_Layout(new ElementLayout(0, 0, 4, 4, 0, 0, 60, 26));
            this.lblItemcode.set_Name("lblItemcode");
            this.lblItemcode.set_TabIndex(9);
            this.lblItemcode.set_Text("Itemcode");
            this.lblItemcode.set_TextAlignment(2);
            this.txtItemcode.set_Layout(new ElementLayout(3, 0, 69, 4, 6, 0, 163, 26));
            this.txtItemcode.set_Name("txtItemcode");
            this.txtItemcode.set_ReadOnly(true);
            this.txtItemcode.set_TabIndex(13);
            this.txtItemcode.set_TabStop(false);
            this.lblDesc.set_AutoSize(false);
            this.lblDesc.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblDesc.set_Layout(new ElementLayout(0, 0, 4, 31, 0, 0, 60, 36));
            this.lblDesc.set_Name("lblDesc");
            this.lblDesc.set_TabIndex(10);
            this.lblDesc.set_Text("Desc");
            this.lblDesc.set_TextAlignment(2);
            this.txtDesc.set_Layout(new ElementLayout(3, 0, 69, 31, 6, 0, 163, 36));
            this.txtDesc.set_Multiline(true);
            this.txtDesc.set_Name("txtDesc");
            this.txtDesc.set_ReadOnly(true);
            this.txtDesc.set_TabIndex(1);
            this.txtDesc.set_TabStop(false);
            this.lblUOM.set_AutoSize(false);
            this.lblUOM.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblUOM.set_Layout(new ElementLayout(0, 0, 4, 68, 0, 0, 71, 26));
            this.lblUOM.set_Name("lblUOM");
            this.lblUOM.set_TabIndex(12);
            this.lblUOM.set_Text("UOM/Stock");
            this.lblUOM.set_TextAlignment(2);
            this.txtUOM.set_Layout(new ElementLayout(0, 0, 69, 68, 0, 0, 81, 26));
            this.txtUOM.set_Name("txtUOM");
            this.txtUOM.set_ReadOnly(true);
            this.txtUOM.set_TabIndex(2);
            this.txtUOM.set_TabStop(false);
            this.txtStock.set_Layout(new ElementLayout(0, 0, 151, 68, 0, 0, 81, 26));
            this.txtStock.set_Name("txtStock");
            this.txtStock.set_ReadOnly(true);
            this.txtStock.set_TabIndex(3);
            this.txtStock.set_TabStop(false);
            this.txtSales30.set_Layout(new ElementLayout(0, 0, 69, 95, 0, 0, 81, 26));
            this.txtSales30.set_Name("txtSales30");
            this.txtSales30.set_ReadOnly(true);
            this.txtSales30.set_TabIndex(4);
            this.txtSales30.set_TabStop(false);
            this.lblSales30.set_AutoSize(false);
            this.lblSales30.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblSales30.set_Layout(new ElementLayout(0, 0, 69, 123, 0, 0, 80, 15));
            this.lblSales30.set_Name("lblSales30");
            this.lblSales30.set_TabIndex(12);
            this.lblSales30.set_Text("30 Days");
            this.lblSales30.set_TextAlignment(8);
            this.txtSales60.set_Layout(new ElementLayout(0, 0, 151, 95, 0, 0, 81, 26));
            this.txtSales60.set_Name("txtSales60");
            this.txtSales60.set_ReadOnly(true);
            this.txtSales60.set_TabIndex(5);
            this.txtSales60.set_TabStop(false);
            this.lblSales60.set_AutoSize(false);
            this.lblSales60.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblSales60.set_Layout(new ElementLayout(0, 0, 150, 123, 0, 0, 80, 15));
            this.lblSales60.set_Name("lblSales60");
            this.lblSales60.set_TabIndex(12);
            this.lblSales60.set_Text("60 Days");
            this.lblSales60.set_TextAlignment(0);
            this.tbcMenu.set_ArrowsTransparency(0);
            this.tbcMenu.BackColor = Color.Black;
            this.tbcMenu.set_BmpArrowNext(imgManager.GetImage("iNTrack.Arrow Right2"));
            this.tbcMenu.set_BmpArrowPrevious(imgManager.GetImage("iNTrack.Arrow Left2"));
            this.tbcMenu.BorderStyle = BorderStyle.FixedSingle;
            this.tbcMenu.Dock = DockStyle.Bottom;
            this.tbcMenu.set_EnableArrowsTransparency(false);
            this.tbcMenu.ForeColor = Color.Black;
            this.tbcMenu.get_Items().Add(this.tbiBack);
            this.tbcMenu.set_ItemsAlignment(4);
            this.tbcMenu.set_ItemSpacing(10);
            this.tbcMenu.Location = new Point(0, 244);
            this.tbcMenu.Name = "tbcMenu";
            this.tbcMenu.Size = new Size(318, 50);
            this.tbcMenu.TabIndex = 7;
            this.tbcMenu.add_SelectionChanged(new EventHandler(this.tbcMenu_SelectionChanged));
            this.tbiBack.set_BackColor(Color.Black);
            this.tbiBack.set_CustomSize(new Size(0, 0));
            this.tbiBack.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Left"));
            this.tbiBack.set_Name("tbiBack");
            this.tbiBack.set_ToolbarItemBehavior(2);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(318, 294);
            base.ControlBox = false;
            base.Controls.Add(this.tbcMenu);
            base.Controls.Add(this.pnlForm);
            base.MinimizeBox = false;
            base.Name = "frmInvLookup";
            this.Text = ":: Inventory Lookup";
            base.Load += new EventHandler(this.frmInvLookup_Load);
            this.pnlForm.ResumeElementLayout(false);
            base.ResumeLayout(false);
        }

        private void tbcMenu_SelectionChanged(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
        }
    }
}