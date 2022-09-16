package android.cs453.pdtapplication;
import android.os.StrictMode;

import org.ksoap2.serialization.Marshal;
import org.ksoap2.serialization.PropertyInfo;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;
import org.xmlpull.v1.XmlSerializer;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class DAL {

    //String connectionString = "Data Source=116.202.214.159;Initial Catalog=AFC1010;Persist Security Info=False;User ID=user_tm3;Password=qazwsx@1;";

    String dbName = "AFC1010";
    String serverip = "116.202.214.159";
    String serverport = "1433";
    String driver = "net.sourceforge.jtds.jdbc.Driver";
    String databaseUserName = "user_tm3";
    String databasePassword = "qazwsx@1";
    String url = "jdbc:jtds:sqlserver://" + serverip + ":" + serverport + ";databaseName=" + dbName + ";user=" + databaseUserName + ";password=" + databasePassword + ";";
    //private static final String SOAP_ACTION = "";
    //private static final String METHOD_NAME = "";
    //private static final String NAMESPACE = "http://26.11.251.144:8080";
    //private static final String URL = "http://26.11.251.144:8081/service.asmx";

    //Users
    public ArrayList<User> CheckDbConnection() {
        String sql = "SELECT * FROM [ax].HHTUSERSETUP";
        ArrayList<User> users = new ArrayList<User>();
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        try {
            Class.forName(driver);
            Connection conn = DriverManager.getConnection(url);

            Statement statement = conn.createStatement();
            ResultSet rs = statement.executeQuery(sql);

            while (rs.next()) {
                User newUser = new User(rs.getString("USERID"), rs.getString("PASSWORD"));
                users.add(newUser);
            }
            conn.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return users;
    }


    //User Rights (Permission)
    //public ArrayList<UserRights> GetUserRights(String userId) {

        /*
        String SOAP_ACTION = "http://tempuri.org/GetData";
        String METHOD_NAME = "GetData";
        String NAMESPACE = "http://tempuri.org";
        String URL = "http://26.11.251.144:8081/service.asmx?op=GetData";
        String emptyString = "";

        String[] str = new String[]{"HHT_User_Permission_3000", "afcs", userId, emptyString};
       // List<String> str = Arrays.asList(new String[]{"HHT_User_Permission_3000", "afcs", userId, emptyString});
        ArrayList<UserRights> userRights = new ArrayList<>();

        SoapObject request = new SoapObject(NAMESPACE, METHOD_NAME);
        PropertyInfo property = new PropertyInfo();
        property.setName("Param");
        property.setValue(str);
        //property.setType();
        request.addProperty(property);

        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        MarshallArray arrayMarshal = new MarshallArray();
        arrayMarshal.register(envelope);
        envelope.setOutputSoapObject(request);
        HttpTransportSE androidHttpTransport = new HttpTransportSE(URL, 0);

        try {
            androidHttpTransport.call(SOAP_ACTION, envelope);
            //SoapObject result = (SoapObject)envelope.bodyIn;

            SoapPrimitive resultString = (SoapPrimitive) envelope.getResponse();

            ResultSet rs = (ResultSet) resultString;

            while (rs.next()) {
                UserRights ur = new UserRights();
                ur.setHHTUserRoleCode(rs.getString("HHT User Role Code"));
                ur.setTransactionType(rs.getString("Transaction Type"));
                userRights.add(ur);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }


         */
        //return userRights;
   // }

    /*
    //User Rights (Permission)
    public ArrayList<UserRights> GetUserRights(String userId) {
        String sql = "Select UP.CODE [HHTUserRoleCode], Case RP.MODULE  When 1 Then 'PO'  When 2 Then 'PI'  When 3 Then 'PR'  When 4" +
                " Then 'PRQ'  When 5 Then 'SO'  When 6 Then 'SI'  When 7 Then 'SR'  When 8 Then 'ADJ'  When 9 Then 'SC'  When 10 Then 'TRO'  When 11 Then" +
                " 'TRI'  When 12 Then 'PC'  When 13 Then 'IC'  When 14 Then 'SET'  When 15 Then 'PLC'  When 16 Then 'SLC'  When 17 Then 'SHRINK'  When 18 Then " +
                "'TRQ'  When 20 Then 'PRS'  When 21 Then 'TRS'  When 22 Then 'SRR'  When 23 Then 'SPC'  When 24 Then 'MISC' End [TransactionType] " +
                "From ax.HHTLOCATIONS UP Inner Join ax.HHTPERMISION RP On UP.CODE = RP.CODE WHERE UP.USERID = '"+ userId+"'";

        ArrayList<UserRights> userRights = new ArrayList<UserRights>();
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        try {
            Class.forName("net.sourceforge.jtds.jdbc.Driver");
            Connection conn = DriverManager.getConnection(url);

            Statement statement = conn.createStatement();
            ResultSet rs = statement.executeQuery(sql);

            while (rs.next()) {
                UserRights right = new UserRights();
                right.setHHTUserRoleCode(rs.getString("HHTUserRoleCode"));
                right.setTransactionType(rs.getString("TransactionType"));
                userRights.add(right);
            }
            conn.close();
        }
        catch (Exception e) {
            e.printStackTrace();
        }
        return userRights;
    }
    */

    public List<String[]> GetUserRightsDataFromCSV () throws IOException {
        int count = 0;
        String file = "UserRightsData.csv";
        List<String[]> rights = new ArrayList<>();

        try(BufferedReader br = new BufferedReader(new FileReader(file))) {
            String line = "";
            while ((line = br.readLine()) != null) {
                rights.add(line.split(","));
            }
        } catch (FileNotFoundException e) {
            //Some error logging
        }
        
        return rights;
    }



    public void CreateDB() {
        try {
            /*
            SqlCeLib.ConnectionString = string.Format("Data Source={0};Password=a1pntbs1365*;Max Database Size=1000;", string.Concat("Data.sdf"));
            SqlCeLib.CreateDatabase();
            SqlCeLib.Execute("Create Table [Parameter]([Code] nvarchar(10), [Description] nvarchar(250), [Value] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixCode On [Parameter] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [Location]([Code] nvarchar(10), [Name] nvarchar(250), [Location is a Warehouse] nvarchar(5))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixCode On [Location] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [Vendor]([Code] nvarchar(20), [Name] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixCode On Vendor ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [Customer]([Code] nvarchar(20), [Name] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixCode On Customer ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [Reason]([Code] nvarchar(10), [Description] nvarchar(250), [Type] nvarchar(10))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixCode On [Reason] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [Transporter]([Code] nvarchar(10), [Name] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixCode On [Transporter] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [HHT Setup]([AIF User Domain] nvarchar(250), [AIF User Name] nvarchar(250), [AIF User Password] nvarchar(250), [Version No.] nvarchar(10), [Location wise HHT Barcodes] nvarchar(5), [Download Purchase Invoice Line] nvarchar(5), [Download Purchase Return Line] nvarchar(5), [Download Sales Invoice Line] nvarchar(5), [Download Sales Return Line] nvarchar(5), [Download Transfer Shipment Line] nvarchar(5), [Download Transfer Receipt Line] nvarchar(5), [Show Purchase Invoice Line] nvarchar(5), [Show Purchase Return Line] nvarchar(5), [Show Sales Invoice Line] nvarchar(5), [Show Sales Return Line] nvarchar(5), [Show Transfer Shipment Line] nvarchar(5), [Show Transfer Receipt Line] nvarchar(5), [Check Item Validity - Stock] nvarchar(5), [Prompt on Invalid Barcode-SC] nvarchar(5), [Check Item Validity - Data] nvarchar(5), [Prompt on Invalid Barcode-Data] nvarchar(5), [Capture Reference No.] nvarchar(5), [Enable Auto Quantity - Data] nvarchar(5), [Enable Auto Quantity - SC] nvarchar(5), [iNTrack Web Service URL] nvarchar(250), [Download Path] nvarchar(250), [Update Path] nvarchar(250), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT Setup] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [HHT User Role]([Code] nvarchar(20), [Name] nvarchar(250), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixCode On [HHT User Role] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT User Role] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [HHT User Role Permission]([HHT User Role Code] nvarchar(20), [Transaction Type] nvarchar(20), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixCode On [HHT User Role Permission] ([HHT User Role Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT User Role Permission] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [HHT User Setup]([HHT User ID] nvarchar(20), [Password] nvarchar(10), [HHT User Name] nvarchar(250), [Backdated Document Allowed] nvarchar(5), [Show Inventory] nvarchar(5), [Show Cost Price] nvarchar(5), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixHHTUserID On [HHT User Setup] ([HHT User ID])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT User Setup] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [HHT User Permission]([HHT User ID] nvarchar(20), [Location Code] nvarchar(10), [HHT User Role Code] nvarchar(20), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixHHTUserID On [HHT User Permission] ([HHT User ID])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT User Permission] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixCombo On [HHT User Permission] ([HHT User ID], [Location Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [HHT Document Setup]([Location Code] nvarchar(10), [Transaction Type] nvarchar(20), [Backdated Document Allowed] nvarchar(5), [Negative Stock Allowed] nvarchar(5), [Show Inventory] nvarchar(5), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixCombo On [HHT Document Setup] ([Location Code], [Transaction Type])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [HHT Barcodes]([Itemcode] nvarchar(20), [Barcode] nvarchar(80), [Description] nvarchar(250), [Vendor] nvarchar(1000), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixItemcode On [HHT Barcodes] ([Itemcode])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixBarcode On [HHT Barcodes] ([Barcode])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixDescription On [HHT Barcodes] ([Description])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT Barcodes] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [Item Category]([Code] nvarchar(10), [Description] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixCode On [Item Category] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [Product Group]([Item Category Code] nvarchar(10), [Code] nvarchar(10), [Description] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixCode On [Product Group] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixCombo On [Product Group] ([Item Category Code], [Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [Transaction Header]([Transaction Type] nvarchar(10), [Transaction No.] nvarchar(20), [Source] nvarchar(20), [Source Name] nvarchar(250), [Destination] nvarchar(20), [Destination Name] nvarchar(250), [Document Date] datetime, [Expected Date] datetime, [Closing Date] datetime, [Reference No.1] nvarchar(20), [Reference No.2] nvarchar(20), [Reference No.3] nvarchar(20), [Reference No.4] nvarchar(20), [Reference No.5] nvarchar(20), [Receive] int, [Remarks] nvarchar(250), [Status] nvarchar(10), [Origin] nvarchar(10), [HHT User ID] nvarchar(20), [Created On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Index ixCombo On [Transaction Header] ([Transaction Type], [Transaction No.])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [Transaction Line]([Transaction Type] nvarchar(10), [Transaction No.] nvarchar(20), [Line No.] int, [Itemcode] nvarchar(20), [Barcode] nvarchar(20), [Description] nvarchar(250), [UOM] nvarchar(10), [Quantity] float, [Unit Price] float, [Amount] float, [Discount Perc.] float, [Discount Amount] float)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [HHT Transactions]([Line No.] int, [Transaction Type] nvarchar(10), [Transaction No.] nvarchar(20), [Source] nvarchar(20), [Source Name] nvarchar(250), [Destination] nvarchar(20), [Destination Name] nvarchar(250), [Itemcode] nvarchar(20), [Barcode] nvarchar(20), [Description] nvarchar(250), [UOM] nvarchar(10), [FOC Item] int, [Reason Code] nvarchar(10), [Reference No.1] nvarchar(20), [Reference No.2] nvarchar(20), [Reference No.3] nvarchar(20), [Reference No.4] nvarchar(20), [Reference No.5] nvarchar(20), [Quantity] float, [Unit Price] float, [Amount] float, [Status] nvarchar(10), [HHT User ID] nvarchar(20), [Created On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [HHT Stock Count Bin]([Count No.] nvarchar(20), [Location Code] nvarchar(20), [Bin Code] nvarchar(20), [Enable Count] int)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            SqlCeLib.Execute("Create Table [HHT Stock Count]([Line No.] int, [Count No.] nvarchar(20), [Location Code] nvarchar(20), [Bin Code] nvarchar(20), [Itemcode] nvarchar(20), [Barcode] nvarchar(20), [Description] nvarchar(250), [UOM] nvarchar(10), [Valid Item] int, [Quantity] float, [Unit Price] float, [Amount] float, [Status] nvarchar(10), [HHT User ID] nvarchar(20), [Created On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);

             */
        }
        catch (Exception e) {

        }
    }

    public class MarshallArray implements Marshal {
        //this method doesn't work yet
        public Object readInstance(XmlPullParser parser, String namespace, String name, PropertyInfo expected)
                throws IOException, XmlPullParserException {
            return parser.nextText();
        }

        public void register(SoapSerializationEnvelope cm) {
            cm.addMapping(cm.xsd, "String[]", String[].class, this);
        }

        public void writeInstance(XmlSerializer writer, Object obj) throws IOException {
            String[] myArray = (String[]) obj;
            for (int i = 0; i < myArray.length; i++) {
                        writer.startTag("", "string");
                        writer.text(myArray[i]);
                        writer.endTag("", "string");
                    }
            }
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


