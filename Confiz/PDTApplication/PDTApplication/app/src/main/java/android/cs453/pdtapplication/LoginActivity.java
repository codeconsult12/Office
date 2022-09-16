package android.cs453.pdtapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;

import android.os.Environment;
import android.os.Handler;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;


import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.Inet4Address;
import java.net.InetAddress;
import java.net.MalformedURLException;
import java.net.NetworkInterface;
import java.net.URL;
import java.util.*;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

public class LoginActivity extends AppCompatActivity {

    private Button loginButton;
    private EditText username, password;
    private TextView incorrectCredentials, ipAddress,lblDeviceName,lblLocation,lblCompany;
    private User u;
    private int index;

    public boolean CheckInternetConnection() throws IOException {
        URL url=new URL("http://www.google.com");
        HttpURLConnection urlConnection= (HttpURLConnection)url.openConnection();
        urlConnection.setRequestMethod("GET");
        int StatusCode=urlConnection.getResponseCode();
        if (StatusCode==200){return true;}
        else{return  false;}
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.login_activity);

        loginButton = (Button) findViewById(R.id.login_button);
        username = (EditText) findViewById(R.id.username_edit_text);
        password = (EditText) findViewById(R.id.password_edit_text);
        incorrectCredentials = (TextView) findViewById(R.id.incorrect_credentials);
        ipAddress = (TextView) findViewById(R.id.ip);
     lblDeviceName=(TextView)findViewById(R.id.device_id);
        lblLocation=(TextView)findViewById(R.id.location);
        lblCompany=(TextView)findViewById(R.id.company);
        try
        {
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
                            lblDeviceName.setText(getNodeValue("DeviceName", elm));
                            lblCompany.setText(getNodeValue("CompanyName", elm));
                            lblLocation.setText(getNodeValue("LocationName", elm));
                            ipAddress.setText(getNodeValue("IPAddress", elm));
                        }
                    }
                }
                catch (Exception e){

                }
            }
            else {
                Toast toast = Toast.makeText(getApplicationContext(), "Device not registered! Please Register your device first.", Toast.LENGTH_LONG);

                Handler handler = new Handler();
                handler.postDelayed(new Runnable() {
                    @Override
                    public void run() {
                        Intent DeviceMgmt = new Intent(LoginActivity.this, DeviceActivity.class);
                        startActivity(DeviceMgmt);
                    }
                }, 4000);

/*                DeviceManagement dm = new DeviceManagement();
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
                }*/
            }
        }
        catch (Exception e)
        {
            ipAddress.setText("Not Found");
        }





        ipAddress.setText("IP: " + GetIPAddress());

        //Login button listener
        loginButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    boolean validUserID = false;
                    boolean validPassword = false;

                    DAL d = new DAL();
                    ArrayList<User> users = new ArrayList<>();
                    ArrayList<UserRights> rights = new ArrayList<>();
                    users = d.CheckDbConnection();
                    rights = d.GetUserRights("000032");


                    //username = 000032   password = 9000032        (index 4 in ArrayList)
                    if ((users != null) && (users.size() > 0)) {
                        for (int i = 0; i < users.size(); i++) {
                            u = users.get(i);

                            if ((username.getText().toString().equals(u.getUserID()))) {
                                validUserID = true;
                                if ((password.getText().toString().equals(u.getPassword()))) {
                                    //grant access to user
                                    validPassword = true;
                                    incorrectCredentials.setText("");
                                    index = i;
                                    login();
                                    break;
                                }
                            }
                        }
                        if ((validUserID == true) && (validPassword == true)) {
                            incorrectCredentials.setText("");
                        }
                        else if((validUserID == true) && (validPassword == false)) {
                            incorrectCredentials.setText("Invalid password. Please try again.");
                        }
                        else if((validUserID == false) && (validPassword == false)) {
                            incorrectCredentials.setText("Invalid username. Please try again.");
                        }
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
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
    private void login() {
        Intent intent = new Intent(LoginActivity.this, MenuActivity.class);
        intent.putExtra("CURRENT_USER", u);
        intent.putExtra("index", index);
        startActivity(intent);
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
}