package com.example.carrillo.santamarta;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class MainActivity extends AppCompatActivity {

    private EditText nick, password;
    private Button insert;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        nick = (EditText)findViewById(R.id.txt_nick);
        password = (EditText) findViewById(R.id.txt_password);
        insert = (Button) findViewById(R.id.btn_login);


        insert.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent menu = new Intent(MainActivity.this, MenuActivity.class);
                startActivity(menu);
            }
        });
    }
}
