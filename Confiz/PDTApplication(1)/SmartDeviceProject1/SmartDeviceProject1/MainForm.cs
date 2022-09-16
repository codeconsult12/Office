using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SmartDeviceProject1.DBClasses;

namespace SmartDeviceProject1
{
    public partial class MainForm : Form
    {
      public  List<UserRights> userrightdata = new List<UserRights>();

        public MainForm()
        {
            InitializeComponent();
          
        }
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            //if (userrightdata != null && userrightdata.Count > 0)
            //{
            //    if (userrightdata.Where(x => x.TransactionType == "PC").Count() > 0)
            //    {
            //        PriceChecker.Enabled = true;
            //    }
            //    else
            //    {
            //        PriceChecker.Enabled = false;
            //    }
            //    if (userrightdata.Where(x => x.TransactionType == "SI").Count() > 0)
            //    {
            //        SalesOrder.Enabled = true;
            //    }
            //    else
            //    {
            //        SalesOrder.Enabled = false;
            //    }
            //    //if (userrightdata.Where(x => x.TransactionType == "DM").Count() > 0)
            //    //{
            //    //    pictureBox7.Enabled = true;
            //    //}
            //    //else
            //    //{
            //    //    pictureBox7.Enabled = false;
            //    //}
            //    if (userrightdata.Where(x => x.TransactionType == "PO").Count() > 0)
            //    {
            //        PurchaseOrder.Enabled = true;
            //    }
            //    else
            //    {
            //        PurchaseOrder.Enabled = false;
            //    }
            //}
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (userrightdata != null && userrightdata.Count > 0)
            {
                if (userrightdata.Where(x => x.TransactionType == "PC").Count() > 0)
                {
                    PriceChecker pc = new PriceChecker();
                    pc.ShowDialog();
                }
                else
                {
                    MessageBox.Show("You dont have rights of Price checker! Contact your IT administrator.");

                }
               

            }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (userrightdata != null && userrightdata.Count > 0)
            {
                if (userrightdata.Where(x => x.TransactionType == "PC").Count() > 0)
                {
                    MessageBox.Show("Not Available! Contact your IT administrator.");
                }
                else
                {
                    MessageBox.Show("You dont have rights of Price checker! Contact your IT administrator.");

                }


            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //SalesOrder
            if (userrightdata != null && userrightdata.Count > 0)
            {
                if (userrightdata.Where(x => x.TransactionType == "SO").Count() > 0)
                {
                    MessageBox.Show("Not Available! Contact your IT administrator.");
                }
                else
                {
                    MessageBox.Show("You dont have rights of Sales Order! Contact your IT administrator.");

                }


            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //PurchaseOrder

            if (userrightdata != null && userrightdata.Count > 0)
            {
                if (userrightdata.Where(x => x.TransactionType == "PO").Count() > 0)
                {
                    MessageBox.Show("Not Available! Contact your IT administrator.");
                }
                else
                {
                    MessageBox.Show("You dont have rights of Purchase Order! Contact your IT administrator.");

                }


            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //DeliveryOrder
            if (userrightdata != null && userrightdata.Count > 0)
            {
                if (userrightdata.Where(x => x.TransactionType == "SI").Count() > 0)
                {
                    MessageBox.Show("Not Available! Contact your IT administrator.");
                }
                else
                {
                    MessageBox.Show("You dont have rights of Delivery Note! Contact your IT administrator.");

                }


            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Available! Contact your IT administrator.");
            //if (CheckInternetConnection())
            //{

            //    //AllProduct
            //    DAL d = new DAL();
            //    d.GetAllProducts();
            //}
            //else {
            //    MessageBox.Show("No Internet Connection!");
            
            //}
        }

      
       
        public  bool CheckInternetConnection()
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

        private void label6_ParentChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //DeviceManagement
            if (userrightdata != null && userrightdata.Count > 0)
            {
                if (userrightdata.Where(x => x.TransactionType == "SET").Count() > 0)
                {
                    DeviceManagement lg = new DeviceManagement();
                    lg.ShowDialog();
                    if (lg.issaved == true) {
                        this.Close();
                    }
                  
                }
                else
                {
                    MessageBox.Show("You dont have rights of Device Setup! Contact your IT administrator.");

                }


            }
        
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login lg = new Login();
            lg.Show();
         
        }

        private void CreditNote_Click(object sender, EventArgs e)
        {
            if (userrightdata.Where(x => x.TransactionType == "SRR").Count() > 0)
            {
                MessageBox.Show("Not Available! Contact your IT administrator.");
            }
            else
            {
                MessageBox.Show("You dont have rights of Credit Note! Contact your IT administrator.");

            }
        }

        private void TransferOrder_Click(object sender, EventArgs e)
        {
            if (userrightdata.Where(x => x.TransactionType == "TRO").Count() > 0)
            {
                MessageBox.Show("Not Available! Contact your IT administrator.");
            }
            else
            {
                MessageBox.Show("You dont have rights of Transfer Order! Contact your IT administrator.");

            }
        }

        private void PurchaseReturnNote_Click(object sender, EventArgs e)
        {
            if (userrightdata.Where(x => x.TransactionType == "PI").Count() > 0)
            {
                MessageBox.Show("Not Available! Contact your IT administrator.");
            }
            else
            {
                MessageBox.Show("You dont have rights of Purchase Receipt Note! Contact your IT administrator.");

            }

        }

        private void Shipment_Click(object sender, EventArgs e)
        {
            if (userrightdata.Where(x => x.TransactionType == "TRS").Count() > 0)
            {
                MessageBox.Show("Not Available! Contact your IT administrator.");
            }
            else
            {
                MessageBox.Show("You dont have rights of Transfer Shipment! Contact your IT administrator.");

            }
        }

        private void Store_Click(object sender, EventArgs e)
        {

            MessageBox.Show("You dont have rights of Store! Contact your IT administrator.");

           
        }

        private void TransferReceipt_Click(object sender, EventArgs e)
        {
            if (userrightdata.Where(x => x.TransactionType == "TRI").Count() > 0)
            {
                MessageBox.Show("Not Available! Contact your IT administrator.");
            }
            else
            {
                MessageBox.Show("You dont have rights of Transfer Receipt! Contact your IT administrator.");

            }

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //TransferOrder 
                 if (userrightdata.Where(x => x.TransactionType == "TRI").Count() > 0)
            {
                MessageBox.Show("Not Available! Contact your IT administrator.");
            }
            else
            {
                MessageBox.Show("You dont have rights of Transfer Order! Contact your IT member.");

            }
        }

        private void PurchaseReturn_Click(object sender, EventArgs e)
        {
            if (userrightdata.Where(x => x.TransactionType == "PR").Count() > 0)
            {
                MessageBox.Show("Not Available! Contact your IT administrator.");
            }
            else
            {
                MessageBox.Show("You dont have rights of Purchase Return! Contact your IT member.");

            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            //ShelfPrice
            if (userrightdata.Where(x => x.TransactionType == "PR").Count() > 0)
            {
                MessageBox.Show("Not Available! Contact your IT administrator.");
            }
            else
            {
                MessageBox.Show("You dont have rights of Purchase Return! Contact your IT administrator.");

            }
        }

        private void SaleReturn_Click(object sender, EventArgs e)
        {
            if (userrightdata.Where(x => x.TransactionType == "SR").Count() > 0)
            {
                MessageBox.Show("Not Available! Contact your IT administrator.");
            }
            else
            {
                MessageBox.Show("You dont have rights of Sales Return! Contact your IT administrator.");

            }
        }

        private void StockAdjustment_Click(object sender, EventArgs e)
        {
            if (userrightdata.Where(x => x.TransactionType == "ADJ").Count() > 0)
            {
                MessageBox.Show("Not Available! Contact your IT administrator.");
            }
            else
            {
                MessageBox.Show("You dont have rights of Stock Adjustment! Contact your IT administrator.");

            }
        }

        private void TransferRequest_Click(object sender, EventArgs e)
        {
            if (userrightdata.Where(x => x.TransactionType == "TRQ").Count() > 0)
            {
                MessageBox.Show("Not Available! Contact your IT administrator.");
            }
            else
            {
                MessageBox.Show("You dont have rights of Transfer Request! Contact your IT administrator.");

            }
        }

        private void label11_ParentChanged(object sender, EventArgs e)
        {

        }

    
    }
}