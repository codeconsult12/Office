using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.Net;
using System.IO;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using SmartDeviceProject1.DBClasses;
using SmartDeviceProject1.Webservice;
using System.Xml;



namespace SmartDeviceProject1
{
    public partial class DeviceManagement : Form
    {
      public  bool issaved = false;
        public DeviceManagement()
        {
            InitializeComponent();
        }
        [DllImport("iphlpapi.dll", SetLastError = true)]
        public static extern int GetAdaptersInfo(byte[] info, ref uint size);

        [DllImport("iphlpapi.dll")]
        public static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);


        private void label3_ParentChanged(object sender, EventArgs e)
        {

        }

        private void menuItem1_Click(object sender, EventArgs e)
        {

        }

        private void DeviceManagement_Load(object sender, EventArgs e)
        {
            if (File.Exists("Config.xml"))
            {
                XmlTextReader textReader = new XmlTextReader("Config.xml");
                textReader.Read();
                // If the node has value  
                while (textReader.Read())
                {
                    if (textReader.IsStartElement())
                    {
                        //return only when you have START tag  
                        switch (textReader.Name.ToString())
                        {
                            case "ServiceURL":
                               textBox1.Text = textReader.ReadString();
                                break;
                            case "DeviceID":
                            textBox2.Text = textReader.ReadString();
                                break;
                            case "DeviceName":
                                textBox3.Text = textReader.ReadString();
                                break;
                            case "CompanyName":
                                ComboboxItem cobitem = new ComboboxItem();
                                cobitem.Value = "0";
                                cobitem.Text = textReader.ReadString();
                                CompanyCombo.Items.Add(cobitem);
                                CompanyCombo.SelectedIndex = 0;
                                break;
                            case "LocationName":
                                ComboboxItem cobitem2 = new ComboboxItem();
                                cobitem2.Value = "0";
                                cobitem2.Text = textReader.ReadString();
                                LocationCombo.Items.Add(cobitem2);
                               LocationCombo.SelectedIndex = 0;
                                break;
                            case "TimeZone":
                                ComboboxItem cobitem3 = new ComboboxItem();
                                cobitem3.Value = "0";
                                cobitem3.Text = textReader.ReadString();
                              TimeZoneCombo.Items.Add(cobitem3);
                                TimeZoneCombo.SelectedIndex = 0;
                                break;
                        }
                    }
                    // Move to fist element  
                    textReader.MoveToElement();



                }
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                LocationCombo.Enabled = false;
                CompanyCombo.Enabled = false;
                TimeZoneCombo.Enabled = false;

            }else{
                TimeZoneLoad();
            }
          //  CompanyLoad();
           // LoadComboLocation(5);
        
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public string CheckWebservice(string url)
        {
            try
            {
                var myRequest = (HttpWebRequest)WebRequest.Create(url);

                var response = (HttpWebResponse)myRequest.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //  it's at least in some way responsive
                    //  but may be internally broken
                    //  as you could find out if you called one of the methods for real
                    return string.Format("Available");
                }
                else
                {
                    //  well, at least it returned...
                            return string.Format("{0} Returned, but with status: {1}",
                        url, response.StatusDescription);
                }
            }
            catch (Exception ex)
            {
                //  not available at all, for some reason
               return string.Format("{0} unavailable: {1}", url, ex.Message);
            }

        }
        public static void SetDropDown(string DisplayMember, string ValueMember, object DataSource, ComboBox ComboBox)
        {
            try
            {
                ComboBox.DisplayMember=DisplayMember;
                ComboBox.ValueMember=ValueMember;
                ComboBox.DataSource=DataSource;
                ComboBox.SelectedIndex=-1;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        private void OnKeyDownHandler(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var url = ""; ;
                 if (textBox1.Text.Trim().ToString() != "")
                 {
                     url = textBox1.Text.Trim().ToString();
                     string Result = CheckWebservice(url);
                     if (Result == "Available")
                     {
                         Service service = new Service();
                         service.Url = this.textBox1.Text.Trim();
                         string[] strArrays = new string[] { "Company_3000" };
                         string[] str;

                         DataTable item = service.GetData(strArrays).Tables[0];
                         strArrays = new string[] { "Company_3000" };
                         SetDropDown("Name", "Code", service.GetData(strArrays).Tables[0], CompanyCombo);


                     }
                     else
                     {
                         MessageBox.Show(Result);
                     }
                     textBox1.SelectionStart = 0;
                     CompanyCombo.Focus();
                 }
                 else
                 {
                     MessageBox.Show("Please enter service URL!");

                 }
            

            }
            if (e.KeyCode == Keys.V && e.Control)
            {

                IDataObject iData = Clipboard.GetDataObject();

                // Determines whether the data is in a format you can use.
                if (iData.GetDataPresent(DataFormats.Text))
                {
                   
                    // Yes it is, so display it in a text box.
                    textBox1.Text = (String)iData.GetData(DataFormats.Text);
                }
            }
        }

        private void label5_ParentChanged(object sender, EventArgs e)
        {

        }
        public void TimeZoneLoad()
        {
            DataRow dr;

            DAL d = new DAL();
            SqlConnection con = new SqlConnection(d.connString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Id,DisplayName FROM TimeZoneInfo", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            //dr = dt.NewRow();
            //dr.ItemArray = new object[] { 0, "--Select Movie--" };
            //dt.Rows.InsertAt(dr, 0);
       
            TimeZoneCombo.ValueMember = "Id";

            TimeZoneCombo.DisplayMember = "DisplayName";
            TimeZoneCombo.DataSource = dt;

            con.Close();

        }
 


        private void DeviceManagement_KeyDown(object sender, KeyEventArgs e)
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

        private void CompanyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (this.CompanyCombo.Items.Count > 1) { 
                    if (this.CompanyCombo.SelectedIndex > -1)
                    {
                        Service service = new Service();
                        try
                        {
                            service.Url = textBox1.Text.Trim().ToString();
                            string[] str = new string[] { "Location_3000", this.CompanyCombo.SelectedValue.ToString(), "%" };
                           SetDropDown("Name", "Code", service.GetData(str).Tables[0], this.LocationCombo);
                      
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
                }
                catch (WebException webException)
                {
                    MessageBox.Show("Server not found");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message.ToString());
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

 
        private void LoadComboLocation(int CompanyId)
        {
            DataRow dr;

            DAL d = new DAL();
            SqlConnection con = new SqlConnection(d.connString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * fROm ax.INVENTLOCATION WHERE DATAAREAID = 'afcs'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            //dr = dt.NewRow();
            //dr.ItemArray = new object[] { 0, "--Select Movie--" };
            //dt.Rows.InsertAt(dr, 0);


            LocationCombo.ValueMember = "RECID";

            LocationCombo.DisplayMember = "NAME";
            LocationCombo.DataSource = dt;

            con.Close();
            


        }
        public static string FormatString(string Value)
        {
            string str;
            try
            {
                str = (!string.IsNullOrEmpty(Value) ? Value.Replace("'", "''").Trim() : string.Empty);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        private void SaveMenu_Click(object sender, EventArgs e)
        {
            if (textBox1.Enabled == false || textBox2.Enabled == false || textBox3.Enabled == false || CompanyCombo.Enabled == false || LocationCombo.Enabled == false || TimeZoneCombo.Enabled == false)
            {
                MessageBox.Show("Please reset and setup new device");
                return;
            }

            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Please enter service URL!");
                return;
            }
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Please enter device Id");
                return;
            }
            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Please enter device name!");
                return;
            }
            if (CompanyCombo.Text.Trim() == "")
            {
                MessageBox.Show("Please select company!");
                return;
            }
            if (LocationCombo.Text.Trim() == "")
            {
                MessageBox.Show("Please select location!");
                return;
            }
            if (TimeZoneCombo.Text.Trim() == "")
            {
                MessageBox.Show("Please select timezone!");
                return;
            }


            try
            {
                string MacAddress = "";

                MacAddress = GetMac();
                if (MacAddress != "")
                {
                    DAL d = new DAL();
                    string []str;
                         Service service = new Service();
                       
                            service.Url = this.textBox1.Text.Trim();
                    DataTable dt = new DataTable();
                       str = new string[] { "HHT_Register_3000", this.CompanyCombo.SelectedValue.ToString(), FormatString(this.textBox2.Text.Trim()) };
                       DataTable item = service.GetData(str).Tables[0];
                            if ((item.Rows.Count <= 0 ? false : (string)item.Rows[0]["MAC Address"] != MacAddress))
                            {
                         MessageBox.Show(  "Same device id has already been registered");
                         return;
                            }
                            string deviceID = MacAddress;
                            str = new string[] { "HHT_Register_3001", this.CompanyCombo.SelectedValue.ToString(), FormatString(deviceID) };
                            item = service.GetData(str).Tables[0];
                            Service service1 = service;
                            str = new string[] { (item.Rows.Count == 0 ? "HHT_Register_1000" : "HHT_Register_4000"), this.CompanyCombo.SelectedValue.ToString(), FormatString(deviceID), FormatString(this.textBox2.Text.ToString()), FormatString(this.LocationCombo.SelectedValue.ToString()) };
                            service1.SetData(str, new DataSet());

                            if (item.Rows.Count == 0)
                            {
                                MessageBox.Show("Saved Succesfully");

                            }
                            else
                            {
                                MessageBox.Show("Updated Succesfully");
                            }
                            bool isdeviceConfigured=false;
                            if (File.Exists("Config.xml"))
                            {
                                isdeviceConfigured = true;
                                File.Delete("Config.xml");

                                DAL dal = new DAL();
                                using (XmlTextWriter xmlwriter = new XmlTextWriter("Config.xml", Encoding.UTF8))
                                {
                                    xmlwriter.Formatting = Formatting.Indented;

                                    xmlwriter.WriteStartDocument();

                                    xmlwriter.WriteStartElement("DeviceManagement");

                                    xmlwriter.WriteElementString("ServiceURL", textBox1.Text.ToString());
                                    xmlwriter.WriteElementString("DeviceID", textBox2.Text.ToString());
                                    xmlwriter.WriteElementString("DeviceName", textBox3.Text.ToString());
                                    xmlwriter.WriteElementString("CompanyName", CompanyCombo.Text.ToString());
                                    xmlwriter.WriteElementString("CompanyId", CompanyCombo.SelectedValue.ToString());
                                    xmlwriter.WriteElementString("LocationId", LocationCombo.SelectedValue.ToString());
                                    xmlwriter.WriteElementString("LocationName", LocationCombo.Text.ToString());
                                    xmlwriter.WriteElementString("TimeZoneId", TimeZoneCombo.SelectedValue.ToString());
                                    xmlwriter.WriteElementString("TimeZone", TimeZoneCombo.Text.ToString());
                                    xmlwriter.WriteElementString("IPAddress", dal.GETIPAddress());
                                    xmlwriter.WriteElementString("MACAddress", MacAddress);
                                    xmlwriter.WriteEndElement();
                                    xmlwriter.WriteEndDocument();
                                    xmlwriter.Flush();

                                    xmlwriter.Close();
                                }

                            }
                            else
                            {
                                DAL dal = new DAL();
                                using (XmlTextWriter xmlwriter = new XmlTextWriter("Config.xml", Encoding.UTF8))
                                {
                                    xmlwriter.Formatting = Formatting.Indented;

                                    xmlwriter.WriteStartDocument();

                                    xmlwriter.WriteStartElement("DeviceManagement");

                                    xmlwriter.WriteElementString("ServiceURL", textBox1.Text.ToString());
                                    xmlwriter.WriteElementString("DeviceID", textBox2.Text.ToString());
                                    xmlwriter.WriteElementString("DeviceName", textBox3.Text.ToString());
                                    xmlwriter.WriteElementString("CompanyName", CompanyCombo.Text.ToString());
                                    xmlwriter.WriteElementString("CompanyId", CompanyCombo.SelectedValue.ToString());
                                    xmlwriter.WriteElementString("LocationId", LocationCombo.SelectedValue.ToString());
                                    xmlwriter.WriteElementString("LocationName", LocationCombo.Text.ToString());
                                    xmlwriter.WriteElementString("TimeZoneId", TimeZoneCombo.SelectedValue.ToString());
                                    xmlwriter.WriteElementString("TimeZone", TimeZoneCombo.Text.ToString());
                                    xmlwriter.WriteElementString("IPAddress", dal.GETIPAddress());
                                    xmlwriter.WriteElementString("MACAddress", MacAddress);
                                    xmlwriter.WriteEndElement();
                                    xmlwriter.WriteEndDocument();
                                    xmlwriter.Flush();

                                    xmlwriter.Close();
                                }
                            }
                            issaved = true;
                            this.Close();
                            

                }
        
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Couldn't saved! Contact your IT administrator." );
            }
        }
      
        public string GetMac() {
            IPHostEntry IPHost = Dns.Resolve(Dns.GetHostName());
            IPAddress[] addressList = IPHost.AddressList;
            if (addressList.Length > 0)
            {
                StringBuilder address = new StringBuilder();
                foreach (IPAddress a in addressList)
                {
                    address.Append(a.ToString());
                    address.Append(" ");
                }
                return  GetMacUsingARP(address.ToString());
            }
            else
                return "";
        }
        public static  string GetMacAddress()
        {
            uint num = 0u;
            GetAdaptersInfo(null, ref num);
            byte[] array = new byte[(int)((UIntPtr)num)];
            int adaptersInfo = GetAdaptersInfo(array, ref num);
            if (adaptersInfo == 0)
            {
                string macAddress = "";
                int macLength = BitConverter.ToInt32(array, 400);
                macAddress = BitConverter.ToString(array, 404, macLength);
                macAddress = macAddress.Replace("-", ":");

                return macAddress;
            }
            else
                return "";
        }
        private string GetMacUsingARP(string IPAddr)
        {
            IPAddress IP = IPAddress.Parse(IPAddr);
            byte[] macAddr = new byte[6];
            uint macAddrLen = (uint)macAddr.Length;

            if (SendARP((int)IP.Address, 0, macAddr, ref macAddrLen) != 0)
                throw new Exception("ARP command failed");

            string[] str = new string[(int)macAddrLen];
            for (int i = 0; i < macAddrLen; i++)
                str[i] = macAddr[i].ToString("x2");

            return string.Join(":", str);
        }

        private void BackMenu_Click(object sender, EventArgs e)
        {
            Reset();
            TimeZoneLoad();

        }

        private void Reset()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            LocationCombo.Items.Clear();
            TimeZoneCombo.Items.Clear();
            CompanyCombo.Items.Clear();
            LocationCombo.Enabled = true;
            CompanyCombo.Enabled = true;
            TimeZoneCombo.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            LocationCombo.Text = "";
            CompanyCombo.Text = "";
            TimeZoneCombo.Text = "";
          
        }

    

    }
}