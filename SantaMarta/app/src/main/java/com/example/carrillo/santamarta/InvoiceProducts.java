package com.example.carrillo.santamarta;

import android.content.Intent;
import android.os.Bundle;
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

/**
 * Created by joser on 17/11/2017.
 */

public class InvoiceProducts extends AppCompatActivity {

    private ListView list;
    private EditText txtQuantity;
    private Button back;
    private String token = "";
    private Contextdb contextdb = new Contextdb();
    private List<Product> listProducts;
    private Product product;
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
                Intent menu = new Intent(InvoiceProducts.this, InsertInvoiceActivity.class);
                startActivity(menu);
                finish();
            }
        });

        list.setOnItemClickListener(new android.widget.AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                if(!txtQuantity.getText().toString().equals("")){
                    if(Integer.parseInt(txtQuantity.getText().toString())<1){
                        Toast.makeText(getApplicationContext(), "Ingrese una cantidad de producto mayor a cero", Toast.LENGTH_LONG).show();
                    }else {
                        product = listProducts.get(position);
                        product.setQuantity(Integer.parseInt(txtQuantity.getText().toString()));
                        product.setTotal((product.getPrice() + ((product.getPrice()*product.getTax())/100))*Integer.parseInt(txtQuantity.getText().toString()));
                        InsertInvoiceActivity.display(product);
                        finish();
                    }
                }else {
                    Toast.makeText(getApplicationContext(), "El campo de cantidad de producto esta vacio, porfavor ingrese una cantidad", Toast.LENGTH_LONG).show();
                }

            }
        });
    }

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
}
