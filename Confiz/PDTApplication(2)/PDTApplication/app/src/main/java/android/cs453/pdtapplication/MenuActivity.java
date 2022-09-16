package android.cs453.pdtapplication;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.cardview.widget.CardView;

import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.AndroidHttpTransport;
import org.ksoap2.transport.HttpTransportSE;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.InputSource;
import org.xml.sax.SAXException;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.StringReader;
import java.net.HttpURLConnection;
import java.util.*;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

public class MenuActivity extends AppCompatActivity {

    private CardView priceChecker, store, salesInvoice, sync, purchaseOrder, device;
    private Button logoutButton;
    private TextView textview1;
    private int index;
    private User user;
    private String companyId, locationId;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.menu_activity);

        //Getting data from Login class
        Bundle data = getIntent().getExtras();
        user = (User) data.getParcelable("CURRENT_USER");
        companyId = data.getString("companyId");
        locationId = data.getString("locationId");
        textview1 = (TextView)findViewById(R.id.dashboard_text_view);

        priceChecker = (CardView)findViewById(R.id.price_checker_card);
        store = (CardView)findViewById(R.id.store_card);
        salesInvoice = (CardView)findViewById(R.id.sales_invoice_card);
        sync = (CardView)findViewById(R.id.sync_card);
        purchaseOrder = (CardView)findViewById(R.id.purchase_order_card);
        device = (CardView)findViewById(R.id.device_card);
        logoutButton = (Button)findViewById(R.id.logout_button);

        DAL d1 = new DAL();
        ArrayList<UserRights> userRights;
        //userRights = d1.GetUserRights(user.getUserID());

        LoadPermission LP=new LoadPermission();
        LP.execute();

    }

    private void openPriceChecker() {
        Intent intent = new Intent(this, PriceCheckerActivity.class);
        intent.putExtra("companyId", companyId);
        intent.putExtra("locationId", locationId);
        startActivity(intent);
    }

    private class LoadPermission extends AsyncTask<String,String,String> {
        protected void onPostExecute(String result) {
            Document doc=null;
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
            ArrayList<UserRights> userRights = new ArrayList<UserRights>();
            NodeList nl = doc.getElementsByTagName("Table");
            {
                for (int i = 0; i < nl.getLength(); i++) {
                    Element e = (Element) nl.item(i);
                    UserRights ur = new UserRights();
                    ur.setHHTUserRoleCode(getValue(e, "HHT_x0020_User_x0020_Role_x0020_Code"));
                    ur.setTransactionType(getValue(e, "Transaction_x0020_Type"));
                    userRights.add(ur);
                }
            }

            //Price Checker
            priceChecker.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {

                boolean hasPcAccess = false;

                for (int i = 0; i < userRights.size(); i++) {
                    String s1 = userRights.get(i).getTransactionType();

                    if (s1.equals("PC")) {
                        hasPcAccess = true;
                    }
                }

                if(hasPcAccess == true) {
                    //Open price checker
                    openPriceChecker();
                }
                else {
                    AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(MenuActivity.this);
                    alertDialogBuilder.setMessage("User access has been denied.");
                    alertDialogBuilder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialogInterface, int arg1) {
                            dialogInterface.dismiss();
                        }
                    });
                    AlertDialog alertDialog = alertDialogBuilder.create();
                    alertDialog.show();
                }

                }
            });

            //Store
            store.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {


                String s1 = "";
                String s2 = "";
                for (int i = 0; i < userRights.size(); i++) {
                    s1 = userRights.get(i).getHHTUserRoleCode();
                    s2 = userRights.get(i).getTransactionType();
                    //delete this
                    AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(MenuActivity.this);
                    alertDialogBuilder.setMessage(s2);
                    alertDialogBuilder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialogInterface, int arg1) {
                            dialogInterface.dismiss();
                        }
                    });

                    AlertDialog alertDialog = alertDialogBuilder.create();
                    alertDialog.show();
                }
                }
            });

            //Sales Invoice
            salesInvoice.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {

                    AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(MenuActivity.this);
                    alertDialogBuilder.setMessage("User does not have permission to access Sales Invoice");
                    alertDialogBuilder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialogInterface, int arg1) {
                            dialogInterface.dismiss();
                        }
                    });

                    AlertDialog alertDialog = alertDialogBuilder.create();
                    alertDialog.show();
                }
            });

            //Sync
            sync.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {

                }
            });

            //Purchase
            purchaseOrder.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {

                }
            });

            //Device management
            device.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    Intent intent = new Intent(MenuActivity.this, DeviceActivity.class);
                    startActivity(intent);
                }
            });

            logoutButton.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    MenuActivity.this.finish();
                }
            });
        }

        @Override
        protected String doInBackground(String... params) {
            String response = null;
            String METHOD_NAME = "GetData";
            String NAMESPACE = "http://tempuri.org";
            String SOAP_ACTION = NAMESPACE+"/"+METHOD_NAME;
            String URL = "http://26.11.251.144:8081/Service.asmx";
            String emptyString = "";
            String[] str = new String[]{"HHT_User_Permission_3000", "afcs", user.getUserID(), emptyString};
            ArrayList<UserRights> userRights = new ArrayList<>();
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


}