using iNTrack.iNTrackService;
using Resco.Controls.CommonControls;
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
    public class frmPriceCheck : Form
    {
        private IContainer components = null;

        private UIElementPanelControl pnlForm;

        private UILabel lblBarcode;

        private UILabel lblItemcode;

        private UILabel lblDesc;

        private UITextBox txtDesc;

        private UILabel lblUOM;

        private UITextBox txtCostPrice;

        private UILabel lblSalesPrice;

        private UITextBox txtSalesPrice;

        private ToolbarControl tbcMenu;

        private ToolbarItem tbiBack;

        private ToolbarItem tbiLookup;

        private UIComboBox cmbUOM;

        private UITextBox txtBarcode;

        private UITextBoxButton btnBarcode;

        private UITextBox txtItemcode;

        private UITextBoxButton btnItemcode;

        private UILabel lblVendor;

        private UITextBox txtVendor;

        private bool m_bIsItemValidated;

        private DataTable m_dtItem;

        public frmPriceCheck()
        {
            this.InitializeComponent();
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int width = bounds.Width;
            bounds = Screen.PrimaryScreen.Bounds;
            base.Size = new Size(width, bounds.Height);
            this.AutoScroll = false;
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

        private void frmPriceCheck_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.tbiLookup.set_Enabled(false);
                    this.txtCostPrice.set_Visible(Property.ShowCostPrice);
                    this.txtBarcode.Focus();
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
                if (dataRow == null)
                {
                    if (this.txtBarcode.get_Text().Length == 0)
                    {
                        throw new Exception("Invalid itemcode");
                    }
                    throw new Exception("Invalid barcode");
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
                this.tbiLookup.set_Enabled(true);
                this.m_bIsItemValidated = true;
                this.txtBarcode.Focus();
                this.txtBarcode.SelectAll();
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

        private void InitializeComponent()
        {
            this.tbcMenu = new ToolbarControl();
            this.tbiBack = new ToolbarItem();
            this.tbiLookup = new ToolbarItem();
            this.pnlForm = new UIElementPanelControl();
            this.lblSalesPrice = new UILabel();
            this.lblBarcode = new UILabel();
            this.lblItemcode = new UILabel();
            this.lblDesc = new UILabel();
            this.txtDesc = new UITextBox();
            this.lblUOM = new UILabel();
            this.txtCostPrice = new UITextBox();
            this.txtSalesPrice = new UITextBox();
            this.cmbUOM = new UIComboBox();
            this.txtBarcode = new UITextBox();
            this.btnBarcode = new UITextBoxButton();
            this.txtItemcode = new UITextBox();
            this.btnItemcode = new UITextBoxButton();
            this.lblVendor = new UILabel();
            this.txtVendor = new UITextBox();
            this.pnlForm.SuspendElementLayout();
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
            this.tbcMenu.get_Items().Add(this.tbiLookup);
            this.tbcMenu.set_ItemsAlignment(4);
            this.tbcMenu.set_ItemSpacing(5);
            this.tbcMenu.Location = new Point(0, 244);
            this.tbcMenu.Name = "tbcMenu";
            this.tbcMenu.Size = new Size(318, 50);
            this.tbcMenu.set_StretchBackgroundImage(true);
            this.tbcMenu.TabIndex = 6;
            this.tbcMenu.add_SelectionChanged(new EventHandler(this.tbcMenu_SelectionChanged));
            this.tbiBack.set_BackColor(Color.Black);
            this.tbiBack.set_CustomSize(new Size(0, 0));
            this.tbiBack.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Left"));
            this.tbiBack.set_Name("tbiBack");
            this.tbiBack.set_ToolbarItemBehavior(2);
            this.tbiLookup.set_BackColor(Color.Black);
            this.tbiLookup.set_CustomSize(new Size(0, 0));
            this.tbiLookup.set_ImageDefault(imgManager.GetImage("iNTrack.Info"));
            this.tbiLookup.set_Name("tbiLookup");
            this.tbiLookup.set_ToolbarItemBehavior(2);
            this.tbiLookup.set_Visible(false);
            this.pnlForm.set_BackgroundImage(imgManager.GetImage("iNTrack.BGP"));
            this.pnlForm.set_BackgroundImageLayout(6);
            this.pnlForm.get_Children().Add(this.lblSalesPrice);
            this.pnlForm.get_Children().Add(this.lblBarcode);
            this.pnlForm.get_Children().Add(this.lblItemcode);
            this.pnlForm.get_Children().Add(this.lblDesc);
            this.pnlForm.get_Children().Add(this.txtDesc);
            this.pnlForm.get_Children().Add(this.lblUOM);
            this.pnlForm.get_Children().Add(this.txtCostPrice);
            this.pnlForm.get_Children().Add(this.txtSalesPrice);
            this.pnlForm.get_Children().Add(this.cmbUOM);
            this.pnlForm.get_Children().Add(this.txtBarcode);
            this.pnlForm.get_Children().Add(this.txtItemcode);
            this.pnlForm.get_Children().Add(this.lblVendor);
            this.pnlForm.get_Children().Add(this.txtVendor);
            this.pnlForm.Dock = DockStyle.Fill;
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new Size(318, 294);
            this.pnlForm.TabIndex = 7;
            this.lblSalesPrice.set_AutoSize(false);
            this.lblSalesPrice.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblSalesPrice.set_Layout(new ElementLayout(0, 0, 5, 160, 0, 0, 65, 26));
            this.lblSalesPrice.set_Name("lblSalesPrice");
            this.lblSalesPrice.set_TabIndex(14);
            this.lblSalesPrice.set_Text("Price");
            this.lblSalesPrice.set_TextAlignment(2);
            this.lblBarcode.set_AutoSize(false);
            this.lblBarcode.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblBarcode.set_Layout(new ElementLayout(0, 0, 5, 5, 0, 0, 65, 26));
            this.lblBarcode.set_Name("lblBarcode");
            this.lblBarcode.set_TabIndex(8);
            this.lblBarcode.set_Text("Barcode");
            this.lblBarcode.set_TextAlignment(2);
            this.lblItemcode.set_AutoSize(false);
            this.lblItemcode.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblItemcode.set_Layout(new ElementLayout(0, 0, 5, 32, 0, 0, 65, 26));
            this.lblItemcode.set_Name("lblItemcode");
            this.lblItemcode.set_TabIndex(9);
            this.lblItemcode.set_Text("Itemcode");
            this.lblItemcode.set_TextAlignment(2);
            this.lblDesc.set_AutoSize(false);
            this.lblDesc.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblDesc.set_Layout(new ElementLayout(0, 0, 5, 59, 0, 0, 60, 36));
            this.lblDesc.set_Name("lblDesc");
            this.lblDesc.set_TabIndex(10);
            this.lblDesc.set_Text("Desc");
            this.lblDesc.set_TextAlignment(2);
            this.txtDesc.set_Layout(new ElementLayout(3, 0, 70, 59, 3, 0, 245, 36));
            this.txtDesc.set_Multiline(true);
            this.txtDesc.set_Name("txtDesc");
            this.txtDesc.set_ReadOnly(true);
            this.txtDesc.set_TabIndex(2);
            this.lblUOM.set_AutoSize(false);
            this.lblUOM.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblUOM.set_Layout(new ElementLayout(0, 0, 5, 96, 0, 0, 65, 26));
            this.lblUOM.set_Name("lblUOM");
            this.lblUOM.set_TabIndex(12);
            this.lblUOM.set_Text("UOM");
            this.lblUOM.set_TextAlignment(2);
            this.txtCostPrice.set_Layout(new ElementLayout(0, 0, 153, 160, 0, 0, 82, 26));
            this.txtCostPrice.set_Name("txtCostPrice");
            this.txtCostPrice.set_ReadOnly(true);
            this.txtCostPrice.set_TabIndex(5);
            this.txtSalesPrice.set_Layout(new ElementLayout(0, 0, 70, 160, 0, 0, 82, 26));
            this.txtSalesPrice.set_Name("txtSalesPrice");
            this.txtSalesPrice.set_ReadOnly(true);
            this.txtSalesPrice.set_TabIndex(4);
            this.cmbUOM.set_BackColor(SystemColors.Window);
            this.cmbUOM.set_DropDownWidth(100);
            this.cmbUOM.set_Layout(new ElementLayout(0, 0, 70, 96, 0, 0, 82, 26));
            this.cmbUOM.set_Name("cmbUOM");
            this.cmbUOM.set_TabIndex(3);
            this.cmbUOM.add_SelectedIndexChanged(new EventHandler(this.cmbUOM_SelectedIndexChanged));
            this.cmbUOM.add_Click(new UIMouseEventHandler(this, frmPriceCheck.cmbUOM_Click));
            this.txtBarcode.get_Buttons().Add(this.btnBarcode);
            this.txtBarcode.set_Layout(new ElementLayout(3, 0, 70, 5, 3, 0, 245, 26));
            this.txtBarcode.set_Name("txtBarcode");
            this.txtBarcode.set_TabIndex(15);
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
            this.txtItemcode.set_Layout(new ElementLayout(3, 0, 70, 32, 3, 0, 245, 26));
            this.txtItemcode.set_Name("txtItemcode");
            this.txtItemcode.set_TabIndex(1);
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
            this.lblVendor.set_AutoSize(false);
            this.lblVendor.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblVendor.set_Layout(new ElementLayout(0, 0, 5, 123, 0, 0, 65, 36));
            this.lblVendor.set_Name("lblVendor");
            this.lblVendor.set_TabIndex(14);
            this.lblVendor.set_Text("Vendor");
            this.lblVendor.set_TextAlignment(2);
            this.txtVendor.set_Layout(new ElementLayout(3, 0, 70, 123, 3, 0, 245, 36));
            this.txtVendor.set_Multiline(true);
            this.txtVendor.set_Name("txtVendor");
            this.txtVendor.set_ReadOnly(true);
            this.txtVendor.set_TabIndex(4);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(318, 294);
            base.ControlBox = false;
            base.Controls.Add(this.tbcMenu);
            base.Controls.Add(this.pnlForm);
            base.MinimizeBox = false;
            base.Name = "frmPriceCheck";
            base.Tag = "Price Check";
            this.Text = ":: Price Check";
            base.Load += new EventHandler(this.frmPriceCheck_Load);
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
                this.txtVendor.set_Text(string.Empty);
                this.txtSalesPrice.set_Text(string.Empty);
                this.txtCostPrice.set_Text(string.Empty);
                this.tbiLookup.set_Enabled(false);
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
                this.txtVendor.set_Text(string.Format("{0} {1}", datarow["Vendor Code"].ToString(), datarow["Vendor Name"].ToString()));
                UITextBox uITextBox = this.txtSalesPrice;
                double num = double.Parse(datarow["Sales Price"].ToString());
                uITextBox.set_Text(num.ToString("F"));
                UITextBox uITextBox1 = this.txtCostPrice;
                num = double.Parse(datarow["Unit Price"].ToString());
                uITextBox1.set_Text(num.ToString("F"));
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
                                CommonLib.SwitchForm(new frmHome());
                                break;
                            }
                        case 1:
                            {
                                if (string.IsNullOrEmpty(this.txtBarcode.get_Text()))
                                {
                                    throw new Exception("Invalid barcode");
                                }
                                break;
                            }
                        case 2:
                            {
                                this.ResetControls();
                                this.txtBarcode.set_Text(string.Empty);
                                this.txtBarcode.Focus();
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
                            Application.DoEvents();
                            Cursor.Current = Cursors.WaitCursor;
                            this.GetItemDetail(string.Empty);
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
    }
}