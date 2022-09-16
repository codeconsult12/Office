package android.cs453.pdtapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.ContextWrapper;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Environment;
import android.os.Handler;
import android.os.StrictMode;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.util.Xml;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import org.w3c.dom.*;
import org.xml.sax.InputSource;
import org.xml.sax.SAXException;
import org.xmlpull.v1.XmlSerializer;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.StringReader;
import java.net.HttpURLConnection;
import java.net.Inet4Address;
import java.net.InetAddress;
import java.net.NetworkInterface;
import java.net.SocketException;
import java.net.URL;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.*;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.transform.OutputKeys;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerException;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;


public class DeviceActivity extends AppCompatActivity {

    String dbName = "AFC1010";
    String serverip = "116.202.214.159";
    String serverport = "1433";
    String driver = "net.sourceforge.jtds.jdbc.Driver";
    String databaseUserName = "user_tm3";
    String databasePassword = "qazwsx@1";
    String url = "jdbc:jtds:sqlserver://" + serverip + ":" + serverport + ";databaseName=" + dbName + ";user=" + databaseUserName + ";password=" + databasePassword + ";";

    Spinner companiesSpinner, locationSpinner, dataPathSpinner, timeZoneSpinner;
    EditText serviceURL, deviceID, deviceName;
    Button saveButton, backButton;
    Hashtable<String, String> HtCompanies;
    Hashtable<String, String> HtLocations;
    Hashtable<String, String> HtTimeZones = new Hashtable<String,String>();
    private String MacAddress = "";
    private String deviceidString = "";
    private String strLength= "";
    private String companyId, locationId;

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
        //dataPathSpinner = (Spinner)findViewById(R.id.data_path_spinner);
        timeZoneSpinner = (Spinner)findViewById(R.id.time_zone_spinner);


