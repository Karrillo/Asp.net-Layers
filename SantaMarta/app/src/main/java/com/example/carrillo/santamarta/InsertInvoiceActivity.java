package com.example.carrillo.santamarta;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.SeekBar;
import android.widget.TextView;
import android.widget.Toast;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;

/**
 * Created by Carrillo on 10/11/2017.
 */

public class InsertInvoiceActivity extends AppCompatActivity {
    private static TextView txtClient;
    private TextView txtCredit;
    private static TextView txtDiscont,txtTotal;
    private Button client,product,more,less,invoice,back;
    private static ListView list;
    private CheckBox checkCredit;
    private SeekBar barCredit;
    private static List<Product> listProducts = new ArrayList<Product>();
    private static Context context;
    private String token = "";
    private Contextdb contextdb = new Contextdb();
    private static Client clientSelect;
    private static int provider;
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_invoices_create);

        txtClient = (TextView) findViewById(R.id.txt_client);
        txtCredit = (TextView) findViewById(R.id.txt_credit);
        txtDiscont = (TextView) findViewById(R.id.txt_discont);
        txtTotal = (TextView) findViewById(R.id.txt_total);
        client = (Button) findViewById(R.id.btn_client);
        more = (Button) findViewById(R.id.btn_more);
        less = (Button) findViewById(R.id.btn_less);
        product = (Button) findViewById(R.id.btn_product);
        invoice = (Button) findViewById(R.id.btn_invoices);
        back = (Button) findViewById(R.id.btn_back);
        list = (ListView) findViewById(R.id.list_invoices);
        barCredit = (SeekBar) findViewById(R.id.sb_credit);
        checkCredit = (CheckBox) findViewById(R.id.cb_credit);
        context = getBaseContext();
        barCredit.setEnabled(false);
        token = MainActivity.token;
        final Contextdb contextdb = new Contextdb();

        checkCredit.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener()
        {
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked)
            {
                if (checkCredit.isChecked()==true) {
                    barCredit.setEnabled(true);
                }
                if (checkCredit.isChecked()==false) {
                    barCredit.setEnabled(false);
                }
            }
        });

        barCredit.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {
                // TODO Auto-generated method stub
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {
                // TODO Auto-generated method stub
            }

            @Override
            public void onProgressChanged(SeekBar seekBar, int progress,boolean fromUser) {
                switch (progress) {
                    case 0:
                        txtCredit.setText("7");
                        break;
                    case 1:
                        txtCredit.setText("15");
                        break;
                    case 2:
                        txtCredit.setText("22");
                        break;
                    case 3:
                        txtCredit.setText("30");
                        break;
                    default:
                        break;
                }
            }
        });

        back.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent menu = new Intent(InsertInvoiceActivity.this, InvoicesActivity.class);
                startActivity(menu);
                finish();
            }
        });

        client.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent create = new Intent(InsertInvoiceActivity.this, InvoiceClients.class);
                startActivity(create);
            }
        });

        product.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent create = new Intent(InsertInvoiceActivity.this, InvoiceProducts.class);
                startActivity(create);
            }
        });

        more.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                if(Integer.parseInt(txtDiscont.getText().toString())<15){
                    txtDiscont.setText(String.valueOf(Integer.parseInt(txtDiscont.getText().toString())+1));
                    total();
                }
            }
        });

        less.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                if(Integer.parseInt(txtDiscont.getText().toString())>0){
                    txtDiscont.setText(String.valueOf(Integer.parseInt(txtDiscont.getText().toString())-1));
                    total();
                }
            }
        });

        invoice.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                if(MainActivity.idUSer.length()>0){
                    if(clientSelect.getIDClient()!=0){
                        if(listProducts.size()!=0){
                            String dateCredit="";
                            Date date = new Date();
                            Calendar calendar = Calendar.getInstance();
                            if(checkCredit.isChecked()==true){
                                calendar.setTime(date); // Configuramos la fecha que se recibe
                                calendar.add(Calendar.DAY_OF_YEAR, Integer.parseInt(txtCredit.getText().toString()));  // numero de días a añadir, o restar en caso de días<0
                                date = calendar.getTime();
                                SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
                                dateCredit = format.format(date);
                                String response = contextdb.getDetail(MainActivity.idUSer,token);
                                if(!response.toString().equals("false")){
                                    String responseInvoice = contextdb.insertInvoices(dateCredit, "02", Integer.parseInt(txtDiscont.getText().toString()), Double.parseDouble(txtTotal.getText().toString()),
                                            true, clientSelect.getIDClient(), provider, Long.parseLong(response),token);
                                    if(!responseInvoice.toString().equals("500")){
                                        Product item;
                                        String responseSale = "";
                                        for(int x=0;x<listProducts.size();x++){
                                            item = listProducts.get(x);
                                            responseSale = contextdb.insertSales(item.getCode(),item.getQuantity(),item.getTotal(),item.getIDProduct(),
                                                    Long.parseLong(response),token);
                                            if(responseInvoice.toString().equals("500")){
                                                Toast.makeText(getApplicationContext(), "Error, factura mal ingresada al sistema", Toast.LENGTH_LONG).show();
                                                break;
                                            }
                                            if(responseSale.equals("200")){
                                                Toast.makeText(getApplicationContext(), "Factura de venta ingresada correctamente", Toast.LENGTH_LONG).show();
                                                // SLEEP 2 SECONDS HERE ...
                                                final Handler handler = new Handler();
                                                Timer t = new Timer();
                                                t.schedule(new TimerTask() {
                                                    public void run() {
                                                        handler.post(new Runnable() {
                                                            public void run() {
                                                                Intent menu = new Intent(InsertInvoiceActivity.this, InvoicesActivity.class);
                                                                startActivity(menu);
                                                                finish();
                                                            }
                                                        });
                                                    }
                                                }, 1000);
                                                break;
                                            }
                                        }
                                    }else {
                                        Toast.makeText(getApplicationContext(), "Error, factura mal ingresada al sistema", Toast.LENGTH_LONG).show();
                                    }
                                }else {
                                    Toast.makeText(getApplicationContext(), "Error al intentar ingresar la factura al sistema", Toast.LENGTH_LONG).show();
                                }
                            }else {
                                calendar.add(Calendar.DATE, 1);
                                date = calendar.getTime();
                                SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
                                dateCredit = format.format(date);
                                String response = contextdb.getDetail(MainActivity.idUSer,token);
                                if(!response.toString().equals("false")){
                                    String responseInvoice = contextdb.insertInvoices(dateCredit, "02", Integer.parseInt(txtDiscont.getText().toString()), Double.parseDouble(txtTotal.getText().toString()),
                                            true, clientSelect.getIDClient(), provider, Long.parseLong(response),token);
                                    if(!responseInvoice.toString().equals("500")){
                                        Product item;
                                        String responseSale = "";
                                        for(int x=0;x<listProducts.size();x++){
                                            item = listProducts.get(x);
                                            responseSale = contextdb.insertSales(item.getCode(),item.getQuantity(),item.getTotal(),item.getIDProduct(),
                                                    Long.parseLong(response),token);
                                            if(responseInvoice.toString().equals("500")){
                                                Toast.makeText(getApplicationContext(), "Error, factura mal ingresada al sistema", Toast.LENGTH_LONG).show();
                                                break;
                                            }
                                            if(responseSale.equals("200")){
                                                Toast.makeText(getApplicationContext(), "Factura de venta ingresada correctamente", Toast.LENGTH_LONG).show();
                                                // SLEEP 2 SECONDS HERE ...
                                                final Handler handler = new Handler();
                                                Timer t = new Timer();
                                                t.schedule(new TimerTask() {
                                                    public void run() {
                                                        handler.post(new Runnable() {
                                                            public void run() {
                                                                Intent menu = new Intent(InsertInvoiceActivity.this, InvoicesActivity.class);
                                                                startActivity(menu);
                                                                finish();
                                                            }
                                                        });
                                                    }
                                                }, 1000);
                                                break;
                                            }
                                        }
                                    }else {
                                        Toast.makeText(getApplicationContext(), "Error, factura mal ingresada al sistema", Toast.LENGTH_LONG).show();
                                    }
                                }else {
                                    Toast.makeText(getApplicationContext(), "Error al intentar ingresar la factura al sistema", Toast.LENGTH_LONG).show();
                                }
                            }
                        }else {
                            Toast.makeText(getApplicationContext(), "Por favor ingrese una lista de productos a vender", Toast.LENGTH_LONG).show();
                        }
                    }else {
                        Toast.makeText(getApplicationContext(), "Por favor seleccione un cliente", Toast.LENGTH_LONG).show();
                    }
                }else {
                    Toast.makeText(getApplicationContext(), "Error de autentificacion, por favor vuelva salir y volver a loguear ", Toast.LENGTH_LONG).show();
                }
            }
        });
    }

    public static void display(Product product) {
            provider = product.getIdProvider();
            listProducts.add(new Product(product.getIDProduct(),product.getName(),product.getCode(),
                    product.getState(),product.getDescription(),product.getPrice(),product.getTax(),
                    product.getIdProvider(),product.getQuantity(),product.getTotal()));
            ArrayAdapter<Product> adapter = new ArrayAdapter<>(context, android.R.layout.simple_list_item_1, listProducts);
            //se setean los datos en el listView
            list.setAdapter(adapter);
            total();
    }

    public static void display_client(Client client){
        clientSelect = client;
        if(client.getNameCompany().equals("null")) {
            txtClient.setText(client.getName() + " " + client.getFirstName() + " / " + "N/D");
        }else {
            txtClient.setText(client.getName() + " " + client.getFirstName() + " / " + client.getNameCompany());
        }
    }

    public static void total(){
        if(listProducts.size()>0){
            Double total = 0.0;
            Product item;
            for(int x=0;x<listProducts.size();x++){
                item = listProducts.get(x);
                total = total +item.getTotal();
            }
            if(txtDiscont.getText().toString().equals("0")){
                txtTotal.setText(String.valueOf(total));
            }else {
                total = total - ((total * Integer.parseInt(txtDiscont.getText().toString()))/100);
                txtTotal.setText(String.valueOf(total));
            }
        }else {
            txtTotal.setText("0");
        }
    }
}
