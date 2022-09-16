package android.cs453.pdtapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.os.Environment;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import org.w3c.dom.*;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.InputStream;
import java.util.HashMap;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;


public class DeviceActivity extends AppCompatActivity {

    Spinner companiesSpinner, locationSpinner, dataPathSpinner, timeZoneSpinner;
    EditText serviceURL, deviceID, deviceName;
    Button saveButton, backButton;




    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_device);

        saveButton = (Button)findViewById(R.id.save_button);
        backButton = (Button)findViewById(R.id.back_button);
        serviceURL = (EditText)findViewById(R.id.service_url_edit_text);
        deviceID = (EditText)findViewById(R.id.device_id_edit_text);
        deviceName = (EditText)findViewById(R.id.device_name_edit_text);
        companiesSpinner = (Spinner)findViewById(R.id.companies_spinner);
        locationSpinner = (Spinner) findViewById(R.id.location_spinner);
        dataPathSpinner = (Spinner)findViewById(R.id.data_path_spinner);
        timeZoneSpinner = (Spinner)findViewById(R.id.time_zone_spinner);


        String root = Environment.getExternalStorageDirectory().toString();
        File file= new File(root+"/PDTApplication/Config.xml");
        if (file.exists())
        {
            InputStream is = null;
            try {
                is = new FileInputStream(root+"/PDTApplication/Config.xml");
            } catch (FileNotFoundException e) {
                e.printStackTrace();
            }
            DocumentBuilderFactory dbf=DocumentBuilderFactory.newInstance();
            try {
                DocumentBuilder db = dbf.newDocumentBuilder();
                Document doc = db.parse(is);
                NodeList nList = doc.getElementsByTagName("DeviceManagement");
                for (int i = 0; i < nList.getLength(); i++) {
                    if (nList.item(0).getNodeType() == Node.ELEMENT_NODE) {
                        HashMap<String, String> user = new HashMap<>();
                        Element elm = (Element) nList.item(i);
                        serviceURL.setText(getNodeValue("ServiceURL",elm));
                        deviceID.setText(getNodeValue("DeviceID",elm));
                        deviceName.setText(getNodeValue("DeviceName", elm));
                        String[] companies={getNodeValue("CompanyName", elm)};
                        ArrayAdapter aa=new ArrayAdapter(this, android.R.layout.simple_spinner_item,companies);
                        aa.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                        companiesSpinner.setAdapter(aa);

                        lblCompany.setText(getNodeValue("CompanyName", elm));
                        lblLocation.setText(getNodeValue("LocationName", elm));
                        ipAddress.setText(getNodeValue("IPAddress", elm));
                    }
                }
            }
            catch (Exception e){

            }
        }











        String[] companies = new String[]{"AFCOOP"};
        String[] locations = new String[]{"Abu Dhabi", "CupCafe-AFCOOP"};
        String[] dataPaths = new String[]{};
        String[] timeZones = new String[]{};
        ArrayAdapter<String> adapter1 = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, companies);
        ArrayAdapter<String> adapter2 = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, locations);
        ArrayAdapter<String> adapter3 = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, dataPaths);
        ArrayAdapter<String> adapter4 = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, timeZones);
        companiesSpinner.setAdapter(adapter1);
        locationSpinner.setAdapter(adapter2);
        dataPathSpinner.setAdapter(adapter3);
        timeZoneSpinner.setAdapter(adapter4);

        //
        try {
            File fileName = new File("Config.xml");
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            DocumentBuilder db = dbf.newDocumentBuilder();

            if(fileName.exists()) {
                Document document = db.parse(fileName);
                document.getDocumentElement().normalize();

                NodeList nodeList = document.getElementsByTagName("Device");
                for(int i = 0; i < nodeList.getLength(); i++) {
                    Node node = nodeList.item(i);
                    if(node.getNodeType() == Node.ELEMENT_NODE) {
                        Element e = (Element) node;
                        serviceURL.setText(e.getElementsByTagName("ServiceURL").item(0).getTextContent());
                        deviceID.setText(e.getElementsByTagName("DeviceID").item(0).getTextContent());
                        deviceName.setText(e.getElementsByTagName("DeviceName").item(0).getTextContent());

                    }
                }
            }
        }
        catch (Exception e) {
            e.printStackTrace();
        }


        saveButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

            }
        });

        backButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                DeviceActivity.this.finish();
            }
        });
    }
    protected String getNodeValue(String tag, Element element) {
        NodeList nodeList = element.getElementsByTagName(tag);
        Node node = nodeList.item(0);
        if(node!=null){
            if(node.hasChildNodes()){
                Node child = node.getFirstChild();
                while (child!=null){
                    if(child.getNodeType() == Node.TEXT_NODE){
                        return  child.getNodeValue();
                    }
                }
            }
        }
        return "";
    }
}