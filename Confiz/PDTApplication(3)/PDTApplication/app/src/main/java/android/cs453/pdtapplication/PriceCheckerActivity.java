package android.cs453.pdtapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Environment;
import android.os.Handler;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.MotionEvent;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.InputSource;
import org.xml.sax.SAXException;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.StringReader;
import java.net.HttpURLConnection;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.List;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

public class PriceCheckerActivity extends AppCompatActivity {

    EditText barcode, itemCode;
    TextView description, vendor, unitPrice, salesPrice, promotionalPrice;
    Spinner UOMSpinner;
    Button back;

    Property device = new Property();
    Price price = new Price();
    ArrayList<Price> items = new ArrayList<Price>();
    ArrayList<Property> devices = new ArrayList<Property>();
    List<String> UOMList = new ArrayList<>();


    public PriceCheckerActivity() throws IOException {
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_price_checker);

//        Bundle data = getIntent().getExtras();
  //      companyId = data.getString("companyId");
    //    locationId = data.getString("locationId");

        barcode = (EditText) findViewById(R.id.barcode_edit_text);
        itemCode = (EditText) findViewById(R.id.item_code_edit_text);
        description = (TextView) findViewById(R.id.description_text_view);
        vendor = (TextView) findViewById(R.id.vendor_text_view);
        unitPrice = (TextView) findViewById(R.id.unit_price_text_view);
        salesPrice = (TextView) findViewById(R.id.sales_price_text_view);
        promotionalPrice = (TextView)findViewById(R.id.promotional_price_text_view);
        UOMSpinner = (Spinner) findViewById(R.id.UOM_spinner);
        back = (Button) findViewById(R.id.back_button);

        //String[] UOM = new String[]{};
        //ArrayAdapter<String> adapter1 = new ArrayAdapter(this, android.R.layout.simple_spinner_dropdown_item, UOM);
        //UOMSpinner.setAdapter(adapter1);

        /*
        try {
            File file = new File("/data/user/0/android.cs453.pdtapplication/files/Config.xml");

            if (file.exists())
            {
                InputStream is = null;
                try {
                    is = new FileInputStream("/data/user/0/android.cs453.pdtapplication/files/Config.xml");
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
                            Element elm = (Element)nList.item(i);
                            device.SetServiceURL(getNodeValue("ServiceURL", elm));
                            device.SetDeviceID(getNodeValue("DeviceID", elm));
                            device.SetDeviceName(getNodeValue("DeviceName", elm));
                            device.SetCompanyName(getNodeValue("CompanyName", elm));
                            device.SetCompanyId(getNodeValue("CompanyId", elm));
                            device.SetLocationId(getNodeValue("LocationId", elm));
                            device.SetLocationName(getNodeValue("LocationName", elm));
                            device.SetTimeZoneId(getNodeValue("TimeZoneId", elm));
                            device.SetTimeZone(getNodeValue("TimeZone", elm));
                            device.SetIPAddress(getNodeValue("IPAddress", elm));
                            device.SetMACAddress(getNodeValue("MACAddress", elm));

                            devices.add(device);
                        }
                    }
                }
                catch (Exception e){
                    e.printStackTrace();
                }
            }
            else {
                Toast toast = Toast.makeText(this, "File not found", Toast.LENGTH_LONG);
                toast.show();
            }
        }
        catch (Exception e) {
            e.printStackTrace();
        }
         */
        
        try{
            File file = new File("/data/user/0/android.cs453.pdtapplication/files/Config.xml");
            FileInputStream fis = new FileInputStream(file);
            //InputStream is = getAssets().open("Config.xml");
            //InputStream is = getAssets().open("/data/user/0/android.cs453.pdtapplication/files/Config.xml");
            DocumentBuilderFactory builderFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder docBuilder = builderFactory.newDocumentBuilder();
            //Document doc = docBuilder.parse(is);
            Document doc = docBuilder.parse(fis);
            NodeList nList = doc.getElementsByTagName("DeviceManagement");
            for(int i =0;i<nList.getLength();i++){
                if(nList.item(0).getNodeType() == Node.ELEMENT_NODE) {
                    Element elm = (Element)nList.item(i);
                    device.SetServiceURL(getNodeValue("ServiceURL", elm));
                    device.SetDeviceID(getNodeValue("DeviceID", elm));
                    device.SetDeviceName(getNodeValue("DeviceName", elm));
                    device.SetCompanyName(getNodeValue("CompanyName", elm));
                    device.SetCompanyId(getNodeValue("CompanyId", elm));
                    device.SetLocationId(getNodeValue("LocationId", elm));
                    device.SetLocationName(getNodeValue("LocationName", elm));
                    device.SetTimeZoneId(getNodeValue("TimeZoneId", elm));
                    device.SetTimeZone(getNodeValue("TimeZone", elm));
                    device.SetIPAddress(getNodeValue("IPAddress", elm));
                    device.SetMACAddress(getNodeValue("MACAddress", elm));

                    devices.add(device);
                }
            }

        }
        catch (IOException e) {
            e.printStackTrace();
        } catch (ParserConfigurationException e) {
            e.printStackTrace();
        } catch (SAXException e) {
            e.printStackTrace();
        }


