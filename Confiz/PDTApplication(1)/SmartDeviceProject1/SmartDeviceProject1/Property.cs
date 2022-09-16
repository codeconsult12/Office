using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace SmartDeviceProject1
{
    class Property
    {
        public string ServiceURL { get; set; }
        public string DeviceID { get; set; }
        public string DeviceName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyId { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string TimeZone { get; set; }
        public string TimeZoneId { get; set; }
        public string IPAddress { get; set; }
        public string MACAddress { get; set; }

        public Property()
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
                                ServiceURL = textReader.ReadString();
                                break;
                            case "DeviceID":
                                DeviceID = textReader.ReadString();
                                break;
                            case "DeviceName":
                                DeviceName = textReader.ReadString();
                                break;
                            case "CompanyName":
                          

                                CompanyName = textReader.ReadString();
                            
                                break;
                            case "LocationName":
                          

                                LocationName = textReader.ReadString();
                      
                                break;
                            case "TimeZone":
                

                                TimeZone = textReader.ReadString();
                      
                                break;
                            case "TimeZoneId":


                                TimeZoneId = textReader.ReadString();

                                break;

                            case "LocationId":
                           
                                LocationId = textReader.ReadString();

                                break;
                            case "CompanyId":
                           

                                CompanyId = textReader.ReadString();

                                break;
                            case "IpAddress":
                                IPAddress = textReader.ReadString();
                                break;
                            case "MACAddress":
                                MACAddress = textReader.ReadString();
                                break;
                        }
                    }
                    // Move to fist element  
                    textReader.MoveToElement();



                }
     

            }


        }
    
    
    }
}
