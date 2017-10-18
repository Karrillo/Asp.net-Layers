package com.example.carrillo.santamarta;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.Toast;

import java.util.Timer;
import java.util.TimerTask;

/**
 * Created by Carrillo on 9/21/2017.
 */

public class InsertClientsActivity extends AppCompatActivity {
    private EditText txtIdentification;
    private EditText txtName;
    private EditText txtFirstName;
    private EditText txtSecondName;
    private EditText txtEmail;
    private EditText txtPhone;
    private EditText txtCellphone;
    private EditText txtAddress;
    private EditText txtNameCompany;
    private Button insert;
    private Button back;
    private String token = "";
    private Contextdb contextdb = new Contextdb();
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_clients_create);

        txtIdentification = (EditText) findViewById(R.id.txt_identification);
        txtName = (EditText) findViewById(R.id.txt_Name);
        txtFirstName = (EditText) findViewById(R.id.txt_firstName);
        txtSecondName = (EditText) findViewById(R.id.txt_secondName);
        txtEmail = (EditText) findViewById(R.id.txt_email);
        txtPhone = (EditText) findViewById(R.id.txt_phone);
        txtCellphone = (EditText) findViewById(R.id.txt_cellPhone);
        txtAddress = (EditText) findViewById(R.id.txt_address);
        txtNameCompany = (EditText) findViewById(R.id.txt_nameCompany);
        insert = (Button) findViewById(R.id.btn_insert);
        back = (Button) findViewById(R.id.btn_back);
        token = MainActivity.token;
        final Contextdb contextdb = new Contextdb();

        back.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent menu = new Intent(InsertClientsActivity.this, ClientsActivity.class);
                startActivity(menu);
                finish();
            }
        });

        insert.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Client client = new Client();
                if(txtName.getText().toString().equals("")){
                    client.setName("null");
                }else {
                    client.setName(txtName.getText().toString());
                }
                if(txtFirstName.getText().toString().equals("")){
                    client.setFirstName("null");
                }else {
                client.setFirstName(txtFirstName.getText().toString());
                }
                if(txtSecondName.getText().toString().equals("")){
                    client.setSecondName("null");
                }else {
                client.setSecondName(txtSecondName.getText().toString());
                }
                if(txtPhone.getText().toString().equals("")){
                    client.setPhone("null");
                }else {
                client.setPhone(txtPhone.getText().toString());
                }
                if(txtCellphone.getText().toString().equals("")){
                    client.setCellPhone("null");
                }else {
                client.setCellPhone(txtCellphone.getText().toString());
                }
                client.setEmail(txtEmail.getText().toString());
                client.setAddress(txtAddress.getText().toString());
                client.setIdentification(txtIdentification.getText().toString());
                if(txtNameCompany.getText().toString().equals("")){
                    client.setNameCompany("null");
                }else {
                client.setNameCompany(txtNameCompany.getText().toString());
                }
                if(contextdb.insertClients(client,token)==true){
                    Toast.makeText(getApplicationContext(), "Cliente ingresado correctamente", Toast.LENGTH_LONG).show();
                    // SLEEP 2 SECONDS HERE ...
                    final Handler handler = new Handler();
                    Timer t = new Timer();
                    t.schedule(new TimerTask() {
                        public void run() {
                            handler.post(new Runnable() {
                                public void run() {
                                    Intent menu = new Intent(InsertClientsActivity.this, ClientsActivity.class);
                                    startActivity(menu);
                                    finish();
                                }
                            });
                        }
                    }, 1000);
                }else {
                    Toast.makeText(getApplicationContext(), "Fallo al insertar cliente", Toast.LENGTH_LONG).show();
                }

            }
        });
     }

     public boolean check(){
         if(txtName.getText().toString().equals("")){
             if(txtNameCompany.toString().equals("")){
                 Toast.makeText(getApplicationContext(), "Ingrese un nombre o un nombre de conpañia completo", Toast.LENGTH_LONG).show();
             }else {}
         }else {
             if (txtFirstName.toString().equals("") || txtSecondName.getText().toString().equals("")) {
                 Toast.makeText(getApplicationContext(), "Ingrese nombre y apellidos completos", Toast.LENGTH_LONG).show();
             }
         }
         if(txtCellphone.getText().toString().equals("")&&txtPhone.getText().toString().equals("")){
             Toast.makeText(getApplicationContext(), "Ingrese un numero de telefono residencial o uno celular", Toast.LENGTH_LONG).show();
         }
         if(txtAddress.getText().toString().equals("")){
             Toast.makeText(getApplicationContext(), "Ingrese una dirección del cliente", Toast.LENGTH_LONG).show();
         }
         if(txtIdentification.getText().toString().equals("")){
             Toast.makeText(getApplicationContext(), "Ingrese una identificacion del cliente", Toast.LENGTH_LONG).show();
         }
         if(txtEmail.getText().toString().equals("")){
             Toast.makeText(getApplicationContext(), "Ingrese un email del cliente", Toast.LENGTH_LONG).show();
         }
         return false;
     }
    }
