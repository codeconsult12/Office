using Resco.Controls.CommonControls;
using Resco.UIElements;
using Resco.UIElements.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace iNTrack
{
    public class frmItem : Form
    {
        private IContainer components = null;

        private UIElementPanelControl pnlForm;

        private UILabel lblBarcode;

        private ToolbarControl tbcMenu;

        private ToolbarItem tbiBack;

        private UITextBox txtItemcode;

        private UILabel lblItemcode;

        private UITextBox txtBarcode;

        private UITextBox txtDesc;

        private UILabel lblDesc;

        private UILabel lblUOM;

        private UITextBox txtUOM;

        private UILabel lblPrice;

        private UITextBox txtPrice;

        private UILabel lblQuantity;

        private UITextBox txtQuantity;

        public frmItem(string Itemcode, string Barcode, string Description, string UOM, double SalesPrice, double Quantity)
        {
            this.InitializeComponent();
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int width = bounds.Width;
            bounds = Screen.PrimaryScreen.Bounds;
            base.Size = new Size(width, bounds.Height);
            this.AutoScroll = false;
            this.txtItemcode.set_Text(Itemcode);
            this.txtBarcode.set_Text(Barcode);
            this.txtDesc.set_Text(Description);
            this.txtUOM.set_Text(UOM);
            this.txtPrice.set_Text(SalesPrice.ToString());
            this.lblQuantity.set_Visible(Quantity > 0);
            this.txtQuantity.set_Visible(Quantity > 0);
            this.txtQuantity.set_Text(Quantity.ToString());
        }

        protected override void Dispose(bool disposing)
        {
            if ((!disposing ? false : this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tbcMenu = new ToolbarControl();
            this.tbiBack = new ToolbarItem();
            this.pnlForm = new UIElementPanelControl();
            this.lblPrice = new UILabel();
            this.lblBarcode = new UILabel();
            this.txtItemcode = new UITextBox();
            this.lblItemcode = new UILabel();
            this.txtBarcode = new UITextBox();
            this.txtDesc = new UITextBox();
            this.lblDesc = new UILabel();
            this.lblUOM = new UILabel();
            this.txtUOM = new UITextBox();
            this.txtPrice = new UITextBox();
            this.lblQuantity = new UILabel();
            this.txtQuantity = new UITextBox();
            this.pnlForm.SuspendElementLayout();
            base.SuspendLayout();
            this.tbcMenu.set_ArrowsTransparency(0);
            this.tbcMenu.BackColor = Color.Black;
            this.tbcMenu.set_BmpArrowNext(imgManager.GetImage("iNTrack.Arrow Right2"));
            this.tbcMenu.set_BmpArrowPrevious(imgManager.GetImage("iNTrack.Arrow Left2"));
            this.tbcMenu.Dock = DockStyle.Bottom;
            this.tbcMenu.set_EnableArrowsTransparency(false);
            this.tbcMenu.get_Items().Add(this.tbiBack);
            this.tbcMenu.set_ItemsAlignment(4);
            this.tbcMenu.Location = new Point(0, 243);
            this.tbcMenu.set_MarginAtBegin(40);
            this.tbcMenu.set_MarginAtEnd(40);
            this.tbcMenu.Name = "tbcMenu";
            this.tbcMenu.Size = new Size(318, 51);
            this.tbcMenu.TabIndex = 7;
            this.tbcMenu.add_SelectionChanged(new EventHandler(this.tbcMenu_SelectionChanged));
            this.tbiBack.set_BackColor(Color.Black);
            this.tbiBack.set_CustomSize(new Size(0, 0));
            this.tbiBack.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Left"));
            this.tbiBack.set_Name("tbiBack");
            this.tbiBack.set_ToolbarItemBehavior(2);
            this.pnlForm.set_BackgroundImage(imgManager.GetImage("iNTrack.BGP"));
            this.pnlForm.set_BackgroundImageLayout(6);
            this.pnlForm.get_Children().Add(this.lblPrice);
            this.pnlForm.get_Children().Add(this.lblBarcode);
            this.pnlForm.get_Children().Add(this.txtItemcode);
            this.pnlForm.get_Children().Add(this.lblItemcode);
            this.pnlForm.get_Children().Add(this.txtBarcode);
            this.pnlForm.get_Children().Add(this.txtDesc);
            this.pnlForm.get_Children().Add(this.lblDesc);
            this.pnlForm.get_Children().Add(this.lblUOM);
            this.pnlForm.get_Children().Add(this.txtUOM);
            this.pnlForm.get_Children().Add(this.txtPrice);
            this.pnlForm.get_Children().Add(this.lblQuantity);
            this.pnlForm.get_Children().Add(this.txtQuantity);
            this.pnlForm.Dock = DockStyle.Fill;
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new Size(318, 294);
            this.pnlForm.TabIndex = 3;
            this.lblPrice.set_AutoSize(false);
            this.lblPrice.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblPrice.set_Layout(new ElementLayout(0, 0, 5, 123, 0, 0, 54, 26));
            this.lblPrice.set_Name("lblPrice");
            this.lblPrice.set_TabIndex(13);
            this.lblPrice.set_Text("Price");
            this.lblPrice.set_TextAlignment(2);
            this.lblBarcode.set_AutoSize(false);
            this.lblBarcode.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblBarcode.set_Layout(new ElementLayout(0, 0, 5, 6, 0, 0, 60, 26));
            this.lblBarcode.set_Name("lblBarcode");
            this.lblBarcode.set_TabIndex(7);
            this.lblBarcode.set_Text("Barcode");
            this.lblBarcode.set_TextAlignment(2);
            this.txtItemcode.set_Layout(new ElementLayout(3, 0, 65, 32, 4, 0, 249, 26));
            this.txtItemcode.set_Name("txtItemcode");
            this.txtItemcode.set_ReadOnly(true);
            this.txtItemcode.set_TabIndex(1);
            this.lblItemcode.set_AutoSize(false);
            this.lblItemcode.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblItemcode.set_Layout(new ElementLayout(0, 0, 5, 33, 0, 0, 60, 26));
            this.lblItemcode.set_Name("lblItemcode");
            this.lblItemcode.set_TabIndex(7);
            this.lblItemcode.set_Text("Itemcode");
            this.lblItemcode.set_TextAlignment(2);
            this.txtBarcode.set_Layout(new ElementLayout(3, 0, 65, 5, 4, 0, 249, 26));
            this.txtBarcode.set_Name("txtBarcode");
            this.txtBarcode.set_ReadOnly(true);
            this.txtBarcode.set_SelectedForeColor(Color.FromArgb(255, 255, 255));
            this.txtBarcode.set_TabIndex(14);
            this.txtDesc.set_Layout(new ElementLayout(3, 0, 65, 59, 4, 0, 249, 36));
            this.txtDesc.set_Multiline(true);
            this.txtDesc.set_Name("txtDesc");
            this.txtDesc.set_ReadOnly(true);
            this.txtDesc.set_TabIndex(2);
            this.lblDesc.set_AutoSize(false);
            this.lblDesc.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblDesc.set_Layout(new ElementLayout(0, 0, 5, 59, 0, 0, 60, 36));
            this.lblDesc.set_Name("lblDesc");
            this.lblDesc.set_TabIndex(6);
            this.lblDesc.set_Text("Desc");
            this.lblDesc.set_TextAlignment(2);
            this.lblUOM.set_AutoSize(false);
            this.lblUOM.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblUOM.set_Layout(new ElementLayout(0, 0, 5, 95, 0, 0, 60, 26));
            this.lblUOM.set_Name("lblUOM");
            this.lblUOM.set_TabIndex(6);
            this.lblUOM.set_Text("UOM");
            this.lblUOM.set_TextAlignment(2);
            this.txtUOM.set_Layout(new ElementLayout(0, 0, 65, 96, 0, 0, 88, 26));
            this.txtUOM.set_Name("txtUOM");
            this.txtUOM.set_ReadOnly(true);
            this.txtUOM.set_SelectedForeColor(Color.FromArgb(255, 255, 255));
            this.txtUOM.set_TabIndex(4);
            this.txtPrice.set_Layout(new ElementLayout(0, 0, 65, 123, 0, 0, 88, 26));
            this.txtPrice.set_Name("txtPrice");
            this.txtPrice.set_ReadOnly(true);
            this.txtPrice.set_TabIndex(5);
            this.lblQuantity.set_AutoSize(false);
            this.lblQuantity.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblQuantity.set_Layout(new ElementLayout(0, 0, 5, 150, 0, 0, 54, 26));
            this.lblQuantity.set_Name("lblQuantity");
            this.lblQuantity.set_TabIndex(13);
            this.lblQuantity.set_Text("Quantity");
            this.lblQuantity.set_TextAlignment(2);
            this.txtQuantity.set_Layout(new ElementLayout(0, 0, 65, 150, 0, 0, 88, 26));
            this.txtQuantity.set_Name("txtQuantity");
            this.txtQuantity.set_TabIndex(6);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(318, 294);
            base.ControlBox = false;
            base.Controls.Add(this.tbcMenu);
            base.Controls.Add(this.pnlForm);
            base.MinimizeBox = false;
            base.Name = "frmItem";
            this.Text = ":: Item Detail";
            this.pnlForm.ResumeElementLayout(false);
            base.ResumeLayout(false);
        }

        private void tbcMenu_SelectionChanged(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
        }
    }
}