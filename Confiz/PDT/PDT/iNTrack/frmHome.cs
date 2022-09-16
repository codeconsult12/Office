using Resco.UIElements;
using Resco.UIElements.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace iNTrack
{
    public class frmHome : Form
    {
        private IContainer components = null;

        private UIElementPanelControl pnlUIElements;

        private UIGridPanel gpMenu;

        private UIButton btnPriceChecker;

        private UIButton btnPurchase;

        private UIButton btnItemCard;

        private UIButton btnSales;

        private UIButton btnStore;

        private UIButton btnCount;

        private UIButton btnLogout;

        private UIButton btnDeviceSetup;

        private UIButton btnPrint;

        public frmHome()
        {
            this.InitializeComponent();
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int width = bounds.Width;
            bounds = Screen.PrimaryScreen.Bounds;
            base.Size = new Size(width, bounds.Height);
            this.AutoScroll = false;
        }

        private void btnPriceChecker_Click(object sender, UIMouseEventArgs e)
        {
            try
            {
                string str = ((UIButton)sender).get_Tag().ToString();
                if (str != null)
                {
                    switch (str)
                    {
                        case "Price Checker":
                            {
                                if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionTypeEnum.PC.ToString())).Length == 0)
                                {
                                    throw new Exception("User access has been denied");
                                }
                                CommonLib.SwitchForm(new frmPriceCheck());
                                break;
                            }
                        case "Print":
                            {
                                Property.Module = Property.ModuleEnum.Print;
                                CommonLib.SwitchForm(new frmOptions());
                                break;
                            }
                        case "Item Card":
                            {
                                if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionTypeEnum.IC.ToString())).Length == 0)
                                {
                                    throw new Exception("User access has been denied");
                                }
                                CommonLib.SwitchForm(new frmItems(frmItems.ParentForm.Home));
                                break;
                            }
                        case "Purchase":
                            {
                                Property.Module = Property.ModuleEnum.Purchase;
                                CommonLib.SwitchForm(new frmOptions());
                                break;
                            }
                        case "Sales":
                            {
                                Property.Module = Property.ModuleEnum.Sales;
                                CommonLib.SwitchForm(new frmOptions());
                                break;
                            }
                        case "Store":
                            {
                                Property.Module = Property.ModuleEnum.Store;
                                CommonLib.SwitchForm(new frmOptions());
                                break;
                            }
                        case "Count":
                            {
                                Property.Module = Property.ModuleEnum.Count;
                                CommonLib.SwitchForm(new frmOptions());
                                break;
                            }
                        case "Device Setup":
                            {
                                if ((int)Property.UserPermission.Select(string.Format("[Transaction Type] = '{0}'", Property.TransactionTypeEnum.SET.ToString())).Length == 0)
                                {
                                    throw new Exception("User access has been denied");
                                }
                                CommonLib.SwitchForm(new frmDevSetup());
                                break;
                            }
                        case "Logout":
                            {
                                CommonLib.SwitchForm(Property.PrincipalForm);
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

        protected override void Dispose(bool disposing)
        {
            if ((!disposing ? false : this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    this.SetGranules();
                    Property.Module = Property.ModuleEnum.None;
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
            this.pnlUIElements = new UIElementPanelControl();
            this.gpMenu = new UIGridPanel();
            this.btnPriceChecker = new UIButton();
            this.btnPurchase = new UIButton();
            this.btnItemCard = new UIButton();
            this.btnSales = new UIButton();
            this.btnStore = new UIButton();
            this.btnCount = new UIButton();
            this.btnLogout = new UIButton();
            this.btnDeviceSetup = new UIButton();
            this.btnPrint = new UIButton();
            this.pnlUIElements.SuspendElementLayout();
            base.SuspendLayout();
            this.pnlUIElements.BackColor = Color.Black;
            this.pnlUIElements.set_BorderColor(Color.Black);
            this.pnlUIElements.get_Children().Add(this.gpMenu);
            this.pnlUIElements.Dock = DockStyle.Fill;
            this.pnlUIElements.Name = "pnlUIElements";
            this.pnlUIElements.Size = new Size(320, 320);
            this.gpMenu.set_BackColor(Color.Black);
            this.gpMenu.get_Children().Add(this.btnPriceChecker, 0, 0);
            this.gpMenu.get_Children().Add(this.btnPurchase, 0, 1);
            this.gpMenu.get_Children().Add(this.btnItemCard, 1, 0);
            this.gpMenu.get_Children().Add(this.btnSales, 1, 1);
            this.gpMenu.get_Children().Add(this.btnStore, 0, 2);
            this.gpMenu.get_Children().Add(this.btnCount, 1, 2);
            this.gpMenu.get_Children().Add(this.btnLogout, 1, 3);
            this.gpMenu.get_Children().Add(this.btnDeviceSetup, 0, 3);
            this.gpMenu.get_Children().Add(this.btnPrint, 1, 0);
            this.gpMenu.get_Columns().Add(new GridLinePosition(100, 0, true));
            this.gpMenu.get_Columns().Add(new GridLinePosition(100, 0, true));
            this.gpMenu.set_IsFocusable(true);
            // JB    this.gpMenu.set_Layout(new ElementLayout(3, 0, 0, 0, 0, 0, 320, 320));
            this.gpMenu.set_Name("gpMenu");
            this.gpMenu.get_Rows().Add(new GridLinePosition(100, 0, true));
            this.gpMenu.get_Rows().Add(new GridLinePosition(100, 0, true));
            this.gpMenu.get_Rows().Add(new GridLinePosition(100, 0, true));
            this.gpMenu.get_Rows().Add(new GridLinePosition(100, 0, true));
            this.gpMenu.set_TabIndex(1);
            this.btnPriceChecker.set_AutoEllipsis(true);
            this.btnPriceChecker.set_BackColor(Color.Black);
            this.btnPriceChecker.set_BorderColor(Color.FromArgb(0, 0, 0));
            this.btnPriceChecker.set_Font(new Font("Tahoma", 10f, FontStyle.Bold));
            this.btnPriceChecker.set_ForeColor(Color.White);
            this.btnPriceChecker.set_Image(imgManager.GetImage("iNTrack.Search"));
            this.btnPriceChecker.set_IsFocusable(false);
           //JB this.btnPriceChecker.set_Layout(new ElementLayout(3, 1, 0, 0, 0, 0, 160, 72));
            this.btnPriceChecker.set_Name("btnPriceChecker");
            this.btnPriceChecker.set_TabIndex(10);
            this.btnPriceChecker.set_Tag("Price Checker");
            this.btnPriceChecker.set_Text("Price Checker");
            this.btnPriceChecker.set_TextImageRelation(3);
          //JB   this.btnPriceChecker.add_Click(new UIMouseEventHandler(this, frmHome.btnPriceChecker_Click));
            this.btnPurchase.set_AutoEllipsis(true);
            this.btnPurchase.set_BackColor(Color.Black);
            this.btnPurchase.set_BorderColor(Color.FromArgb(0, 0, 0));
            this.btnPurchase.set_Font(new Font("Tahoma", 10f, FontStyle.Bold));
            this.btnPurchase.set_ForeColor(Color.White);
            this.btnPurchase.set_Image(imgManager.GetImage("iNTrack.Quotes"));
            this.btnPurchase.set_IsFocusable(false);
          // JB  this.btnPurchase.set_Layout(new ElementLayout(3, 1, 0, 0, 0, 0, 160, 72));
            this.btnPurchase.set_Name("btnPurchase");
            this.btnPurchase.set_TabIndex(2);
            this.btnPurchase.set_Tag("Purchase");
            this.btnPurchase.set_Text("Purchase");
            this.btnPurchase.set_TextImageRelation(3);
            // JB   this.btnPurchase.add_Click(new UIMouseEventHandler(this, frmHome.btnPriceChecker_Click));
            this.btnItemCard.set_AutoEllipsis(true);
            this.btnItemCard.set_BackColor(Color.Black);
            this.btnItemCard.set_BorderColor(Color.FromArgb(0, 0, 0));
            this.btnItemCard.set_Font(new Font("Tahoma", 10f, FontStyle.Bold));
            this.btnItemCard.set_ForeColor(Color.White);
            this.btnItemCard.set_Image(imgManager.GetImage("iNTrack.Dots"));
            this.btnItemCard.set_IsFocusable(false);
          // JB  this.btnItemCard.set_Layout(new ElementLayout(3, 1, 0, 0, 0, 0, 160, 72));
            this.btnItemCard.set_Name("btnItemCard");
            this.btnItemCard.set_TabIndex(1);
            this.btnItemCard.set_Tag("Item Card");
            this.btnItemCard.set_Text("Item Card");
            this.btnItemCard.set_TextImageRelation(3);
            this.btnItemCard.set_Visible(false);
          // JB  this.btnItemCard.add_Click(new UIMouseEventHandler(this, frmHome.btnPriceChecker_Click));
            this.btnSales.set_AutoEllipsis(true);
            this.btnSales.set_BackColor(Color.Black);
            this.btnSales.set_BorderColor(Color.FromArgb(0, 0, 0));
            this.btnSales.set_Font(new Font("Tahoma", 10f, FontStyle.Bold));
            this.btnSales.set_ForeColor(Color.White);
            this.btnSales.set_Image(imgManager.GetImage("iNTrack.Sale"));
            this.btnSales.set_IsFocusable(false);
         // JB   this.btnSales.set_Layout(new ElementLayout(3, 1, 0, 0, 0, 0, 160, 72));
            this.btnSales.set_Name("btnSales");
            this.btnSales.set_TabIndex(3);
            this.btnSales.set_Tag("Sales");
            this.btnSales.set_Text("Sales");
            this.btnSales.set_TextImageRelation(3);
         // JB   this.btnSales.add_Click(new UIMouseEventHandler(this, frmHome.btnPriceChecker_Click));
            this.btnStore.set_AutoEllipsis(true);
            this.btnStore.set_BackColor(Color.Black);
            this.btnStore.set_Font(new Font("Tahoma", 10f, FontStyle.Bold));
            this.btnStore.set_ForeColor(Color.White);
            this.btnStore.set_Image(imgManager.GetImage("iNTrack.Cart2"));
            this.btnStore.set_IsFocusable(false);
         // JB   this.btnStore.set_Layout(new ElementLayout(3, 1, 0, 0, 0, 0, 160, 72));
            this.btnStore.set_Name("btnStore");
            this.btnStore.set_TabIndex(4);
            this.btnStore.set_Tag("Store");
            this.btnStore.set_Text("Store");
            this.btnStore.set_TextImageRelation(3);
            // JB    this.btnStore.add_Click(new UIMouseEventHandler(this, frmHome.btnPriceChecker_Click));
            this.btnCount.set_AutoEllipsis(true);
            this.btnCount.set_BackColor(Color.Black);
            this.btnCount.set_Font(new Font("Tahoma", 10f, FontStyle.Bold));
            this.btnCount.set_ForeColor(Color.White);
            this.btnCount.set_Image(imgManager.GetImage("iNTrack.Inventory"));
            this.btnCount.set_IsFocusable(false);
            // JB    this.btnCount.set_Layout(new ElementLayout(3, 1, 0, 0, 0, 0, 160, 72));
            this.btnCount.set_Name("btnCount");
            this.btnCount.set_TabIndex(5);
            this.btnCount.set_Tag("Count");
            this.btnCount.set_Text("Count");
            this.btnCount.set_TextImageRelation(3);
            // JB    this.btnCount.add_Click(new UIMouseEventHandler(this, frmHome.btnPriceChecker_Click));
            this.btnLogout.set_AutoEllipsis(true);
            this.btnLogout.set_BackColor(Color.Black);
            this.btnLogout.set_Font(new Font("Tahoma", 10f, FontStyle.Bold));
            this.btnLogout.set_ForeColor(Color.White);
            this.btnLogout.set_Image(imgManager.GetImage("iNTrack.Go Out"));
            this.btnLogout.set_IsFocusable(false);
            // JB   this.btnLogout.set_Layout(new ElementLayout(3, 3, 0, 0, 0, 0, 160, 80));
            this.btnLogout.set_Name("btnLogout");
            this.btnLogout.set_TabIndex(9);
            this.btnLogout.set_Tag("Logout");
            this.btnLogout.set_Text("Logout");
            this.btnLogout.set_TextImageRelation(3);
            // JB    this.btnLogout.add_Click(new UIMouseEventHandler(this, frmHome.btnPriceChecker_Click));
            this.btnDeviceSetup.set_AutoEllipsis(true);
            this.btnDeviceSetup.set_BackColor(Color.Black);
            this.btnDeviceSetup.set_Font(new Font("Tahoma", 10f, FontStyle.Bold));
            this.btnDeviceSetup.set_ForeColor(Color.White);
            this.btnDeviceSetup.set_Image(imgManager.GetImage("iNTrack.Mobile"));
            this.btnDeviceSetup.set_IsFocusable(false);
            // JB    this.btnDeviceSetup.set_Layout(new ElementLayout(3, 3, 0, 0, 0, 0, 160, 80));
            this.btnDeviceSetup.set_Name("btnDeviceSetup");
            this.btnDeviceSetup.set_TabIndex(7);
            this.btnDeviceSetup.set_Tag("Device Setup");
            this.btnDeviceSetup.set_Text("Device Setup");
            this.btnDeviceSetup.set_TextImageRelation(3);
            // JB    this.btnDeviceSetup.add_Click(new UIMouseEventHandler(this, frmHome.btnPriceChecker_Click));
            this.btnPrint.set_AutoEllipsis(true);
            this.btnPrint.set_BackColor(Color.Black);
            this.btnPrint.set_BorderColor(Color.FromArgb(0, 0, 0));
            this.btnPrint.set_Font(new Font("Tahoma", 10f, FontStyle.Bold));
            this.btnPrint.set_ForeColor(Color.White);
            this.btnPrint.set_Image(imgManager.GetImage("iNTrack.Printer"));
            this.btnPrint.set_IsFocusable(false);
            // JB    this.btnPrint.set_Layout(new ElementLayout(3, 3, 0, 0, 0, 0, 160, 80));
            this.btnPrint.set_Name("btnPrint");
            this.btnPrint.set_TabIndex(1);
            this.btnPrint.set_Tag("Print");
            this.btnPrint.set_Text("Print");
            this.btnPrint.set_TextImageRelation(3);
            // JB    this.btnPrint.add_Click(new UIMouseEventHandler(this, frmHome.btnPriceChecker_Click));
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            // JB             base.AutoScaleMode = AutoScaleMode.Dpi;
            this.BackColor = Color.Black;
            base.ClientSize = new Size(320, 320);
            base.ControlBox = false;
            base.Controls.Add(this.pnlUIElements);
            this.ForeColor = Color.Black;
            // JB             base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.Location = new Point(-2, -2);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmHome";
            base.Tag = "App Menu";
            this.Text = ":: App Menu";
            base.Load += new EventHandler(this.frmHome_Load);
            this.pnlUIElements.ResumeElementLayout(false);
            base.ResumeLayout(false);
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
    }
}