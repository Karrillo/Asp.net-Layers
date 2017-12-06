package com.example.carrillo.santamarta;

import android.content.Intent;
import android.content.SharedPreferences;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    private EditText nick, password;
    private Button insert;
    public static String token;
    public static String idUSer;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        nick = (EditText)findViewById(R.id.txt_nick);
        password = (EditText) findViewById(R.id.txt_password);
        insert = (Button) findViewById(R.id.btn_login);
        final Contextdb contextdb = new Contextdb();

        insert.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                if(nick.getText().toString().equals("") || password.getText().toString().equals("")){
                    Toast.makeText(getApplicationContext(), "Ingrese el usuario y la contraseña", Toast.LENGTH_LONG).show();
                }else {
                    insert.setEnabled(false);
                    String response = contextdb.getCheck(nick.getText().toString(),password.getText().toString());
                    password.setText("");
                    if(!response.toString().equals("0") && !response.toString().equals("false")) {
                        token= contextdb.getToken();
                        idUSer = response;
                        insert.setEnabled(true);
                        Intent menu = new Intent(MainActivity.this, MenuActivity.class);
                        startActivity(menu);
                    }else if(response.toString().equals("0")){
                        Toast.makeText(getApplicationContext(), "Usuario o contraseña incorrectos", Toast.LENGTH_LONG).show();
                        insert.setEnabled(true);
                    }else {
                        Toast.makeText(getApplicationContext(), "Fallo en la conexion con el servidor", Toast.LENGTH_LONG).show();
                        insert.setEnabled(true);
                    }
                }
            }
        });
    }
}
