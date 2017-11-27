package com.example.carrillo.santamarta;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

/**
 * Created by joser on 27/11/2017.
 */

public class AssetsliabilitiesActivity extends AppCompatActivity {

    private static EditText txtQuantity, txtTotal, txtRode, txtCode,txtClient, txtDate, txtDescription;
    private static TextView txtAccount, txtCategory, txtSubcategory;
    private Button back, insert, account, category, subCategory;
    private String token = "";
    private Contextdb contextdb = new Contextdb();
    private static Invoice invoice;
    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_assetsliabilities);


        txtQuantity = (EditText) findViewById(R.id.txt_total_rode);
        txtTotal = (EditText) findViewById(R.id.txt_total);
        txtRode = (EditText) findViewById(R.id.txt_rode);
        txtCode = (EditText) findViewById(R.id.txt_code);
        txtClient = (EditText) findViewById(R.id.txt_client);
        txtDate = (EditText) findViewById(R.id.txt_date);
        txtDescription = (EditText) findViewById(R.id.txt_description);
        txtAccount = (TextView) findViewById(R.id.txt_account);
        txtCategory = (TextView) findViewById(R.id.txt_category);
        txtSubcategory = (TextView) findViewById(R.id.txt_subCategory);
        back = (Button) findViewById(R.id.btn_back);
        insert = (Button) findViewById(R.id.btn_insert);
        account = (Button) findViewById(R.id.btn_account);
        category = (Button) findViewById(R.id.btn_category);
        subCategory = (Button) findViewById(R.id.btn_subCategory);
        token = MainActivity.token;
        final Contextdb contextdb = new Contextdb();
        display(InvoicesActivity.invoice);
        back.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                finish();
            }
        });

    }

    public void display(Invoice invoice) {
        if(invoice.getNameCompany().toString().equals("null")){
            txtClient.setText(invoice.getName());
            txtCode.setText(invoice.getCode());
            txtTotal.setText(String.valueOf(invoice.getTotal()));
            txtRode.setText(String.valueOf(invoice.getRode()));
            String dateCurent = "";
            Date date = new Date();
            Calendar calendar = Calendar.getInstance();
            calendar.add(Calendar.DATE, 0);
            date = calendar.getTime();
            SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
            dateCurent = format.format(date);
            txtDate.setText(dateCurent);
        }else {
            txtClient.setText(invoice.getNameCompany());
            txtCode.setText(invoice.getCode());
            txtTotal.setText(String.valueOf(invoice.getTotal()));
            txtRode.setText(String.valueOf(invoice.getRode()));
            String dateCurent = "";
            Date date = new Date();
            Calendar calendar = Calendar.getInstance();
            calendar.add(Calendar.DATE, 0);
            date = calendar.getTime();
            SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
            dateCurent = format.format(date);
            txtDate.setText(dateCurent);
        }
    }
}
