package android.cs453.pdtapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

public class PriceCheckerActivity extends AppCompatActivity {

    EditText barcode, itemCode;
    TextView description, vendor, price;
    Spinner UOMSpinner;
    Button submit, back;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_price_checker);


        barcode = (EditText) findViewById(R.id.barcode_edit_text);
        itemCode = (EditText) findViewById(R.id.item_code_edit_text);
        description = (TextView) findViewById(R.id.description_text_view);
        vendor = (TextView) findViewById(R.id.vendor_text_view);
        price = (TextView) findViewById(R.id.price_text_view);
        UOMSpinner = (Spinner) findViewById(R.id.UOM_spinner);
        submit = (Button) findViewById(R.id.submit_button);
        back = (Button) findViewById(R.id.back_button);

        //String[] UOM = new String[]{};
        //ArrayAdapter<String> adapter1 = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, UOM);
        //UOMSpinner.setAdapter(adapter1);

        submit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

            }
        });

        back.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                PriceCheckerActivity.this.finish();
            }
        });
    }
}