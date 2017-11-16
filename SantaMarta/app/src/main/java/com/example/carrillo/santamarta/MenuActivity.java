package com.example.carrillo.santamarta;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;

/**
 * Created by Carrillo on 9/21/2017.
 */

public class MenuActivity extends AppCompatActivity {

    private Button invoices, clients, logout, config;

    @Override
    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);

        invoices = (Button) findViewById(R.id.btn_invoices);
        clients = (Button) findViewById(R.id.btn_clients);
        logout = (Button) findViewById(R.id.btn_logout);
        config = (Button) findViewById(R.id.btn_config);

        invoices.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MenuActivity.this, InvoicesActivity.class);
                startActivity(intent);
                finish();
            }
        });

        clients.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MenuActivity.this, ClientsActivity.class);
                startActivity(intent);
                finish();
            }
        });

        config.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MenuActivity.this, MainPrintActivity.class);
                startActivity(intent);
                finish();
            }
        });

        logout.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                MainActivity.token="";
                finish();
            }
        });
    }
}
