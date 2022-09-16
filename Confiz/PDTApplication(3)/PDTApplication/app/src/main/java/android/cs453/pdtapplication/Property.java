package android.cs453.pdtapplication;

import android.content.Context;
import android.content.res.AssetManager;
import android.os.Environment;

//import com.example.myapplication.MainActivity;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

public class Property {
    public String ServiceURL;

    public String GetServiceURL() {
        return this.ServiceURL;
    }

    public void SetServiceURL(String url) {
        this.ServiceURL = url;
    }

    public String DeviceID;

    public String GetDeviceID() {
        return this.DeviceID;
    }

    public void SetDeviceID(String DID) {
        this.DeviceID = DID;
    }

    public String DeviceName;

    public String GetDeviceName() {
        return this.DeviceName;
    }

    public void SetDeviceName(String DName) {
        this.DeviceName = DName;
    }

    public String CompanyName;

    public String GetCompanyName() {
        return this.CompanyName;
    }

    public void SetCompanyName(String CompanyName) {
        this.CompanyName = CompanyName;
    }

    public String CompanyId;

    public String GetCompanyId() {
        return this.CompanyId;
    }

    public void SetCompanyId(String CompanyId) {
        this.CompanyId = CompanyId;
    }

    public String LocationId;

    public String GetLocationId() {
        return this.LocationId;
    }

    public void SetLocationId(String LocationId) {
        this.LocationId = LocationId;
    }

    public String LocationName;

    public String GetLocationName() {
        return this.LocationName;
    }

    public void SetLocationName(String LocationName) {
        this.LocationName = LocationName;
    }

    public String TimeZone;

    public String GetTimeZone() {
        return this.TimeZone;
    }

    public void SetTimeZone(String TimeZone) {
        this.TimeZone = TimeZone;
    }

    public String TimeZoneId;

    public String GetTimeZoneId() {
        return this.TimeZoneId;
    }

    public void SetTimeZoneId(String TimeZoneId) {
        this.TimeZoneId = TimeZoneId;
    }

    public String IPAddress;

    public String GetIPAddress() {
        return this.IPAddress;
    }

    public void SetIPAddress(String IPAddress) {
        this.IPAddress = IPAddress;
    }

    public String MACAddress;

    public String GetMACAddress() {
        return this.MACAddress;
    }

    public void SetMACAddress(String MACAddress) {
        this.MACAddress = MACAddress;
    }

    public Property() throws IOException {
        InputStream is = null;
        try {
            String root = Environment.getExternalStorageDirectory().toString();
            File file = new File(root+"/PDTApplication/Config.xml");

            if (file.exists()) {

                try {
                    is = new FileInputStream(root+"/PDTApplication/Config.xml");
                } catch (FileNotFoundException e) {
                    e.printStackTrace();
                }

                DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
                try {
                    DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
                    Document doc = dBuilder.parse(is);

                    Element element = doc.getDocumentElement();
                    element.normalize();

                    NodeList nList = doc.getElementsByTagName("DeviceManagement");

                    for (int i = 0; i < nList.getLength(); i++) {
                        Node node = nList.item(i);
                        if (node.getNodeType() == Node.ELEMENT_NODE) {
                            Element e = (Element) node;

                            ServiceURL = e.getElementsByTagName("ServiceURL").item(0).getTextContent();
                            DeviceID = e.getElementsByTagName("DeviceID").item(0).getTextContent();
                            DeviceName = e.getElementsByTagName("DeviceName").item(0).getTextContent();
                            CompanyName = e.getElementsByTagName("CompanyName").item(0).getTextContent();
                            CompanyId = e.getElementsByTagName("CompanyId").item(0).getTextContent();
                            LocationId = e.getElementsByTagName("LocationId").item(0).getTextContent();
                            LocationName = e.getElementsByTagName("LocationName").item(0).getTextContent();
                            TimeZone = e.getElementsByTagName("TimeZone").item(0).getTextContent();
                            TimeZoneId = e.getElementsByTagName("TimeZoneId").item(0).getTextContent();
                            IPAddress = e.getElementsByTagName("IPAddress").item(0).getTextContent();
                            MACAddress = e.getElementsByTagName("MACAddress").item(0).getTextContent();
                        }
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        } finally {
            if (is != null) {
                is.close();
            }
        }
    }
}

