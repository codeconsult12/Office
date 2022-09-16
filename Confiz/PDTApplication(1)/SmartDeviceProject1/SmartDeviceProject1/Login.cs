using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using SmartDeviceProject1.DBClasses;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;
using System.Web.Services;
using SmartDeviceProject1.DBClasses;
using SmartDeviceProject1.Webservice;
using System.Xml;

namespace SmartDeviceProject1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
           
            try
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

                                case "DeviceName":
                                    LbldeviceName.Text = textReader.ReadString();
                                    break;
                                case "CompanyName":
                                    LblCompanyName.Text = textReader.ReadString();
                                    break;
                                case "LocationName":
                                    LblLocation.Text = textReader.ReadString();
                                    break;
                                case "IPAddress":
                                    LblIP.Text = textReader.ReadString();
                                    break;
                            }
                        }
                        // Move to fist element  
                        textReader.MoveToElement();



                    }

                }
                else
                {
                    MessageBox.Show("Device not registered! Please Register your device first.");
                    DeviceManagement dm = new DeviceManagement();
                    dm.ShowDialog();
                    if (File.Exists("Config.xml") && dm.issaved == true)
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

                                    case "DeviceName":
                                        LbldeviceName.Text = textReader.ReadString();
                                        break;
                                    case "CompanyName":
                                        LblCompanyName.Text = textReader.ReadString();
                                        break;
                                    case "LocationName":
                                        LblLocation.Text = textReader.ReadString();
                                        break;
                                    case "IPAddress":
                                        LblIP.Text = textReader.ReadString();
                                        break;
                                }
                            }
                            // Move to fist element  
                            textReader.MoveToElement();



                        }
                    }
                    else
                    {
                        MessageBox.Show("Device couldn't registered! Contact your IT administrator");
                        Application.Exit();
                    }
                }
               
            }
            catch (Exception)
            {
                LblIP.Text = "Not Found";
            }
        }

        private void label1_ParentChanged(object sender, EventArgs e)
        {

        }
        public bool CheckInternetConnection()
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
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                DAL d = new DAL();
                List<User> userlist = new List<User>();
                userlist = d.CheckDbConnection();
                if (userlist != null && userlist.Count>0)
                {
                    if (userlist.Where(x => x.USERID == textBox1.Text.Trim()).Count() > 0)
                    {
                        if (userlist.Where(x => x.PASSWORD == textBox2.Text.Trim()).Count() >0)
                        {
                            List<UserRights> URData = new List<UserRights>();
                            //if (CheckInternetConnection())
                            //{
                        
                                URData = d.GetUserRights(textBox1.Text.Trim());
                                if (URData == null)
                                {
                                    MessageBox.Show("Couldn't connect web service!");
                                    return;
                                }

                            //}
                            //else
                            //{
                            //    URData = d.GetUserRightsDataFromCSV();

                            //}
                          
                            MainForm mf = new MainForm();

                            mf.userrightdata = URData;
                            mf.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Password");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Wrong UserName");
                    }
                }
                else
                {
                    MessageBox.Show("Connection Error!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }



            //if (textBox1.Text == "CEUser")
            //{

            //    if (textBox2.Text == "123456")
            //    {
            //        MainForm mf = new MainForm();
            //        mf.ShowDialog();

            //    }
            //    else
            //    {
            //        MessageBox.Show("Wrong Password");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Wrong UserName");
            //}
        }
       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            Offlinelbl.Text = "Online";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox1.Visible = false;
            Offlinelbl.Text = "Offline";
        }

        private void label3_ParentChanged(object sender, EventArgs e)
        {

        }
    }
}