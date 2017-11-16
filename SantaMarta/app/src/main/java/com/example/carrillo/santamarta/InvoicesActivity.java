package com.example.carrillo.santamarta;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.text.TextWatcher;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Carrillo on 9/21/2017.
 */

public class InvoicesActivity extends AppCompatActivity {

    private ListView list;
    private EditText txtadd;
    private ImageButton add;
    private Button back;
    private String token = "";
    private Contextdb contextdb = new Contextdb();
    private List<Invoice> listInvoices;
    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_invoices);

        list = (ListView) findViewById(R.id.list_invoices);
        add = (ImageButton) findViewById(R.id.btn_add);
        back = (Button) findViewById(R.id.btn_back);
        token = MainActivity.token;
        final Contextdb contextdb = new Contextdb();
        listInvoices = contextdb.getAllInvoices(token);
        display();
        back.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent menu = new Intent(InvoicesActivity.this, MenuActivity.class);
                startActivity(menu);
                finish();
            }
        });

        add.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent invoice = new Intent(InvoicesActivity.this, InsertInvoiceActivity.class);
                startActivity(invoice);
            }
        });

    }
    public void display() {
        if (listInvoices.size()==0) {
            List<String> search = new ArrayList<String>();
            search.add("Facturas no encontradas");
            ArrayAdapter<String> adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, search);
            //se setean los datos en el listView
            list.setAdapter(adapter);
        } else{
            ArrayAdapter<Invoice> adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, listInvoices);
            //se setean los datos en el listView
            list.setAdapter(adapter);
        }
    }
}
