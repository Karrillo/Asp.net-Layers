package com.example.carrillo.santamarta;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import java.text.DecimalFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Timer;
import java.util.TimerTask;

/**
 * Created by joser on 27/11/2017.
 */

public class AssetsliabilitiesActivity extends AppCompatActivity {

    private static EditText txtQuantity, txtTotal, txtRode, txtCode,txtClient, txtDate, txtDescription;
    private static TextView txtAccount, txtCategory, txtSubcategory;
    private Button back, insert, account, category;
    private static Button subCategory;
    private String token = "";
    private Contextdb contextdb = new Contextdb();
    private static Invoice invoiceSelect;
    private static Account accountSelect;
    private static Category categorySelect;
    private static SubCategory subCategorySelect;
    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_assetsliabilities);


        txtQuantity = (EditText) findViewById(R.id.txt_total_rode);
        txtTotal = (EditText) findViewById(R.id.txt_total);
        txtRode = (EditText) findViewById(R.id.txt_rode);
        txtCode = (EditText) findViewById(R.id.txt_code);
        txtClient = (EditText) findViewById(R.id.txt_client);
        txtDate = (EditText) findViewById(R.id.txt_date);
        txtDescription = (EditText) findViewById(R.id.txt_description);
        txtAccount = (TextView) findViewById(R.id.txt_account);
        txtCategory = (TextView) findViewById(R.id.txt_category);
        txtSubcategory = (TextView) findViewById(R.id.txt_subCategory);
        back = (Button) findViewById(R.id.btn_back);
        insert = (Button) findViewById(R.id.btn_insert);
        account = (Button) findViewById(R.id.btn_account);
        category = (Button) findViewById(R.id.btn_category);
        subCategory = (Button) findViewById(R.id.btn_subCategory);
        token = MainActivity.token;
        subCategory.setEnabled(false);
        final Contextdb contextdb = new Contextdb();
        display(InvoicesActivity.invoice);

        back.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                finish();
            }
        });

        account.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent menu = new Intent(AssetsliabilitiesActivity.this, AssetsliabilitiesAccount.class);
                startActivity(menu);
            }
        });

        category.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent menu = new Intent(AssetsliabilitiesActivity.this, AssetsliabilitiesCategory.class);
                startActivity(menu);
            }
        });

        subCategory.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent menu = new Intent(AssetsliabilitiesActivity.this, AssetsliabilitiesSubCategory.class);
                startActivity(menu);
            }
        });

        insert.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                if(check()==true) {
                    String dateNow="";
                    Date date = new Date();
                    Calendar calendar = Calendar.getInstance();
                    calendar.add(Calendar.DATE, 1);
                    date = calendar.getTime();
                    SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
                    dateNow = format.format(date);
                    String response = contextdb.insertAssetsLiabilities(dateNow,"005",Double.parseDouble(txtRode.getText().toString()),true,txtDescription.getText().toString(),
                            invoiceSelect.getName().toString(),true,invoiceSelect.getIDInvoice(),accountSelect.getId(),subCategorySelect.getId(),Integer.parseInt(MainActivity.idUSer), token);
                    switch (response) {
                        case "200":
                            Toast.makeText(getApplicationContext(), "Abono ingresado correctamente", Toast.LENGTH_LONG).show();
                            InvoicesActivity.refresh();
                            DecimalFormat df = new DecimalFormat("#.00");
                            Double total = Double.parseDouble(txtTotal.getText().toString()) - Double.parseDouble(txtRode.getText().toString());
                            Double quantity = Double.parseDouble(txtQuantity.getText().toString()) + Double.parseDouble(txtRode.getText().toString());
                            InvoicesActivity.printRode(txtClient.getText().toString(),"010",dateNow,df.format(total),
                                    df.format(quantity),txtRode.getText().toString());
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
                            break;
                        case "500":
                            Toast.makeText(getApplicationContext(), "Fallo al insertar el abono", Toast.LENGTH_LONG).show();
                            break;
                        default:
                            break;
                    }
                }
            }
        });
    }
    public boolean check(){
        if(txtRode.getText().toString().equals("")){
            Toast.makeText(getApplicationContext(), "Ingrese la cantidad a abonar a la factura", Toast.LENGTH_LONG).show();
            return false;
        }
        if(txtDescription.getText().toString().equals("")){
            Toast.makeText(getApplicationContext(), "Ingrese la descripcion de la factura", Toast.LENGTH_LONG).show();
            return false;
        }
        if(txtAccount.getText().toString().equals("No Seleccionado")){
            Toast.makeText(getApplicationContext(), "Ingrese una cuenta", Toast.LENGTH_LONG).show();
            return false;
        }
        if(txtCategory.getText().toString().equals("No Seleccionado")){
            Toast.makeText(getApplicationContext(), "Ingrese una categoria", Toast.LENGTH_LONG).show();
            return false;
        }
        if(txtSubcategory.getText().toString().equals("No Seleccionado")){
            Toast.makeText(getApplicationContext(), "Ingrese una subcategoria", Toast.LENGTH_LONG).show();
            return false;
        }
        if(MainActivity.idUSer.toString().equals("0")){
            Toast.makeText(getApplicationContext(), "Error con los datos del usuario, por favor vuelva a loguear", Toast.LENGTH_LONG).show();
            return false;
        }
        if(Double.parseDouble(txtRode.getText().toString())>(invoiceSelect.getTotal())){
            Toast.makeText(getApplicationContext(), "Ingrese un monto menor o igual al faltante no abonado de la factura", Toast.LENGTH_LONG).show();
            return false;
        }
        return true;
    }

    public void display(Invoice invoice) {
        DecimalFormat df = new DecimalFormat("#.00");
        if(invoice.getNameCompany().toString().equals("null")){
            txtClient.setText(invoice.getName());
            txtCode.setText(invoice.getCode());
            if(invoice.getTotal()<1){
                txtTotal.setText(String.valueOf(invoice.getTotal()));
            }else {
                txtTotal.setText(df.format(invoice.getTotal()));
            }
            if(invoice.getRode()<1){
                txtQuantity.setText(String.valueOf(invoice.getRode()));
            }else {
                txtQuantity.setText(df.format(invoice.getRode()));
            }
            String dateCurent = "";
            Date date = new Date();
            Calendar calendar = Calendar.getInstance();
            calendar.add(Calendar.DATE, 0);
            date = calendar.getTime();
            SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
            dateCurent = format.format(date);
            txtDate.setText(dateCurent);
            invoiceSelect=invoice;
        }else {
            txtClient.setText(invoice.getNameCompany());
            txtCode.setText(invoice.getCode());
            if(invoice.getTotal()<1){
                txtTotal.setText(String.valueOf(invoice.getTotal()));
            }else {
                txtTotal.setText(df.format(invoice.getTotal()));
            }
            if(invoice.getRode()<1){
                txtQuantity.setText(String.valueOf(invoice.getRode()));
            }else {
                txtQuantity.setText(df.format(invoice.getRode()));
            }
            String dateCurent = "";
            Date date = new Date();
            Calendar calendar = Calendar.getInstance();
            calendar.add(Calendar.DATE, 0);
            date = calendar.getTime();
            SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
            dateCurent = format.format(date);
            txtDate.setText(dateCurent);
            invoiceSelect=invoice;
        }
    }
    public static void display_account(Account account){
        accountSelect = account;
        txtAccount.setText(accountSelect.getName());
    }
    public static void display_category(Category category){
        categorySelect = category;
        txtCategory.setText(categorySelect.getName());
        subCategory.setEnabled(true);
        txtSubcategory.setText("No Seleccionado");
        subCategorySelect = null;
    }
    public static void display_subCategory(SubCategory subCategory){
        subCategorySelect = subCategory;
        txtSubcategory.setText(subCategorySelect.getName());
    }
    public static int select_Category(){
        return categorySelect.getId();
    }
}
