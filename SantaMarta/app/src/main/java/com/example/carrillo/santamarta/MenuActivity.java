package com.example.carrillo.santamarta;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import java.util.Timer;
import java.util.TimerTask;

/**
 * Created by Carrillo on 9/21/2017.
 */

public class MenuActivity extends AppCompatActivity {

    private Button invoices, clients, logout;
    private static String token = "";
    private static Contextdb contextdb = new Contextdb();
    @Override
    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);

        invoices = (Button) findViewById(R.id.btn_invoices);
        clients = (Button) findViewById(R.id.btn_clients);
        logout = (Button) findViewById(R.id.btn_logout);
        token = MainActivity.token;
        final Contextdb contextdb = new Contextdb();
        invoices.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                if(session()==false) {
                    Intent intent = new Intent(MenuActivity.this, InvoicesActivity.class);
                    startActivity(intent);
                    finish();
                }
            }
        });

        clients.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                if(session()==false) {
                    Intent intent = new Intent(MenuActivity.this, ClientsActivity.class);
                    startActivity(intent);
                    finish();
                }
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
    public boolean session(){
        String responce = contextdb.getSession(token);
        if(responce.toString().equals("false")){
            Toast.makeText(getApplicationContext(), "Sesión expirada, por favor vuelva a loguear su cuenta!", Toast.LENGTH_LONG).show();
            // SLEEP 2 SECONDS HERE ...
            final Handler handler = new Handler();
            Timer t = new Timer();
            t.schedule(new TimerTask() {
                public void run() {
                    handler.post(new Runnable() {
                        public void run() {
                            Intent menu = new Intent(MenuActivity.this, MainActivity.class);
                            startActivity(menu);
                            finish();
                        }
                    });
                }
            }, 1000);
            return true;
        }else if(responce.toString().equals("error")){
            Toast.makeText(getApplicationContext(), "Error en la conexion con el servidor!", Toast.LENGTH_LONG).show();
            // SLEEP 2 SECONDS HERE ...
            final Handler handler = new Handler();
            Timer t = new Timer();
            t.schedule(new TimerTask() {
                public void run() {
                    handler.post(new Runnable() {
                        public void run() {
                            Intent menu = new Intent(MenuActivity.this, MainActivity.class);
                            startActivity(menu);
                            finish();
                        }
                    });
                }
            }, 1000);
            return true;
        }
        return false;
    }
}