        List<String> timeZones = getTimeZones();
        ArrayAdapter<String> adapter1 = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, timeZones);
        timeZoneSpinner.setAdapter(adapter1);


        serviceURL.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    LoadCompanies lc = new LoadCompanies();
                    lc.execute();
                }
            }
        });

        //Companies Spinner listener - when an item is selected
        companiesSpinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int position, long id) {
                //String[] str = new String[]{"Location_3000", companiesSpinner.getSelectedItem().toString(), "%"};
                String Company = companiesSpinner.getSelectedItem().toString();
                String s = HtCompanies.get(Company).toString();
                LoadLocation ll = (LoadLocation) new LoadLocation().execute(s);
            }
            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {
                //ignore
            }
            });


        //Save Button
        saveButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                if(serviceURL.getText().toString().length() == 0) {
                    Toast toast = Toast.makeText(DeviceActivity.this, "Please enter Service URL.", Toast.LENGTH_SHORT);
                    toast.show();
                }
                else if (deviceID.getText().toString().length() == 0) {
                    Toast toast = Toast.makeText(DeviceActivity.this, "Please enter Device ID.", Toast.LENGTH_SHORT);
                    toast.show();
                }
                else if (deviceName.getText().toString().length() == 0) {
                    Toast toast = Toast.makeText(DeviceActivity.this, "Please enter Device Name.", Toast.LENGTH_SHORT);
                    toast.show();
                }
                else if (companiesSpinner.getSelectedItem() == null) {
                    Toast toast = Toast.makeText(DeviceActivity.this, "Please select a company.", Toast.LENGTH_SHORT);
                    toast.show();
                }
                else if (locationSpinner.getSelectedItem() == null) {
                    Toast toast = Toast.makeText(DeviceActivity.this, "Please select a location.", Toast.LENGTH_SHORT);
                    toast.show();
                }
                else if (timeZoneSpinner.getSelectedItem() == null) {
                    Toast toast = Toast.makeText(DeviceActivity.this, "Please select a time zone.", Toast.LENGTH_SHORT);
                    toast.show();
                }
                else {
                    MacAddress = getMac();

                    if(MacAddress != null) {
                        DAL d = new DAL();
                        String[] str;

                        RegisterDevice rd = new RegisterDevice();
                        rd.execute();
                    }

                    String root = Environment.getExternalStorageDirectory().toString();
                    File file= new File("Config.xml");

                    if (file.exists()) {
                        file.delete();
                    }

                    saveToXML("Config.xml");

                    Handler handler = new Handler();
                    handler.postDelayed(new Runnable() {
                        @Override
                        public void run() {
                            Intent i = new Intent(DeviceActivity.this, LoginActivity.class);
                            i.putExtra("companyId", companyId);
                            i.putExtra("locationId", locationId);
                            startActivity(i);
                        }
                    }, 4000);
                }

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

    //Check web service
    public String CheckWebservice(String urlstring)
    {
        String s = "";
        try
        {
            URL url = new URL(urlstring);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            int responseCode = connection.getResponseCode();
            if(responseCode == HttpURLConnection.HTTP_OK) {
                s = "Available";
            }
            else {
                s = "Unavailable";
            }

        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
        return s;
    }

    private class LoadCompanies extends AsyncTask<String,String,String> {
        protected void onPostExecute(String result) {
            Document doc = null;
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            try {
                DocumentBuilder db = dbf.newDocumentBuilder();

                InputSource is = new InputSource();
                is.setCharacterStream(new StringReader(result));
                doc = db.parse(is);

            } catch (ParserConfigurationException e) {
                Log.e("Error: ", e.getMessage());
            } catch (SAXException e) {
                Log.e("Error: ", e.getMessage());
            } catch (IOException e) {
                Log.e("Error: ", e.getMessage());
            }

            // return DOM
            List<String> companies = new ArrayList<String>();
            HtCompanies = new Hashtable<String, String>();
            NodeList nl = doc.getElementsByTagName("Table");
            {
                for (int i = 0; i < nl.getLength(); i++) {
                    Element e = (Element) nl.item(i);
                    try {
                        HtCompanies.put(getValue(e, "Name"),getValue(e, "Code"));
                        companies.add(getValue(e, "Name"));
                    } catch (Exception ex) {
                        ex.printStackTrace();
                    }
                }

                final ArrayAdapter aa = new ArrayAdapter<>(getApplicationContext(), android.R.layout.simple_spinner_dropdown_item, companies);
                companiesSpinner.setAdapter(aa);
            }
        }

        @Override
        protected String doInBackground(String... params) {
            String response = null;
            String METHOD_NAME = "GetData";
            String NAMESPACE = "http://tempuri.org";
            String SOAP_ACTION = NAMESPACE+"/"+METHOD_NAME;
            String URL = serviceURL.getText().toString();//"http://26.11.251.144:8081/Service.asmx";

            //String values?
            String[] str = new String[]{"Company_3000"};

            BufferedReader reader = null;

            try {
                String body= "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\n" +
                        "  <soap:Body>\n" +
                        "    <GetData xmlns=\"http://tempuri.org/\">\n" +
                        "      <Param>\n" +
                        "        <string>"+str[0]+"</string>\n" +
                        "      </Param>\n" +
                        "    </GetData>\n" +
                        "  </soap:Body>\n" +
                        "</soap:Envelope>";

                try {
                    java.net.URL url = new java.net.URL(URL);
                    HttpURLConnection conn = (HttpURLConnection) url.openConnection();
                    conn.setRequestMethod("POST");
                    conn.setDoOutput(true);
                    conn.setDefaultUseCaches(false);
                    conn.setRequestProperty("Accept", "*/*");
                    conn.setRequestProperty("Content-Type", "text/xml");
                    conn.setRequestProperty("SOAPAction", SOAP_ACTION);

                    //push the request to the server address

                    OutputStreamWriter wr = new OutputStreamWriter(conn.getOutputStream());
                    wr.write(body);
                    wr.flush();

                    //get the server response
                    int code=conn.getResponseCode();

                    reader = new BufferedReader(new InputStreamReader(conn.getInputStream()));
                    StringBuilder builder = new StringBuilder();
                    String line = null;

                    while ((line = reader.readLine()) != null) {
                        builder.append(line);
                        response = builder.toString();//this is the response, parse it in onPostExecute
                    }
                }
                catch (Exception e) {
                    e.printStackTrace();
                }
                finally {
                    try {
                        reader.close();
                    }
                    catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            } catch (Exception e) {

                e.printStackTrace();
            }
            return response;
        }

        public String getValue(Element item, String str) {
            NodeList n = item.getElementsByTagName(str);
            return this.getElementValue(n.item(0));
        }

        public final String getElementValue( Node elem ) {
            Node child;
            if( elem != null){
                if (elem.hasChildNodes()){
                    for( child = elem.getFirstChild(); child != null; child = child.getNextSibling() ){
                        if( child.getNodeType() == Node.TEXT_NODE  ){
                            return child.getNodeValue();
                        }
                    }
                }
            }
            return "";
        }
    }

    private class LoadLocation extends AsyncTask<String,String,String> {
        protected void onPostExecute(String result)
        {
            Document doc = null;
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            try {
                DocumentBuilder db = dbf.newDocumentBuilder();

                InputSource is = new InputSource();
                is.setCharacterStream(new StringReader(result));
                doc = db.parse(is);

            } catch (ParserConfigurationException e) {
                Log.e("Error: ", e.getMessage());
            } catch (SAXException e) {
                Log.e("Error: ", e.getMessage());
            } catch (IOException e) {
                Log.e("Error: ", e.getMessage());
            }

            // return DOM
            List<String> locations = new ArrayList<String>();
            HtLocations = new Hashtable<String, String>();
            NodeList nl = doc.getElementsByTagName("Table");
            {
                for (int i = 0; i < nl.getLength(); i++) {
                    Element e = (Element) nl.item(i);
                    try {
                        HtLocations.put(getValue(e, "Name"),getValue(e, "Code"));
                        locations.add(getValue(e, "Name"));
                    } catch (Exception ex) {
                        ex.printStackTrace();
                    }
                }

                final ArrayAdapter aa = new ArrayAdapter<>(getApplicationContext(), android.R.layout.simple_spinner_dropdown_item, locations);
                locationSpinner.setAdapter(aa);
            }
        }

        @Override
        protected String doInBackground(String... params) {
            String response = null;
            String METHOD_NAME = "GetData";
            String NAMESPACE = "http://tempuri.org";
            String SOAP_ACTION = NAMESPACE+"/"+METHOD_NAME;
            String URL = "http://26.11.251.144:8081/Service.asmx";


            //String s = HtCompanies.get(companiesSpinner.getSelectedItem().toString());
            String s = params[0];

            String[] str = new String[]{"Location_3000", s, "%"};

            BufferedReader reader = null;

            try {
                String body= "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\n" +
                        "  <soap:Body>\n" +
                        "    <GetData xmlns=\"http://tempuri.org/\">\n" +
                        "      <Param>\n" +
                        "        <string>"+str[0]+"</string>\n" +
                        "        <string>"+str[1]+"</string>\n" +
                        "        <string>"+str[2]+"</string>\n" +
                        "      </Param>\n" +
                        "    </GetData>\n" +
                        "  </soap:Body>\n" +
                        "</soap:Envelope>";

                try {
                    java.net.URL url = new java.net.URL(URL);
                    HttpURLConnection conn = (HttpURLConnection) url.openConnection();
                    conn.setRequestMethod("POST");
                    conn.setDoOutput(true);
                    conn.setDefaultUseCaches(false);
                    conn.setRequestProperty("Accept", "*/*");
                    conn.setRequestProperty("Content-Type", "text/xml");
                    conn.setRequestProperty("SOAPAction", SOAP_ACTION);

                    //push the request to the server address

                    OutputStreamWriter wr = new OutputStreamWriter(conn.getOutputStream());
                    wr.write(body);
                    wr.flush();

                    //get the server response
                    int code=conn.getResponseCode();

                    reader = new BufferedReader(new InputStreamReader(conn.getInputStream()));
                    StringBuilder builder = new StringBuilder();
                    String line = null;

                    while ((line = reader.readLine()) != null) {
                        builder.append(line);
                        response = builder.toString();//this is the response, parse it in onPostExecute
                    }
                }
                catch (Exception e) {
                    e.printStackTrace();
                }
                finally {
                    try {
                        reader.close();
                    }
                    catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            } catch (Exception e) {

                e.printStackTrace();
            }
            return response;
        }

        public String getValue(Element item, String str) {
            NodeList n = item.getElementsByTagName(str);
            return this.getElementValue(n.item(0));
        }

        public final String getElementValue( Node elem ) {
            Node child;
            if( elem != null){
                if (elem.hasChildNodes()){
                    for( child = elem.getFirstChild(); child != null; child = child.getNextSibling() ){
                        if( child.getNodeType() == Node.TEXT_NODE  ){
                            return child.getNodeValue();
                        }
                    }
                }
            }
            return "";
        }
    }

    public String getMac() {
        try{
            List<NetworkInterface> networkInterfaceList = Collections.list(NetworkInterface.getNetworkInterfaces());
            String stringMac = "";
            for(NetworkInterface networkInterface : networkInterfaceList)
            {
                if(networkInterface.getName().equalsIgnoreCase("wlon0"));
                {
                    for(int i = 0 ;i <networkInterface.getHardwareAddress().length; i++){
                        String stringMacByte = Integer.toHexString(networkInterface.getHardwareAddress()[i]& 0xFF);
                        if(stringMacByte.length() == 1)
                        {
                            stringMacByte = "0" +stringMacByte;
                        }
                        stringMac = stringMac + stringMacByte.toUpperCase() + ":";
                    }
                    break;
                }
            }
            return stringMac;
        }catch (SocketException e)
        {
            e.printStackTrace();
        }
        return  "0";
    }

    private class SaveData extends AsyncTask<String,String,String> {
        protected void onPostExecute(String result)
        {
            Document doc = null;
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            try {
                DocumentBuilder db = dbf.newDocumentBuilder();

                InputSource is = new InputSource();
                is.setCharacterStream(new StringReader(result));
                doc = db.parse(is);

            } catch (ParserConfigurationException e) {
                Log.e("Error: ", e.getMessage());
            } catch (SAXException e) {
                Log.e("Error: ", e.getMessage());
            } catch (IOException e) {
                Log.e("Error: ", e.getMessage());
            }


            NodeList nl = doc.getElementsByTagName("Table");
            String macAddressString = "";

            int length = nl.getLength();
            if(length > 0) {
                Element e = (Element) nl.item(0);
                try {
                    macAddressString = (getValue(e, "MAC_x0020_Address"));
                } catch (Exception ex) {
                    ex.printStackTrace();
                }
            }
            if(macAddressString != getMac()) {
                Toast toast = Toast.makeText(DeviceActivity.this, "Same device id has already been registered", Toast.LENGTH_SHORT);
                toast.show();

            }
            deviceidString = MacAddress;
            RegisterDevice rd = new RegisterDevice();
            rd.execute();
        }

        @Override
        protected String doInBackground(String... params) {
            String response = null;
            String METHOD_NAME = "GetData";
            String NAMESPACE = "http://tempuri.org";
            String SOAP_ACTION = NAMESPACE + "/" + METHOD_NAME;
            String URL = "http://26.11.251.144:8081/Service.asmx";

            String s = params[0];

            String[] str = new String[]{"HHT_Register_3000", HtCompanies.get(companiesSpinner.getSelectedItem().toString()), deviceID.getText().toString()};

            BufferedReader reader = null;

            try {
                String body = "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\n" +
                        "  <soap:Body>\n" +
                        "    <GetData xmlns=\"http://tempuri.org/\">\n" +
                        "      <Param>\n" +
                        "        <string>" + str[0] + "</string>\n" +
                        "        <string>" + str[1] + "</string>\n" +
                        "        <string>" + str[2] + "</string>\n" +
                        "      </Param>\n" +
                        "    </GetData>\n" +
                        "  </soap:Body>\n" +
                        "</soap:Envelope>";

                try {
                    java.net.URL url = new java.net.URL(URL);
                    HttpURLConnection conn = (HttpURLConnection) url.openConnection();
                    conn.setRequestMethod("POST");
                    conn.setDoOutput(true);
                    conn.setDefaultUseCaches(false);
                    conn.setRequestProperty("Accept", "*/*");
                    conn.setRequestProperty("Content-Type", "text/xml");
                    conn.setRequestProperty("SOAPAction", SOAP_ACTION);

                    //push the request to the server address

                    OutputStreamWriter wr = new OutputStreamWriter(conn.getOutputStream());
                    wr.write(body);
                    wr.flush();

                    //get the server response
                    int code = conn.getResponseCode();

                    reader = new BufferedReader(new InputStreamReader(conn.getInputStream()));
                    StringBuilder builder = new StringBuilder();
                    String line = null;

                    while ((line = reader.readLine()) != null) {
                        builder.append(line);
                        response = builder.toString();//this is the response, parse it in onPostExecute
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                } finally {
                    try {
                        reader.close();
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            } catch (Exception e) {

                e.printStackTrace();
            }
            return response;
        }
        public String getValue(Element item, String str) {
            NodeList n = item.getElementsByTagName(str);
            return this.getElementValue(n.item(0));
        }

        public final String getElementValue( Node elem ) {
            Node child;
            if( elem != null){
                if (elem.hasChildNodes()){
                    for( child = elem.getFirstChild(); child != null; child = child.getNextSibling() ){
                        if( child.getNodeType() == Node.TEXT_NODE  ){
                            return child.getNodeValue();
                        }
                    }
                }
            }
            return "";
        }
    }
    private class RegisterDevice extends AsyncTask<String,String,String> {
        protected void onPostExecute(String result)
        {
            Document doc = null;
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            try {
                DocumentBuilder db = dbf.newDocumentBuilder();

                InputSource is = new InputSource();
                is.setCharacterStream(new StringReader(result));
                doc = db.parse(is);

            } catch (ParserConfigurationException e) {
                Log.e("Error: ", e.getMessage());
            } catch (SAXException e) {
                Log.e("Error: ", e.getMessage());
            } catch (IOException e) {
                Log.e("Error: ", e.getMessage());
            }

            // return DOM

            NodeList nl = doc.getElementsByTagName("Table");
            strLength = Integer.toString(nl.getLength());

            SetRegisterDevice srd = new SetRegisterDevice();
            srd.execute(strLength);
        }

        @Override
        protected String doInBackground(String... params) {
            String response = null;
            String METHOD_NAME = "GetData";
            String NAMESPACE = "http://tempuri.org";
            String SOAP_ACTION = NAMESPACE+"/"+METHOD_NAME;
            String URL = "http://26.11.251.144:8081/Service.asmx";

            //String s = params[0];

            String[] str = new String[]{"HHT_Register_3001", HtCompanies.get(companiesSpinner.getSelectedItem().toString()), deviceidString};

            BufferedReader reader = null;

            try {
                String body= "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\n" +
                        "  <soap:Body>\n" +
                        "    <GetData xmlns=\"http://tempuri.org/\">\n" +
                        "      <Param>\n" +
                        "        <string>"+str[0]+"</string>\n" +
                        "        <string>"+str[1]+"</string>\n" +
                        "        <string>"+str[2]+"</string>\n" +
                        "      </Param>\n" +
                        "    </GetData>\n" +
                        "  </soap:Body>\n" +
                        "</soap:Envelope>";

                try {
                    java.net.URL url = new java.net.URL(URL);
                    HttpURLConnection conn = (HttpURLConnection) url.openConnection();
                    conn.setRequestMethod("POST");
                    conn.setDoOutput(true);
                    conn.setDefaultUseCaches(false);
                    conn.setRequestProperty("Accept", "*/*");
                    conn.setRequestProperty("Content-Type", "text/xml");
                    conn.setRequestProperty("SOAPAction", SOAP_ACTION);

                    //push the request to the server address

                    OutputStreamWriter wr = new OutputStreamWriter(conn.getOutputStream());
                    wr.write(body);
                    wr.flush();

                    //get the server response
                    int code=conn.getResponseCode();

                    reader = new BufferedReader(new InputStreamReader(conn.getInputStream()));
                    StringBuilder builder = new StringBuilder();
                    String line = null;

                    while ((line = reader.readLine()) != null) {
                        builder.append(line);
                        response = builder.toString();//this is the response, parse it in onPostExecute
                    }
                }
                catch (Exception e) {
                    e.printStackTrace();
                }
                finally {
                    try {
                        reader.close();
                    }
                    catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            } catch (Exception e) {

                e.printStackTrace();
            }
            return response;
        }

        public String getValue(Element item, String str) {
            NodeList n = item.getElementsByTagName(str);
            return this.getElementValue(n.item(0));
        }

        public final String getElementValue( Node elem ) {
            Node child;
            if( elem != null){
                if (elem.hasChildNodes()){
                    for( child = elem.getFirstChild(); child != null; child = child.getNextSibling() ){
                        if( child.getNodeType() == Node.TEXT_NODE  ){
                            return child.getNodeValue();
                        }
                    }
                }
            }
            return "";
        }
    }

    private class SetRegisterDevice extends AsyncTask<String,String,String> {
        @Override
        protected void onPostExecute(String result)
        {
            Document doc = null;
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            try {
                DocumentBuilder db = dbf.newDocumentBuilder();

                InputSource is = new InputSource();
                is.setCharacterStream(new StringReader(result));
                doc = db.parse(is);

            } catch (ParserConfigurationException e) {
                Log.e("Error: ", e.getMessage());
            } catch (SAXException e) {
                Log.e("Error: ", e.getMessage());
            } catch (IOException e) {
                Log.e("Error: ", e.getMessage());
            }

            int length = Integer.parseInt(strLength);
            //NodeList nl = doc.getElementsByTagName("Table");
            if (length == 0)
            {
                Toast toast = Toast.makeText(DeviceActivity.this, "Saved Successfully", Toast.LENGTH_SHORT);
                toast.show();
            }
            else
            {
                Toast toast = Toast.makeText(DeviceActivity.this, "Updated Successfully", Toast.LENGTH_SHORT);
                toast.show();
            }

        }

        @Override
        protected String doInBackground(String... params) {
            String response = null;
            String METHOD_NAME = "SetData";
            String NAMESPACE = "http://tempuri.org";
            String SOAP_ACTION = NAMESPACE+"/"+METHOD_NAME;
            String URL = "http://26.11.251.144:8081/Service.asmx";

            String s = params[0];
            int length = Integer.parseInt(s);

            String[] str = new String[]{ (length == 0 ? "HHT_Register_1000" : "HHT_Register_4000"), HtCompanies.get(companiesSpinner.getSelectedItem()).toString(),
                    deviceidString, deviceID.getText().toString(), HtLocations.get(locationSpinner.getSelectedItem().toString())};

            BufferedReader reader = null;

            try {
                String body= "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\n" +
                        "  <soap:Body>\n" +
                        "    <SetData xmlns=\"http://tempuri.org/\">\n" +
                        "      <Param>\n" +
                        "        <string>"+str[0]+"</string>\n" +
                        "        <string>"+str[1]+"</string>\n" +
                        "        <string>"+str[2]+"</string>\n" +
                        "        <string>"+str[3]+"</string>\n" +
                        "        <string>"+str[4]+"</string>\n" +
                        "      </Param>\n" +
//                        "      <dataset>\n" +
//                        "        <xsd:schema></xsd:schema>xml</dataset>" +
                        "    </SetData>\n" +
                        "  </soap:Body>\n" +
                        "</soap:Envelope>";

                try {
                    java.net.URL url = new java.net.URL(URL);
                    HttpURLConnection conn = (HttpURLConnection) url.openConnection();
                    conn.setRequestMethod("POST");
                    conn.setDoOutput(true);
                    conn.setDefaultUseCaches(false);
                    conn.setRequestProperty("Accept", "*/*");
                    conn.setRequestProperty("Content-Type", "text/xml");
                    conn.setRequestProperty("SOAPAction", SOAP_ACTION);

                    //push the request to the server address

                    OutputStreamWriter wr = new OutputStreamWriter(conn.getOutputStream());
                    wr.write(body);
                    wr.flush();

                    //get the server response
                    int code=conn.getResponseCode();

                    reader = new BufferedReader(new InputStreamReader(conn.getInputStream()));
                    StringBuilder builder = new StringBuilder();
                    String line = null;

                    while ((line = reader.readLine()) != null) {
                        builder.append(line);
                        response = builder.toString();//this is the response, parse it in onPostExecute
                    }
                }
                catch (Exception e) {
                    e.printStackTrace();
                }
                finally {
                    try {
                        reader.close();
                    }
                    catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            } catch (Exception e) {

                e.printStackTrace();
            }
            return response;
        }

        public String getValue(Element item, String str) {
            NodeList n = item.getElementsByTagName(str);
            return this.getElementValue(n.item(0));
        }

        public final String getElementValue( Node elem ) {
            Node child;
            if( elem != null){
                if (elem.hasChildNodes()){
                    for( child = elem.getFirstChild(); child != null; child = child.getNextSibling() ){
                        if( child.getNodeType() == Node.TEXT_NODE  ){
                            return child.getNodeValue();
                        }
                    }
                }
            }
            return "";
        }
    }
    public void saveToXML(String xmlFile) {

        try {
            String file = "Config.xml";
            File yourFile = new File(file);
              //yourFile.createNewFile(); // if file already exists will do nothing
            //FileOutputStream fos = new FileOutputStream(yourFile, false);

            FileOutputStream fos = new FileOutputStream(yourFile);
            //FileOutputStream fos;
            //fos = openFileOutput(file, Context.MODE_APPEND);

            XmlSerializer serializer = Xml.newSerializer();
            serializer.setOutput(fos, "UTF-8");
            serializer.startDocument(null, Boolean.valueOf(true));
            serializer.setFeature("http://xmlpull.org/v1/doc/features.html#indent-output", true);
            serializer.startTag(null, "DeviceManagement");

            serializer.startTag(null, "ServiceURL");
            serializer.text(serviceURL.getText().toString());
            serializer.endTag(null, "ServiceURL");

            serializer.startTag(null, "DeviceID");
            serializer.text(deviceID.getText().toString());
            serializer.endTag(null, "DeviceID");

            serializer.startTag(null, "DeviceName");
            serializer.text(deviceName.getText().toString());
            serializer.endTag(null, "DeviceName");

            serializer.startTag(null, "CompanyName");
            serializer.text(companiesSpinner.getSelectedItem().toString());
            serializer.endTag(null, "CompanyName");

            serializer.startTag(null, "CompanyId");
            serializer.text(HtCompanies.get(companiesSpinner.getSelectedItem().toString()));
            serializer.endTag(null, "CompanyId");

            serializer.startTag(null, "LocationId");
            serializer.text(HtLocations.get(locationSpinner.getSelectedItem().toString()));
            serializer.endTag(null, "LocationId");

            serializer.startTag(null, "LocationName");
            serializer.text(locationSpinner.getSelectedItem().toString());
            serializer.endTag(null, "LocationName");

            serializer.startTag(null, "TimeZoneId");
            serializer.text(HtTimeZones.get(timeZoneSpinner.getSelectedItem().toString()));
            serializer.endTag(null, "TimeZoneId");

            serializer.startTag(null, "TimeZone");
            serializer.text(timeZoneSpinner.getSelectedItem().toString());
            serializer.endTag(null, "TimeZone");

            serializer.startTag(null, "IPAddress");
            serializer.text(GetIPAddress());
            serializer.endTag(null, "IPAddress");

            serializer.startTag(null, "MACAddress");
            serializer.text(getMac());
            serializer.endTag(null, "MACAddress");

            serializer.endDocument();
            serializer.flush();

            fos.close();

        }
        catch (Exception e) {
            e.printStackTrace();
        }

    }

    public String GetIPAddress() {
        try {
            for (Enumeration<NetworkInterface> en = NetworkInterface.getNetworkInterfaces(); en.hasMoreElements(); ) {
                NetworkInterface intf = en.nextElement();
                for (Enumeration<InetAddress> enumIpAddr = intf.getInetAddresses(); enumIpAddr.hasMoreElements(); ) {
                    InetAddress inetAddress = enumIpAddr.nextElement();
                    if (!inetAddress.isLoopbackAddress() && inetAddress instanceof Inet4Address) {
                        return inetAddress.getHostAddress();
                    }
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }

    public List<String> getTimeZones() {
        String sql = "SELECT Id,DisplayName FROM TimeZoneInfo";
        ArrayList<String> timeZones = new ArrayList<String>();
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        try {
            Class.forName(driver);
            Connection conn = DriverManager.getConnection(url);

            Statement statement = conn.createStatement();
            ResultSet rs = statement.executeQuery(sql);


            while (rs.next()) {
                HtTimeZones.put(rs.getString("DisplayName"), rs.getString("Id"));
                String timeZone = rs.getString("DisplayName");
                timeZones.add(timeZone);

            }
            conn.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return timeZones;
    }
}
