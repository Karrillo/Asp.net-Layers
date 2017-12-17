package com.example.carrillo.santamarta;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;

/**
 * Created by joser on 17/11/2017.
 */

public class InvoiceProductsActivity extends AppCompatActivity {
    private ListView list;
    private EditText txtQuantity;
    private Button back;
    private String token = "";
    private Contextdb contextdb = new Contextdb();
    private List<Product> listProducts;
    private Product product;
    /**
     * @param savedInstanceState
     * metodo onCreate de InvoiceProductsActivity
     */
    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_invoices_product);
        list = (ListView) findViewById(R.id.list_products);
        txtQuantity = (EditText) findViewById(R.id.txt_quantity);
        back = (Button) findViewById(R.id.btn_back);
        token = MainActivity.token;
        final Contextdb contextdb = new Contextdb();
        listProducts = contextdb.getAllProducts(token);
        display(listProducts);
        back.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                if(session()==false) {
                    finish();
                }
            }
        });
        list.setOnItemClickListener(new android.widget.AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                if(!txtQuantity.getText().toString().equals("")){
                    if(Integer.parseInt(txtQuantity.getText().toString())<1){
                        Toast.makeText(getApplicationContext(), "¡Ingrese una cantidad de producto mayor a cero!", Toast.LENGTH_LONG).show();
                    }else {
                        if(session()==false) {
                            product = listProducts.get(position);
                            product.setQuantity(Integer.parseInt(txtQuantity.getText().toString()));
                            product.setTotal((product.getPrice() + ((product.getPrice() * product.getTax()) / 100)) * Integer.parseInt(txtQuantity.getText().toString()));
                            InsertInvoiceActivity.display(product);
                            finish();
                        }
                    }
                }else {
                    Toast.makeText(getApplicationContext(), "¡El campo de cantidad de producto esta vacio, por favor ingrese una cantidad!", Toast.LENGTH_LONG).show();
                }

            }
        });
    }
    /**
     * @param Products
     * metodo para mostrar Products
     */
    public void display(List<Product> Products) {
        if (Products.size()==0) {
            List<String> search = new ArrayList<String>();
            search.add("Productos no encontrados");
            ArrayAdapter<String> adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, search);
            //se setean los datos en el listView
            list.setAdapter(adapter);
        } else{
            ArrayAdapter<Product> adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, Products);
            //se setean los datos en el listView
            list.setAdapter(adapter);
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
                            Intent menu = new Intent(InvoiceProductsActivity.this, MainActivity.class);
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
                            Intent menu = new Intent(InvoiceProductsActivity.this, MainActivity.class);
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
