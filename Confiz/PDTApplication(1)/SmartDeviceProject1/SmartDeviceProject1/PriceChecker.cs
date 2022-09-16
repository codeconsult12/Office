using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.IO;
using System.Web;
using System.Reflection;
using System.Globalization;
using System.Runtime.InteropServices;
using SmartDeviceProject1.Webservice;
namespace SmartDeviceProject1

{
   
    public partial class PriceChecker : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);
        DAL dal = new DAL();
        Property p = new Property();
        private bool m_bIsItemValidated;
        private DataTable m_dtItem;

     
        static bool InternetConnected
        {
            get
            {
                int Description = 0;
                return InternetGetConnectedState(out Description, 0);
            }
        }
        public PriceChecker()
        {
            InitializeComponent();
        
     
       
          
          
        }

        public static bool WebRequestTest()
        {
            string url = "http://www.google.com";
            try
            {
                System.Net.WebRequest myRequest = System.Net.WebRequest.Create(url);
                System.Net.WebResponse myResponse = myRequest.GetResponse();
            }
            catch (System.Net.WebException)
            {
                return false;
            }
            return true;
        }


        private void OnKeyDownHandlerItemCode(Object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    if (e.KeyValue == '\r')
                    {
                        this.ItemCode.Text=this.ItemCode.Text.Trim().ToUpper();
                        if (!string.IsNullOrEmpty(this.ItemCode.Text))
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            this.GetItemDetail(this.ItemCode.Text);
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void OnPaste(Object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    if (e.Control == true && e.KeyCode == Keys.V)
                    {
                        IDataObject ClipData = System.Windows.Forms.Clipboard.GetDataObject();
                        
                        if (ClipData.GetDataPresent(DataFormats.Text))
                        {
                            string s = System.Windows.Forms.Clipboard.GetDataObject().GetData(DataFormats.Text).ToString();
                            Barcode.Text = s;
                        }
                    }
                 
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void OnKeyDownHandler(Object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    if (e.KeyValue == '\r')
                    {
                        this.Barcode.Text=this.Barcode.Text.Trim().ToUpper();
                        if (!string.IsNullOrEmpty(this.Barcode.Text))
                        {
                            Application.DoEvents();
                            Cursor.Current = Cursors.WaitCursor;
                            this.GetItemDetail(string.Empty);
                        }
                    }
                }
                catch (Exception exception)
                {
                  MessageBox.Show( exception.Message);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

       

        private void Reset_Click(object sender, EventArgs e)
        {
            resetform();
        }
        public void resetform()
        {
         //   Barcode.Text = "";
         //   ProductName.Text = "-";
         //   Description.Text = "-";
         //   LabelCost.Text = "0.00";
         //   labeldicountAmount.Text = "0.00";
         //   labelDiscount.Text = "0.00";
         //   labelSale.Text = "0.00";
        }

        private void PriceChecker_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Close();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Close();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            resetform();
        }

        private void Barcode_TextChanged(object sender, EventArgs e)
        {

        }
        private void cmbUOM_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if ((!this.m_bIsItemValidated ? false : (int)this.ComboBoxUnit.Items.Count == 1))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        Service service = new Service();
                        try
                        {
                            service.Url = p.ServiceURL.ToString();
                            string[] str = new string[] { "HHT_Barcodes_3000", p.CompanyId.ToString(), p.LocationId.ToString(), string.Empty, dal.FormatString(this.ItemCode.Text.ToString()) };
                            this.m_dtItem = service.GetData(str).Tables[0];
                            if (this.m_dtItem.Rows.Count > 1)
                            {
                                ComboBoxUnit.DisplayMember="UOM";
                                ComboBoxUnit.ValueMember = "UOM";
                                ComboBoxUnit.DataSource = m_dtItem;
                                //this.cmbUOM.set_StringData((
                                //    from r in this.m_dtItem.AsEnumerable()
                                //    select r.Field<string>("UOM")).ToArray<string>());
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
                    MessageBox.Show(exception.Message);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void ComboBoxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.ComboBoxUnit.SelectedIndex > -1)
                    {
                        DataRow dataRow = this.m_dtItem.Select(string.Format("[UOM] = '{0}'", this.ComboBoxUnit.Text))[0];
                        this.Barcode.Text=(string)dataRow["Barcode"];
                        this.ItemCode.Text=(string)dataRow["Itemcode"];
                        this.SetItemDetail(dataRow);
                        
                 
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error! " + exception.Message);
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
                    empty = (this.Barcode.Text.Length != 14 || !(this.Barcode.Text.Substring(0, 3) == "990") ? this.Barcode.Text : string.Format("{0}00000", this.Barcode.Text.Substring(0, 9)));
                    service = new Service();
                    try
                    {
                        service.Url = p.ServiceURL.ToString(); ;
                        str = new string[] { "HHT_Barcodes_3001", p.CompanyId, p.LocationId.ToString(), string.Empty, dal.FormatString(empty) };
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
                        service.Url = p.ServiceURL.ToString();
                        str = new string[] { "HHT_Barcodes_3000", p.CompanyId, p.LocationId, string.Empty, dal.FormatString(Itemcode) };
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
                    if (this.Barcode.Text.Length == 0)
                    {
                        throw new Exception("Invalid itemcode");
                    }
                    throw new Exception("Invalid barcode");
                }
                if (this.Barcode.Text.Length == 0)
                {

                    this.Barcode.Text=(string)dataRow["Barcode"];
           
                }
                else
                {
        
                    this.ItemCode.Text=(string)dataRow["Itemcode"];
       
                }
            
                ComboBox uIComboBox = this.ComboBoxUnit;
                str = new string[] { (string)dataRow["UOM"] };
                ComboBoxUnit.Refresh();
                ComboBoxUnit.DataSource = null;
                ComboBoxUnit.Items.Clear();
                uIComboBox.Refresh();
                uIComboBox.DataSource = null;
                uIComboBox.Items.Clear();
               
                ComboboxItem cbi = new ComboboxItem();
                int i=0;
                foreach (string st in str)
                {
                    cbi.Text=string.Empty;
                    cbi.Value = null;
                    cbi.Value = i.ToString();
                    cbi.Text = st.ToString();
                    uIComboBox.Items.Add(cbi);
                }
                uIComboBox.SelectedIndex = 0;
                this.ComboBoxUnit.SelectedIndexChanged+= new EventHandler(this.ComboBoxUnit_SelectedIndexChanged);
                this.SetItemDetail(dataRow);
   
                this.m_bIsItemValidated = true;
                this.Barcode.Focus();
                this.Barcode.SelectAll();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                if (this.Barcode.Text.Length == 0)
                {
                    this.ItemCode.SelectAll();
                    this.ItemCode.Focus();
                }
                else
                {
                    this.Barcode.SelectAll();
                    this.Barcode.Focus();
                }
                throw exception;
            }
        }
        private void SetItemDetail(DataRow datarow)
        {
            try
            {
                this.Description.Text=datarow["Description"].ToString();
                this.Vendor.Text=string.Format("{0} {1}", datarow["Vendor Code"].ToString(), datarow["Vendor Name"].ToString());
                TextBox uITextBox = this.SalePrice;
                double num = double.Parse(datarow["Sales Price"].ToString());
                uITextBox.Text=num.ToString("F");
                
                TextBox uITextBox1 = this.CostPrice;
                num = double.Parse(datarow["Unit Price"].ToString());
                uITextBox1.Text= num.ToString("F");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

   
      

        //public static List<PriceCheck> GetCSV()
        //{
        //    List<PriceCheck> product = new List<PriceCheck>();

        //List<PriceCheck> prduct = new List<PriceCheck>();

        //PriceCheck product = new PriceCheck();
        //product.ProductId = 1;
        //product.Barcode = "123";
        //product.Name = "Pepsi";
        //product.Description = "Colddrink Brand";
        //product.Cost = "30.00";
        //product.Sale = "50.00";
        //product.Discount = "10.00";
        //product.DiscountPer = "20.00";
        //prduct.Add(product);
        //PriceCheck product1 = new PriceCheck();
        //product1.ProductId = 2;
        //product1.Barcode = "124";
        //product1.Name = "7 up";
        //product1.Description = "Colddrink Brand";
        //product1.Cost = "30.00";
        //product1.Sale = "50.00";
        //product1.Discount = "05.00";
        //product1.DiscountPer = "10.00";
        //prduct.Add(product1);
        //PriceCheck product2 = new PriceCheck();
        //product2.ProductId = 3;
        //product2.Barcode = "125";
        //product2.Name = "Lays";
        //product2.Description = "Snaks";
        //product2.Cost = "50.00";
        //product2.Sale = "70.00";
        //product2.Discount = "07.00";
        //product2.DiscountPer = "10.00";
        //prduct.Add(product2);
        //return prduct;
        //}
    }
}