package com.example.carrillo.santamarta;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.ListView;
import android.widget.SeekBar;
import android.widget.TextView;
import android.widget.Toast;

import java.text.DecimalFormat;
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
    private static Double total;
    private static Print print = new Print();
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
        listProducts.clear();
        txtDiscont.setText("0");
        txtTotal.setText("0");
        txtClient.setText("No seleccionado");
        context = getBaseContext();
        barCredit.setEnabled(false);
        total = 0.0;
        token = MainActivity.token;
        final Contextdb contextdb = new Contextdb();

        list.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> arg0, View arg1,
                                           final int pos, long id) {
                AlertDialog.Builder informacion = new AlertDialog.Builder(InsertInvoiceActivity.this);
                informacion.setMessage("¿Desea eliminar este producto de la lista?");
                informacion.setPositiveButton("Eliminar", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        int position = pos;
                        listProducts.remove(position);
                        display_delete();
                    }
                });
                informacion.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                    }
                });
                informacion.setTitle("Facturas");
                informacion.show();
                return true;
            }
        });

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
                //Intent menu = new Intent(InsertInvoiceActivity.this, InvoicesActivity.class);
                //startActivity(menu);
                finish();
            }
        });

        client.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent create = new Intent(InsertInvoiceActivity.this, InvoiceClientsActivity.class);
                startActivity(create);
            }
        });

        product.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent create = new Intent(InsertInvoiceActivity.this, InvoiceProductsActivity.class);
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
                            session();
                                String dateCredit = "";
                                String dateCurent = "";
                                Date date = new Date();
                                Calendar calendar = Calendar.getInstance();
                                Date date_Curent = new Date();
                                Calendar calendarCurent = Calendar.getInstance();
                                if (checkCredit.isChecked() == true) {
                                    calendar.setTime(date); // Configuramos la fecha que se recibe
                                    calendar.add(Calendar.DAY_OF_YEAR, Integer.parseInt(txtCredit.getText().toString()));  // numero de días activity_assetsliabilities añadir, o restar en caso de días<0
                                    date = calendar.getTime();
                                    SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
                                    dateCredit = format.format(date);
                                    print.setLimit(dateCredit);
                                    calendarCurent.add(Calendar.DATE, 0);
                                    date_Curent = calendarCurent.getTime();
                                    SimpleDateFormat formatCurent = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
                                    dateCurent = format.format(date_Curent);
                                    print.setCurent(dateCurent);
                                    print.setDiscount(txtDiscont.getText().toString());
                                    print.setTotal(txtTotal.getText().toString());
                                    String response = contextdb.getDetail(MainActivity.idUSer, token);
                                    if (!response.toString().equals("false")) {
                                        String code = contextdb.getCode(token);
                                        String responseInvoice = contextdb.insertInvoices(dateCredit, code, Integer.parseInt(txtDiscont.getText().toString()), total,
                                                true, clientSelect.getIDClient(), provider, Long.parseLong(response), token);
                                        if (!responseInvoice.toString().equals("500")) {
                                            Product item;
                                            String responseSale = "";
                                            for (int x = 0; x < listProducts.size(); x++) {
                                                item = listProducts.get(x);
                                                responseSale = contextdb.insertSales(item.getCode(), item.getQuantity(), item.getTotal(), item.getIDProduct(),
                                                        Long.parseLong(response), token);
                                                if (responseSale.toString().equals("500")) {
                                                    Toast.makeText(getApplicationContext(), "Error, factura mal ingresada al sistema", Toast.LENGTH_LONG).show();
                                                    break;
                                                }
                                                if (responseSale.equals("200")) {
                                                    if (clientSelect.getNameCompany().toString().equals("null")) {
                                                        InvoicesActivity.printInvoiceCredit(clientSelect.getName() + " " + clientSelect.getFirstName() + " " + clientSelect.getSecondName(),
                                                                code, print.getCurent(), print.getLimit(), "Si", listProducts, print.getDiscount(), print.getTotal());
                                                    } else {
                                                        InvoicesActivity.printInvoiceCredit(clientSelect.getNameCompany(),
                                                                code, print.getCurent(), print.getLimit(), "Si", listProducts, print.getDiscount(), print.getTotal());
                                                    }
                                                    if(responseInvoice.toString().equals("501")){
                                                        Toast.makeText(getApplicationContext(), "Factura de venta ingresada correctamente, error al enviar el correo", Toast.LENGTH_LONG).show();
                                                    }else {
                                                        Toast.makeText(getApplicationContext(), "Factura de venta ingresada correctamente", Toast.LENGTH_LONG).show();
                                                    }
                                                    InvoicesActivity.refresh();
                                                    // SLEEP 2 SECONDS HERE ...
                                                    final Handler handler = new Handler();
                                                    Timer t = new Timer();
                                                    t.schedule(new TimerTask() {
                                                        public void run() {
                                                            handler.post(new Runnable() {
                                                                public void run() {
                                                                    //Intent menu = new Intent(InsertInvoiceActivity.this, InvoicesActivity.class);
                                                                    //startActivity(menu);
                                                                    finish();
                                                                }
                                                            });
                                                        }
                                                    }, 1000);
                                                    break;
                                                }
                                            }
                                        } else {
                                            Toast.makeText(getApplicationContext(), "Error, factura mal ingresada al sistema", Toast.LENGTH_LONG).show();
                                        }
                                    } else {
                                        Toast.makeText(getApplicationContext(), "Error al intentar ingresar la factura al sistema", Toast.LENGTH_LONG).show();
                                    }
                                } else {
                                    calendar.add(Calendar.DATE, 0);
                                    date = calendar.getTime();
                                    SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
                                    dateCredit = format.format(date);
                                    print.setCurent(dateCredit);
                                    print.setLimit(dateCredit);
                                    print.setDiscount(txtDiscont.getText().toString());
                                    print.setTotal(txtTotal.getText().toString());
                                    String response = contextdb.getDetail(MainActivity.idUSer, token);
                                    if (!response.toString().equals("false")) {
                                        String code = contextdb.getCode(token);
                                        String responseInvoice = contextdb.insertInvoices(dateCredit, code, Integer.parseInt(txtDiscont.getText().toString()), total,
                                                true, clientSelect.getIDClient(), provider, Long.parseLong(response), token);
                                        if (!responseInvoice.toString().equals("500")) {
                                            Product item;
                                            String responseSale = "";
                                            for (int x = 0; x < listProducts.size(); x++) {
                                                item = listProducts.get(x);
                                                responseSale = contextdb.insertSales(item.getCode(), item.getQuantity(), item.getTotal(), item.getIDProduct(),
                                                        Long.parseLong(response), token);
                                                if (responseSale.toString().equals("500")) {
                                                    Toast.makeText(getApplicationContext(), "Error, factura mal ingresada al sistema", Toast.LENGTH_LONG).show();
                                                    break;
                                                }
                                                if (responseSale.equals("200")) {
                                                    if(responseInvoice.toString().equals("501")){
                                                        Toast.makeText(getApplicationContext(), "Factura de venta ingresada correctamente, error al enviar el correo", Toast.LENGTH_LONG).show();
                                                    }else {
                                                        Toast.makeText(getApplicationContext(), "Factura de venta ingresada correctamente", Toast.LENGTH_LONG).show();
                                                    }
                                                    InvoicesActivity.refresh();
                                                    if (clientSelect.getNameCompany().toString().equals("null")) {
                                                        InvoicesActivity.printInvoice(clientSelect.getName() + " " + clientSelect.getFirstName() + " " + clientSelect.getSecondName(),
                                                                code, print.getCurent(), "Si", listProducts, print.getDiscount(), print.getTotal());
                                                    } else {
                                                        InvoicesActivity.printInvoice(clientSelect.getNameCompany(),
                                                                code, print.getCurent(), "Si", listProducts, print.getDiscount(), print.getTotal());
                                                    }
                                                    // SLEEP 2 SECONDS HERE ...
                                                    final Handler handler = new Handler();
                                                    Timer t = new Timer();
                                                    t.schedule(new TimerTask() {
                                                        public void run() {
                                                            handler.post(new Runnable() {
                                                                public void run() {
                                                                    //Intent menu = new Intent(InsertInvoiceActivity.this, InvoicesActivity.class);
                                                                    //startActivity(menu);
                                                                    finish();
                                                                }
                                                            });
                                                        }
                                                    }, 1000);
                                                    break;
                                                }
                                            }
                                        } else {
                                            Toast.makeText(getApplicationContext(), "Error, factura mal ingresada al sistema", Toast.LENGTH_LONG).show();
                                        }
                                    } else {
                                        Toast.makeText(getApplicationContext(), "Error al intentar ingresar la factura al sistema", Toast.LENGTH_LONG).show();
                                    }
                                }
                        }else {
                            Toast.makeText(getApplicationContext(), "Por favor ingrese una lista de productos activity_assetsliabilities vender", Toast.LENGTH_LONG).show();
                        }
                    }else {
                        Toast.makeText(getApplicationContext(), "Por favor seleccione un cliente", Toast.LENGTH_LONG).show();
                    }
                }else {
                    Toast.makeText(getApplicationContext(), "Error de autentificacion, por favor vuelva salir y volver activity_assetsliabilities loguear ", Toast.LENGTH_LONG).show();
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

    public static void display_delete() {
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
            total = 0.0;
            Product item;
            for(int x=0;x<listProducts.size();x++){
                item = listProducts.get(x);
                total = total +item.getTotal();
            }
            if(txtDiscont.getText().toString().equals("0")){
                DecimalFormat df = new DecimalFormat("#.00");
                String sumTotal = df.format(total);
                txtTotal.setText(sumTotal);
            }else {
                total = total - ((total * Integer.parseInt(txtDiscont.getText().toString()))/100);
                DecimalFormat df = new DecimalFormat("#.00");
                String sumTotal = df.format(total);
                txtTotal.setText(sumTotal);
            }
        }else {
            total = 0.0;
            txtTotal.setText("0");
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
                            finish();
                        }
                    });
                }
            }, 1000);
        }else if(responce.toString().equals("error")){
            Toast.makeText(getApplicationContext(), "Error en la conexion con el servidor!", Toast.LENGTH_LONG).show();
            // SLEEP 2 SECONDS HERE ...
            final Handler handler = new Handler();
            Timer t = new Timer();
            t.schedule(new TimerTask() {
                public void run() {
                    handler.post(new Runnable() {
                        public void run() {
                            finish();
                        }
                    });
                }
            }, 1000);
        }
    }
}
