package com.example.carrillo.santamarta;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;

/**
 * Created by Carrillo on 9/21/2017.
 */

public class InvoicesActivity extends AppCompatActivity {

    private ListView list;
    private EditText txtsearch;
    private ImageButton search;
    private Button back;

    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_invoices);

        list = (ListView) findViewById(R.id.list_clients);
        txtsearch = (EditText) findViewById(R.id.txt_search);
        search = (ImageButton) findViewById(R.id.btn_search);
        back = (Button) findViewById(R.id.btn_back);

        back.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent menu = new Intent(InvoicesActivity.this, MenuActivity.class);
                startActivity(menu);
                finish();
            }
        });

        search.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
            }
        });

    }
}
