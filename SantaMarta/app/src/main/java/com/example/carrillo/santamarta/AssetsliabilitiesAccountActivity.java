package com.example.carrillo.santamarta;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;

/**
 * Created by joser on 27/11/2017.
 */

public class AssetsliabilitiesAccountActivity extends AppCompatActivity {

    private ListView list;

    private Button back;
    private String token = "";
    private Contextdb contextdb = new Contextdb();
    private List<Account> listAccounts;
    private Account account;
    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_assetsliabilities_account);

        list = (ListView) findViewById(R.id.list_accounts);
        back = (Button) findViewById(R.id.btn_back);
        token = MainActivity.token;
        final Contextdb contextdb = new Contextdb();
        session();
        listAccounts = contextdb.getAllAccounts(token);
        display(listAccounts);
        back.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                finish();
            }
        });

        list.setOnItemClickListener(new android.widget.AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                if(position>=0){
                    account = listAccounts.get(position);
                    AssetsliabilitiesActivity.display_account(account);
                    finish();
                }
            }
        });
    }

    public void display(List<Account> Accounts) {
        if (Accounts.size()==0) {
            List<String> search = new ArrayList<String>();
            search.add("Cuentas no encontradas");
            ArrayAdapter<String> adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, search);
            //se setean los datos en el listView
            list.setAdapter(adapter);
        } else{
            ArrayAdapter<Account> adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, Accounts);
            //se setean los datos en el listView
            list.setAdapter(adapter);
        }
    }
    public void session(){
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
                            Intent menu = new Intent(AssetsliabilitiesAccountActivity.this, MainActivity.class);
                            startActivity(menu);
                            finish();
                        }
                    });
                }
            }, 1000);
        }else if(responce.toString().equals("false")){
            Toast.makeText(getApplicationContext(), "Error en la conexion con el servidor!", Toast.LENGTH_LONG).show();
            // SLEEP 2 SECONDS HERE ...
            final Handler handler = new Handler();
            Timer t = new Timer();
            t.schedule(new TimerTask() {
                public void run() {
                    handler.post(new Runnable() {
                        public void run() {
                            Intent menu = new Intent(AssetsliabilitiesAccountActivity.this, MainActivity.class);
                            startActivity(menu);
                            finish();
                        }
                    });
                }
            }, 1000);
        }
    }
}