        //Barcode listener -- Barcodes: 8690088015571 - 4800194105972 - 03436602 - 6294003557256
        barcode.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if(barcode.getText().toString().length() != 0) {

                    LoadFromBarcode lfb = new LoadFromBarcode();
                    lfb.execute();

                }
            }
        });

        //Itemcode listener -- Itemcodes: AF00002929 - AF00002930 - AF00003032
        itemCode.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if(itemCode.getText().toString().length() != 0) {
                    LoadFromItemcode lfc = new LoadFromItemcode();
                    lfc.execute();
                }
            }
        });

        //UOM dropdown listener... need to fix str values
        UOMSpinner.setOnTouchListener(new View.OnTouchListener(){
            @Override
            public boolean onTouch(View v, MotionEvent event) {

                if(items.size() <= 1) {
                    UOMDropdown uom = new UOMDropdown();
                    uom.execute();
                }

                return false;
            }
        });

        UOMSpinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int position, long id) {

                if(UOMSpinner.getSelectedItem() != null) {

                    String selection = UOMSpinner.getSelectedItem().toString();
                    try {
                        for (int i = 0; i < items.size(); i++) {
                            if(items.get(i).getUOM().equals(selection)) {
                                barcode.setText(items.get(i).getBarcode());
                                itemCode.setText(items.get(i).getItemcode());
                                description.setText(items.get(i).getDescription());
                                vendor.setText(items.get(i).getVendor());
                                unitPrice.setText(items.get(i).getUnitPrice());
                                salesPrice.setText(items.get(i).getSalesPrice());

                            }
                        }
                        LoadPromotionalPrice lpp = (LoadPromotionalPrice) new LoadPromotionalPrice().execute(selection);
                    }
                    catch (Exception e) {
                        e.printStackTrace();
                    }
                }
                //LoadPromotionalPrice lpp = new LoadPromotionalPrice();
                //lpp.execute();
            }
            public void onNothingSelected(AdapterView<?> adapterView) {
                //ignore
            }
        });

        back.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                PriceCheckerActivity.this.finish();
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

    private class LoadFromBarcode extends AsyncTask<String,String,String> {
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
            String itemcodeString = "";
            String descriptionString = "";
            List<String> UOMList = new ArrayList<>();
            String UOMString = "";
            String vendorString = "";
            String unitPriceString = "";
            String salesPriceString = "";
            //Price price = new Price();
            NodeList nl = doc.getElementsByTagName("Table");

            Element e = doc.getDocumentElement();

            for (int i = 0; i < nl.getLength(); i++) {
                Element e1 = (Element) nl.item(i);
                try {
                    UOMList.add(getValue(e1, "UOM"));
                } catch (Exception ex) {
                    ex.printStackTrace();
                }
            }

            itemcodeString = getString("Itemcode", e);
            descriptionString = getString("Description", e);
            vendorString = getString("Vendor_x0020_Name", e);
            unitPriceString = getString("Unit_x0020_Price", e);
            salesPriceString = getString("Sales_x0020_Price", e);
            UOMString = getString("UOM", e);
            price = new Price(barcode.getText().toString(), itemcodeString, descriptionString, UOMString, vendorString, unitPriceString, salesPriceString);
            items.add(price);

            itemCode.setText(itemcodeString);
            description.setText(descriptionString);
            vendor.setText(vendorString);
            unitPrice.setText(unitPriceString);
            salesPrice.setText(salesPriceString);

            final ArrayAdapter aa = new ArrayAdapter<>(getApplicationContext(), android.R.layout.simple_spinner_dropdown_item, UOMList);
            UOMSpinner.setAdapter(aa);
        }

        @Override
        protected String doInBackground(String... params) {
            String response = null;
            String METHOD_NAME = "GetData";
            String NAMESPACE = "http://tempuri.org";
            String SOAP_ACTION = NAMESPACE+"/"+METHOD_NAME;
            String URL = "http://26.11.251.144:8081/Service.asmx";
            //String URL = device.GetServiceURL();

            //String s = params[0];

            String[] str = {"HHT_Barcodes_3001", "AFCS", "AFC1010", "", barcode.getText().toString()};
            //String[] str = {"HHT_Barcodes_3001", device.GetCompanyId(), device.GetLocationId(), "", barcode.getText().toString()};

            BufferedReader reader = null;

            try {
                String body= "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\n" +
                        "  <soap:Body>\n" +
                        "    <GetData xmlns=\"http://tempuri.org/\">\n" +
                        "      <Param>\n" +
                        "        <string>"+str[0]+"</string>\n" +
                        "        <string>"+str[1]+"</string>\n" +
                        "        <string>"+str[2]+"</string>\n" +
                        "        <string>"+str[3]+"</string>\n" +
                        "        <string>"+str[4]+"</string>\n" +
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

        public String getString(String tagName, Element element) {
            NodeList list = element.getElementsByTagName(tagName);
            if (list != null && list.getLength() > 0) {
                NodeList subList = list.item(0).getChildNodes();

                if (subList != null && subList.getLength() > 0) {
                    return subList.item(0).getNodeValue();
                }
            }

            return null;
        }
    }

    private class LoadFromItemcode extends AsyncTask<String,String,String> {
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
            String barcodeString = "";
            String descriptionString = "";
            List<String> UOMList = new ArrayList<>();
            String UOMString = "";
            String vendorString = "";
            String unitPriceString = "";
            String salesPriceString = "";
            NodeList nl = doc.getElementsByTagName("Table");

            Element e = doc.getDocumentElement();

            UOMList.clear();
            for (int i = 0; i < nl.getLength(); i++) {
                Element e1 = (Element) nl.item(i);
                try {
                    UOMList.add(getValue(e1, "UOM"));
                } catch (Exception ex) {
                    ex.printStackTrace();
                }
            }

            items.clear();
            barcodeString = getString("Barcode", e);
            descriptionString = getString("Description", e);
            vendorString = getString("Vendor_x0020_Name", e);
            unitPriceString = getString("Unit_x0020_Price", e);
            salesPriceString = getString("Sales_x0020_Price", e);
            price = new Price(barcodeString, itemCode.getText().toString(), descriptionString, vendorString, unitPriceString, salesPriceString);
            items.add(price);

            barcode.setText(barcodeString);
            description.setText(descriptionString);
            vendor.setText(vendorString);
            unitPrice.setText(unitPriceString);
            salesPrice.setText(salesPriceString);

            final ArrayAdapter aa = new ArrayAdapter<>(getApplicationContext(), android.R.layout.simple_spinner_dropdown_item, UOMList);
            UOMSpinner.setAdapter(aa);
        }

        @Override
        protected String doInBackground(String... params) {
            String response = null;
            String METHOD_NAME = "GetData";
            String NAMESPACE = "http://tempuri.org";
            String SOAP_ACTION = NAMESPACE+"/"+METHOD_NAME;
            String URL = "http://26.11.251.144:8081/Service.asmx";
            //String URL = device.GetServiceURL();

            //String s = params[0];

            String[] str = {"HHT_Barcodes_3000", "AFCS", "AFC1010", "", itemCode.getText().toString()};
            //String[] str = {"HHT_Barcodes_3000", device.GetCompanyId(), device.GetLocationId(), "", barcode.getText().toString()};

            BufferedReader reader = null;

            try {
                String body= "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\n" +
                        "  <soap:Body>\n" +
                        "    <GetData xmlns=\"http://tempuri.org/\">\n" +
                        "      <Param>\n" +
                        "        <string>"+str[0]+"</string>\n" +
                        "        <string>"+str[1]+"</string>\n" +
                        "        <string>"+str[2]+"</string>\n" +
                        "        <string>"+str[3]+"</string>\n" +
                        "        <string>"+str[4]+"</string>\n" +
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

        public String getString(String tagName, Element element) {
            NodeList list = element.getElementsByTagName(tagName);
            if (list != null && list.getLength() > 0) {
                NodeList subList = list.item(0).getChildNodes();

                if (subList != null && subList.getLength() > 0) {
                    return subList.item(0).getNodeValue();
                }
            }

            return null;
        }
    }

    private class UOMDropdown extends AsyncTask<String,String,String> {
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

            items.clear();  //Price ArrayList
            UOMList.clear();//String ArrayList

            NodeList nl = doc.getElementsByTagName("Table");

            for (int i = 0; i < nl.getLength(); i++) {
                Element e = (Element) nl.item(i);
                try {
                    Price pr = new Price();
                    pr.setBarcode(getValue(e, "Barcode"));
                    pr.setItemcode(getValue(e, "Itemcode"));
                    pr.setDescription(getValue(e, "Description"));
                    pr.setUOM(getValue(e, "UOM"));
                    pr.setVendor(getValue(e, "Vendor_x0020_Name"));
                    pr.setUnitPrice(getValue(e, "Unit_x0020_Price"));
                    pr.setSalesPrice(getValue(e, "Sales_x0020_Price"));
                    items.add(pr);  //ArrayList<Price>

                    UOMList.add(getValue(e, "UOM"));    //ArrayList<String>
                } catch (Exception ex) {
                    ex.printStackTrace();
                }
            }

            ArrayAdapter<String> adapter1 = new ArrayAdapter(getApplicationContext(), android.R.layout.simple_spinner_dropdown_item, UOMList);
            UOMSpinner.setAdapter(adapter1);
        }


        @Override
        protected String doInBackground(String... params) {
            String response = null;
            String METHOD_NAME = "GetData";
            String NAMESPACE = "http://tempuri.org";
            String SOAP_ACTION = NAMESPACE+"/"+METHOD_NAME;
            String URL = "http://26.11.251.144:8081/Service.asmx";

            //String s = params[0];

            String[] str = {"HHT_Barcodes_3000", "AFCS", "AFC1010", "", items.get(0).getItemcode()};

            BufferedReader reader = null;

            try {
                String body= "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\n" +
                        "  <soap:Body>\n" +
                        "    <GetData xmlns=\"http://tempuri.org/\">\n" +
                        "      <Param>\n" +
                        "        <string>"+str[0]+"</string>\n" +
                        "        <string>"+str[1]+"</string>\n" +
                        "        <string>"+str[2]+"</string>\n" +
                        "        <string>"+str[3]+"</string>\n" +
                        "        <string>"+str[4]+"</string>\n" +
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

        public String getString(String tagName, Element element) {
            NodeList list = element.getElementsByTagName(tagName);
            if (list != null && list.getLength() > 0) {
                NodeList subList = list.item(0).getChildNodes();

                if (subList != null && subList.getLength() > 0) {
                    return subList.item(0).getNodeValue();
                }
            }

            return null;
        }
    }

    private class LoadPromotionalPrice extends AsyncTask<String,String,String> {
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


            String selection = UOMSpinner.getSelectedItem().toString();
            Element e = doc.getDocumentElement();
            String promotion = "";

            promotion = getValue(e, "GETPriceResult");
            promotionalPrice.setText(promotion);

            /*
            for (int i = 0; i < items.size(); i++) {
                if (items.get(i).getUOM().equals(selection)) {
                    promotion = getValue(e, "GETPriceResult");
                    promotionalPrice.setText(promotion);
                }
            }
            */
        }

        @Override
        protected String doInBackground(String... params) {
            String response = null;
            String METHOD_NAME = "GETPrice";
            String NAMESPACE = "http://tempuri.org";
            String SOAP_ACTION = NAMESPACE+"/"+METHOD_NAME;
            String URL = "http://26.11.251.144:8080/Service1.asmx";

            String s = params[0];       //s = UOMSpinner.getSelectedItem().toString()

            String[] str = {itemCode.getText().toString(), barcode.getText().toString(), s};

            BufferedReader reader = null;

            try {
                String body= "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\n" +
                        "  <soap:Body>\n" +
                        "    <GETPrice xmlns=\"http://tempuri.org/\">\n" +
                        "      <ItemId>"+str[0]+"</ItemId>\n" +
                        "      <Barcode>"+str[1]+"</Barcode>\n" +
                        "      <UOM>"+str[2]+"</UOM>\n" +
                        "    </GETPrice>\n" +
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

        public String getString(String tagName, Element element) {
            NodeList list = element.getElementsByTagName(tagName);
            if (list != null && list.getLength() > 0) {
                NodeList subList = list.item(0).getChildNodes();

                if (subList != null && subList.getLength() > 0) {
                    return subList.item(0).getNodeValue();
                }
            }
            return null;
        }
    }
}