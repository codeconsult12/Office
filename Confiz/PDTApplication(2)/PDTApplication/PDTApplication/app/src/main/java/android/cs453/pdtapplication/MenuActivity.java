package android.cs453.pdtapplication;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.cardview.widget.CardView;

import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
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

import java.util.*;

public class MenuActivity extends AppCompatActivity {

    private CardView priceChecker, store, salesInvoice, sync, purchaseOrder, device;
    private Button logoutButton;
    private TextView textview1;
    private int index;
    private static final String SOAP_ACTION = "";
    private static final String METHOD_NAME = "";
    private static final String NAMESPACE = "http://26.11.251.144:8080";
    private static final String URL = "http://26.11.251.144:8081/service.asmx";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.menu_activity);

        //Getting data from Login class
        Bundle data = getIntent().getExtras();
        User user = (User) data.getParcelable("CURRENT_USER");
        index = data.getInt("index");
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

        //UserRights permission = userRights.get(index);

        //Price Checker
        priceChecker.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                /*
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

                 */
            }
        });

        //Store
        store.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                /*
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

                 */
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

    private void openPriceChecker() {
        Intent intent = new Intent(this, PriceCheckerActivity.class);
        startActivity(intent);
    }
}