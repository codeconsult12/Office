using Resco.Controls.CommonControls;
using Resco.UIElements;
using Resco.UIElements.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace iNTrack
{
    public class frmLicense : Form
    {
        private IContainer components = null;

        private UIElementPanelControl pnlForm;

        private ToolbarControl tbcMenu;

        private ToolbarItem tbiBack;

        private ToolbarItem tbiGenerate;

        private UILabel lblInfo1;

        public frmLicense()
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

        private void InitializeComponent()
        {
            this.pnlForm = new UIElementPanelControl();
            this.lblInfo1 = new UILabel();
            this.tbcMenu = new ToolbarControl();
            this.tbiBack = new ToolbarItem();
            this.tbiGenerate = new ToolbarItem();
            this.pnlForm.SuspendElementLayout();
            base.SuspendLayout();
            this.pnlForm.BackColor = Color.FromArgb(213, 231, 255);
            this.pnlForm.set_BackgroundImageLayout(6);
            this.pnlForm.get_Children().Add(this.lblInfo1);
            this.pnlForm.Dock = DockStyle.Fill;
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new Size(318, 294);
            this.lblInfo1.set_AutoSize(false);
            this.lblInfo1.set_Font(new Font("Tahoma", 9f, FontStyle.Bold));
            this.lblInfo1.set_ForeColor(Color.Black);
            this.lblInfo1.set_Layout(new ElementLayout(3, 0, 3, 5, 2, 0, 313, 135));
            this.lblInfo1.set_Name("lblInfo1");
            this.lblInfo1.set_TabIndex(13);
            this.lblInfo1.set_Text("Please generate product key file and contact AP&T for license file to activate the product.\r\n\r\n\r\n\r\nNote: Product key can be found in iNTrack program files folder saved as iNTrack.key!!");
            this.lblInfo1.set_TextAlignment(2);
            this.tbcMenu.set_ArrowsTransparency(0);
            this.tbcMenu.BackColor = Color.Black;
            this.tbcMenu.set_BmpArrowNext(imgManager.GetImage("iNTrack.Arrow Right2"));
            this.tbcMenu.set_BmpArrowPrevious(imgManager.GetImage("iNTrack.Arrow Left2"));
            this.tbcMenu.BorderStyle = BorderStyle.FixedSingle;
            this.tbcMenu.Dock = DockStyle.Bottom;
            this.tbcMenu.set_EnableArrowsTransparency(false);
            this.tbcMenu.ForeColor = Color.Black;
            this.tbcMenu.get_Items().Add(this.tbiBack);
            this.tbcMenu.get_Items().Add(this.tbiGenerate);
            this.tbcMenu.set_ItemsAlignment(4);
            this.tbcMenu.set_ItemSpacing(5);
            this.tbcMenu.Location = new Point(0, 244);
            this.tbcMenu.Name = "tbcMenu";
            this.tbcMenu.Size = new Size(318, 50);
            this.tbcMenu.set_StretchBackgroundImage(true);
            this.tbcMenu.TabIndex = 1;
            this.tbcMenu.add_SelectionChanged(new EventHandler(this.tbcMenu_SelectionChanged));
            this.tbiBack.set_BackColor(Color.Black);
            this.tbiBack.set_CustomSize(new Size(0, 0));
            this.tbiBack.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Left"));
            this.tbiBack.set_ItemSizeType(1);
            this.tbiBack.set_Name("tbiBack");
            this.tbiBack.set_ToolbarItemBehavior(2);
            this.tbiGenerate.set_BackColor(Color.Black);
            this.tbiGenerate.set_CustomSize(new Size(0, 0));
            this.tbiGenerate.set_ImageDefault(imgManager.GetImage("iNTrack.Start"));
            this.tbiGenerate.set_ItemSizeType(1);
            this.tbiGenerate.set_Name("tbiGenerate");
            this.tbiGenerate.set_ToolbarItemBehavior(2);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(318, 294);
            base.ControlBox = false;
            base.Controls.Add(this.tbcMenu);
            base.Controls.Add(this.pnlForm);
            base.MinimizeBox = false;
            base.Name = "frmLicense";
            this.Text = ":: Product License";
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
                                base.Close();
                                break;
                            }
                        case 1:
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                string str = string.Concat(Property.ProgramPath, Path.DirectorySeparatorChar, "iNTrack.key");
                                string deviceID = InteropLib.GetDeviceID();
                                if (string.IsNullOrEmpty(deviceID))
                                {
                                    deviceID = InteropLib.GetDeviceID("AP&T-iNTrack");
                                }
                                StreamWriter streamWriter = new StreamWriter(str, false);
                                try
                                {
                                    streamWriter.WriteLine(CommonLib.Encrypt("apnttnpa", deviceID));
                                }
                                finally
                                {
                                    if (streamWriter != null)
                                    {
                                        ((IDisposable)streamWriter).Dispose();
                                    }
                                }
                                base.Close();
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
    }
}