package com.example.carrillo.santamarta;

import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;
/**
 * Created by Carrillo on 9/21/2017.
 */
public class ClientsActivity extends AppCompatActivity{
    private ListView list;
    private EditText txtsearch;
    private Button add;
    private Button back;
    private String token = "";
    private Contextdb contextdb = new Contextdb();
    private TextWatcher text = null;
    private List<Client> listClients;
    private List<Client> listSearchClients;
    private static Context context;
    /**
     * @param savedInstanceState
     * metodo onCreate de ClientsActivity
     */
    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_clients);
        list = (ListView) findViewById(R.id.list_clients);
        txtsearch = (EditText) findViewById(R.id.txt_search);
        add = (Button) findViewById(R.id.btn_add);
        back = (Button) findViewById(R.id.btn_back);
        token = MainActivity.token;
        final Contextdb contextdb = new Contextdb();
        context = getBaseContext();
        listClients = contextdb.getAllClients(token);
        display(listClients);
        back.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                if(session()==false) {
                    Intent menu = new Intent(ClientsActivity.this, MenuActivity.class);
                    startActivity(menu);
                    finish();
                }
            }
        });
        add.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                if(session()==false) {
                    Intent create = new Intent(ClientsActivity.this, InsertClientsActivity.class);
                    startActivity(create);
                    finish();
                }
            }
        });
        text = new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {}
            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                if(txtsearch.getText().toString().equals("")) {
                    display(listClients);
                }else {
                    if(session()==false) {
                        listSearchClients = contextdb.searchClients(token, txtsearch.getText().toString());
                        display(listSearchClients);
                    }
                }
            }
            @Override
            public void afterTextChanged(Editable s) {}
        };
        txtsearch.addTextChangedListener(text);
    }
    /**
     * @param clients
     * metodo para mostrar clients
     */
    public void display(List<Client> clients) {
        if (clients.size()==0) {
            List<String> search = new ArrayList<String>();
            search.add("Cliente no encontrado");
            ArrayAdapter<String> adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, search);
            //se setean los datos en el listView
            list.setAdapter(adapter);
        } else{
            //ArrayAdapter<Client> adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, clients);
            //se setean los datos en el listView
            final ArrayAdapter arrayAdapter2 = new ArrayAdapter
                    (context, android.R.layout.simple_list_item_1, clients){
                @Override
                public View getView(int position, View convertView, ViewGroup parent){
                    View view = super.getView(position,convertView,parent);
                    return view;
                }
            };
            list.setAdapter(arrayAdapter2);
        }
    }
    /**
     * @return boolean
     * metodo de verificacion de sesion
     */
    public boolean session(){
        String responce = contextdb.getSession(token);
        if(responce.toString().equals("false")){
            Toast.makeText(getApplicationContext(), "¡Sesión expirada, por favor vuelva a loguear su cuenta!", Toast.LENGTH_LONG).show();
            // SLEEP 2 SECONDS HERE ...
            final Handler handler = new Handler();
            Timer t = new Timer();
            t.schedule(new TimerTask() {
                public void run() {
                    handler.post(new Runnable() {
                        public void run() {
                            Intent menu = new Intent(ClientsActivity.this, MainActivity.class);
                            startActivity(menu);
                            finish();
                        }
                    });
                }
            }, 1000);
            return true;
        }else if(responce.toString().equals("error")){
            Toast.makeText(getApplicationContext(), "¡Error en la conexión con el servidor!", Toast.LENGTH_LONG).show();
            // SLEEP 2 SECONDS HERE ...
            final Handler handler = new Handler();
            Timer t = new Timer();
            t.schedule(new TimerTask() {
                public void run() {
                    handler.post(new Runnable() {
                        public void run() {
                            Intent menu = new Intent(ClientsActivity.this, MainActivity.class);
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
