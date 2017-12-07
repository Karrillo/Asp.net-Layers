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
    private EditText txtCode;
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

        txtCode = (EditText) findViewById(R.id.txt_code);
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
                if(check()==true) {
                    Client client = new Client();
                    if (txtPhone.getText().toString().equals("")) {
                        client.setPhone("null");
                    } else {
                        client.setPhone(txtPhone.getText().toString());
                    }
                    if (txtCellphone.getText().toString().equals("")) {
                        client.setCellPhone("null");
                    } else {
                        client.setCellPhone(txtCellphone.getText().toString());
                    }
                    client.setName(txtName.getText().toString());
                    client.setFirstName(txtFirstName.getText().toString());
                    client.setSecondName(txtSecondName.getText().toString());
                    client.setEmail(txtEmail.getText().toString());
                    client.setAddress(txtAddress.getText().toString());
                    client.setCode(txtCode.getText().toString());
                    if (txtNameCompany.getText().toString().equals("")) {
                        client.setNameCompany("null");
                    } else {
                        client.setNameCompany(txtNameCompany.getText().toString());
                    }
                    String response = contextdb.insertClients(client, token);
                    switch (response) {
                        case "200":
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
                            break;
                        case "400":
                            Toast.makeText(getApplicationContext(), "El codigo ingresado ya existe en el sistema", Toast.LENGTH_LONG).show();
                            break;
                        case "500":
                            Toast.makeText(getApplicationContext(), "Fallo al insertar cliente", Toast.LENGTH_LONG).show();
                            break;
                        default:
                            break;
                    }
                }
            }
        });
     }

     public boolean check(){
         if(txtName.getText().toString().equals("") || txtFirstName.getText().toString().equals("") || txtSecondName.getText().toString().equals("")){
                 Toast.makeText(getApplicationContext(), "Ingrese nombre y apellidos completos", Toast.LENGTH_LONG).show();
                 return false;
         }
         if(txtCellphone.getText().toString().equals("")&&txtPhone.getText().toString().equals("")){
             Toast.makeText(getApplicationContext(), "Ingrese un numero de telefono residencial o uno celular", Toast.LENGTH_LONG).show();
             return false;
         }
         if(txtAddress.getText().toString().equals("")){
             Toast.makeText(getApplicationContext(), "Ingrese una dirección del cliente", Toast.LENGTH_LONG).show();
             return false;
         }
         if(txtCode.getText().toString().equals("")){
             Toast.makeText(getApplicationContext(), "Ingrese el codigo del cliente", Toast.LENGTH_LONG).show();
             return false;
         }
         if(txtEmail.getText().toString().equals("")){
             Toast.makeText(getApplicationContext(), "Ingrese un email del cliente", Toast.LENGTH_LONG).show();
             return false;
         }
         return true;
     }
    }
