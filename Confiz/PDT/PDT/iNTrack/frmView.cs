using Resco.Controls.CommonControls;
using Resco.Controls.SmartGrid;
using Resco.UIElements;
using Resco.UIElements.Controls;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace iNTrack
{
    public class frmView : Form
    {
        private frmView.SourceEnum m_SourceEnum;

        private DataTable m_dtData = null;

        private IContainer components = null;

        private UIElementPanelControl pnlForm;

        private UILabel lblFilter;

        private UITextBox txtFilter;

        private UITextBoxButton btnBarcode;

        private ToolbarControl tbcMenu;

        private ToolbarItem tbiBack;

        private SmartGrid sgData;

        public frmView(frmView.SourceEnum Source, DataTable Data)
        {
            this.InitializeComponent();
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int width = bounds.Width;
            bounds = Screen.PrimaryScreen.Bounds;
            base.Size = new Size(width, bounds.Height);
            this.AutoScroll = false;
            this.m_SourceEnum = Source;
            if (this.m_SourceEnum == frmView.SourceEnum.Supplementary)
            {
                this.m_dtData = Data;
                this.lblFilter.set_Visible(false);
                this.txtFilter.Visible( set_Visible(false);
                this.sgData.Location = new Point(3, 3);
                this.sgData.Size = new Size(312, 239);
            }
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

        private void frmView_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (this.m_SourceEnum == frmView.SourceEnum.Supplementary)
                    {
                        foreach (DataRow row in this.m_dtData.Copy().Rows)
                        {
                            this.m_dtData = new DataTable();
                            this.m_dtData.Columns.Add("Deal");
                            object[] item = new object[] { row["purchQty"], row["PurchUnit"], row["ItemName"], null, null, null, null, null };
                            DateTime date = (DateTime)row["FromDate"];
                            date = date.Date;
                            item[3] = date.ToString("dd/MM/yyyy");
                            date = (DateTime)row["ToDate"];
                            date = date.Date;
                            item[4] = date.ToString("dd/MM/yyyy");
                            item[5] = row["suppQty"];
                            item[6] = row["SuppUnit"];
                            item[7] = row["SuppItemName"];
                            string str = string.Format("Buy {0} {1} of {2} between {3} to {4} get {5} {6} {7} ", item);
                            if (double.Parse(row["DiscountPercent"].ToString()) > 0)
                            {
                                str = string.Concat(str, string.Format("with {0}% discount", row["DiscountPercent"]));
                            }
                            else if (double.Parse(row["DiscountperUnit"].ToString()) > 0)
                            {
                                str = string.Concat(str, string.Format("with discount of {0} per unit", row["DiscountperUnit"]));
                            }
                            else if ((row["SuppItemFree"].ToString() == "Yes" ? true : row["SuppItemFree"].ToString() == "1"))
                            {
                                string.Concat(str, "for free");
                            }
                            DataRowCollection rows = this.m_dtData.Rows;
                            item = new object[] { str };
                            rows.Add(item);
                        }
                        this.AddSmartGridColumn("Deal", "Deal", "colDeal", 240, 2, this.sgData);
                    }
                    this.sgData.set_DataSource(this.m_dtData);
                    this.sgData.set_AutoSizeColumnsMode(6);
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
            this.lblFilter = new UILabel();
            this.txtFilter = new UITextBox();
            this.btnBarcode = new UITextBoxButton();
            this.tbcMenu = new ToolbarControl();
            this.tbiBack = new ToolbarItem();
            this.sgData = new SmartGrid();
            this.pnlForm.SuspendElementLayout();
            base.SuspendLayout();
            this.pnlForm.BackColor = Color.FromArgb(213, 231, 255);
            this.pnlForm.set_BackgroundImageLayout(6);
            this.pnlForm.get_Children().Add(this.lblFilter);
            this.pnlForm.get_Children().Add(this.txtFilter);
            this.pnlForm.Dock = DockStyle.Fill;
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new Size(318, 294);
            this.pnlForm.TabIndex = 9;
            this.lblFilter.set_AutoSize(false);
            this.lblFilter.set_Font(new Font("Tahoma", 8f, FontStyle.Bold));
            this.lblFilter.set_Layout(new ElementLayout(0, 0, 5, 5, 0, 0, 60, 26));
            this.lblFilter.set_Name("lblFilter");
            this.lblFilter.set_TabIndex(7);
            this.lblFilter.set_Text("Filter");
            this.lblFilter.set_TextAlignment(2);
            this.txtFilter.get_Buttons().Add(this.btnBarcode);
            this.txtFilter.set_Layout(new ElementLayout(3, 0, 70, 5, 5, 0, 243, 26));
            this.txtFilter.set_Name("txtFilter");
            this.txtFilter.set_TabIndex(1);
            this.btnBarcode.set_Action(1);
            this.btnBarcode.set_BackColor(Color.Transparent);
            this.btnBarcode.set_BorderThickness(0);
            this.btnBarcode.set_HorizontalAlignment(2);
            this.btnBarcode.set_Name("btnBarcode");
            this.btnBarcode.get_PressedBackground().set_BackColor(Color.Transparent);
            this.btnBarcode.set_Size(new Size(18, 18));
            this.btnBarcode.set_StateIcon(2);
            this.btnBarcode.set_VisibleMode(1);
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
            this.tbcMenu.set_StretchBackgroundImage(true);
            this.tbcMenu.TabIndex = 7;
            this.tbcMenu.add_SelectionChanged(new EventHandler(this.tbcMenu_SelectionChanged));
            this.tbiBack.set_BackColor(Color.Black);
            this.tbiBack.set_CustomSize(new Size(0, 0));
            this.tbiBack.set_ImageDefault(imgManager.GetImage("iNTrack.Arrow Left"));
            this.tbiBack.set_Name("tbiBack");
            this.tbiBack.set_ToolbarItemBehavior(2);
            this.sgData.set_AlternatingBackColor(Color.FromArgb(213, 231, 255));
            this.sgData.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this.sgData.set_AutoSizeColumnsMode(16);
            this.sgData.set_BackgroundColor(Color.FromArgb(213, 231, 255));
            this.sgData.set_BorderStyle(BorderStyle.Fixed3D);
            this.sgData.set_ColumnHeaderHeight(40);
            this.sgData.set_HeaderBackColor(Color.RoyalBlue);
            this.sgData.set_HeaderForeColor(Color.White);
            this.sgData.set_HeaderVistaStyle(true);
            this.sgData.Location = new Point(3, 33);
            this.sgData.Name = "sgData";
            this.sgData.set_RowHeight(20);
            this.sgData.set_ScrollBars(ScrollBars.None);
            this.sgData.Size = new Size(312, 209);
            this.sgData.TabIndex = 10;
            this.sgData.set_TouchScrolling(true);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(318, 294);
            base.ControlBox = false;
            base.Controls.Add(this.sgData);
            base.Controls.Add(this.tbcMenu);
            base.Controls.Add(this.pnlForm);
            base.MinimizeBox = false;
            base.Name = "frmView";
            this.Text = ":: View";
            base.Load += new EventHandler(this.frmView_Load);
            this.pnlForm.ResumeElementLayout(false);
            base.ResumeLayout(false);
        }

        private void tbcMenu_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.tbcMenu.get_SelectedIndex() == 0)
                    {
                        base.DialogResult = DialogResult.Cancel;
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

        public enum SourceEnum
        {
            Supplementary
        }
    }
}